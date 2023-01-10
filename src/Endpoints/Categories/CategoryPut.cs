namespace IWantApp.Endpoints.Categories;

public class CategoryPut
{
    public static string Template => "/categories/{id}";
    public static string[] Methods => new string[] { HttpMethod.Put.ToString() };
    public static Delegate Handle => Action;

    public static IResult Action([FromRoute] Guid Id, CategoryRequest categoryRequest, ApplicationDbContext context)
    {
        var category = context.Categories.Where(c => c.Id == Id).FirstOrDefault();
        category.Name = categoryRequest.Name;
        category.Active = category.Active;
        context.Categories.Update(category);
        context.SaveChanges();

        return Results.Ok("Atualizado com sucesso");

    }
}
