using System.Collections.Generic;
using ProjectionView.Data;

namespace ProjectionView._1 {
	public sealed class JobsListView :
		ViewBase {
		public IList<Job> Jobs { get; set; }
	}
}
