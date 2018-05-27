using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using WinFormDDD.dataset;

namespace WinFormDDD.control
{
    /// <summary>
    /// 書籍マスタ表示用のDataGridViewコントロール
    /// </summary>
    public partial class BookMasterGridView : UserControl
    {
        BindingSource binding = new BindingSource();
        ViewDataSet.ViewDataTableDataTable dataSource = new ViewDataSet.ViewDataTableDataTable();

        public enum Column
        {
            BOOK_ID,
            BOOK_NAME,
            USER_ID,
            ARRIVAL_DATE,
            DIV1,
            DIV2,
            DIV3,
            MODIFY_FLAG,
        }

        public BookMasterGridView()
        {
            InitializeComponent();
        }

        #region 公開メソッド

        /// <summary>
        /// データソースを設定します
        /// </summary>
        /// <param name="source"></param>
        public void SetDataSource(DbDataSet.BOOK_MASTERDataTable source)
        {
            dataSource = Mapping(source);
            binding.DataSource = dataSource;
            binding.DataMember = string.Empty;

            dataGridView1.DataSource = binding;

            binding.ResetBindings(false);
        }

        /// <summary>
        /// カラムの非表示を設定します
        /// </summary>
        /// <param name="column"></param>
        /// <param name="enable"></param>
        public void EnableColumnVisible(BookMasterGridView.Column column, bool enable)
        {
            dataGridView1.Columns[(int)column].Visible = enable;
        }

        public void Clear()
        {
            dataSource.Clear();
        }

        /// <summary>
        /// 書籍名がブランクであるか
        /// </summary>
        /// <returns></returns>
        public bool IsBookNameBlank()
        {
            var indexSource = dataSource.Select((data, index) => new { data, index });
            return indexSource.Any(x => x.data.IsBOOK_NAMENull() || string.IsNullOrEmpty(x.data.BOOK_NAME));
        }

        // スプレッドシートもラップするなら、これをpublicでやる必要はなくて、
        // 最終的にフォーカス合わせた後に、結果メッセージだけ返してあげれば良い気がする。
        // Messageがnullであれば、何も表示しなくてOKということで。
        // ただ、Messageの取得方法については、BaseFormで用意されているメッセージ取得メソッドを
        // 使わなければならないようだから、true,falseで返すのが手っ取り早い気がしている。

        public int RowIndexBookNameBlank()
        {
            var indexSource = dataSource.Select((data, index) => new { data, index });
            return indexSource.Where(x => x.data.IsBOOK_NAMENull() || string.IsNullOrEmpty(x.data.BOOK_NAME)).Select(x => x.index).First();
        }

        public void SetCellFocus(int row, int column)
        {
            dataGridView1.CurrentCell = dataGridView1.Rows[row].Cells[column];
        }

        #endregion

        
        private ViewDataSet.ViewDataTableDataTable Mapping(DbDataSet.BOOK_MASTERDataTable source)
        {
            ViewDataSet viewSource = new ViewDataSet();
            var viewTable = viewSource.ViewDataTable;

            foreach (var row in source)
            {
                var viewRow = viewTable.NewViewDataTableRow();

                viewRow.BOOK_ID         = row.BOOK_ID;
                viewRow.BOOK_NAME       = row.BOOK_NAME;
                viewRow.ARRIVAL_USER_ID = row.ARRIVAL_USER_ID;
                viewRow.ARRIVAL_DATE    = row.ARRIVAL_DATE;
                viewRow.DIVISION_ID1    = row.DIVISION_ID1;
                viewRow.DIVISION_ID2    = row.DIVISION_ID2;
                viewRow.DIVISION_ID3    = row.DIVISION_ID3;
                viewRow.MODIFY_FLAG     = "0";
                viewTable.AddViewDataTableRow(viewRow);
            }
            return viewTable;
        }


        /// <summary>
        /// ユーザコントロールがリサイズされたら
        /// 内部のDataGridViewもリサイズする
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UserControl1_Resize(object sender, EventArgs e)
        {
            dataGridView1.Height = this.Height;
            dataGridView1.Width = this.Width;
        }

        

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex+2 == dataGridView1.RowCount)
                dataGridView1.Rows[e.RowIndex].Cells[(int)Column.MODIFY_FLAG].Value = "1";
        }
    }
}
