using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DBModel
{
    public class Dictionary : BaseModel
    {
        /// <summary>
        /// 字典类型
        /// </summary>
        public string Type { get; set; }
        /// <summary>
        /// 字典名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 字典描述
        /// </summary>
        public string Desc { get; set; }
        /// <summary>
        /// 字典值
        /// </summary>
        public string Value { get; set; }

        public User Creator { get; set; }
        public User Updator { get; set; }
    }
}
