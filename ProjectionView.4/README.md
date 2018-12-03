## Projection-View Pattern: MVC with Vertical Slices using MediatR, AutoMapper, Future Queries, and Projection-Views

This example is part 4 of 4 in a series demonstrating the Projection-View pattern. In this example, we take the MVC application from part three and enhance it with by separating the database projections from the views.

#### Series Parts

1. MVC
2. MVC with Vertical Slices using MediatR and AutoMapper
3. MVC with Vertical Slices using MediatR, AutoMapper, and Future Queries
4. MVC with Vertical Slices using MediatR, AutoMapper, FutureQueries, and Projection-Views

#### Changes from Part 3

These changes are not in any specific order, and I may have missed a couple.

- Renamed `SignedInEmployee` to `SignedInEmployeeProjectionView`
- Added `ProjectionBase`
- Added `QueryHandlerBase<TQuery, TProjection, TView>`
- Added `MappingProfileBase`
- Updated mapping profiles
