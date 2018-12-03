## Projection-View Pattern: MVC

This example is part 1 of 4 in a series demonstrating the Projection-View pattern. In this example, we start with a simple MVC application similar to what many beginner developers, even some non-beginners, will do.

The controllers will contain most if not all logic required to serve the view and we'll be interacting with the entities directly. This is a bad approach for multiple reasons, but many projects stay in this state because it's the easiest way to get a project up and running. This is especially true if the project is small and is rarely updated after the initial development.

#### Series Parts

1. MVC
2. MVC with Vertical Slices using MediatR and AutoMapper
3. MVC with Vertical Slices using MediatR, AutoMapper, and Future Queries
4. MVC with Vertical Slices using MediatR, AutoMapper, FutureQueries, and Projection-Views
