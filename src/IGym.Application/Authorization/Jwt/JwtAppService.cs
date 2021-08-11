using IGym.Application.Authorization.Jwt.DataTransferObject;
using IGym.Application.Authorization.Secret.DataTransferObject;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace IGym.Application.Authorization.Jwt
{
    public class JwtAppService : IJwtAppService
    {
        #region Initialize

        /// <summary>
        /// 已授权的 Token 信息集合
        /// </summary>
        private static ISet<JwtAuthorizationDto> _tokens = new HashSet<JwtAuthorizationDto>();

        /// <summary>
        /// 分布式缓存
        /// </summary>
        private readonly IDistributedCache _cache;

        /// <summary>
        /// 配置信息
        /// </summary>
        private readonly IConfiguration _configuration;

        /// <summary>
        /// 获取 HTTP 请求上下文
        /// </summary>
        private readonly IHttpContextAccessor _httpContextAccessor;

        public JwtAppService(IDistributedCache cache, IHttpContextAccessor httpContextAccessor, IConfiguration configuration)
        {
            _cache = cache;
            _httpContextAccessor = httpContextAccessor;
            _configuration = configuration;
        }

        #endregion

        JwtAuthorizationDto IJwtAppService.Create(UserDto dto)
        {
            //生成秘钥
            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            SymmetricSecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:SecurityKey"]));

            //签发时间、过期时间
            DateTime authTime = DateTime.UtcNow;
            DateTime expiresAt = authTime.AddMinutes(Convert.ToDouble(_configuration["Jwt:ExpireMinutes"]));

            //将用户信息添加到 claim 集合中
            var identity = new ClaimsIdentity(JwtBearerDefaults.AuthenticationScheme);

            IEnumerable<Claim> claims = new Claim[]
            {
                new Claim(ClaimTypes.Name, dto.UserName),
                new Claim(ClaimTypes.Role, dto.Role.ToString()),
                new Claim(ClaimTypes.Email, dto.Email),
                new Claim(ClaimTypes.Expiration, expiresAt.ToString()),
                new Claim(ClaimTypes.MobilePhone, dto.Phone)
            };
            identity.AddClaims(claims);

            //签发一个加密后的用户信息凭证，用来标识用户的身份
            _httpContextAccessor.HttpContext.SignInAsync(JwtBearerDefaults.AuthenticationScheme, new ClaimsPrincipal(identity));

            SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),//创建声明信息
                Issuer = _configuration["Jwt:Issuer"],//签发者
                Audience = _configuration["Jwt:Audience"],//接收者
                Expires = expiresAt,//过期时间
                SigningCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256)//创建 token
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            //存储 Token 信息到 Jwt数据传输对象
            var jwt = new JwtAuthorizationDto
            {
                UserId = dto.Id,
                Token = tokenHandler.WriteToken(token),
                Auths = new DateTimeOffset(authTime).ToUnixTimeSeconds(),
                Expires = new DateTimeOffset(expiresAt).ToUnixTimeSeconds(),
                Success = true
            };

            _tokens.Add(jwt);
            return jwt;
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
