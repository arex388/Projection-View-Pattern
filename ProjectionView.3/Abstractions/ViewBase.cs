namespace ProjectionView._3 {
	public abstract class ViewBase {
		public SignedInEmployee SignedInEmployee { get; set; }
	}

	public sealed class SignedInEmployee {
		public int Id { get; set; }
		public string Name { get; set; }
	}
}