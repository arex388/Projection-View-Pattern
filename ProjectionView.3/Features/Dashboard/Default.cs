using AutoMapper;
using MediatR;
using ProjectionView.Data;
using Z.EntityFramework.Plus;

namespace ProjectionView._3.Features.Dashboard {
	public sealed class Default {
		public sealed class Query :
			IRequest<View> {
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
				var employeesCount = Context.Employees.DeferredCount(
					e => e.IsActive).FutureValue();
				var jobsCount = Context.Jobs.DeferredCount().FutureValue();
				var signedInEmployee = GetSignedInEmployee();

				return new View {
					EmployeesCount = employeesCount.Value,
					JobsCount = jobsCount.Value,
					SignedInEmployee = signedInEmployee.Value
				};
			}
		}

		public sealed class View :
			ViewBase {
			public int EmployeesCount { get; set; }
			public int JobsCount { get; set; }
		}
	}
}