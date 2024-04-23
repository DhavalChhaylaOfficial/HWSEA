using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RedBackEnd.Exceptions
{
    public class SalaryLessThan5:Exception
    {
        public SalaryLessThan5():base("Salary Cannot be less than 5000") { }
    }
}