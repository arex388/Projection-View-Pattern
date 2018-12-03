using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ProjectionView._4.Features.Dashboard {
	public sealed class DashboardController :
		ControllerBase {
		public DashboardController(
			IMediator mediator)
			: base(mediator) {
		}

		[HttpGet]
		public async Task<IActionResult> Default() {
			var view = await Mediator.Send(new Default.Query());

			return View(view);
		}
	}
}