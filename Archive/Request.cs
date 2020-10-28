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
        //ユーザーID
        private string userId;

        public Request()
        {
            InitializeComponent();

            //user_idテキストボックスを非表示
            this.user_id.Visible = false;

            //ヘッダーとすべてのセルの内容に合わせて、行の高さを自動調整する
            requestGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
        }

        //requestGridViewのセルがクリックされたときの処理
        private void requestGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //DateTimePickerの設定 ( Short → "yyyy/MM/dd" )
            DateTimePicker dateTimePicker = new DateTimePicker();
            dateTimePicker.Format = DateTimePickerFormat.Short;

            requestGridView.Columns[1].ReadOnly = true;
            requestGridView.Columns[2].ReadOnly = true;
            requestGridView.Columns[5].ReadOnly = true;

            //カレンダーのサイズと表示位置の設定
            Rectangle oRectangle = requestGridView.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);
            dateTimePicker.Size = new Size(oRectangle.Width, oRectangle.Height);
            dateTimePicker.Location = new Point(oRectangle.X, oRectangle.Y);

            //画面サイズを変更可能にする
            this.FormBorderStyle = FormBorderStyle.Sizable;

            //貸出日のセル(3)と返却期日のセル(4)がクリックされたときのみ実行
            if (e.ColumnIndex == 3 || e.ColumnIndex == 4)
            {
                //画面サイズを変更できないようにする
                this.FormBorderStyle = FormBorderStyle.FixedToolWindow;

                if (e.RowIndex >= 0)
                {
                    //一覧画面に日付入力のセルを追加する
                    requestGridView.Controls.Add(dateTimePicker);

                    //日付変更のセルが選択されたときに実行するイベント
                    //初めてセルがクリックされたときは実行されない。(初回はdateTimePickerが生成されるだけで値は変更されないため)
                    dateTimePicker.ValueChanged += new System.EventHandler(this.dateTimePicker_ValueChanged);

                    //選択した日付をセルに表示
                    requestGridView.CurrentRow.Cells[e.ColumnIndex].Value = dateTimePicker.Value.ToShortDateString();
                }
            }
            
            dateTimePicker.CloseUp += new System.EventHandler(this.dateTimePicker_CloseUp);
        }

        //dataTimePickerの値が変更されたら呼出し
        //変更された値を元のセルに反映
        private void dateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            DateTimePicker dtp = (DateTimePicker)sender;

            //DateTimePickerが表示されている座標を取得し、同じ座標にあるDataGridViewのセルにカレンダーの値を設定
            DataGridView.HitTestInfo hit = requestGridView.HitTest(dtp.Location.X, dtp.Location.Y);

            if (hit.Type == DataGridViewHitTestType.Cell)
            {
                requestGridView.Rows[hit.RowIndex].Cells[hit.ColumnIndex].Value = dtp.Value.ToShortDateString();
            }
        }

        //申請ボタン押下
        private void requestButton_Click(object sender, EventArgs e)
        {
            //ダイアログ表示
            DialogResult result = MessageBox.Show("申請しますか？", "", MessageBoxButtons.OKCancel);

            //「いいえ」を選んだ場合は処理を行わない
            if (result == DialogResult.Cancel)
            {
                return;
            }

            //現在日付取得
            DateTime dtn = DateTime.Now;
            string DateTimeNow = dtn.ToString("yyyy/MM/dd");

            //DBに接続する処理
            //string sLogin = "server=192.168.8.102; database=books; userid=bks; password=bksbooklist;";
            string sLogin = "server=localhost; database=books; userid=root; password=Yamakyo0811@;";

            MySqlConnection cn = new MySqlConnection(sLogin);
            DataTable dt = new DataTable();

            //1つでも☑があるかの確認
            bool Checked = false;

            //行のカウント
            for (int i = 0; i < requestGridView.Rows.Count; i++)
            {
                Object checkBox = ((DataGridViewCheckBoxCell)((DataGridViewRow)requestGridView.Rows[i]).Cells[0]).Value;

                if ((checkBox != null) && ((bool)checkBox == true))
                {
                    Checked = true;
                }
            }

            //1つも☑がなかった場合
            if (!Checked)
            {
                MessageBox.Show("ERROR: １つ以上選択してください。");
                return;
            }

            string sql = null;

            //申請する書籍のIDを一時格納
            string[] bookIdList = new string[requestGridView.Rows.Count];

            for (int i = 0; i < requestGridView.Rows.Count; i++)
            { 
                bookIdList[i] = (string)requestGridView.Rows[i].Cells[1].Value;

                //貸出日
                string loanDate = requestGridView.Rows[i].Cells[3].Value.ToString();
                //返却期日
                string returnDate = requestGridView.Rows[i].Cells[4].Value.ToString();

                //貸出日・返却期日の両方がnullもしくは空ではないなら処理を行う
                if ((!string.IsNullOrEmpty(loanDate)) && (!string.IsNullOrEmpty(returnDate)))
                {
                    //返却期日が貸出日より過去の日付になっていないか確認
                    if ((-1 == string.Compare(loanDate, returnDate)))
                    {
                        //貸出日が今日or今日より未来の日付なら処理を行う
                        if ((-1 == string.Compare(DateTimeNow, loanDate)) || (0 == string.Compare(DateTimeNow, loanDate)))
                        {
                            sql = "START TRANSACTION; " +
                                "UPDATE books.books " +
                              "SET LOAN_DATE = '" + requestGridView.Rows[i].Cells[3].Value + "' , " +
                              "RETURN_DATE = '" + requestGridView.Rows[i].Cells[4].Value + "' , " +
                              "REQUEST_FLAG = '1' , " +
                              "USER_ID = '" + userId + "' " +
                              "WHERE BOOK_ID = '" + bookIdList[i] + "' " +
                               "; COMMIT;";

                            //SQL文実行
                            MySqlDataAdapter da = new MySqlDataAdapter(sql, cn);

                            try
                            {
                                cn.Open();

                                da.Fill(dt);
                            }
                            catch (MySqlException me)
                            {
                                MessageBox.Show("ERROR: " + me.Message);
                            }
                            finally
                            {
                                //DBとの接続をcloseする
                                cn.Close();
                            }
                            //申請画面を閉じる
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("ERROR: 貸出日は今日以降の日付で設定してください。");
                            return;
                        }
                    }
                    else
                    {
                        MessageBox.Show("ERROR: 返却期日を貸出日以降の日付で設定してください。");
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("ERROR: 貸出日と返却期日を設定してください。");
                    return;
                }
            }
            
        }

        private void returnButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //Search.csから渡されたuserIdがテキストボックスに反映された時
        private void user_id_Changed(object sender, EventArgs e)
        {
            userId = this.user_id.Text;
        }

        private void dateTimePicker_CloseUp(object sender, EventArgs e)
        {
            DateTimePicker dtp = (DateTimePicker)sender;

            // datatimepickerを非表示にする
            dtp.Visible = false;

            // 画面サイズを変更可能にする
            this.FormBorderStyle = FormBorderStyle.Sizable;
        }
    }
}
