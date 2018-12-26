using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;

namespace MidPointNational
{
    public class clsLockFile
    {

      static  FileStream fs = null;
     
       
        public void LockFile(string FilePath)
        {
           
            fs = new FileStream(FilePath, FileMode.Open, FileAccess.ReadWrite, FileShare.None);

            // FileStream s2 = new FileStream(FilePath, FileMode.Open, FileAccess.Read, FileShare.None);
           //fs = new FileStream(@"F:\Dbffile\INVENTOR.DBF", FileMode.Open, FileAccess.ReadWrite, FileShare.None);
           // fs.Close();
        }

        public void UnLockFile()
        {
            fs.Close();
        }
    }
}