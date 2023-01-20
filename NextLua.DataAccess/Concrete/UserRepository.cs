using NextLua.Core.DataAccess.EntityFramework;
using NextLua.DataAccess.Abstract;
using NextLua.DataAccess.Concrete.Context;
using NextLua.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NextLua.DataAccess.Concrete
{
    public class UserRepository : EfEntityRepositoryBase<User, NextLuaDB>, IUserRepository
    {
    }
}
