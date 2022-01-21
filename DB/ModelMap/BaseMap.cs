using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Model.DBModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.ModelMap
{
    public class BaseMap<T> : IEntityTypeConfiguration<T> where T : BaseModel
    {
        public virtual void SonConfigure(EntityTypeBuilder<T> builder) { }
        public void Configure(EntityTypeBuilder<T> builder)
        {
            //统一指定表名，防止ef自动为表名增加s/es后缀
            builder.ToTable(typeof(T).Name);
            //统一指定主键
            builder.HasKey(h => h.Id);
            //执行各表自定的规则
            SonConfigure(builder);
        }
    }
}
