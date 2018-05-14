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
    public class CategorysRequestDto
    {
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// 类别名称
        /// </summary>
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
    }
}
