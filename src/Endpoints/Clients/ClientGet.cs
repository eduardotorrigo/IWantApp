namespace IWantApp.Endpoints.Clients;

public class ClientGet
{
    public static string Template => "/clients";
    public static string[] Methods => new string[] { HttpMethod.Get.ToString() };
    public static Delegate Handle => Action;
    [AllowAnonymous]
        public static IResult Action(HttpContext http, UserManager<IdentityUser> userManager)
    {
        var user = http.User;

        var result = new
        {
            Id = user.Claims.First(c => c.Type == ClaimTypes.NameIdentifier).Value,
            Name = user.Claims.First(c => c.Type == "Name").Value,
            Email = user.Claims.First(c => c.Type == ClaimTypes.Email).Value,
            CPF = user.Claims.First(c => c.Type == "Cpf").Value,
        };
        //return Results.ValidationProblem(result.identity.Errors.ConvertToProblemDetails());


        return Results.Ok(result);
    }
}
