using AutoMapper;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProjectionView.Data;

namespace ProjectionView._4.Features.Employees {
	internal sealed class MappingProfile :
		Profile {
		public MappingProfile() {
			CreateMap<Edit.Projection, Edit.View>()
				.IncludeBase<ProjectionBase, ViewBase>()
				.ForMember(
					d => d.Employee,
					o => o.MapFrom(
						s => s.Employee.Value));

			CreateMap<List.Projection, List.View>()
				.IncludeBase<ProjectionBase, ViewBase>();

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