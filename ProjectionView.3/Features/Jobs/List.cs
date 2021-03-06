﻿using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using ProjectionView.Data;
using Z.EntityFramework.Plus;

namespace ProjectionView._3.Features.Jobs {
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

			public override Task<View> Handle(
				Query query,
				CancellationToken cancellationToken = default) {
				var jobs = Context.Jobs.ProjectTo<JobProjection>(MapperConfig).Future();
				var signedInEmployee = GetSignedInEmployee();

				return Task.FromResult(new View {
					Jobs = jobs.ToList(),
					SignedInEmployee = signedInEmployee.Value
				});
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