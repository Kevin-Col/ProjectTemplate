using Model.DBModel;
using efqe = Microsoft.EntityFrameworkCore.EntityFrameworkQueryableExtensions;

namespace DB
{
    public static class ContextExtention
    {
        public static async Task<List<T>> ToListAsync<T>(this IQueryable<T> ts) where T : BaseModel
        {
            return await efqe.ToListAsync(ts.Where(w => !w.IsDeleted));
        }
        public static async Task<T> FirstOrDefaultAsync<T>(this IQueryable<T> ts) where T : BaseModel
        {
            return await efqe.FirstOrDefaultAsync(ts.Where(w => !w.IsDeleted));
        }
    }
}
