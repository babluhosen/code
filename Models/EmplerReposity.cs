using Code.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Code.Models
{
    public class EmplerReposity:IEmplerRepository
    {
        private readonly ApplicationDbContext applicationDbContext;
        public EmplerReposity(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }
        // post method//
        public async Task<IEnumerable<emplyer>> Addemplyer(emplyer emplyer)
        {
            if (emplyer.deprtment != null)
            {
                applicationDbContext.Entry(emplyer.deprtment).State = EntityState.Unchanged;
            }
            var result = await applicationDbContext.emplyers.AddAsync(emplyer);
            await applicationDbContext.SaveChangesAsync();
            return ((IEnumerable<emplyer>)result.Entity);
        }
        //api delte method //
        public async Task Deletedemplyer(int empId)
        {
            var result = await applicationDbContext.emplyers.FirstOrDefaultAsync(e => e.empId == empId);
           if(result!=null)
            {
                applicationDbContext.Remove(result);
                await applicationDbContext.SaveChangesAsync();
            }
        }
        // api get method//
        public async Task<IEnumerable<emplyer>> GetEmplyers()
        {
            return await applicationDbContext.emplyers.ToListAsync();
        }

        public async Task<IEnumerable<emplyer>> GetEmplyers(int empId)
        {
            return ((IEnumerable<emplyer>)await applicationDbContext.emplyers.Include(e => e.deprtment).FirstOrDefaultAsync(e => e.empId == empId));
        }

        public async Task<IEnumerable<emplyer>> Updateemplyer(emplyer emplyer)
        {
            var result = await applicationDbContext.emplyers.FirstOrDefaultAsync(e => e.empId==emplyer.empId);
            if (result != null)
            {
                result.empName = emplyer.empName;
                result.deprtId = emplyer.deprtId;
                await applicationDbContext.SaveChangesAsync();
                return (IEnumerable<emplyer>)result;
            }
            return null;
        }
       
    }
}
