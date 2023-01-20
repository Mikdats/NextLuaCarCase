using Microsoft.AspNetCore.Identity;
using NextLua.Core.Entities;

namespace NextLua.Entities.Concrete
{
    public class User: IdentityUser, IEntity
    {
        public User()
        {
            BuyerCars = new HashSet<Car>();
            SellerCars = new HashSet<Car>();
        }
        public virtual ICollection<Car> BuyerCars { get; set; }
        public virtual ICollection<Car> SellerCars { get; set; }
    }
}
