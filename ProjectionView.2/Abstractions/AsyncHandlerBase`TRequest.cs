using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using ProjectionView.Data;

namespace ProjectionView._2 {
	public abstract class AsyncHandlerBase<TRequest> :
		IRequestHandler<TRequest>
		where TRequest : IRequest {
		protected ProjectionViewContext Context { get; }
		protected IMapper Mapper { get; }

		protected AsyncHandlerBase(
			ProjectionViewContext context,
			IMapper mapper) {
			Context = context;
			Mapper = mapper;
		}

		public abstract Task<Unit> Handle(
			TRequest request,
			CancellationToken cancellationToken = default);
	}
}