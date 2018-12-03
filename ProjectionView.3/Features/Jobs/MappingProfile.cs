using AutoMapper;
using ProjectionView.Data;

namespace ProjectionView._3.Features.Jobs {
	internal sealed class MappingProfile :
		Profile {
		public MappingProfile() {
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
		}
	}
}