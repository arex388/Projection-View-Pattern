using AutoMapper;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProjectionView.Data;

namespace ProjectionView._3.Features.Employees {
	internal sealed class MappingProfile :
		Profile {
		public MappingProfile() {
			CreateMap<Employee, SelectListItem>()
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