using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using ProjectionView.Data;
using Z.EntityFramework.Plus;

namespace ProjectionView._4.Features.Employees {
	public sealed class Edit {
		public sealed class Command {
			public string Name { get; set; }
		}

		public sealed class Query :
			IRequest<View> {
			public int Id { get; set; }
		}

		public sealed class QueryHandler :
			QueryHandlerBase<Query, Projection, View> {
			public QueryHandler(
				ProjectionViewContext context,
				IMapper mapper)
				: base(context, mapper) {
			}

			protected override Projection GetProjection(
				Query query) {
				var projection = base.GetProjection(query);

				projection.Employee = Context.Employees.Where(
					e => e.Id == query.Id).ProjectTo<Command>(MapperConfig).DeferredSingle().FutureValue();
				projection.Jobs = Context.Jobs.Where(
					j => j.CsrId == query.Id).ProjectTo<JobProjectionView>(MapperConfig).Future();

				return projection;
			}
		}

		public sealed class Projection :
			ProjectionBase {
			public QueryFutureValue<Command> Employee { get; set; }
			public QueryFutureEnumerable<JobProjectionView> Jobs { get; set; }
		}

		public sealed class View :
			ViewBase {
			public Command Employee { get; set; }
			public IList<JobProjectionView> Jobs { get; set; }
		}

		#region Models
		public sealed class JobProjectionView {
			public int Id { get; set; }
			public string Name { get; set; }
		}
		#endregion
	}
}