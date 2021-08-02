using RestWithASPNET.Data.Converter.Contract;
using RestWithASPNET.Data.VO;
using RestWithASPNET.Model;
using System.Collections.Generic;
using System.Linq;

namespace RestWithASPNET.Data.Converter.Implementations
{
    public class UserConverter : IParser<UserVO, User>, IParser<User, UserVO>
    {
        public User Parse(UserVO origin)
        {
            if (origin == null) return null;
            return new User
            {
                Id = origin.Id,
                UserName = origin.UserName,
                FullName = origin.FullName,
                Password = origin.Password,
                RefreshToken = origin.RefreshToken,
                RefreshTokenExpiryTime = origin.RefreshTokenExpiryTime
            };
        }
        public UserVO Parse(User origin)
        {
            if (origin == null) return null;
            return new UserVO
            {
                Id = origin.Id,
                UserName = origin.UserName,
                FullName = origin.FullName,
                Password = origin.Password,
                RefreshToken = origin.RefreshToken,
                RefreshTokenExpiryTime = origin.RefreshTokenExpiryTime
            };
        }

        public List<User> Parse(List<UserVO> origin)
        {
            if (origin == null) return null;
            return origin.Select(item => Parse(item)).ToList();
        }

        public List<UserVO> Parse(List<User> origin)
        {
            if (origin == null) return null;
            return origin.Select(item => Parse(item)).ToList();
        }
    }
}
