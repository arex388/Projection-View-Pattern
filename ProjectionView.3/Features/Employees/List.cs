﻿using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using ProjectionView.Data;
using Z.EntityFramework.Plus;

namespace ProjectionView._3.Features.Employees {
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
				var employees = Context.Employees.ProjectTo<EmployeeProjection>(MapperConfig).Future();
				var signedInEmployee = GetSignedInEmployee();

				return Task.FromResult(new View {
					Employees = employees.ToList(),
					SignedInEmployee = signedInEmployee.Value
				});
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