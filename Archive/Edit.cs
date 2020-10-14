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
    public partial class Edit : Form
    {
        public Edit()
        {
            InitializeComponent();

            //ヘッダーとすべてのセルの内容に合わせて、列の幅を自動調整する
            editGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            //ヘッダーとすべてのセルの内容に合わせて、行の高さを自動調整する
            editGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

        }

        private void editButton_Click(object sender, EventArgs e)
        {
            //DBに接続する処理
            //string sLogin = "server=192.168.8.102; database=books; userid=bks; password=bksbooklist;";
            string sLogin = "server=localhost; database=books; userid=root; password=Yamakyo0811@;";

            MySqlConnection cn = new MySqlConnection(sLogin);
            DataTable dt = new DataTable();

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
                    //貸出日と返却期日に日付が入っている(=貸出中 or 期限切れ)場合はすべて更新
                    if ((!string.IsNullOrEmpty((editGridView.Rows[i].Cells[3].Value).ToString())) && (!string.IsNullOrEmpty((editGridView.Rows[i].Cells[4].Value).ToString())))
                    {
                        sql = "UPDATE books.books " +
                              "SET BOOK_NAME = '" + editGridView.Rows[i].Cells[2].Value + "' , " +
                              "LOAN_DATE = '" + editGridView.Rows[i].Cells[3].Value + "' , " +
                              "RETURN_DATE = '" + editGridView.Rows[i].Cells[4].Value + "' " +
                              "WHERE BOOK_ID = '" + bookIdList[i] + "' ";
                    }
                    //貸出日と返却期日に日付が入っていない(=貸出されていない)場合は書籍名のみ更新
                    else if ((string.IsNullOrEmpty((editGridView.Rows[i].Cells[3].Value).ToString())) && (string.IsNullOrEmpty((editGridView.Rows[i].Cells[4].Value).ToString())))
                    {
                        sql = "UPDATE books.books " +
                              "SET BOOK_NAME = '" + editGridView.Rows[i].Cells[2].Value + "' " +
                              "WHERE BOOK_ID = '" + bookIdList[i] + "' ";
                    }

                    //SQL文実行
                    MySqlDataAdapter da = new MySqlDataAdapter(sql, cn);

                    try
                    {
                        cn.Open();

                        da.Fill(dt);

                        MessageBox.Show("更新完了");

                        //DBとの接続をcloseする
                        cn.Close();
                    }
                    catch (MySqlException me)
                    {
                        MessageBox.Show("ERROR: " + me.Message);
                    }
                }
                else
                {
                    MessageBox.Show("ERROR: 書名が未入力です。");
                    break;
                }
            }

        }
    }
}
