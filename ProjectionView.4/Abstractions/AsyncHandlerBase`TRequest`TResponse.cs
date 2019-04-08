using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using ProjectionView.Data;

namespace ProjectionView._4 {
	public abstract class AsyncHandlerBase<TRequest, TResponse> :
		IRequestHandler<TRequest, TResponse>
		where TRequest : IRequest<TResponse> {
		protected ProjectionViewContext Context { get; }
		protected IMapper Mapper { get; }

		protected IConfigurationProvider MapperConfig => Mapper.ConfigurationProvider;

		protected AsyncHandlerBase(
			ProjectionViewContext context,
			IMapper mapper) {
			Context = context;
			Mapper = mapper;
		}

		public abstract Task<TResponse> Handle(
			TRequest request,
			CancellationToken cancellationToken = default);
	}
}