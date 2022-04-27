using System;
using System.Collections.Generic;
using System.Data; // add to allow database conntion
using System.Text;
using Dapper; // allows access to dapper methods

namespace ORMex1
{
    public class DapperDepartmentRepository: IDepartmentRepository
    {
        //make property readonly so file can not modified outside calss
        private readonly IDbConnection _connection;
        //Constructor
        public DapperDepartmentRepository(IDbConnection connection)
        {
            _connection = connection;
        }

        public IEnumerable<Department> GetAllDepartments()
        {
            //Using Dapper; added at top access to .Query<t>
            //() holds SQL statment of what to do
            var depos = _connection.Query<Department>("SELECT * FROM departments");

            //return values of database using depos variable
            return depos; 
        }

        public void InsertDepartment(string newDepartmentName)
        {
            //@ before departmentName will turn departmentName into a usable variable for SQL
            _connection.Execute("INSERT INTO DEPARTMENTS (Name) VALUES (@departmentName);",
            new { departmentName = newDepartmentName });
        }

    }// end public class
}
