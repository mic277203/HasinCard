using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HasinCard.Core.Domain
{
    /// <summary>
    /// 用户
    /// </summary>
    public class SysUsers
    {
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// 邮箱
        /// </summary>
        [MaxLength(50)]
        public string Email { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        [MaxLength(20)]
        [Required]
        public string Password { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        [MaxLength(20)]
        public string Name { get; set; }

        /// <summary>
        /// 手机号码
        /// </summary>
        [MaxLength(15)]
        public string TelNo { get; set; }

        /// <summary>
        /// QQ号码
        /// </summary>
        [MaxLength(15)]
        public string QQ { get; set; }

        /// <summary>
        ///创建时间
        /// </summary>
        [Required]
        public DateTime CreationTime { get; set; }

        /// <summary>
        /// 最后修改时间
        /// </summary>
        public DateTime? LastModificationTime { get; set; }
    }
}
