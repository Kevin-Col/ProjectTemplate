using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Model.DBModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.ModelMap
{
    public class UserMap : BaseMap<User>
    {
        public override void SonConfigure(EntityTypeBuilder<User> builder)
        {
        }
    }
}
