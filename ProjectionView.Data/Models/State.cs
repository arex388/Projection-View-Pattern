using System.Collections.Generic;

namespace ProjectionView.Data {
	public class State :
		EntityBase<int> {
		public string Abbreviation { get; set; }
		public int CountryId { get; set; }
		public bool IsActive { get; set; }
		public string Name { get; set; }

		public virtual Country Country { get; set; }
		public virtual IList<Job> Jobs { get; } = new List<Job>();
	}
}