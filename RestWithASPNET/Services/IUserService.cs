using RestWithASPNET.Data.VO;
using System.Collections.Generic;

namespace RestWithASPNET.Services
{
    public interface IUserService
    {
        UserVO Create(UserVO user);
        UserVO FindByID(long id);
        List<UserVO> FindAll();
        UserVO Update(UserVO user);
        void Delete(long id);
    }
}