namespace ProjectionView.Data {
	public class Job :
		EntityBase<int> {
		public int? CsrId { get; set; }
		public string Name { get; set; }
		public int? StateId { get; set; }
		public int? StatusId { get; set; }
		public int? TypeId { get; set; }

		public virtual State State { get; set; }
		public virtual Status Status { get; set; }
		public virtual Employee Csr { get; set; }
		public virtual Type Type { get; set; }
	}
}