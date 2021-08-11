using IGym.Application.Authorization.Jwt.DataTransferObject;
using IGym.Application.Authorization.Secret.DataTransferObject;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IGym.Application.Authorization.Jwt
{
    public interface IJwtAppService
    {
        /// <summary>
        /// 创建 Jwt 数据传输对象
        /// </summary>
        /// <param name="dto">用户实体信息数据传输对象</param>
        /// <returns></returns>
        JwtAuthorizationDto Create(UserDto dto);

        /// <summary>
        /// 刷新 Jwt 数据传输对象
        /// </summary>
        /// <param name="token">token</param>
        /// <param name="dto">用户实体信息数据传输对象</param>
        /// <returns></returns>
        Task<JwtAuthorizationDto> RefreshAsync(string token, UserDto dto);

        /// <summary>
        /// 判断当前 Token 是否有效
        /// </summary>
        /// <returns></returns>
        Task<bool> IsCurrentActiveTokenAsync();

        /// <summary>
        /// 停用当前 Token
        /// </summary>
        /// <returns></returns>
        Task DeactivateCurrentAsync();

        /// <summary>
        /// 判断 Token 是否有效
        /// </summary>
        /// <param name="token">token</param>
        /// <returns></returns>
        Task<bool> IsActiveAsync(string token);

        /// <summary>
        /// 停用 Token
        /// </summary>
        /// <param name="token">token</param>
        /// <returns></returns>
        Task DeactivateAsync(string token);
    }
}
