using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Razor;

namespace ProjectionView._2 {
	internal sealed class FeaturesViewLocationExpander :
		IViewLocationExpander {
		public IEnumerable<string> ExpandViewLocations(
			ViewLocationExpanderContext context,
			IEnumerable<string> viewLocations) {
			//	{0} = action
			//	{1} = controller
			//	{2} = area

			return new[] {
				"/Features/{1}/{0}.cshtml"
			};
		}

		public void PopulateValues(
			ViewLocationExpanderContext context) {
		}
	}
}