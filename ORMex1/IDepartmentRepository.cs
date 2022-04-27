using System;
using System.Collections.Generic;
using System.Text;

namespace ORMex1
{
    public interface IDepartmentRepository
    {
                IEnumerable<Department> GetAllDepartments();

        void InsertDepartment(string newDepartmentName);
    }
}
