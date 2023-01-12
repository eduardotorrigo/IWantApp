namespace IWantApp.Endpoints.Employees;

public class EmployeeGetAll
{
    public static string Template => "/employees";
    public static string[] Methods => new string[] { HttpMethod.Get.ToString() };
    public static Delegate Handle => Action;

    [Authorize(Policy = "EmployeePolicy")]
    public static async Task<IResult> Action(UserManager<IdentityUser> userManager)
    {
        var user = userManager.Users.ToList();
        var employees = new List<EmployeeResponse>();
        foreach (var item in user)
        {
            var claims = await userManager.GetClaimsAsync(item);
            var claimName = claims.FirstOrDefault(c => c.Type == "Name");
            var userName = claimName != null ? claimName.Value : string.Empty;
            employees.Add(new EmployeeResponse(item.Email, userName));
        }

        return Results.Ok(employees);
    }
}
