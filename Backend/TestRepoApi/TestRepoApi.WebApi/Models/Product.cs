namespace TestRepoApi.WebApi.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Decription { get; set; } = string.Empty;
        public decimal Price { get; set; }
    }
}
