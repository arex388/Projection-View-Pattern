using AutoMapper;
using MediatR;
using ProjectionView.Data;

namespace ProjectionView._4 {
	public abstract class HandlerBase<TRequest> :
		RequestHandler<TRequest>
		where TRequest : IRequest {
		protected ProjectionViewContext Context { get; }
		protected IMapper Mapper { get; }

		protected HandlerBase(
			ProjectionViewContext context,
			IMapper mapper) {
			Context = context;
			Mapper = mapper;
		}
	}
}