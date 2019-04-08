using System;
using System.Linq;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using ProjectionView.Data;
using Z.EntityFramework.Plus;

namespace ProjectionView._4 {
	public abstract class QueryHandlerBase<TQuery, TProjection, TView> :
		AsyncProjectionHandlerBase<TQuery, TProjection, TView>
		where TQuery : IRequest<TView>
		where TProjection : ProjectionBase, new()
		where TView : ViewBase {
		protected QueryHandlerBase(
			ProjectionViewContext context,
			IMapper mapper)
			: base(context, mapper) {
		}

		protected override TProjection GetProjection(
			TQuery query) {
			var id = new Random().Next(1, 10);

			return new TProjection {
				SignedInEmployee = Context.Employees.Where(
					e => e.Id == id).ProjectTo<SignedInEmployeeProjectionView>(MapperConfig).DeferredSingle().FutureValue()
			};
		}
	}
}