using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using ProjectionView.Data;

namespace ProjectionView._4 {
	public abstract class AsyncProjectionHandlerBase<TRequest, TProjection, TResponse> :
		AsyncHandlerBase<TRequest, TResponse>
		where TRequest : IRequest<TResponse>
		where TProjection : class, new()
		where TResponse : class {
		protected AsyncProjectionHandlerBase(
			ProjectionViewContext context,
			IMapper mapper)
			: base(context, mapper) {
		}

		public override Task<TResponse> Handle(
			TRequest request,
			CancellationToken cancellationToken = default) {
			var response = GetResponse(request);

			return Task.FromResult(response);
		}

		protected virtual TProjection GetProjection(
			TRequest request) {
			return new TProjection();
		}

		protected virtual TResponse GetResponse(
			TRequest request) {
			var projection = GetProjection(request);
			var response = Mapper.Map<TResponse>(projection);

			NormalizeResponse(request, projection, response);

			return response;
		}

		protected virtual void NormalizeResponse(
			TRequest request,
			TProjection projection,
			TResponse response) {
		}
	}
}
