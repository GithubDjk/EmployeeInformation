using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeInformation.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeInformation.Controllers
{
    public class EmployeeeDataController : Controller
    {

        /*private readonly DataContext EmployeeDb = new DataContext();
        *//*public EmployeeeDataController(DataContext EmployeeDb)
        {
            _EmployeeDb = EmployeeDb;
        }*/
        
        private DataContext db;

        public EmployeeeDataController(DataContext _db)
        {
            db = _db;
        }

        [HttpGet]
        public async Task<IActionResult> EmployeeLists()
        {
                try {

                    /*               List<EmployeeeData> EmployeesList = db.Employeees.ToList();*/
                
                        var EmployeesList = db.Employeees;
                        return View(EmployeesList); 
                 }
                catch
                {
                
                    return View();
                }
        
       }


        public IActionResult AddEmployee(EmployeeeData Employee)
        {
            this.db.Employeees.Add(Employee);
            try
            {
                if (ModelState.IsValid)
                {
                    this.db.SaveChanges();
                    return RedirectToAction("EmployeeLists");
                }
                else
                {
                    return View();
                }
            }

            //Fetch the CustomerId returned via SCOPE IDENTITY.
            /*int id = Employee.CustomerId;*/

            catch
            {
                return View();
            }
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var employee = this.db.Employeees.Where(emp => emp.EmployeeId == id).FirstOrDefault();
            return View(employee);    
        }

        [HttpPost]
        public IActionResult Edit(EmployeeeData Employee)
        {
            if (ModelState.IsValid)
            {
                var employee = this.db.Employeees.Where(emp => emp.EmployeeId == Employee.EmployeeId).FirstOrDefault();
                this.db.Employeees.Remove(employee);
                this.db.Employeees.Add(Employee);
                this.db.SaveChanges();

                return RedirectToAction("EmployeeLists");
            }
            else
            {
                return View(Employee);
            }
        }

        public IActionResult Details(int id)
        {

            var employee = db.Employeees.Find(id);
            return View(employee);
        }

        public IActionResult Delete(int id)
        {

            var employee = db.Employeees.Find(id);
            this.db.Employeees.Remove(employee);
            db.SaveChanges();
            return RedirectToAction("EmployeeLists");
        }
    }
}
