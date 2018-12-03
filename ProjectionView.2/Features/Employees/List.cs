using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using ProjectionView.Data;

namespace ProjectionView._2.Features.Employees {
	public sealed class List {
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
					Employees = Context.Employees.ProjectTo<EmployeeProjection>(MapperConfig).ToList(),
					SignedInEmployee = GetSignedInEmployee()
				};
			}
		}

		public sealed class View :
			ViewBase {
			public IList<EmployeeProjection> Employees { get; set; }
		}

		#region Models
		public sealed class EmployeeProjection {
			public int Id { get; set; }
			public int JobsCount { get; set; }
			public string Name { get; set; }
		}
		#endregion
	}
}