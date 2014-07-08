using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

namespace _002_TestProject
{
    public partial class Default : System.Web.UI.Page
    {
        RadGrid grid;
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            grid = new RadGrid();
            SetGridProperties();
            FillColumns();
            phGrid.Controls.Add(grid);
        }

        private void SetGridProperties()
        {
            //grid.AllowFilteringByColumn = false;
            //grid.MasterTableView.AutoGenerateColumns = false;
            grid.AllowPaging = true;
            //grid.AllowSorting = true;
            //grid.GridLines = GridLines.Both;
            //grid.PagerStyle.Mode = GridPagerMode.NextPrevAndNumeric;
            grid.ClientSettings.DataBinding.SelectMethod = "GetResults";
            grid.ClientSettings.DataBinding.Location = "~/SearchService.asmx";
        }
        
        [Serializable]
        public class Field
        {
            public String ColumnName { get; set; }
            public String DisplayName { get; set; }
            public Type DataType { get; set; }
        }

        private void FillColumns()
        {
            List<Field> fields = new List<Field>  
            {  
                new Field { DisplayName = "ID", ColumnName = "ID", DataType = typeof(Int32)},  
                new Field { DisplayName = "Name", ColumnName = "Name", DataType = typeof(string) },  
                new Field { DisplayName = "Description", ColumnName = "Description", DataType = typeof(string) },  
                new Field { DisplayName = "Location", ColumnName = "Location",  DataType = typeof(string) },  
                new Field { DisplayName = "UpdatedDate", ColumnName = "UpdatedDate", DataType = typeof(DateTime) },  
            };

            grid.MasterTableView.Columns.Clear();

            foreach (var field in fields)
            {
                GridBoundColumn col = GetGridColumn(field.DataType);
                grid.MasterTableView.Columns.Add(col);
                col.DataField = field.ColumnName;
                col.HeaderText = field.DisplayName;
            }
        }
        public static GridBoundColumn GetGridColumn(Type type)
        {
            switch (Type.GetTypeCode(type))
            {
                case TypeCode.Int32:
                    {
                        GridNumericColumn col = new GridNumericColumn { DataType = type };
                        col.ItemStyle.HorizontalAlign = HorizontalAlign.Right;
                        return col;
                    }
                case TypeCode.DateTime:
                    {
                        GridDateTimeColumn col = new GridDateTimeColumn { DataType = type, DataFormatString = "{0:" + DateTimeFormatInfo.CurrentInfo.ShortDatePattern + "}" };
                        col.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
                        return col;
                    }
                default:
                    return new GridBoundColumn { DataType = type };
            };
        } 
    }
}