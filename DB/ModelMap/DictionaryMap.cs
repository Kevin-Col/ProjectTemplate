using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Model.DBModel;

namespace DB.ModelMap
{
    public class DictionaryMap : BaseMap<Dictionary>
    {
        public override void SonConfigure(EntityTypeBuilder<Dictionary> builder)
        {
            builder.HasOne(h => h.Creator).WithOne().HasForeignKey<Dictionary>(f => f.CreateBy);
            builder.HasOne(h => h.Updator).WithOne().HasForeignKey<Dictionary>(f => f.UpdateBy);
        }
    }
}
