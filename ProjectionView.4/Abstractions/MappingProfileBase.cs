using AutoMapper;

namespace ProjectionView._4 {
	public sealed class MappingProfileBase :
		Profile {
		public MappingProfileBase() {
			CreateMap<ProjectionBase, ViewBase>();
		}
	}
}