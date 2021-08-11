using System;

namespace IGym.Application.Authorization.Jwt.DataTransferObject
{
    /// <summary>
    /// Jwt 数据传输实体
    /// </summary>
    class JwtAuthorizationDto
    {
        /// <summary>
        /// 授权时间
        /// </summary>
        public long Auths { get; set; }

        /// <summary>
        /// 过期时间
        /// </summary>
        public long Expires { get; set; }

        /// <summary>
        /// 授权结果
        /// </summary>
        public bool Success { get; set; }

        /// <summary>
        /// Token
        /// </summary>
        public string Token { get; set; }

        /// <summary>
        /// 用户主键
        /// </summary>
        public Guid UserId { get; set; }
    }
}
