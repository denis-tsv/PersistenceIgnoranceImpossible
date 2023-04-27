using Microsoft.EntityFrameworkCore;
using PersistenceIgnoranceImpossible;

var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>()
    .UseNpgsql("Server=localhost; Port=5432; Database=PersistenceIgnorance; User Id=postgres; Password=postgres-007;");
var context = new AppDbContext(optionsBuilder.Options);
context.Database.EnsureCreated();

var orderInt = new OrderInt
{
    Number = "1i"
};
context.OrderInts.Add(orderInt);
context.SaveChanges();

var orderGuid = new OrderGuid
{
    Id = Guid.NewGuid(),
    Number = "1g"
};
context.OrderGuids.Add(orderGuid);
context.SaveChanges();

var itemInt = new OrderItemInt
{
    Count = 10
};
orderInt.Items = new List<OrderItemInt>();
orderInt.AddItem(itemInt);
context.SaveChanges();

var itemGuid = new OrderItemGuid
{
    Id = Guid.NewGuid(),
    Count = 10
};
orderGuid.Items = new List<OrderItemGuid>();
orderGuid.AddItem(itemGuid);
try
{
    context.SaveChanges();
}
catch (Exception e)
{
    //itemGuid State is Modified instead of Added
    Console.WriteLine(context.Entry(itemGuid).State);
    Console.WriteLine();
    Console.WriteLine(e);
}

context.Entry(itemGuid).State = EntityState.Added;
context.SaveChanges();

var itemGuid2 = new OrderItemGuid
{
    Id = Guid.NewGuid(),
    Count = 10
};
orderGuid.AddItem(itemGuid2, () => context.Entry(itemGuid2).State = EntityState.Added);
context.SaveChanges();

orderGuid.Items.Clear();
context.SaveChanges();
