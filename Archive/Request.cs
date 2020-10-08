using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Archive
{
    public partial class Request : Form
    {
        public Request()
        {
            InitializeComponent();

            //ヘッダーとすべてのセルの内容に合わせて、列の幅を自動調整する
            requestGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            //ヘッダーとすべてのセルの内容に合わせて、行の高さを自動調整する
            requestGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
        }


        //requestGridViewのセルがクリックされたときの処理
        private void requestGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //DateTimePickerの設定 ( Short → "yyyy/MM/dd" )
            DateTimePicker dateTimePicker = new DateTimePicker();
            dateTimePicker.Format = DateTimePickerFormat.Short;

            //カレンダーのサイズと表示位置の設定
            Rectangle oRectangle = requestGridView.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);
            dateTimePicker.Size = new Size(oRectangle.Width, oRectangle.Height);
            dateTimePicker.Location = new Point(oRectangle.X, oRectangle.Y);

            //貸出開始日のセル(3)と貸出終了日のセル(4)がクリックされたときのみ実行
            if (e.ColumnIndex == 3 || e.ColumnIndex == 4)
            {
                if(e.RowIndex >= 0)
                {
                    //一覧画面に日付入力のセルを追加する
                    requestGridView.Controls.Add(dateTimePicker);

                    //日付変更のセルが選択されたときに実行するイベント
                    //初めてセルがクリックされたときは実行されない。(初回はdateTimePickerが生成されるだけで値は変更されないため)
                    dateTimePicker.ValueChanged += new System.EventHandler(this.dateTimePicker_ValueChanged);

                    //選択した日付をセルに表示
                    requestGridView.CurrentRow.Cells[e.ColumnIndex].Value = dateTimePicker.Value.ToShortDateString();
                    //MessageBox.Show("変更後の日付 : " + requestGridView.CurrentRow.Cells[e.ColumnIndex].Value);
                }
            }
            requestGridView.Columns[1].ReadOnly = true;
            requestGridView.Columns[2].ReadOnly = true;
            requestGridView.Columns[5].ReadOnly = true;
        }

        //dataTimePickerの値が変更されたら呼出し
        //変更された値を元のセルに反映
        private void dateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            DateTimePicker dtp = (DateTimePicker)sender;
            //MessageBox.Show("senderからカレンダーの値を取得 : " + dtp.Value.ToShortDateString());

            //DateTimePickerが表示されている座標を取得し、同じ座標にあるDataGridViewのセルにカレンダーの値を設定
            DataGridView.HitTestInfo hit = requestGridView.HitTest(dtp.Location.X, dtp.Location.Y);
            if (hit.Type == DataGridViewHitTestType.Cell)
            {
                requestGridView.Rows[hit.RowIndex].Cells[hit.ColumnIndex].Value = dtp.Value.ToShortDateString();
                //MessageBox.Show("dateTimePicker_ValueChanged : " + requestGridView.Rows[hit.RowIndex].Cells[hit.ColumnIndex].Value);
            }
        }

        private void requestButton_Click(object sender, EventArgs e)
        {
            //現在日付取得
            DateTime dtn = DateTime.Now;
            string DateTimeNow = dtn.ToString("yyyy/MM/dd");

            //DBに接続する処理
            string sLogin = "server=192.168.8.102; database=books; userid=bks; password=bksbooklist;";

            MySqlConnection cn = new MySqlConnection(sLogin);
            DataTable dt = new DataTable();

            string sql = null;

            //申請する書籍のIDを一時格納
            string[] bookIdList = new string[requestGridView.Rows.Count];

            for (int i = 0; i < requestGridView.Rows.Count; i++)
            { 
                bookIdList[i] = (string)requestGridView.Rows[i].Cells[1].Value;

                //貸出開始日
                string loanDate = requestGridView.Rows[i].Cells[3].Value.ToString();
                //貸出終了日
                string returnDate = requestGridView.Rows[i].Cells[4].Value.ToString();

                //貸出開始日が今日or今日より後なら処理実行
                if ((-1 == string.Compare(DateTimeNow, loanDate)) || (0 == string.Compare(DateTimeNow, loanDate)))
                {
                    //貸出終了日が貸出開始日より前の日付になっていないか確認
                    if ((-1 == string.Compare(loanDate, returnDate)))
                    {

                        if ((!string.IsNullOrEmpty(loanDate)) && (!string.IsNullOrEmpty(returnDate)))
                        {
                            sql = "UPDATE books.books " +
                              "SET LOAN_DATE = '" + requestGridView.Rows[i].Cells[3].Value + "' , " +
                              "RETURN_DATE = '" + requestGridView.Rows[i].Cells[4].Value + "' , " +
                              "REQUEST_FLAG = '1' " +
                              "WHERE BOOK_ID = '" + bookIdList[i] + "' ";

                            //SQL文実行
                            MySqlDataAdapter da = new MySqlDataAdapter(sql, cn);

                            try
                            {
                                cn.Open();

                                da.Fill(dt);

                                //DBとの接続をcloseする
                                cn.Close();
                            }
                            catch (MySqlException me)
                            {
                                MessageBox.Show("ERROR: " + me.Message);
                            }

                            MessageBox.Show("申請完了");
                        }
                        else
                        {
                            MessageBox.Show("ERROR: 貸出開始日と貸出終了日を設定してください。");
                        }
                    }
                    else
                    {
                        MessageBox.Show("ERROR: 貸出終了日を貸出開始日より後の日付で設定してください。");
                    }
                }
                else
                {
                    MessageBox.Show("ERROR: 貸出開始日は今日以降の日付で設定してください。");
                }
            }
            
        }
    }
}
