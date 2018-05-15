using System;
using System.Collections.Generic;
using System.Text;

namespace HasinCard.Core
{
    public class HasinPagerModel<T> where T : class
    {
        /// <summary>
        /// 当前显示页面
        /// </summary>
        public int Draw { get; set; }

        /// <summary>
        /// 总记录
        /// </summary>
        public int RecordsTotal { get; set; }

        /// <summary>
        /// 条件过滤后的总数
        /// </summary>
        public int RecordsFiltered { get; set; }

        /// <summary>
        /// 数据
        /// </summary>
        public List<T> Data { get; set; }
    }
}
