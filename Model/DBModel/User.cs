using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DBModel
{
    public class User : BaseModel
    {
        public string NickName { get; set; }
        public string LoginName { get; set; }
        public string Password { get; set; }
    }
}
