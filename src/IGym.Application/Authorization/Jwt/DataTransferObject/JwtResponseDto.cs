namespace IGym.Application.Authorization.Jwt.DataTransferObject
{
    /// <summary>
    /// Jwt 响应对象
    /// </summary>
    public class JwtResponseDto
    {
        /// <summary>
        /// 访问 Token 值
        /// </summary>
        public string Access { get; set; }

        /// <summary>
        /// 授权类型
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// 个人信息
        /// </summary>
        public Profile Profile { get; set; }
    }

    /// <summary>
    /// 个人信息
    /// </summary>
    public class Profile
    {
        /// <summary>
        /// 姓名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 授权时间戳
        /// </summary>
        public long Auths { get; set; }

        /// <summary>
        /// 过期时间戳
        /// </summary>
        public long Expires { get; set; }
    }
}
