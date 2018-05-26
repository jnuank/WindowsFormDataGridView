using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;
using WinFormDDD.dataset;
using WinFormDDD.control;

namespace WinFormDDD
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            var datatable = SelectBookMaster();

            dataGridView.SetDataSource(datatable);
            dataGridView.EnableColumnVisible(BookMasterGridView.Column.MODIFY_FLAG, false);
        }
        private void BtnRequired_Click(object sender, EventArgs e)
        {
            bool isBlank = dataGridView.IsBookNameBlank();

            if (isBlank)
            {
                int rowIndex = dataGridView.RowIndexBookNameBlank();
                MessageBox.Show($"空白です{rowIndex}");
                dataGridView.SetCellFocus(0, 0);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            dataGridView.Clear();
        }

        private DbDataSet.BOOK_MASTERDataTable SelectBookMaster()
        {
            string path = @"../../../Library.db";
            using(SQLiteConnection conn = new SQLiteConnection("Data Source=" + path))
            {
                DbDataSet.BOOK_MASTERDataTable table = new DbDataSet.BOOK_MASTERDataTable();
                try
                {
                    SQLiteCommand cmd = new SQLiteCommand();
                    cmd.CommandText = "SELECT * FROM BOOK_MASTER";
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = conn;

                    SQLiteDataAdapter adapter = new SQLiteDataAdapter(cmd);

                    adapter.Fill(table);
                    
                }
                catch(SQLiteException ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    conn.Close();
                }
                return table;
            }
        }

        
    }
}
