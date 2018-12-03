namespace ProjectionView._4 {
	public abstract class ViewBase {
		public SignedInEmployeeProjectionView SignedInEmployee { get; set; }
	}

	public sealed class SignedInEmployeeProjectionView {
		public int Id { get; set; }
		public string Name { get; set; }
	}
}