using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjectionView.Data;

namespace ProjectionView._2.Features.Jobs {
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
					Jobs = await Context.Jobs.ProjectTo<JobProjection>(MapperConfig).ToListAsync(cancellationToken),
					SignedInEmployee = await GetSignedInEmployeeAsync(cancellationToken)
				};
			}
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