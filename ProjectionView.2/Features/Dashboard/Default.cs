using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjectionView.Data;

namespace ProjectionView._2.Features.Dashboard {
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

			public override async Task<View> Handle(
				Query query,
				CancellationToken cancellationToken = default) {
				return new View {
					EmployeesCount = await Context.Employees.CountAsync(
						e => e.IsActive, cancellationToken),
					JobsCount = await Context.Jobs.CountAsync(cancellationToken),
					SignedInEmployee = await GetSignedInEmployeeAsync(cancellationToken)
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