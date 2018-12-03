using System;
using System.Linq;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using ProjectionView.Data;
using Z.EntityFramework.Plus;

namespace ProjectionView._3 {
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

		protected QueryFutureValue<SignedInEmployee> GetSignedInEmployee() {
			var id = new Random().Next(1, 10);

			return Context.Employees.Where(
				e => e.Id == id).ProjectTo<SignedInEmployee>(MapperConfig).DeferredSingle().FutureValue();
		}
	}
}