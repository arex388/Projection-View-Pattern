using System.Collections.Generic;
using ProjectionView.Data;

namespace ProjectionView._1 {
	public sealed class EmployeeEditView :
		ViewBase {
		public Employee Employee { get; set; }
		public IList<Job> Jobs { get; set; }
	}
}