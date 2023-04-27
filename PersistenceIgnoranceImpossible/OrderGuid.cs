namespace PersistenceIgnoranceImpossible;

public class OrderGuid
{
    public Guid Id { get; set; }
    public string Number { get; set; } = default!;

    public ICollection<OrderItemGuid>? Items { get; set; }

    public void AddItem(OrderItemGuid item)
    {
        Items.Add(item);
    }

    public void AddItem(OrderItemGuid item, Action onItemAdded)
    {
        Items.Add(item);
        onItemAdded();
    }
}