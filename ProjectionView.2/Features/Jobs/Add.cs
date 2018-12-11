﻿using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProjectionView.Data;

namespace ProjectionView._2.Features.Jobs {
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
			HandlerBase<Command, int> {
			public CommandHandler(
				ProjectionViewContext context,
				IMapper mapper)
				: base(context, mapper) {
			}

			protected override int Handle(
				Command command) {
				var job = Mapper.Map<Job>(command);

				Context.Add(job);
				Context.SaveChanges();

				return job.Id;
			}
		}

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
				var countries = Context.Countries.OrderByDescending(
					c => c.Name).ProjectTo<SelectListGroup>(MapperConfig).ToList();

				return new View {
					CsrsSelectListItems = Context.Employees.Where(
						e => e.IsActive).OrderBy(
						e => e.Name).ProjectTo<SelectListItem>(MapperConfig).ToList(),
					SignedInEmployee = GetSignedInEmployee(),
					StatesSelectListItems = Context.States.Where(
						s => s.IsActive).OrderBy(
						s => s.Name).ProjectTo<SelectListItem>(MapperConfig, new {
							countries
						}).ToList(),
					StatusesSelectListItems = Context.Statuses.Where(
						s => s.IsActive).OrderBy(
						s => s.Name).ProjectTo<SelectListItem>(MapperConfig).ToList(),
					TypesSelectListItems = Context.Types.Where(
						t => t.IsActive).OrderBy(
						t => t.Name).ProjectTo<SelectListItem>(MapperConfig).ToList()
				};
			}
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