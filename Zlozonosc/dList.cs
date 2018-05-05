using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

[assembly: InternalsVisibleTo("Lab2.cs")]
namespace Zlozonosc
{
    internal class dList
    {

        internal string English { get; set; }
        internal string Polish { get; set; }
       

       internal dList(string english, string polish)
        {
            English = english;
            Polish = polish;
        }
    }
}
