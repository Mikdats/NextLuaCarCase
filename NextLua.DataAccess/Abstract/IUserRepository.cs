using NextLua.Core.DataAccess;
using NextLua.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NextLua.DataAccess.Abstract
{
    public interface IUserRepository : IEntityRepository<User>
    {

    }
}
