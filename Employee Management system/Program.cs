using System;
using System.Collections.Generic;
namespace EmployeeManagementSystem
{

    //Abstract class
    public abstract class Employee
    {
        public int EmployeeId { get; set; }   // property
        public string FullName { get; set; }
        

        public  abstract decimal CalculateSalary();  //abstract method

    }
    public class FullTimeEmployee : Employee   // inherit the abstract class
    {
        public decimal MonthlySalary { get; set; }  // property
        public FullTimeEmployee(int Id , string Name , decimal salary)   // constructor
        {
            EmployeeId = Id;
            FullName = Name;
            MonthlySalary = salary;
        }
        public override decimal CalculateSalary()     // override the abstract method
        {
            return MonthlySalary;
        }

    }

    public class PartTimeEmployee : Employee       // inherit again parttimeemployee
    {
        public int HourlyRate { get; set; }    // property
        public int WorkedHour { get; set; }

        public PartTimeEmployee(int Id , string Name ,int hourrate , int workedhour)   // constructor
        {
            EmployeeId = Id;
            FullName = Name;
            HourlyRate = hourrate;
            WorkedHour = workedhour;
        }
        public override decimal CalculateSalary()     // override the abstract method
        {
            return HourlyRate * WorkedHour;
        }
    }
    interface IManager             // introduce interface 
    {
        // body less by default public methods
        void AssignTask(Employee employee, string task);   
        void AllowLeave(Employee employee, int leavedays);
        List<Employee> Getemployeelist();  
    }

        class FullTimeManager : FullTimeEmployee, IManager     // Implementation of interface
        {
           
            List<Employee> managedempployeeList = new List<Employee>();      // object of List<Employee>
            public FullTimeManager(int Id, string Name, decimal salary) : base(Id,Name,salary){ }  // Constructor for FullTimeManager
        public void AssignTask(Employee employee, string task)        // implement of assigntask method
            {
                Console.WriteLine($"{FullName} assign {task} task to {employee.FullName}");
            }
            public void AllowLeave(Employee employee, int leavedays)   // implement of allowleave method
            {
                Console.WriteLine($"{FullName} allow {leavedays} days leave to {employee.FullName}");
            }
            public  List<Employee> Getemployeelist()    // implement of list with return
            {
            return managedempployeeList;
            }
            public void AddManagedEmployee(Employee employee)   // create the method to add employee in the list
            {
                managedempployeeList.Add(employee);
            }
           

    }

    class Program
    {
        public static void Main(string[] args)
        {
            // create objects and pass the parameter
            FullTimeManager manager = new FullTimeManager(200,"john lee",60000);    
            FullTimeEmployee fulltimeemp = new FullTimeEmployee(1001,"Bop george",3000);
            PartTimeEmployee parttimeemp = new PartTimeEmployee(3002, "Nat phillip",200,6);

            Console.WriteLine($"Manager name: {manager.FullName}");
            Console.WriteLine($"Monthly Salary : ${manager.CalculateSalary()}");

            Console.WriteLine("Employee Managed");
            manager.AddManagedEmployee(fulltimeemp);    // call the Add managed employee method and pass the parameter
            manager.AddManagedEmployee(parttimeemp);
            
            // loop for check and print all the list as per requirement
            foreach(var employee  in manager.Getemployeelist())
            {
                Console.WriteLine($"{employee.FullName}, Salary: ${employee.CalculateSalary()}");
            }

            //Parater pass for assigntask and allowleave
            manager.AssignTask(fulltimeemp,"Create SDLC of Techworld software");
            manager.AllowLeave(parttimeemp, 3);

        }
    }
    

}