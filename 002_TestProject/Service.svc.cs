using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Web.Services;
using Telerik.Web.UI;

namespace _002_TestProject
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service.svc or Service.svc.cs at the Solution Explorer and start debugging.
    public class Service
    {
        [WebMethod(EnableSession = true)]
        public Dictionary<String, Object> GetResults(
            int startRowIndex, int maximumRows,
            List<GridSortExpression> sortExpression,
            List<GridFilterExpression> filterExpression)
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
