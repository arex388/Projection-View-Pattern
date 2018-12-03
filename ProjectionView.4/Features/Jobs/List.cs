using System.Collections.Generic;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using ProjectionView.Data;
using Z.EntityFramework.Plus;

namespace ProjectionView._4.Features.Jobs {
	public sealed class List {
		public sealed class Query :
			IRequest<View> {
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

				projection.Jobs = Context.Jobs.ProjectTo<JobProjection>(MapperConfig).Future();

				return projection;
			}
		}

		public sealed class Projection :
			ProjectionBase {
			public QueryFutureEnumerable<JobProjection> Jobs { get; set; }
		}

		public sealed class View :
			ViewBase {
			public IList<JobProjection> Jobs { get; set; }
		}

		#region Models
		public sealed class JobProjection {
			public string CsrName { get; set; }
			public int Id { get; set; }
			public string Name { get; set; }
			public string StateName { get; set; }
			public string StatusName { get; set; }
			public string TypeName { get; set; }
		}
		#endregion
	}
}