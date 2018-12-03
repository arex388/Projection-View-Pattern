using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjectionView.Data;

namespace ProjectionView._1.Controllers {
	public sealed class JobsController :
		ControllerBase {
		public JobsController(
			ProjectionViewContext context)
			: base(context) {
		}

		[HttpGet]
		public async Task<IActionResult> Add() {
			return View(new JobAddView {
				CsrsSelectListItems = await GetCsrsSelectListItems(),
				SignedInEmployee = await GetSignedInEmployee(),
				StatesSelectListItems = await GetStatesSelectListItems(),
				StatusesSelectListItems = await GetStatusesSelectListItems(),
				TypesSelectListItems = await GetTypesSelectListItems()
			});
		}

		[HttpPost]
		public async Task<IActionResult> Add(
			JobAddOrEditForm job) {
			var jobEntity = new Job {
				CsrId = job.CsrId,
				Name = job.Name,
				StateId = job.StateId,
				StatusId = job.StatusId,
				TypeId = job.TypeId
			};

			await Context.AddAsync(jobEntity);
			await Context.SaveChangesAsync();

			return RedirectToAction("Edit", new {
				id = jobEntity.Id
			});
		}

		[HttpGet]
		public async Task<IActionResult> Edit(
			int id) {
			return View(new JobEditView {
				CsrsSelectListItems = await GetCsrsSelectListItems(),
				Job = await Context.Jobs.SingleAsync(
					j => j.Id == id),
				SignedInEmployee = await GetSignedInEmployee(),
				StatesSelectListItems = await GetStatesSelectListItems(),
				StatusesSelectListItems = await GetStatusesSelectListItems(),
				TypesSelectListItems = await GetTypesSelectListItems()
			});
		}

		[HttpPost]
		public async Task<IActionResult> Edit(
			int id,
			JobAddOrEditForm job) {
			var jobEntity = await Context.Jobs.SingleOrDefaultAsync(
				j => j.Id == id);

			if (jobEntity == null) {
				return RedirectToAction("List");
			}

			jobEntity.CsrId = job.CsrId;
			jobEntity.Name = job.Name;
			jobEntity.StateId = job.StateId;
			jobEntity.StatusId = job.StatusId;
			jobEntity.TypeId = job.TypeId;

			await Context.SaveChangesAsync();

			return RedirectToAction("Edit", new {
				id
			});
		}

		[HttpGet]
		public async Task<IActionResult> List() {
			return View(new JobsListView {
				Jobs = await Context.Jobs.Include(
					j => j.Csr).Include(
					j => j.State).Include(
					j => j.Status).Include(
					j => j.Type).ToListAsync(),
				SignedInEmployee = await GetSignedInEmployee()
			});
		}

		private async Task<IList<SelectListItem>> GetCsrsSelectListItems() {
			return await Context.Employees.Where(
				e => e.IsActive).OrderBy(
				e => e.Name).Select(
				e => new SelectListItem {
					Text = e.Name,
					Value = e.Id.ToString()
				}).ToListAsync();
		}

		private async Task<IList<SelectListItem>> GetStatesSelectListItems() {
			var countries = await Context.Countries.OrderByDescending(
				c => c.Name).Select(
				c => new SelectListGroup {
					Name = c.Name
				}).ToListAsync();

			return await Context.States.Where(
				s => s.IsActive).OrderBy(
				s => s.Name).Select(
				s => new SelectListItem {
					Group = countries.Single(
						c => c.Name == s.Country.Name),
					Text = s.Name,
					Value = s.Id.ToString()
				}).ToListAsync();
		}

		private async Task<IList<SelectListItem>> GetStatusesSelectListItems() {
			return await Context.Statuses.Where(
				s => s.IsActive).OrderBy(
				s => s.Name).Select(
				s => new SelectListItem {
					Text = s.Name,
					Value = s.Id.ToString()
				}).ToListAsync();
		}

		private async Task<IList<SelectListItem>> GetTypesSelectListItems() {
			return await Context.Types.Where(
				t => t.IsActive).OrderBy(
				t => t.Name).Select(
				t => new SelectListItem {
					Text = t.Name,
					Value = t.Id.ToString()
				}).ToListAsync();
		}
	}
}