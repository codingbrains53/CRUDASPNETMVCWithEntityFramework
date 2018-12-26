using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MidPointNational
{
    /// <summary>
    /// This Class contains session data details.
    /// </summary>
    public class SessionList
    {
        /// <summary>
        /// Session for logged user.
        /// </summary>
        public static string LoggedUser
        {
            get
            {
                return (string)HttpContext.Current.Session["LoggedUser"];
            }
            set
            {
                HttpContext.Current.Session["LoggedUser"] = value;
            }
        }
    }

}