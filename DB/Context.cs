using DB.ModelMap;
using Microsoft.EntityFrameworkCore;
using Model.DBModel;
using System.Reflection;

namespace DB
{
    public class Context : DbContext
    {
        //无参构造函数用于Migration相关指令实例化Context
        public Context()
        {

        }
        public Context(DbContextOptions<Context> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder)
        {
            optionBuilder.UseMySql("server=rm-bp1gsig2xii7jj3126o.mysql.rds.aliyuncs.com;userid=sa;password=kevin888;database=ProjectTemplate;", MySqlServerVersion.LatestSupportedServerVersion);
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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var types = Assembly.GetAssembly(typeof(Context))?.GetTypes();
            var basetype = typeof(BaseMap<>);


            //获取类：Base所在的程序及下所有继承IEntityTypeConfiguration且类名不为BaseMap的类
            //IsGenericType:是否泛型类
            //GetGenericTypeDefinition：获取泛型类基本类型
            var typesToRegister = Assembly.GetAssembly(typeof(Context))?.GetTypes()
                                  .Where(w => w.BaseType?.IsGenericType == true ? w.BaseType?.GetGenericTypeDefinition() == typeof(BaseMap<>) : false);

            //循环创建map实例并添加到配置
            foreach (var type in typesToRegister ?? new List<Type>())
                modelBuilder.ApplyConfiguration(Activator.CreateInstance(type) as dynamic);
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
        public DbSet<Dictionary> Dictionary { get; set; }
    }
}