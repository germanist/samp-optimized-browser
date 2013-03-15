using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.ComponentModel;

namespace sampBrowser
{
    class GridSource
    {
        public string IP         { get; set; }
        public int      P        { get; set; }
        public string   HostName { get; set; }
        public string   Players  { get; set; }
        public int      Ping     { get; set; }
        public string   Mode     { get; set; }
        public string   Map      { get; set; }
    }
    class InfoAtRow {
        public string HostName { get; set; }
        public string   ip {get; set;}
        public int   port {get; set;}
    }
    public class ServerListManager
    {
        private DataGridView myView;
        BindingList<GridSource> listSource;
        List<InfoAtRow> infoAtRow = new List<InfoAtRow>();

        public ServerListManager(DataGridView grid)
        {
            grid.RowHeadersVisible = false;
            listSource = new BindingList<GridSource>();
            grid.DataSource = listSource;
            myView = grid;
            myView.Columns[0].Visible = false;
            // Initialize basic DataGridView properties.
            myView.Dock = DockStyle.Fill;
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
        public string[] RowToIP(int row)
        {
            string[] rString = new string[3];
            rString[0] = infoAtRow[row].ip;
            rString[1] = infoAtRow[row].port.ToString();
            rString[2] = infoAtRow[row].HostName;
            return rString;
        }
        public void Clear()
        {
            myView.DataSource = null;
            listSource.Clear();
            infoAtRow.Clear();
        }
        public void Add(string ip, int port, int password, string hostname, string players, string mode, string map, int ping ) {
            if (hostname.Count() < 1)
                return;
            myView.EndEdit();
            
            GridSource test1 = new GridSource()
            {
                IP = ip+":"+port,
                P = password,
                HostName = hostname,
                Players = players,
                Ping = ping,
                Mode = mode,
                Map = map
            };
            listSource.Add(test1);
            
            InfoAtRow infoEntry = new InfoAtRow()
            {
                HostName=hostname,
                ip=ip,
                port=port
            };
            infoAtRow.Add(infoEntry);

            myView.DataSource = listSource;
            myView.Columns[0].Visible = false;
        }
    }
}
