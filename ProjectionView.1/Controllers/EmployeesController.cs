using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectionView.Data;

namespace ProjectionView._1.Controllers {
	public sealed class EmployeesController :
		ControllerBase {
		public EmployeesController(
			ProjectionViewContext context)
			: base(context) {
		}

		[HttpGet]
		public async Task<IActionResult> Edit(
			int id) {
			return View(new EmployeeEditView {
				Employee = await Context.Employees.SingleAsync(
					e => e.Id == id),
				Jobs = await Context.Jobs.Where(
					j => j.CsrId == id).ToListAsync(),
				SignedInEmployee = await GetSignedInEmployee()
			});
		}

		[HttpGet]
		public async Task<IActionResult> List() {
			return View(new EmployeesListView {
				Employees = await Context.Employees.Include(
					e => e.Jobs).ToListAsync(),
				SignedInEmployee = await GetSignedInEmployee()
			});
		}
	}
}