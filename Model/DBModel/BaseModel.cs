using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DBModel
{
    public class BaseModel
    {
        public int Id { get; set; }
        public bool IsDeleted { get; set; }
        public int CreateBy { get; set; }
        public DateTime CreateTime { get; set; }
        public int? UpdateBy { get; set; }
        public DateTime? UpdateTime { get; set; }

    }
}
