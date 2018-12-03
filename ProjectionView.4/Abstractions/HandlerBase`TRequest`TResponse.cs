using AutoMapper;
using MediatR;
using ProjectionView.Data;

namespace ProjectionView._4 {
	public abstract class HandlerBase<TRequest, TResponse> :
		RequestHandler<TRequest, TResponse>
		where TRequest : IRequest<TResponse> {
		protected ProjectionViewContext Context { get; }
		protected IMapper Mapper { get; }

		protected IConfigurationProvider MapperConfig => Mapper.ConfigurationProvider;

		protected HandlerBase(
			ProjectionViewContext context,
			IMapper mapper) {
			Context = context;
			Mapper = mapper;
		}
	}
}