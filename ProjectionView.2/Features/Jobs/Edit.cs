using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjectionView.Data;

namespace ProjectionView._2.Features.Jobs {
	public sealed class Edit {
		public sealed class Command :
			IRequest<bool> {
			public int? CsrId { get; set; }
			public int Id { get; set; }
			public string Name { get; set; }
			public int? StateId { get; set; }
			public int? StatusId { get; set; }
			public int? TypeId { get; set; }
		}

		public sealed class CommandHandler :
			AsyncHandlerBase<Command, bool> {
			public CommandHandler(
				ProjectionViewContext context,
				IMapper mapper)
				: base(context, mapper) {
			}

			public override async Task<bool> Handle(
				Command command,
				CancellationToken cancellationToken = default) {
				var job = Context.Jobs.SingleOrDefault(
					j => j.Id == command.Id);

				if (job is null) {
					return false;
				}

				Mapper.Map(command, job);

				await Context.SaveChangesAsync(cancellationToken);

				return true;
			}
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
				var countries = await Context.Countries.OrderByDescending(
					c => c.Name).ProjectTo<SelectListGroup>(MapperConfig).ToListAsync(cancellationToken);

				return new View {
					CsrsSelectListItems = await Context.Employees.Where(
						e => e.IsActive).OrderBy(
						e => e.Name).ProjectTo<SelectListItem>(MapperConfig).ToListAsync(cancellationToken),
					Job = await Context.Jobs.Where(
						j => j.Id == query.Id).ProjectTo<Command>(MapperConfig).SingleAsync(cancellationToken),
					SignedInEmployee = await GetSignedInEmployeeAsync(cancellationToken),
					StatesSelectListItems = await Context.States.Where(
						s => s.IsActive).OrderBy(
						s => s.Name).ProjectTo<SelectListItem>(MapperConfig, new {
							countries
						}).ToListAsync(cancellationToken),
					StatusesSelectListItems = await Context.Statuses.Where(
						s => s.IsActive).OrderBy(
						s => s.Name).ProjectTo<SelectListItem>(MapperConfig).ToListAsync(cancellationToken),
					TypesSelectListItems = await Context.Types.Where(
						t => t.IsActive).OrderBy(
						t => t.Name).ProjectTo<SelectListItem>(MapperConfig).ToListAsync(cancellationToken)
				};
			}
		}

		public sealed class View :
			ViewBase {
			public IList<SelectListItem> CsrsSelectListItems { get; set; }
			public Command Job { get; set; }
			public IList<SelectListItem> StatesSelectListItems { get; set; }
			public IList<SelectListItem> StatusesSelectListItems { get; set; }
			public IList<SelectListItem> TypesSelectListItems { get; set; }
		}
	}
}