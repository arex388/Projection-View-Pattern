using AutoMapper;

namespace ProjectionView._4.Features.Dashboard {
	internal sealed class MappingProfile :
		Profile {
		public MappingProfile() {
			CreateMap<Default.Projection, Default.View>()
				.IncludeBase<ProjectionBase, ViewBase>();
		}
	}
}