namespace PersistenceIgnoranceImpossible;

public class OrderItemInt
{
    public int Id { get; set; }
    public int Count { get; set; }

    public int OrderId { get; set; }
    public OrderInt? Order { get; set; }
}