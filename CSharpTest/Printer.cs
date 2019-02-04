using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CSharpTest
{
    public class Printer
    {
        #region Propertiers
        public int Id { get; set; }
        public string Name { get; set; }
        public string SerialKey { get; set; }
        public DateTime ExpireDate { get; set; }
        public Customer Customer { get; set; }
        #endregion

        #region Methods
        public List<Printer> GetPrinters()
        {
            try
            {
                List<Printer> printers = new List<Printer>();
                using (var client = new WebClient())
                {
                    client.Headers.Add("Content-Type:application/json");
                    client.Headers.Add("Accept:application/json");
                    var result = client.DownloadString(ConfigurationManager.AppSettings["API"] + "/printers");
                    printers = JsonConvert.DeserializeObject<List<Printer>>(result);
                }

                return printers;
            }
            catch(Exception ex)
            {
                throw new Exception("Could not retrieve list of Printers, please get in contact with Support IT");
            }
        }

        public void Save()
        {
            SqlConnection oCon = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
            try
            {
                oCon.Open();

                string strSQL = ""
                    + "INSERT INTO Printers "
                    + "( "
                    + " PrinterName, "
                    + " SerialKey, "
                    + " ExpireDate, "
                    + " CustomerName "
                    + ") "
                    + " VALUES "
                    + "( "
                    + " @PrinterName, "
                    + " @SerialKey, "
                    + " @ExpireDate, "
                    + " @CustomerName "
                    + "); ";

                SqlCommand oCmd = new SqlCommand(strSQL, oCon);
                oCmd.Parameters.AddWithValue("@PrinterName", this.Name);
                oCmd.Parameters.AddWithValue("@SerialKey", this.SerialKey);
                oCmd.Parameters.AddWithValue("@ExpireDate", this.ExpireDate.Date);
                oCmd.Parameters.AddWithValue("@CustomerName", this.Customer.Name);

                oCmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Could not save Printer, please get in contact with Support IT");
            }
            finally
            {
                oCon.Close();
                oCon.Dispose();
            }
        }
        #endregion
    }
}
