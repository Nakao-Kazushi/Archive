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
    public partial class Approval : Form
    {
        //コンストラクタ
        //実行時に申請があった書籍(REQUEST_FLAG = 1)のデータを表示させる
        public Approval()
        {
            InitializeComponent();

            //DBに接続する処理
            string sLogin = "server=localhost; database = books; userid=root; password=Oneok0927;";

            MySqlConnection cn = new MySqlConnection(sLogin);

            //現在日付取得
            DateTime dtn = DateTime.Now;
            string DateTimeNow = dtn.ToString("yyyy/MM/dd");

            //SQL文作成
            string sql = "SELECT BOOK_ID ,BOOK_NAME ,LOAN_DATE ,RETURN_DATE ," +
                         "CASE WHEN REQUEST_FLAG = 1 THEN '申請中' " +
                         "WHEN RETURN_DATE < '" + DateTimeNow + "' THEN '期限切れ' " +
                         "WHEN RETURN_DATE > '" + DateTimeNow + "' THEN '貸出中' " +
                         "ELSE ' ' END AS STATUS " +
                         "FROM books.books " +
                         "WHERE REQUEST_FLAG = 1 ";

            //処理実行
            DataTable dt = new DataTable();

            //SQL文実行
            MySqlDataAdapter da = new MySqlDataAdapter(sql, cn);

            try
            {
                cn.Open();

                da.Fill(dt);

                //検索結果表示画面の設定メソッド実行
                BookListViewSetting();

                //画面表示用のDataGridViewに取得データを設定
                approvalGridView.DataSource = dt;

                //DBとの接続をcloseする
                cn.Close();
            }
            catch (MySqlException me)
            {
                MessageBox.Show("ERROR: " + me.Message);
            }
        }

        //一覧表示画面の設定メソッド
        private void BookListViewSetting()
        {
            // DataGridView初期化（データクリア）
            approvalGridView.Columns.Clear();

            //CheckBox列を追加する
            DataGridViewCheckBoxColumn column = new DataGridViewCheckBoxColumn();
            approvalGridView.Columns.Add(column);

            //ヘッダーとすべてのセルの内容に合わせて、列の幅を自動調整する
            approvalGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            //ヘッダーとすべてのセルの内容に合わせて、行の高さを自動調整する
            approvalGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
        }

        //承認ボタンの処理
        private void ApprovalButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("選択した書籍の貸出申請を承認します。");

            //DBに接続する処理
            string sLogin = "server=192.168.8.102; database=books; userid=bks; password=bksbooklist;";

            MySqlConnection cn = new MySqlConnection(sLogin);

            //行のカウント
            //表の書籍データ分繰り返す
            for (int i = 0; i < approvalGridView.Rows.Count; i++)
            {
                string sql = null;

                //チェックボックスに☑が入っているか確認
                Object checkBox = ((DataGridViewCheckBoxCell)((DataGridViewRow)approvalGridView.Rows[i]).Cells[0]).Value;

                if ((checkBox != null) && ((bool)checkBox == true))
                {
                    //SQL文作成
                    sql = "UPDATE books.books " +
                                 "SET REQUEST_FLAG = '0' ," +
                                 "APPROVAL_FLAG = '1' " +
                                 "WHERE BOOK_ID = '" + approvalGridView.Rows[i].Cells[1].Value + "' ";

                    MessageBox.Show("☑が入っている書籍のID : " + approvalGridView.Rows[i].Cells[1].Value);

                    //処理実行
                    DataTable dt = new DataTable();

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
                }   
            }
        }   
    }
}
