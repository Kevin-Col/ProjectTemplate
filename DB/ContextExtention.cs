using Microsoft.EntityFrameworkCore;
using Model.DBModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB
{
    public static class ContextExtention
    {
        public static async Task<List<T>> ToListAsync<T>(this IQueryable<T> ts) where T : BaseModel
        {
            return await ts.Where(w => !w.IsDeleted).ToListAsync();
        }
        public static async Task<T> FirstOrDefaultAsync<T>(this IQueryable<T> ts) where T : BaseModel
        {
            return await ts.Where(w => !w.IsDeleted).FirstOrDefaultAsync();
        }
    }
}
