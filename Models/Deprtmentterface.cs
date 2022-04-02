using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Code.Models
{
    interface Deprtmentterface
    {
        Task<IEnumerable<Deprtment>> GetEmplyers();
        Task<IEnumerable<Deprtment>> GetEmplyers(int deprtId);
    }
}
