namespace PersistenceIgnoranceImpossible;

public class OrderInt
{
    public int Id { get; set; }
    public string Number { get; set; } = default!;

    public ICollection<OrderItemInt>? Items { get; set; }

    public void AddItem(OrderItemInt item)
    {
        Items.Add(item);
    }
}