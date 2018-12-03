using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using ProjectionView.Data;

namespace ProjectionView._2.Features.Jobs {
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
					Jobs = Context.Jobs.ProjectTo<JobProjection>(MapperConfig).ToList(),
					SignedInEmployee = GetSignedInEmployee()
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