using Z.EntityFramework.Plus;

namespace ProjectionView._4 {
	public abstract class ProjectionBase {
		public QueryFutureValue<SignedInEmployeeProjectionView> SignedInEmployee { get; set; }
	}
}