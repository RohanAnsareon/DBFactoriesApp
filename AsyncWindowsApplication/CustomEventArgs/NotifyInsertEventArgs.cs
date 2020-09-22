using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncWindowsApplication.CustomEventArgs
{
    public class NotifyInsertEventArgs: EventArgs
    {
        public NotifyInsertEventArgs(int id) => this.Id = id;

        public int Id { get; set; }
    }
}
