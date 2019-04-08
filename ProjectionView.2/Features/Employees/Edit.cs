using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjectionView.Data;

namespace ProjectionView._2.Features.Employees {
	public sealed class Edit {
		public sealed class Command {
			public string Name { get; set; }
		}

		public sealed class Query :
			IRequest<View> {
			public int Id { get; set; }
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
					Employee = await Context.Employees.Where(
						e => e.Id == query.Id).ProjectTo<Command>(MapperConfig).SingleAsync(cancellationToken),
					Jobs = await Context.Jobs.Where(
						j => j.CsrId == query.Id).ProjectTo<JobProjection>(MapperConfig).ToListAsync(cancellationToken),
					SignedInEmployee = await GetSignedInEmployeeAsync(cancellationToken)
				};
			}
		}

		public sealed class View :
			ViewBase {
			public Command Employee { get; set; }
			public IList<JobProjection> Jobs { get; set; }
		}

		#region Models
		public sealed class JobProjection {
			public int Id { get; set; }
			public string Name { get; set; }
		}
		#endregion
	}
}