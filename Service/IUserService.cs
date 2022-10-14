using AARCOAPI.Models.Request;
using AARCOAPI.Models.Response;


namespace AARCOAPI.Service
   
{
    public interface IUserService
    {
        UserResponse Auth(AuthRequest model);
    }
}
