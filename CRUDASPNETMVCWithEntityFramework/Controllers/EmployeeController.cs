using CRUDASPNETMVCWithEntityFramework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRUDASPNETMVCWithEntityFramework.Controllers
{
    public class EmployeeController : Controller
    {
        EmployeeDataLayer EmployeeDataLayerObj = new EmployeeDataLayer();
        // GET: Employee
        public ActionResult Index()
        {
            
            return View(EmployeeDataLayerObj.GetAllEmployees());
        }

        // GET: Employee/Details/5
        public ActionResult Details(int id)
        {

            return View(EmployeeDataLayerObj.GetAllEmployees().Where(x=>x.ID==id).SingleOrDefault());
        }

        // GET: Employee/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Employee/Create
        [HttpPost]
        public ActionResult Create(clsEmpolyee obj, FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                Empolyee1 empolyee1 = new Empolyee1();
                empolyee1.Name = obj.Name;
                empolyee1.Email = obj.Email;
                empolyee1.Mobile = obj.Mobile;
                empolyee1.Address = obj.Address;
                empolyee1.PinCode= obj.PinCode;
                empolyee1.CreatedAt = DateTime.Now;
                bool i = EmployeeDataLayerObj.SaveRecard(empolyee1);
                if (i==true)
                {
                    // return RedirectToAction("Index");
                    ViewBag.Msg = "Data Saved Suuceessfully.";
                    ModelState.Clear();
                }
                  
                else
                    //return RedirectToAction("Index");
                 ViewBag.Msg = "Unable to  Save Recard.";
                return View();
            }
            catch(Exception ex)
            {
              
               /// return RedirectToAction("Index");
                return View();
            }
        }

        // GET: Employee/Edit/5
        public ActionResult Edit(int id)
        {
            return View(EmployeeDataLayerObj.GetAllEmployees().Where(x => x.ID == id).SingleOrDefault());
           
        }

        // POST: Employee/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, clsEmpolyee objemp)
        {
            try
            {
                // TODO: Add update logic here
                EmployeeDataLayerObj.UpdateEmployee(objemp);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Employee/Delete/5
        public ActionResult Delete(int id)
        {
            return View(EmployeeDataLayerObj.GetAllEmployees().Where(x => x.ID == id).SingleOrDefault());
        }

        // POST: Employee/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, clsEmpolyee obj)
        {
            try
            {
                // TODO: Add delete logic here
                EmployeeDataLayerObj.DeleteEmployee(obj);
                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                return View();
            }
        }
    }
}
