using AutoMapper;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ProjectionView._2.Features.Types {
	internal sealed class MappingProfile :
		Profile {
		public MappingProfile() {
			CreateMap<Data.Type, SelectListItem>()
				.ForMember(
					d => d.Text,
					o => o.MapFrom(
						s => s.Name))
				.ForMember(
					d => d.Value,
					o => o.MapFrom(
						s => s.Id));
		}
	}
}