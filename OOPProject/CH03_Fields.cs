using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPProject
{
    /// <summary>
    /// The Name of Fields are to be either lowerCamelCase or with _UpperCamelCase
    /// Fields are always kept private
    /// </summary>
    public class CH03_Fields
    {
        private int _Count;//Underscore & UpperCamelCase
        private int count;//lowerCamelCase
        //Readonly fields
        private readonly int aadhaarNo;//we have a single chance to assign a value
        private const double pi = 3.14;//it has to be assigned value directly
    }
}
