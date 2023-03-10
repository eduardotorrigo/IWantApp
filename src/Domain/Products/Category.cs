namespace IWantApp.Domain.Products;

public class Category : Entity
{
    public string Name { get; private set; }
    public bool Active { get; private set; }

    public Category(string name, string createdBy, string editedBy)
    {
        Name = name;
        Active = true;
        CreatedBy = createdBy;
        CreatedOn = DateTime.Now;
        EditedBy = editedBy;
        EditedOn = DateTime.Now;

        Validate();
    }

    private void Validate()
    {
        var contract = new Contract<Category>()
        .IsNotNullOrEmpty(Name, "Name", "Nome é obrigatorio")
        .IsGreaterOrEqualsThan(Name, 3, "Name", "O nome deve ser maior que 3 caracteres")
        .IsNotNullOrEmpty(CreatedBy, "CreateBy")
        .IsNotNullOrEmpty(EditedBy, "EditedBy");
        AddNotifications(contract);
    }

    public void UpdateCategory(string name, bool active, string editedBy)
    {
        Name = name;
        Active = active;
        EditedBy = editedBy;
        EditedOn = DateTime.Now;

        Validate();
    }
}
