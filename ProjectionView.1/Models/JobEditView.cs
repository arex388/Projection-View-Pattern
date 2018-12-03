using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProjectionView.Data;

namespace ProjectionView._1 {
	public sealed class JobEditView :
		ViewBase {
		public IList<SelectListItem> CsrsSelectListItems { get; set; }
		public Job Job { get; set; }
		public IList<SelectListItem> StatesSelectListItems { get; set; }
		public IList<SelectListItem> StatusesSelectListItems { get; set; }
		public IList<SelectListItem> TypesSelectListItems { get; set; }
	}
}