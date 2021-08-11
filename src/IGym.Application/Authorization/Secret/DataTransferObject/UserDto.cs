using System;

namespace IGym.Application.Authorization.Secret.DataTransferObject
{
    /// <summary>
    /// 用户实体信息数据传输对象
    /// </summary>
    class UserDto
    {
        /// <summary>
        /// 主键
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// 电子邮箱
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// 手机号码
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// 角色
        /// </summary>
        public Guid Role { get; set; }
    }
}
