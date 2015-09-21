using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TddErp.Model.Models;
using System.Data.Entity;

namespace TddErp.Service.Interface
{
    public interface IEmployeeService : IEntityService<Employee>
    {
        Employee GetById(string employeeId);
    }

    public class EmployeeService : EntityService<Employee>, IEmployeeService
    {
        public EmployeeService(IContext db)
            : base(db)
        {
            this.db = db;
        }

        public Employee GetById(string employeeId)
        {
            return db.Employee.Include(x => x.User).FirstOrDefault(x => x.Id == employeeId);
        }
    }
}
