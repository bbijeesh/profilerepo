
namespace ProfileServiceGlobal.Profile.CreateProfile
{
    public record CreateProfileRequest (
        
        string FirstName,
        string LastName,
        string Address,
        string Telephone);
    //{
    //    public string UserId { get; init; } = string.Empty;
    //    public string FirstName { get; init; } = string.Empty;
    //    public string LastName { get; init; } = string.Empty;
    //    public string Address { get; init; } = string.Empty;
    //    public string Telephone { get; init; } = string.Empty;
    //}
    public record CreateProfileResponse (Guid Id);

    public class CreateProfileEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost("/profiles", async (CreateProfileRequest request, ISender sender) =>
            {
                var command = request.Adapt<CreateProfileCommand>();
                var result = await sender.Send(command);
                var response = result.Adapt<CreateProfileResponse>();

                return Results.Created($"/profiles/{response.Id}", response);
            });
        }
    }
}
