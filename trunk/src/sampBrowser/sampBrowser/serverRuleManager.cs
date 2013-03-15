using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.ComponentModel;

namespace sampBrowser
{
    class RuleGridSource
    {
        public string Rule { get; set; }
        public string Value { get; set; }
    }
    public class serverRuleManager
    {
        private DataGridView myView;
        BindingList<RuleGridSource> listSource;
        public serverRuleManager(DataGridView grid)
        {
            grid.RowHeadersVisible = false;
            listSource = new BindingList<RuleGridSource>();
            grid.DataSource = listSource;
            myView = grid;
            // Initialize basic DataGridView properties.
            //myView.Dock = DockStyle.Fill;
            myView.BackgroundColor = Color.LightGray;
            myView.BorderStyle = BorderStyle.Fixed3D;

            // Set property values appropriate for read-only display and  
            // limited interactivity. 
            myView.AllowUserToAddRows = false;
            myView.AllowUserToDeleteRows = false;
            myView.AllowUserToOrderColumns = false;
            myView.ReadOnly = true;
            myView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            myView.MultiSelect = false;
            myView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            myView.ColumnHeadersHeightSizeMode =
                DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            myView.AllowUserToResizeRows = false;
            myView.RowHeadersWidthSizeMode =
                DataGridViewRowHeadersWidthSizeMode.DisableResizing;

            // Set the selection background color for all the cells.
            myView.DefaultCellStyle.SelectionBackColor = Color.White;
            myView.DefaultCellStyle.SelectionForeColor = Color.Black;

            // Set RowHeadersDefaultCellStyle.SelectionBackColor so that its default 
            // value won't override DataGridView.DefaultCellStyle.SelectionBackColor.
            myView.RowHeadersDefaultCellStyle.SelectionBackColor = Color.Empty;

            // Set the background color for all rows and for alternating rows.  
            // The value for alternating rows overrides the value for all rows. 
            myView.RowsDefaultCellStyle.BackColor = Color.LightGray;
            myView.AlternatingRowsDefaultCellStyle.BackColor = Color.DarkGray;

            // Set the row and column header styles.
            myView.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            myView.ColumnHeadersDefaultCellStyle.BackColor = Color.Black;
            myView.RowHeadersDefaultCellStyle.BackColor = Color.Black;

            //Add();
        }
        public void Clear()
        {
            listSource.Clear();
        }
        public void Add(string _rule, string value)
        {
            myView.EndEdit();

            RuleGridSource rule = new RuleGridSource()
            {
                Rule = _rule,
                Value = value,
            };
            listSource.Add(rule);


            myView.DataSource = listSource;
        }
    }
}
