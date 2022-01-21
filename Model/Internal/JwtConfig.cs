using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Internal
{
    public class JwtConfig
    {
        public string Secrect { get; set; }
        public string Iss { get; set; }

        /// <summary>
        /// 过期时间，单位秒
        /// </summary>
        public int Expires { get; set; }
    }
}
