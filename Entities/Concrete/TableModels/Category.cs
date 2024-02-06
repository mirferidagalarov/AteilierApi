using Core.Entities;

namespace Entities.Concrete.TableModels
{
    public class Category : BaseEntity
    {
        public string Name { get; set; }
        public List<Product>  Products { get; set; }
    }
}
