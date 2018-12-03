using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using ProjectionView.Data;

namespace ProjectionView._2.Features.Employees {
	public sealed class Edit {
		public sealed class Command {
			public string Name { get; set; }
		}

		public sealed class Query :
			IRequest<View> {
			public int Id { get; set; }
		}

		public sealed class QueryHandler :
			HandlerBase<Query, View> {
			public QueryHandler(
				ProjectionViewContext context,
				IMapper mapper)
				: base(context, mapper) {
			}

			protected override View Handle(
				Query query) {
				return new View {
					Employee = Context.Employees.Where(
						e => e.Id == query.Id).ProjectTo<Command>(MapperConfig).Single(),
					Jobs = Context.Jobs.Where(
						j => j.CsrId == query.Id).ProjectTo<JobProjection>(MapperConfig).ToList(),
					SignedInEmployee = GetSignedInEmployee()
				};
			}
		}

		public sealed class View :
			ViewBase {
			public Command Employee { get; set; }
			public IList<JobProjection> Jobs { get; set; }
		}

		#region Models
		public sealed class JobProjection {
			public int Id { get; set; }
			public string Name { get; set; }
		}
		#endregion
	}
}