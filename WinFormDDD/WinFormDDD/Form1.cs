using System;
using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;
using WinFormDDD.control;
using WinFormDDD.dataset;

namespace WinFormDDD
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        #region イベント

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

        private void BtnClear_Click(object sender, EventArgs e)
        {
            dataGridView.Clear();
        }
        #endregion


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
