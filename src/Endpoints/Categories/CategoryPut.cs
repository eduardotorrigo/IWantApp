namespace IWantApp.Endpoints.Categories;

public class CategoryPut
{
    public static string Template => "/categories/{id:guid}";
    public static string[] Methods => new string[] { HttpMethod.Put.ToString() };
    public static Delegate Handle => Action;

    public static async Task<IResult> Action([FromRoute] Guid Id, CategoryRequest categoryRequest, HttpContext http, ApplicationDbContext context)
    {
        var userId = http.User.Claims.First(c => c.Type == ClaimTypes.NameIdentifier).Value;
        var category = await context.Categories.Where(c => c.Id == Id).FirstOrDefaultAsync();
        
        if (category == null)
            return Results.NotFound();

        category.UpdateCategory(categoryRequest.Name, categoryRequest.Active, userId);        

        if (!category.IsValid)
        return Results.ValidationProblem(category.Notifications.ConvertToProblemDetail());
        
        context.SaveChanges();

        return Results.Ok("Atualizado com sucesso");

    }
}
