using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HasinCard.Core.Domain
{
    /// <summary>
    /// 类别
    /// </summary>
    public class Categorys
    {
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// 类别名称
        /// </summary>
        [MaxLength(100)]
        public string CategoryName { get; set; }

        /// <summary>
        /// 排序号
        /// </summary>
        public int SortNo { get; set; }

        /// <summary>
        /// 创建人
        /// </summary>
        [Required]
        public int SysUserId { get; set; }

        /// <summary>
        /// 是否软删
        /// </summary>
        public bool IsDelete { get; set; }

        [ForeignKey("SysUserId")]
        public virtual SysUsers CreatorUser { get; set; }

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
