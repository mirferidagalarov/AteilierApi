using Core.Entities;

namespace Entities.Concrete.TableModels
{
    public class Category : BaseEntity,IEntity
    {
        public string Name { get; set; }
        public List<Product>  Products { get; set; }
    }
}
