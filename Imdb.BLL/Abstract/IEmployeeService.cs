using Imdb.DATA.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imdb.BLL.Abstract
{
    public interface IEmployeeService
    {
        List<Employee> GetAll();
        //TODO
        //List<Employee> GetEmployeesByMovie(string movieName);
        Employee GetEmployeeById(int? id);
        void Add(Employee employee);
        void Update(Employee employee);
        void Delete(Employee employee);
        IEnumerable<Employee> GetAllWithInclude(params string[] include);
        Employee GetAllWithIncludeById(int? id,params string[] include);

    }
}
