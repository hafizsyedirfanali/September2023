using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPProject
{
    /// <summary>
    /// prop is code snippet for property
    /// </summary>
    public class CH02_Properties
    {
        public void Test()
        {
            Property3 = 1;
        }
        public int Property1 { get; set; } //Read Write
        public int Property2 { get;  }//Read Only - Can be written in two ways (1) Through constructor (2) Direct Assignment
        public int Property3 { get; private set; }//Read / Write by Class Members ONLY
        
        //----------Advanced----------------
        private int _Field1;
        public int MyProperty1
        {
            get
            {
                return _Field1;
            }
            set
            {
                _Field1 = value >=30 && value <=70?value:0;
            } 
        }

    }
}
