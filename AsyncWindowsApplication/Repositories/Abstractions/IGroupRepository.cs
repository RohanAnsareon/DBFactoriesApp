using AsyncWindowsApplication.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncWindowsApplication.Repositories
{
   public  interface IGroupRepository
    {
        event EventHandler<ErrorEventArgs> NotifyClientErrorEvent;

        Task<int> Create(Group group);
        Task Update(Group group);
        Task Delete(int id);
        Task<IEnumerable<Group>> Get();
    }
}
