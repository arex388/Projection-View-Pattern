using System.Linq;
using AutoMapper;
using MediatR;
using ProjectionView.Data;

namespace ProjectionView._2.Features.Dashboard {
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
				return new View {
					EmployeesCount = Context.Employees.Count(
						e => e.IsActive),
					JobsCount = Context.Jobs.Count(),
					SignedInEmployee = GetSignedInEmployee()
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