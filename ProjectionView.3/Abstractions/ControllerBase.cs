﻿using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ProjectionView._3 {
	public abstract class ControllerBase :
		Controller {
		protected IMediator Mediator { get; }

		protected ControllerBase(
			IMediator mediator) {
			Mediator = mediator;
		}
	}
}