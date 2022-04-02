using Code.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Code.Models
{
    public class DeprtmentClass:Deprtmentterface
    {
        private readonly ApplicationDbContext applicationDbContext;
        public DeprtmentClass(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }

        public async Task<IEnumerable<Deprtment>> GetEmplyers()
        {
            return await applicationDbContext.deprtments.ToListAsync();
        }

        public async  Task<IEnumerable<Deprtment>> GetEmplyers(int deprtId)
        {
            return ((IEnumerable<Deprtment>)await applicationDbContext.emplyers.FirstOrDefaultAsync(e => e.deprtId ==deprtId));
        }
    }
}
