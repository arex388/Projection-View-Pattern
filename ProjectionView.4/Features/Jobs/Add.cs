using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProjectionView.Data;
using Z.EntityFramework.Plus;

namespace ProjectionView._4.Features.Jobs {
	public sealed class Add {
		public sealed class Command :
			IRequest<int> {
			public int? CsrId { get; set; }
			public string Name { get; set; }
			public int? StateId { get; set; }
			public int? StatusId { get; set; }
			public int? TypeId { get; set; }
		}

		public sealed class CommandHandler :
			AsyncHandlerBase<Command, int> {
			public CommandHandler(
				ProjectionViewContext context,
				IMapper mapper)
				: base(context, mapper) {
			}

			public override async Task<int> Handle(
				Command command,
				CancellationToken cancellationToken = default) {
				var job = Mapper.Map<Job>(command);

				Context.Add(job);

				await Context.SaveChangesAsync(cancellationToken);

				return job.Id;
			}
		}

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
				var countries = Context.Countries.OrderByDescending(
					c => c.Name).ProjectTo<SelectListGroup>(MapperConfig).Future();
				var projection = base.GetProjection(query);

				projection.CsrsSelectListItems = Context.Employees.Where(
					e => e.IsActive).OrderBy(
					e => e.Name).ProjectTo<SelectListItem>(MapperConfig).Future();
				projection.StatesSelectListItems = Context.States.Where(
					s => s.IsActive).OrderBy(
					s => s.Name).ProjectTo<SelectListItem>(MapperConfig, new {
						countries
					}).Future();
				projection.StatusesSelectListItems = Context.Statuses.Where(
					s => s.IsActive).OrderBy(
					s => s.Name).ProjectTo<SelectListItem>(MapperConfig).Future();
				projection.TypesSelectListItems = Context.Types.Where(
					t => t.IsActive).OrderBy(
					t => t.Name).ProjectTo<SelectListItem>(MapperConfig).Future();

				return projection;
			}
		}

		public sealed class Projection :
			ProjectionBase {
			public QueryFutureEnumerable<SelectListItem> CsrsSelectListItems { get; set; }
			public QueryFutureEnumerable<SelectListItem> StatesSelectListItems { get; set; }
			public QueryFutureEnumerable<SelectListItem> StatusesSelectListItems { get; set; }
			public QueryFutureEnumerable<SelectListItem> TypesSelectListItems { get; set; }
		}

		public sealed class View :
			ViewBase {
			public IList<SelectListItem> CsrsSelectListItems { get; set; }
			public Command Job { get; } = new Command();
			public IList<SelectListItem> StatesSelectListItems { get; set; }
			public IList<SelectListItem> StatusesSelectListItems { get; set; }
			public IList<SelectListItem> TypesSelectListItems { get; set; }
		}
	}
}
