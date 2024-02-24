using EmployeeDetails.DataAccessLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeDetails.Controllers
{
    public class EmployeeDetailsController : Controller
    {
        private readonly IEmployeeInfoRepository _employeeInfo;
        private readonly String _Configure;

        public EmployeeDetailsController(IEmployeeInfoRepository employeeInfo, IConfiguration configure)
        {
            _employeeInfo = employeeInfo;
            _Configure = configure.GetConnectionString("DbConnection");
        }

        // GET: EmployeeDetailsController
        public ActionResult Index()
        {
            try
            {
                var list = _employeeInfo.GetAllEmployee();
                return View("List", list);
            }
            catch(Exception ex)
            {
                return View("Errror");
            }
           
        }

        // GET: EmployeeDetailsController/Details/5
        public ActionResult Details(int id)
        {
            try
            {
                var all = _employeeInfo.GetByNumber(id);
                return View("Details", all);
            }
            catch(Exception ex)
            {
                return View();
            }

        }

        // GET: EmployeeDetailsController/Create
        public ActionResult Create()
        {
            var get = new EmployeeInfo();         
            return View("Create", get);
            
        }

        // POST: EmployeeDetailsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EmployeeInfo employee)
        {
            try
            {
                _employeeInfo.EmployeeInsert(employee);
                return RedirectToAction(nameof(Index));
            }
            catch(Exception ex)
            {
                return View("Error");
            }
        }

        // GET: EmployeeDetailsController/Edit/5
        public ActionResult Edit(int id)
        {
            var res = _employeeInfo.GetByNumber(id);
            return View("Edit",res);
        }

        // POST: EmployeeDetailsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, EmployeeInfo em)
        {
            try
            {
                _employeeInfo.EmployeeUpdate(id,em);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View("Error");
            }
        }

        // GET: EmployeeDetailsController/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                var delete= _employeeInfo.GetByNumber(id);
                return View("Delete", delete);
            }
            catch(Exception ex)
            {
                return View("Error");
            }
           
        }

        // POST: EmployeeDetailsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteRec(int EmployeeID)
        {
            try
            {
                _employeeInfo.EmployeeDelete(EmployeeID);
                return RedirectToAction(nameof(Index));
            }
            catch(Exception ex)
            {
                return View("Errror");
            }
        }
    }
}
