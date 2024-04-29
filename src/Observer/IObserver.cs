using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Observer
{
    public interface IObserver
    {
        /// <summary>
        /// Receive update from subject
        /// </summary>
        /// <param name="subject"></param>
        void Update(ISubject subject);
    }
}
