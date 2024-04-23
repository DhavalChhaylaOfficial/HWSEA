using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RedBackEnd.Exceptions
{
    public class SalaryLessThan1l:Exception
    {
        public SalaryLessThan1l():base("Salary cannot be greater than 100000") { }
    }
}