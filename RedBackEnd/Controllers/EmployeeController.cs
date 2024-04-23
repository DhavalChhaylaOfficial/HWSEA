using RedBackEnd.Exceptions;
using RedBackEnd.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace RedBackEnd.Controllers
{
    public class EmployeeController:ApiController
    {
        Red_DBEntities context = new Red_DBEntities();
        [HttpGet]
        [Route("GetEmpData")]
        public List<TBLEmployee> BookList()
        {
            return context.TBLEmployees.ToList();
        }
        public object PostEmployee(TBLEmployee res)
        {
            try
            {
                if (context.TBLEmployees.Any(b => b.Name.ToLower() == res.Name.ToLower()))
                {
                    var matchingNames = context.TBLEmployees
                                   .Where(b => b.Name.ToLower().StartsWith(res.Name.ToLower()) &&
                                               b.Name.Length > res.Name.Length)
                                   .Select(b => b.Name);

                    int highestNumber = 0;

                    foreach (var name in matchingNames)
                    {
                        string numberString = name.Substring(res.Name.Length);

                        int number;
                        if (int.TryParse(numberString, out number))
                        {
                            highestNumber = Math.Max(highestNumber, number);
                        }
                    }

                    // Append the next number
                    res.Name += (highestNumber + 1).ToString();
                }
                if (res.Salary <= 5000)
                {
                    throw new SalaryLessThan5();

                }
                else if (res.Salary >= 100000)
                {
                    throw new SalaryLessThan1l();
                }
                context.TBLEmployees.Add(res);
                context.SaveChanges();
                return new { output = true, message = "" };
            }
            catch (SalaryLessThan5 ex)
            {
                return new { output = false, message = ex.Message };
            }
            catch (SalaryLessThan1l ex)
            {
                return new { output = false, message = ex.Message };
            }

        }

    
}
}