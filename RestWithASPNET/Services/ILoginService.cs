using RestWithASPNET.Data.VO;

namespace RestWithASPNET.Services
{
    public interface ILoginService
    {
        TokenVO ValidateCredentials(UserVO user);

        TokenVO ValidateCredentials(TokenVO token);

        bool RevokeToken(string userName);
    }
}