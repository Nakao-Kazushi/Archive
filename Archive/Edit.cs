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
using System.Text.RegularExpressions;

namespace Archive
{
    public partial class Edit : Form
    {
        public Edit()
        {
            InitializeComponent();
        }

        private void editButton_Click(object sender, EventArgs e)
        {
            //ダイアログ表示
            DialogResult result = MessageBox.Show("更新しますか？", "", MessageBoxButtons.OKCancel);

            //「いいえ」を選んだ場合は処理を行わない
            if (result == DialogResult.Cancel) return;

            //DBに接続する処理
            //string sLogin = "server=192.168.8.102; database=books; userid=bks; password=bksbooklist;";
            string sLogin = "server=localhost; database=books; userid=root; password=Yamakyo0811@;";

            MySqlConnection cn = new MySqlConnection(sLogin);
            DataTable dt = new DataTable();

            //1つでも☑があるかの確認
            bool Checked = false;

            //行のカウント
            for (int i = 0; i < editGridView.Rows.Count; i++)
            {
                Object checkBox = ((DataGridViewCheckBoxCell)((DataGridViewRow)editGridView.Rows[i]).Cells[0]).Value;

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
            string[] bookIdList = new string[editGridView.Rows.Count];

            string bookname = "";

            for (int i = 0; i < editGridView.Rows.Count; i++)
            {
                bookIdList[i] = (string)editGridView.Rows[i].Cells[1].Value;
                bookname = (string)editGridView.Rows[i].Cells[2].Value;

                //書名が入力されている場合は処理開始
                if (!string.IsNullOrEmpty(bookname))
                {
                    bool halfWidthSymbol = (Regex.IsMatch(bookname, @"[!-"":-@[$-/:-@[-`{-~ ]"));

                    //入力された値に特別な記号が入ってないかどうかチェックする。
                    if (halfWidthSymbol == true)
                    {
                        MessageBox.Show("ERROR: 書籍名に半角記号が入力されています。書籍名は全角で入力してください。" );
                        return;
                    }

                    //貸出日と返却期日に日付が入っていない(=貸出されていない)場合、書籍名のみ更新
                    if ((string.IsNullOrEmpty((editGridView.Rows[i].Cells[3].Value).ToString())) && (string.IsNullOrEmpty((editGridView.Rows[i].Cells[4].Value).ToString())))
                    {
                        sql = "START TRANSACTION; " +
                              "UPDATE books.books " +
                              "SET BOOK_NAME = '" + editGridView.Rows[i].Cells[2].Value + "' " +
                              "WHERE BOOK_ID = '" + bookIdList[i] + "' " +
                              "; COMMIT;";
                    }

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
                    //編集画面を閉じる
                    this.Close();
                }
                else
                {
                    MessageBox.Show("ERROR: 書名が未入力です。");
                    return;
                }
            }
            MessageBox.Show("更新完了 ");
        }

        private void returnButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
