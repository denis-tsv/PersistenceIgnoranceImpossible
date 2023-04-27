namespace PersistenceIgnoranceImpossible;

public class OrderItemGuid
{
    public Guid Id { get; set; }
    public int Count { get; set; }

    public Guid OrderId { get; set; }
    public OrderGuid? Order { get; set; }
}