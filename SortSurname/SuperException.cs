using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortSurname
{
    public class SuperException: Exception
    {
        public SuperException(string message) : base(message) { }
    }
}
