## Projection-View Pattern: MVC with Vertical Slices using MediatR, AutoMapper, and Future Queries

This example is part 3 of 4 in a series demonstrating the Projection-View pattern. In this example, we take the MVC application from part two and enhance it with EntityFramework Plus' Future Queries, again per [Jimmy Bogard's post][1].

Using future queries allows us to efficiently query the database by batching all queries into one request, rather than individual separate requests.

#### Series Parts

1. MVC
2. MVC with Vertical Slices using MediatR and AutoMapper
3. MVC with Vertical Slices using MediatR, AutoMapper, and Future Queries
4. MVC with Vertical Slices using MediatR, AutoMapper, FutureQueries, and Projection-Views

#### Changes from Part 2

These changes are not in any specific order, and I may have missed a couple.

- Added `EntityFrameworkPlus` NuGet
- Changed queries to be future queries

[1]: https://lostechies.com/jimmybogard/2014/03/11/efficient-querying-with-linq-automapper-and-future-queries/
