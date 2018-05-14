using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HasinCard.Core.Domain
{
    public class Cards
    {
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// 商品编号
        /// </summary>
        [Required]
        public int ProductId { get; set; }

        [ForeignKey("ProductId")]
        public virtual Products Procut { get; set; }
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
