

namespace TaseFood.StorageApp.Entities
{
    public class Organisation : EntityBase
    {
        
        public string? Name { get; set; }

        public override string ToString() => $"Id: {Id}, FirstName: {Name}";
    }
}
