using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace   ZCJ.Model
{
    [Serializable]
    public class VideoClass
    {
        public int id { get; set; }
        /// <summary>
        /// 分类名
        /// </summary>
        public string ClassName { get; set; }
        /// <summary>
        /// 父类id
        /// </summary>
        public int ParentId { get; set; }
        /// <summary>
        /// 是否关闭，0为开启
        /// </summary>
        public bool IsDelete { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }
        /// <summary>
        /// 添加时间
        /// </summary>
        public DateTime CreateDate { get; set; }
    }
}
