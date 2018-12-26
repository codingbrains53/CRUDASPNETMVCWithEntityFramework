using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRUDASPNETMVCWithEntityFramework.Models
{
    public class EmployeeDataLayer
    {
        MyDatabaseEntities1 MyDatabaseModel = new MyDatabaseEntities1();

        public List<clsEmpolyee> GetAllEmployees()
        {
            try
            {
                var EmpolyeeDetails = (from i in MyDatabaseModel.Empolyee1
                                       select i).ToList();
                List<clsEmpolyee> EmpList = new List<clsEmpolyee>();
                foreach (Empolyee1 emp in EmpolyeeDetails)
                {

                    EmpList.Add(

                        new clsEmpolyee
                        {

                            ID = Convert.ToInt32(emp.ID),
                            Name = emp.Name,
                            Mobile = emp.Mobile,
                            Email = emp.Email,
                            Address = emp.Address,
                            PinCode = emp.PinCode,
                            CreatedAt = emp.CreatedAt,
                        }
                        );
                }

                return EmpList;
            }
            catch(Exception ex)
            {
                return null;
            }

        }

       public   bool UpdateEmployee(clsEmpolyee objclsEmpolyee)
        {
            try
            {
                var EmpolyeeDetails = (from i in MyDatabaseModel.Empolyee1
                                       where i.ID == objclsEmpolyee.ID
                                       select i).ToList();
                foreach (Empolyee1 emp in EmpolyeeDetails)
                {
                    emp.Name = objclsEmpolyee.Name;
                    emp.Mobile = objclsEmpolyee.Mobile;
                    emp.Email = objclsEmpolyee.Email;
                    emp.Address = objclsEmpolyee.Address;
                    emp.PinCode = objclsEmpolyee.PinCode;
                }
                MyDatabaseModel.SaveChanges();
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }

        public bool DeleteEmployee(clsEmpolyee objclsEmpolyee)
        {
            try
            {
                Empolyee1 Empolyee1 = new Empolyee1();
                var EmpolyeeDetails = (from i in MyDatabaseModel.Empolyee1
                                       where i.ID == objclsEmpolyee.ID
                                       select i).ToList();
                //Empolyee1.ID = objclsEmpolyee.ID;
                //Empolyee1.Name = objclsEmpolyee.Name;
                MyDatabaseModel.Empolyee1.RemoveRange(EmpolyeeDetails);
                MyDatabaseModel.SaveChanges();
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }

        public bool SaveRecard(Empolyee1 Empolyee1)
        {
            try
            {
                MyDatabaseModel.Empolyee1.Add(Empolyee1);
                MyDatabaseModel.SaveChanges();
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }
    }
}