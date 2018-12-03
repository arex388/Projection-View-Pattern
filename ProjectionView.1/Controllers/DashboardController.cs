using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectionView.Data;

namespace ProjectionView._1.Controllers {
	public sealed class DashboardController :
		ControllerBase {
		public DashboardController(
			ProjectionViewContext context)
			: base(context) {
		}

		[HttpGet]
		public async Task<IActionResult> Default() {
			return View(new DashboardDefaultView {
				EmployeesCount = await Context.Employees.CountAsync(
					e => e.IsActive),
				JobsCount = await Context.Jobs.CountAsync(),
				SignedInEmployee = await GetSignedInEmployee()
			});
		}
	}
}