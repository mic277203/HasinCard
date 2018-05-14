using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HasinCard.Core.Domain
{
    public class Products
    {
        [Key]
        public int Id { get; set; }
        /// <summary>
        /// 产品名称
        /// </summary>
        [MaxLength(100)]
        public string ProductName { get; set; }

        /// <summary>
        /// 类别编号
        /// </summary>
        [Required]
        public int CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        public virtual Categorys Category { get; set; }

        /// <summary>
        ///销售单价
        /// </summary>
        public decimal SalePrice { get; set; }

        /// <summary>
        ///成本单价
        /// </summary>
        public decimal CostPrice { get; set; }

        /// <summary>
        /// 产品说明
        /// </summary>
        public decimal ProductDesc { get; set; }

        /// <summary>
        /// 使用说明
        /// </summary>
        public decimal Instructions { get; set; }

        /// <summary>
        /// 排序号
        /// </summary>
        public int SortNo { get; set; }

        /// <summary>
        /// 是否软删
        /// </summary>
        public bool IsDelete { get; set; }

        /// <summary>
        /// 创建人
        /// </summary>
        [Required]
        public int SysUserId { get; set; }

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
