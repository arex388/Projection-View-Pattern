using System.Collections.Generic;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using ProjectionView.Data;
using Z.EntityFramework.Plus;

namespace ProjectionView._4.Features.Employees {
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

				projection.Employees = Context.Employees.ProjectTo<EmployeeProjectionView>(MapperConfig).Future();

				return projection;
			}
		}

		public sealed class Projection :
			ProjectionBase {
			public QueryFutureEnumerable<EmployeeProjectionView> Employees { get; set; }
		}

		public sealed class View :
			ViewBase {
			public IList<EmployeeProjectionView> Employees { get; set; }
		}

		#region Models
		public sealed class EmployeeProjectionView {
			public int Id { get; set; }
			public int JobsCount { get; set; }
			public string Name { get; set; }
		}
		#endregion
	}
}