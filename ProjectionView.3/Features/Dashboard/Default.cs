using System.Threading;
using System.Threading.Tasks;
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
			AsyncHandlerBase<Query, View> {
			public QueryHandler(
				ProjectionViewContext context,
				IMapper mapper)
				: base(context, mapper) {
			}

			public override Task<View> Handle(
				Query query,
				CancellationToken cancellationToken = default) {
				var employeesCount = Context.Employees.DeferredCount(
					e => e.IsActive).FutureValue();
				var jobsCount = Context.Jobs.DeferredCount().FutureValue();
				var signedInEmployee = GetSignedInEmployee();

				return Task.FromResult(new View {
					EmployeesCount = employeesCount.Value,
					JobsCount = jobsCount.Value,
					SignedInEmployee = signedInEmployee.Value
				});
			}
		}

		public sealed class View :
			ViewBase {
			public int EmployeesCount { get; set; }
			public int JobsCount { get; set; }
		}
	}
}