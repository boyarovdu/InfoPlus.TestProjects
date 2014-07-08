using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using Telerik.Web.UI;

namespace _002_TestProject
{
    /// <summary>
    /// Summary description for SearchService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class SearchService : System.Web.Services.WebService
    {
        [WebMethod(EnableSession = true)]
        public Dictionary<String, Object> GetResults(int startRowIndex, int maximumRows)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("ID", Type.GetType("System.Int32"));
            dt.Columns.Add("Name");
            dt.Columns.Add("Description");
            dt.Columns.Add("Location");
            dt.Columns.Add("UpdatedDate");

            for (int i = 0; i < 35; i++)
            {
                System.Data.DataRow dr = dt.NewRow();
                dr["ID"] = i;
                dr["Name"] = "Name" + i;
                dr["Description"] = "Description" + i;
                dr["Location"] = "Location" + i;
                dr["UpdatedDate"] = DateTime.Today.AddDays(i).ToShortDateString();
                dt.Rows.Add(dr);
            }

            return new Dictionary<String, Object>  
            {  
                { "Data", RowsToDictionary(dt, dt.Select(string.Format(" ID > {0} and ID < {1}", startRowIndex.ToString(), (startRowIndex + maximumRows).ToString()))) },  
                { "Count", dt.Rows.Count }  
            };
        }

        private static List<Dictionary<string, object>> RowsToDictionary(DataTable table, DataRow[] rows)
        {
            List<Dictionary<string, object>> objs =
                new List<Dictionary<string, object>>();
            foreach (DataRow dr in rows)
            {
                Dictionary<string, object> drow = new Dictionary<string, object>();
                for (int i = 0; i < table.Columns.Count; i++)
                {
                    drow.Add(table.Columns[i].ColumnName, dr[i]);
                }
                objs.Add(drow);
            }
            return objs;
        }
    }
}
