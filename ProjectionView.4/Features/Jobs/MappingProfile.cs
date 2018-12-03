using AutoMapper;
using ProjectionView.Data;

namespace ProjectionView._4.Features.Jobs {
	internal sealed class MappingProfile :
		Profile {
		public MappingProfile() {
			CreateMap<Add.Projection, Add.View>()
				.IncludeBase<ProjectionBase, ViewBase>();

			CreateMap<Add.Command, Job>()
				.ForMember(
					d => d.Csr,
					o => o.Ignore())
				.ForMember(
					d => d.State,
					o => o.Ignore())
				.ForMember(
					d => d.Status,
					o => o.Ignore())
				.ForMember(
					d => d.Type,
					o => o.Ignore());

			CreateMap<Edit.Projection, Edit.View>()
				.IncludeBase<ProjectionBase, ViewBase>()
				.ForMember(
					d => d.Job,
					o => o.MapFrom(
						s => s.Job.Value));

			CreateMap<Edit.Command, Job>()
				.ForMember(
					d => d.Csr,
					o => o.Ignore())
				.ForMember(
					d => d.Id,
					o => o.Ignore())
				.ForMember(
					d => d.State,
					o => o.Ignore())
				.ForMember(
					d => d.Status,
					o => o.Ignore())
				.ForMember(
					d => d.Type,
					o => o.Ignore());

			CreateMap<List.Projection, List.View>()
				.IncludeBase<ProjectionBase, ViewBase>();
		}
	}
}