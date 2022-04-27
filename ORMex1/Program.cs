using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;

namespace ORMex1
{
    class Program
    {
        static void Main(string[] args)
        {

            #region Configuration
            var config = new ConfigurationBuilder()
                 .SetBasePath(Directory.GetCurrentDirectory())
                 .AddJsonFile("appsettings.json")
                 .Build();

            string connString = config.GetConnectionString("DefaultConnection");
            // writeline to check if using correct connection string was used
            Console.WriteLine(connString);
            #endregion

            IDbConnection conn = new MySqlConnection(connString);

            //create instance for dDapperDepartmentRepository class
            // use conn or name of instance used that stores MySqlConnection
            // place inside ()
            DapperDepartmentRepository repo = new DapperDepartmentRepository(conn);

            Console.WriteLine("List of current departments.");
            Console.WriteLine("Press enter to display list.");

            var depos = repo.GetAllDepartments();
            //call print method to display list
            Print(depos);
                       
           //prompte to user asking if would like to add a department
            Console.WriteLine("Would you like to add a department?");

            string userInput = Console.ReadLine();
           //do while statement to keep adding department while input = yes
           
               do
            { 
                    Console.WriteLine("Enter new department now.");
                    userInput = Console.ReadLine();
            
                    repo.InsertDepartment(userInput);
                   //display new list of departments
                   Print(repo.GetAllDepartments());

             
                Console.WriteLine("Would you like to add another department?");
   // reset userInput and repompte for input
                userInput = Console.ReadLine();
            } while (userInput.ToLower() == "yes" || userInput.ToLower() == "y");
            
            Console.WriteLine("Press any key to close program");
        
            }//end main method

        //method to print list of departments
        private static void Print(IEnumerable<Department> depos)
        {
            //Foreach to display colums of database 
            // use console.writeline ($" ")
            foreach (var depo in depos)
            {
                Console.WriteLine($"ID: {depo.DepartmentId} Name: {depo.Name}");
            }//end foreach
        }// end print method
    }//end class
}
