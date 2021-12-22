using Microsoft.EntityFrameworkCore;
using Model.DBModel;

namespace DB
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {
        }
        public async override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            //检测变化
            ChangeTracker.DetectChanges();
            var modifys = this.ChangeTracker.Entries().Where(w => w.State == EntityState.Modified).Select(s => s.Entity).ToList();
            var adds = this.ChangeTracker.Entries().Where(w => w.State == EntityState.Added).Select(s => s.Entity).ToList();
            modifys.ForEach(f => SetModify(f));
            adds.ForEach(f => SetCreate(f));
            return await base.SaveChangesAsync(cancellationToken);
        }

        public void SetModify(object obj)
        {
            var ldt = obj.GetType().GetProperty("LastModifiedTime");
            if (ldt != null)
                ldt.SetValue(obj, DateTime.Now);

            //var ldb = obj.GetType().GetProperty("LastModifiedBy");
            //if (ldb != null && (ldb.GetValue(obj) == null || ldb.GetValue(obj) == ""))
            //    ldb.SetValue(obj, _User?.UserId ?? "system");
        }

        public void SetCreate(object obj)
        {
            var ct = obj.GetType().GetProperty("CreateTime");
            if (ct != null)
                ct.SetValue(obj, DateTime.Now);

            //var cb = obj.GetType().GetProperty("CreateBy");
            //if (cb != null && (cb.GetValue(obj) == null || cb.GetValue(obj) == ""))
            //    cb.SetValue(obj, _User?.UserId ?? "system");
            SetModify(obj);
        }

        public DbSet<User> User { get; set; }
    }
}