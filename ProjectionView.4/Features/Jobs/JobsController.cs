using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ProjectionView._4.Features.Jobs {
	public sealed class JobsController :
		ControllerBase {
		public JobsController(
			IMediator mediator)
			: base(mediator) {
		}

		[HttpGet]
		public async Task<IActionResult> Add() {
			var view = await Mediator.Send(new Add.Query());

			return View(view);
		}

		[HttpPost]
		public async Task<IActionResult> Add(
			Add.Command job) {
			var id = await Mediator.Send(job);

			return RedirectToAction("Edit", new {
				id
			});
		}

		[HttpGet]
		public async Task<IActionResult> Edit(
			int id) {
			var view = await Mediator.Send(new Edit.Query {
				Id = id
			});

			return View(view);
		}

		[HttpPost]
		public async Task<IActionResult> Edit(
			int id,
			Edit.Command job) {
			var success = await Mediator.Send(job);

			if (!success) {
				return RedirectToAction("List");
			}

			return RedirectToAction("Edit", new {
				id
			});
		}

		[HttpGet]
		public async Task<IActionResult> List() {
			var view = await Mediator.Send(new List.Query());

			return View(view);
		}
	}
}