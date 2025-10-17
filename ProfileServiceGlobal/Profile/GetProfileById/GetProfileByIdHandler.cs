using BuildingBlocks.CQRS;
using ProfileServiceGlobal.Model;

namespace ProfileServiceGlobal.Profile.GetProfileById
{
    public record GetProfileByIdQuery(Guid Id) : IQuery<ProfileSnapshot>;
    internal class GetProfileByIdHandler (IDocumentSession session)
        : IQueryHandler<GetProfileByIdQuery, ProfileSnapshot>
    {
        public async Task<ProfileSnapshot> Handle(GetProfileByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await session.Query<ProfileSnapshot>()
                .FirstOrDefaultAsync(p => p.Id == request.Id, cancellationToken);

            return result;
        }
    }
}
