using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Odbc;
using System.Data.OleDb;
using System.Configuration;
using System.Data.SqlClient;

namespace MidPointNational
{
    public class ConnectFoxproToNet
    {


        clsLockFile clsLock = new clsLockFile();
       static  string FilePath = ConfigurationManager.AppSettings["FilePath"];
        static string INVENTOR = ConfigurationManager.AppSettings["INVENTOR"];
        static string LOCINV = ConfigurationManager.AppSettings["LOCINV"];
        static string L_INVNEW = ConfigurationManager.AppSettings["L_INVNEW"];
        static string CUSTOMER = ConfigurationManager.AppSettings["CUSTOMER"];

        public static DataTable GetDataFromFoxToNet(string FilePath, string FoxproTableName)
        {


            try
            {
               
                OdbcConnection obdcconn = new OdbcConnection();
                obdcconn.ConnectionString = "Driver={Microsoft dBase Driver (*.dbf)};SourceType=DBF;SourceDB=" + FilePath + ";Exclusive=No; NULL=NO;DELETED=NO;BACKGROUNDFETCH=NO;";
                obdcconn.Open();
                OdbcCommand oCmd = obdcconn.CreateCommand();
                oCmd.CommandText = "SELECT * FROM " + FilePath + FoxproTableName;
                DataTable dt1 = new DataTable();
                dt1.Load(oCmd.ExecuteReader());
                obdcconn.Close();
                return dt1;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

      

        public DataTable GetINVENTORYTableDetails()
        {
            return ConnectFoxproToNet.GetDataFromFoxToNet(FilePath, INVENTOR);
        }


        public  DataTable GetDataFromFoxToNetByISBN(string TableName)
        {


            try
            {
               
                string finalPath1 = FilePath + TableName;
                OdbcConnection obdcconn = new OdbcConnection();
                obdcconn.ConnectionString = "Driver={Microsoft dBase Driver (*.dbf)};SourceType=DBF;SourceDB=" + FilePath + ";Exclusive=No; NULL=NO;DELETED=NO;BACKGROUNDFETCH=NO;";
                obdcconn.Open();
                OdbcCommand oCmd1 = obdcconn.CreateCommand();
                DataTable dt1 = new DataTable();
                oCmd1.CommandText = "SELECT * FROM " + finalPath1;
                dt1.Load(oCmd1.ExecuteReader());
                obdcconn.Close();
                return dt1;
            }
            catch (Exception ex)
            {
                return null;
            }
        }



        public static DataTable GetDataFromFoxToNetByLOC(string From, string TO)
        {


            try
            {
               
                OdbcConnection obdcconn = new OdbcConnection();
                obdcconn.ConnectionString = "Driver={Microsoft dBase Driver (*.dbf)};SourceType=DBF;SourceDB=" + FilePath + ";Exclusive=No; NULL=NO;DELETED=NO;BACKGROUNDFETCH=NO;";
                obdcconn.Open();
                OdbcCommand oCmd2 = obdcconn.CreateCommand();
                DataTable dt2 = new DataTable();
                //F:\\Dbffile\\LOCINV.DBF
                oCmd2.CommandText = "SELECT* FROM "+FilePath+ LOCINV + " WHERE LOC BETWEEN '" + From + "' AND '" + TO + "' order by  LOC  asc";
                dt2.Load(oCmd2.ExecuteReader());
                obdcconn.Close();
                return dt2; 
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public static DataTable GetDataFromFoxToNetByLocation(string From, string To)
        {


            try
            {
               
                OdbcConnection obdcconn = new System.Data.Odbc.OdbcConnection();
                obdcconn.ConnectionString = "Driver={Microsoft dBase Driver (*.dbf)};SourceType=DBF;SourceDB=" + FilePath + ";Exclusive=No; NULL=NO;DELETED=NO;BACKGROUNDFETCH=NO;";
                obdcconn.Open();
                OdbcCommand oCmd = obdcconn.CreateCommand();
                oCmd.CommandText = "SELECT * FROM " + FilePath + LOCINV + " WHERE ISBN=" + From;
                DataTable dt1 = new DataTable();
                dt1.Load(oCmd.ExecuteReader());
                obdcconn.Close();
                return dt1;
            }
            catch (Exception ex)
            {
                return null;
            }
        }




        public bool UpdateQTY_BOInFoxToNetByISBNLOC(string ISBN,string LOC, object QTY_ALLO)
        {

            try
            {
                // Unlock File 
               //  clsLock.UnLockFile();
                OdbcConnection obdcconn = new OdbcConnection();
                obdcconn.ConnectionString = "Driver={Microsoft dBase Driver (*.dbf)};SourceType=DBF;SourceDB=" + FilePath + ";Exclusive=No; NULL=NO;DELETED=NO;BACKGROUNDFETCH=NO;";
                obdcconn.Open();
                OdbcCommand oCmd1 = obdcconn.CreateCommand();
                oCmd1.CommandText = "INSERT INTO "+FilePath+ L_INVNEW + " SELECT * FROM " + FilePath + LOCINV + " WHERE ISBN='" + ISBN + "' AND LOC ='" + LOC + "'";
                int c = oCmd1.ExecuteNonQuery();

                oCmd1.CommandText = "UPDATE " + FilePath + LOCINV + "  SET QTY_ALLO =" + QTY_ALLO + " WHERE ISBN='"+ ISBN + "' AND LOC ='" + LOC + "'";

                int a = oCmd1.ExecuteNonQuery();
                obdcconn.Close();
                //Lock File
               // clsLock.LockFile(FilePath + LOCINV);

                if (a > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public bool DeleteQTY_BOInFoxToNetByISBNLOC(string ISBN,string LOC)
        {

            try
            {
            
                OdbcConnection obdcconn = new OdbcConnection();
                obdcconn.ConnectionString = "Driver={Microsoft dBase Driver (*.dbf)};SourceType=DBF;SourceDB=" + FilePath + ";Exclusive=No; NULL=NO;DELETED=NO;BACKGROUNDFETCH=NO;";
                obdcconn.Open();
                OdbcCommand oCmd1 = obdcconn.CreateCommand();
             
                oCmd1.CommandText = "DELETE FROM  " + FilePath + LOCINV + "  WHERE ISBN='" + ISBN + "' AND LOC ='" + LOC + "'";

                int a = oCmd1.ExecuteNonQuery();
                obdcconn.Close();
                if (a > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public bool SaveNewRecardInLOCINVByISBN(string ISBN,string Title, object LOC, object BOH, object OBOH, object QTY_ALLO)
        {

            try
            {
                
                OdbcConnection obdcconn = new OdbcConnection();
                obdcconn.ConnectionString = "Driver={Microsoft dBase Driver (*.dbf)};SourceType=DBF;SourceDB=" + FilePath + ";Exclusive=No; NULL=NO;DELETED=NO;BACKGROUNDFETCH=NO;";
                obdcconn.Open();
                OdbcCommand oCmd1 = obdcconn.CreateCommand();
                oCmd1.CommandText = "INSERT INTO " + FilePath + LOCINV + " (ISBN,LOC,TITLE,BOH,OBOH,QTY_ALLO)  values('" + ISBN + "','" + LOC + "','" + Title + "'," + BOH + "," + OBOH + "," + QTY_ALLO + ")";

                int a = oCmd1.ExecuteNonQuery();
                obdcconn.Close();
                if (a > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }


        public void LockDataBase()
        {

          
            OdbcConnection obdcconn = new OdbcConnection();
            obdcconn.ConnectionString = "Driver={Microsoft dBase Driver (*.dbf)};SourceType=DBF;SourceDB=" + FilePath + ";Exclusive=No; NULL=NO;DELETED=NO;BACKGROUNDFETCH=NO;";

            obdcconn.Open();
            OdbcTransaction transaction = obdcconn.BeginTransaction(IsolationLevel.Serializable);

            try
            {
                ///...
                transaction.Commit();
            }
            catch (Exception)
            {
                transaction.Rollback();
                // ...
            }

            
        }



        public static void ExecuteTransaction(string connectionString)
        {
            using (OdbcConnection connection =
                       new OdbcConnection(connectionString))
            {
                OdbcCommand command = new OdbcCommand();
                OdbcTransaction transaction = null;

                // Set the Connection to the new OdbcConnection.
                command.Connection = connection;

                // Open the connection and execute the transaction.
                try
                {
                    connection.Open();

                    // Start a local transaction
                    transaction = connection.BeginTransaction();

                    // Assign transaction object for a pending local transaction.
                    command.Connection = connection;
                    command.Transaction = transaction;

                    // Execute the commands.
                    command.CommandText = "Insert into L_INVNEW  (LOC, ISBN) VALUES ('LOC', 'Description')";
                    command.ExecuteNonQuery();
                    command.CommandText =
                        "Insert into L_INVNEW  (LOC, ISBN) VALUES ('LOC', 'Description')";
                    command.ExecuteNonQuery();

                    // Commit the transaction.
                    transaction.Commit();
                    Console.WriteLine("Both records are written to database.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    try
                    {
                        // Attempt to roll back the transaction.
                        transaction.Rollback();
                    }
                    catch
                    {
                        // Do nothing here; transaction is not active.
                    }
                }
                // The connection is automatically closed when the
                // code exits the using block.
            }
        }



        public static DataTable GetDataFromFoxToNetByCustomerId( object CUST_NO)
        {
            try
            {
               
                OdbcConnection obdcconn = new OdbcConnection();
                obdcconn.ConnectionString = "Driver={Microsoft dBase Driver (*.dbf)};SourceType=DBF;SourceDB=" + FilePath + ";Exclusive=No; NULL=NO;DELETED=NO;BACKGROUNDFETCH=NO;";
                obdcconn.Open();
                OdbcCommand oCmd2 = obdcconn.CreateCommand();
                oCmd2.CommandText = "SELECT * FROM "+FilePath+CUSTOMER+" WHERE CUST_NO=" + CUST_NO + ""; //F:\\Dbffile\\CUSTOMER.DBF
                DataTable dt2 = new DataTable();
                dt2.Load(oCmd2.ExecuteReader());
                obdcconn.Close();
                return dt2;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}