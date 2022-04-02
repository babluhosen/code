using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Code.Models
{
    public interface IEmplerRepository
    {
        Task<IEnumerable<emplyer>> GetEmplyers();
        Task<IEnumerable<emplyer>> GetEmplyers(int empId);
        Task<IEnumerable<emplyer>> Addemplyer(emplyer emplyer);
        Task<IEnumerable<emplyer>> Updateemplyer(emplyer emplyer);
        Task Deletedemplyer(int empId);
    }
}
