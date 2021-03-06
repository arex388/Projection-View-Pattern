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

			public override Task<View> Handle(
				Query query,
				CancellationToken cancellationToken = default) {
				var employee = Context.Employees.Where(
					e => e.Id == query.Id).ProjectTo<Command>(MapperConfig).DeferredSingle().FutureValue();
				var jobs = Context.Jobs.Where(
					j => j.CsrId == query.Id).ProjectTo<JobProjectionView>(MapperConfig).Future();
				var signedInEmployee = GetSignedInEmployee();

				return Task.FromResult(new View {
					Employee = employee.Value,
					Jobs = jobs.ToList(),
					SignedInEmployee = signedInEmployee.Value
				});
			}
		}

		public sealed class View :
			ViewBase {
			public Command Employee { get; set; }
			public IList<JobProjectionView> Jobs { get; set; }
		}

		#region Models
		public sealed class JobProjectionView {
			public int Id { get; set; }
			public string Name { get; set; }
		}
		#endregion
	}
}