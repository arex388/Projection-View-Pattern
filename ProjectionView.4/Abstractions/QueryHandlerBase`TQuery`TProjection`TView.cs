using System;
using System.Linq;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using ProjectionView.Data;
using Z.EntityFramework.Plus;

namespace ProjectionView._4 {
	public abstract class QueryHandlerBase<TQuery, TProjection, TView> :
		HandlerBase<TQuery, TView>
		where TQuery : IRequest<TView>
		where TProjection : ProjectionBase, new()
		where TView : ViewBase {
		protected QueryHandlerBase(
			ProjectionViewContext context,
			IMapper mapper)
			: base(context, mapper) {
		}

		protected override TView Handle(
			TQuery query) {
			return GetView(query);
		}

		protected virtual TProjection GetProjection(
			TQuery query) {
			var id = new Random().Next(1, 10);

			return new TProjection {
				SignedInEmployee = Context.Employees.Where(
					e => e.Id == id).ProjectTo<SignedInEmployeeProjectionView>(MapperConfig).DeferredSingle().FutureValue()
			};
		}

		protected virtual TView GetView(
			TQuery query) {
			var projection = GetProjection(query);
			var view = Mapper.Map<TView>(projection);

			Normalize(projection, view);

			return view;
		}

		protected virtual void Normalize(
			TProjection projection,
			TView view) {
		}
	}
}