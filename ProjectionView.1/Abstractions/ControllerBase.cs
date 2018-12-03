using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectionView.Data;

namespace ProjectionView._1 {
	public abstract class ControllerBase :
		Controller {
		protected ProjectionViewContext Context { get; }

		protected ControllerBase(
			ProjectionViewContext context) => Context = context;

		protected async Task<Employee> GetSignedInEmployee() {
			var id = new Random().Next(1, 10);

			return await Context.Employees.SingleAsync(
				e => e.Id == id);
		}
	}
}