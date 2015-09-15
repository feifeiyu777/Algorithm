using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Threading.Tasks;
using System.Threading;

namespace Design
{
    public class LockDemo
    {
        Hashtable ht = new Hashtable();

        private static Hashtable htCatch = new Hashtable();
        public void TestMethod()
        {
            lock (htCatch.SyncRoot)
            {
                htCatch.Add("fsd", "vxc");

                
            }
        }
    }
}
