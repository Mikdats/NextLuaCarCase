using NextLua.Business.Abstract;
using NextLua.DataAccess.Abstract;
using NextLua.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NextLua.Business.Concrete
{
    public class UserService:IUserService
    {
        readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public List<User> GetAll()
        {
            return _userRepository.GetAll();
        }

        public User GetById(string userId)
        {
            return _userRepository.Get(x => x.Id == userId);
        }

        public void Add(User user)
        {
            _userRepository.Add(user);
        }

        public void Delete(User user)
        {
            _userRepository.Delete(user);
        }

        public void Update(User user)
        {
            _userRepository.Update(user);
        }

        public User GetById(int userId)
        {
            throw new NotImplementedException();
        }
    }
}
