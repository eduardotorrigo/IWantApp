namespace IWantApp.Endpoints.Categories;

public class CategoryDelete
{
    public static string Template => "/categories/{id}";
    public static string[] Methods => new string[] { HttpMethod.Delete.ToString() };
    public static Delegate Handle => Action;
    public static IResult Action([FromRoute] Guid Id, ApplicationDbContext context)
    {
        var category = context.Categories.Where(c => c.Id == Id).FirstOrDefault();
        var result = context.Categories.Remove(category);
        context.SaveChanges();

        return Results.Ok("Deletado com sucesso");

    }
}
