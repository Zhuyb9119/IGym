using IGym.Application.Authorization.Jwt.DataTransferObject;
using IGym.Application.Authorization.Secret.DataTransferObject;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IGym.Application.Authorization.Jwt
{
    public class JwtAppService : IJwtAppService
    {
        JwtAuthorizationDto IJwtAppService.Create(UserDto dto)
        {
            throw new NotImplementedException();
        }

        Task IJwtAppService.DeactivateAsync(string token)
        {
            throw new NotImplementedException();
        }

        Task IJwtAppService.DeactivateCurrentAsync()
        {
            throw new NotImplementedException();
        }

        Task<bool> IJwtAppService.IsActiveAsync(string token)
        {
            throw new NotImplementedException();
        }

        Task<bool> IJwtAppService.IsCurrentActiveTokenAsync()
        {
            throw new NotImplementedException();
        }

        Task<JwtAuthorizationDto> IJwtAppService.RefreshAsync(string token, UserDto dto)
        {
            throw new NotImplementedException();
        }
    }
}
