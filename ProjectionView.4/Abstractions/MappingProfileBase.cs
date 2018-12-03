using AutoMapper;

namespace ProjectionView._4 {
	internal sealed class MappingProfileBase :
		Profile {
		public MappingProfileBase() {
			CreateMap<ProjectionBase, ViewBase>();
		}
	}
}