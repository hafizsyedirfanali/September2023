using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpBasics
{
    public class CH09_GUID
    {
        /// <summary>
        /// GUID is a Global unique identifier. its 128bit.
        /// it generates a unique identity always over the Globe (World)
        /// </summary>
        public void Test()
        {
            for (int i = 0; i < 10; i++)
            {
                Guid guid = Guid.NewGuid();
                Console.WriteLine(guid.ToString()); 
            }
        }
    }
}
