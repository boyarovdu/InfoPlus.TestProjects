using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

namespace _001_TestProject
{
    public partial class Default : System.Web.UI.Page
    {
        public Default() { }

        protected void Page_Load(object sender, EventArgs e)
        {
            CommonGrid.MasterTableView.AutoGenerateColumns = false;
            CommonGrid.MasterTableView.Columns.Clear();
            CommonGrid.MasterTableView.Columns.Add(new GridBoundColumn { DataType = typeof(string), DataField = "Name", HeaderText = "Name" });
            CommonGrid.MasterTableView.Columns.Add(new GridBoundColumn { DataType = typeof(string), DataField = "Address", HeaderText = "Address" });

            CommonGrid.ClientSettings.DataBinding.Location = @"~\Service.svc";
        }
    }
}