using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ProjectionView._4.Features.Employees {
	public sealed class EmployeesController :
		ControllerBase {
		public EmployeesController(
			IMediator mediator)
			: base(mediator) {
		}

		[HttpGet]
		public async Task<IActionResult> Edit(
			int id) {
			var view = await Mediator.Send(new Edit.Query {
				Id = id
			});

			return View(view);
		}

		[HttpGet]
		public async Task<IActionResult> List() {
			var view = await Mediator.Send(new List.Query());

			return View(view);
		}
	}
}