using System.Collections.Generic;
using ProjectionView.Data;

namespace ProjectionView._1 {
	public sealed class EmployeesListView :
		ViewBase {
		public IList<Employee> Employees { get; set; }
	}
}