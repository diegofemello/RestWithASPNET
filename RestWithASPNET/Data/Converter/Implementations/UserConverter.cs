using RestWithASPNET.Data.Converter.Contract;
using RestWithASPNET.Data.VO;
using RestWithASPNET.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace RestWithASPNET.Data.Converter.Implementations
{
    public class UserConverter : IParser<UserVO, User>, IParser<User, UserVO>
    {
        public User Parse(UserVO origin)
        {
            var passwordHashed = ComputeHash(origin.Password, new SHA256CryptoServiceProvider());
            if (origin == null) return null;
            return new User
            {
                Id = origin.Id,
                UserName = origin.UserName,
                FullName = origin.FullName,
                Password = passwordHashed,
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

        private static string ComputeHash(string input, SHA256CryptoServiceProvider algorithm)
        {
            Byte[] inputBytes = Encoding.UTF8.GetBytes(input);
            Byte[] hashedBytes = algorithm.ComputeHash(inputBytes);
            return BitConverter.ToString(hashedBytes);
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
