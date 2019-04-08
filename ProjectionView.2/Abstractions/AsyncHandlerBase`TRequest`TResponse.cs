using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjectionView.Data;

namespace ProjectionView._2 {
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

		protected async Task<SignedInEmployee> GetSignedInEmployeeAsync(
			CancellationToken cancellationToken) {
			var id = new Random().Next(1, 10);

			return await Context.Employees.Where(
				e => e.Id == id).ProjectTo<SignedInEmployee>(MapperConfig).SingleAsync(cancellationToken);
		}
	}
}