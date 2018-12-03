using System.Collections.Generic;

namespace ProjectionView.Data {
	public class Country :
		EntityBase<int> {
		public string Abbreviation { get; set; }
		public string Name { get; set; }

		public virtual IList<State> States { get; } = new List<State>();
	}
}