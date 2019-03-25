using Microsoft.EntityFrameworkCore;
namespace QandAApi.Models
{    public class Item
    {
        public string Id { get; set; }
        public string Ques { get; set; }
        public string Ans { get; set; }
        
    }
    // public class TableContext : DbContext
    // {
    //     public TableContext(DbContextOptions<TableContext> options)
    //         : base(options)
    //     {
    //     }
    //     public DbSet<Item> Items { get; set; }
    // }    
}