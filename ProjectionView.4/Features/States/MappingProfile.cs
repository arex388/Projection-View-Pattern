using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProjectionView.Data;

namespace ProjectionView._4.Features.States {
	internal sealed class MappingProfile :
		Profile {
		public MappingProfile() {
			IList<SelectListGroup> countries = null;

			CreateMap<State, SelectListItem>()
				.ForMember(
					d => d.Group,
					o => o.MapFrom(
						s => countries.Single(
							c => c.Name == s.Country.Name)))
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