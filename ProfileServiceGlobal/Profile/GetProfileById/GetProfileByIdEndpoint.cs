
namespace ProfileServiceGlobal.Profile.GetProfileById
{
    public record ProfileByIdRequest(Guid Id);
    public record ProfileByIdResponse(
        Guid Id,
        string FirstName,
        string LastName,
        string Address,
        string Telephone);
    public class GetProfileByIdEndpoint: ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/profiles/{id:guid}", async (Guid id, ISender sender) =>
            {
                var query = new GetProfileByIdQuery(id);
                var result = await sender.Send(query);
                if (result is null)
                {
                    return Results.NotFound();
                }
                var response = result.Adapt<ProfileByIdResponse>();
                if(response is null)
                {
                    return Results.NotFound();
                }
                return Results.Ok(response);
            });
        }
    }
}
