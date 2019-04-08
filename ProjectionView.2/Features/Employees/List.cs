using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjectionView.Data;

namespace ProjectionView._2.Features.Employees {
	public sealed class List {
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
					Employees = await Context.Employees.ProjectTo<EmployeeProjection>(MapperConfig).ToListAsync(cancellationToken),
					SignedInEmployee = await GetSignedInEmployeeAsync(cancellationToken)
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