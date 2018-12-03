## Projection-View Pattern: MVC with Vertical Slices using MediatR and AutoMapper

This example is part 2 of 4 in a series demonstrating the Projection-View pattern. In this example, we take the MVC application from part one and enhance it with [Vertical Slices][1] per Jimmy Bogard's post.

Functionality that was in the controllers is now moved to separate, isolated, slices on a view-by-view basis. The controllers are only responsible for forwarding requests to the slice handlers and receiving their responses, if any.

#### Series Parts

1. MVC
2. MVC with Vertical Slices using MediatR and AutoMapper
3. MVC with Vertical Slices using MediatR, AutoMapper, and Future Queries
4. MVC with Vertical Slices using MediatR, AutoMapper, FutureQueries, and Projection-Views

#### Changes from Part 1

These changes are not in any specific order, and I may have missed a couple.

- Added MediatR NuGet
- Added AutoMapper NuGet
- Updated `Startup` services
- Renamed `Views` to `Features`
- Added `FeaturesViewLocationExpander`
- Configured `RazorViewEngineOptions`
- Moved controllers to `Features` folders
- Moved models to `Features` folders
- Updated namespaces
- Added `HandlerBase<TRequest>`
- Added `HandlerBase<TRequest, TResponse>`
- Updated `ControllerBase` dependencies
- Renamed `DashboardDefaultView` to `Default`
- Converted `Default` to a "slice"
- Renamed `EmployeeEditView` to `Edit`
- Converted `Edit` to a "slice"
- Renamed `EmployeeListView` to `List`
- Converted `List` to a "slice"
- Renamed `JobAddView` to `Add`
- Converted `Add` to a "slice"
- Renamed `JobEditView` to `Edit`
- Converted `Edit` to a "slice"
- Removed `JobAddOrEditView`
- Renamed `JobListView` to `List`
- Converted `List` to a "slice"
- Moved `_Layout` to the root of `Features`
- Removed `Shared` folder
- Added `MappingProfile` to Employees
- Implemented projections using AutoMapper
- Added States feature
- Added `MappingProfile` to States
- Added Statuses feature
- Added `MappingProfile` to Statuses
- Added Types features
- Added `MappingProfile` to Types
- Added `MappingProfile` to Jobs

[1]: https://jimmybogard.com/vertical-slice-architecture/
