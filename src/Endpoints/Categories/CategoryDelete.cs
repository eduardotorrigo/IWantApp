namespace IWantApp.Endpoints.Categories;

public class CategoryDelete
{
    public static string Template => "/categories/{id:guid}";
    public static string[] Methods => new string[] { HttpMethod.Delete.ToString() };
    public static Delegate Handle => Action;
    public static async Task<IResult> Action([FromRoute] Guid Id, ApplicationDbContext context)
    {
        
        var category = await context.Categories.Where(c => c.Id == Id).FirstOrDefaultAsync();
        if(category == null)
            return Results.NotFound();

        context.Categories.Remove(category);
        context.SaveChanges();

        return Results.Ok("Deletado com sucesso");

    }
}
