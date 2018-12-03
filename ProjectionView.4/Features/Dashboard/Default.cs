using AutoMapper;
using MediatR;
using ProjectionView.Data;
using Z.EntityFramework.Plus;

namespace ProjectionView._4.Features.Dashboard {
	public sealed class Default {
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

				projection.EmployeesCount = Context.Employees.DeferredCount(
					e => e.IsActive).FutureValue();
				projection.JobsCount = Context.Jobs.DeferredCount().FutureValue();

				return projection;
			}
		}

		public sealed class Projection :
			ProjectionBase {
			public QueryFutureValue<int> EmployeesCount { get; set; }
			public QueryFutureValue<int> JobsCount { get; set; }
		}

		public sealed class View :
			ViewBase {
			public int EmployeesCount { get; set; }
			public int JobsCount { get; set; }
		}
	}
}