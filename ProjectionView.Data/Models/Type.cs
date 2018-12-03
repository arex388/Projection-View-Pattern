using System.Collections.Generic;

namespace ProjectionView.Data {
	public class Type :
		EntityBase<int> {
		public bool IsActive { get; set; }
		public string Name { get; set; }

		public virtual IList<Job> Jobs { get; } = new List<Job>();
	}
}