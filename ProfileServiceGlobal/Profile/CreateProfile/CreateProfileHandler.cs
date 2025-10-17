using BuildingBlocks.CQRS;
using ProfileServiceGlobal.Model;

namespace ProfileServiceGlobal.Profile.CreateProfile
{
    public record CreateProfileCommand(
        string FirstName,
        string LastName,
        string Address,
        string Telephone) : ICommand<CreateProfileResult>;

    public record CreateProfileResult(Guid Id);
    public class CreateProfileHandler (IDocumentSession session) 
        : ICommandHandler<CreateProfileCommand, CreateProfileResult>
    {
        public async Task<CreateProfileResult> Handle(CreateProfileCommand request, CancellationToken cancellationToken)
        {
            var profSnap = new ProfileSnapshot
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Address = request.Address,
                Telephone = request.Telephone
            };
            session.Store(profSnap);
            await session.SaveChangesAsync(cancellationToken);
            return new CreateProfileResult(profSnap.Id);
        }
    }
}
