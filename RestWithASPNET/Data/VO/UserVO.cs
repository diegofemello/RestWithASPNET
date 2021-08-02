using RestWithASPNET.Model.Base;
using System;

namespace RestWithASPNET.Data.VO
{
    public class UserVO : BaseEntity
    {
        public string Password { get; set; }
        public string UserName { get; set; }
        public string FullName { get; set; }
        public string RefreshToken { get; set; }
        public DateTime RefreshTokenExpiryTime { get; set; }
    }
}