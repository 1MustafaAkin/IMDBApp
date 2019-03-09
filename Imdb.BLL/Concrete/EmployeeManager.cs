using Imdb.BLL.Abstract;
using Imdb.BLL.Utilities;
using Imdb.BLL.ValidationRules;
using Imdb.DAL.Abstract;
using Imdb.DATA.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imdb.BLL.Concrete
{
    public class EmployeeManager : IEmployeeService
    {

        private IEmployeeDal _employeeDal;

        public EmployeeManager(IEmployeeDal employeeDal)
        {
            _employeeDal = employeeDal;
        }

        public void Add(Employee employee)
        {
            ValidationTool.Validate(new EmployeeValidator(), employee);
            _employeeDal.Add(employee);
        }

        public void Delete(Employee employee)
        {
            try
            {
                _employeeDal.Delete(employee);
            }
            catch
            {
                throw new Exception("Silme Gerçekleşemedi");
            }
            
        }

        public List<Employee> GetAll()
        {
            return _employeeDal.GetAll();
        }

        public Employee GetEmployeeById(int? id)
        {
            return _employeeDal.Get(x => x.EmployeeID == id);
        }

        public void Update(Employee employee)
        {
            ValidationTool.Validate(new EmployeeValidator(), employee);
            _employeeDal.Update(employee);
        }

        public IEnumerable<Employee> GetAllWithInclude(params string[] include)
        {
            return _employeeDal.GetAllWithInclude(null, include);
        }

        public Employee GetAllWithIncludeById(int? id,params string[] include)
        {
            return _employeeDal.GetAllWithInclude(x => x.EmployeeID == id, include).FirstOrDefault();
        }
    }
}
