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

            //string sLogin = "server=192.168.8.102; database=books; userid=bks; password=bksbooklist;";
            string sLogin = "server=localhost; database=books; userid=root; password=Oneok0927;";

            MySqlConnection cn = new MySqlConnection(sLogin);

            //現在日付取得
            DateTime dtn = DateTime.Now;
            string DateTimeNow = dtn.ToString("yyyy/MM/dd");

            string sql = "START TRANSACTION; " +
                         "SELECT BOOK_ID ,BOOK_NAME ,LOAN_DATE ,RETURN_DATE ," +
                         "CASE WHEN REQUEST_FLAG = 1 THEN '申請中' " +
                         "WHEN RETURN_DATE < '" + DateTimeNow + "' THEN '期限切れ' " +
                         "WHEN RETURN_DATE > '" + DateTimeNow + "' THEN '貸出中' " +
                         "ELSE ' ' END AS STATUS " +
                         "FROM books.books " +
                         "WHERE REQUEST_FLAG = 1 ; " +
                         "COMMIT;";

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

            //☑以外を読み取り専用にする
            approvalGridView.Columns[1].ReadOnly = true;
            approvalGridView.Columns[2].ReadOnly = true;
            approvalGridView.Columns[3].ReadOnly = true;
            approvalGridView.Columns[4].ReadOnly = true;
            approvalGridView.Columns[5].ReadOnly = true;

            // 承認画面で表示するカラム名を設定
            approvalGridView.Columns[0].HeaderText = "選択";
            approvalGridView.Columns[1].HeaderText = "書籍ID";
            approvalGridView.Columns[2].HeaderText = "書籍名";
            approvalGridView.Columns[3].HeaderText = "貸出日";
            approvalGridView.Columns[4].HeaderText = "返却期日";
            approvalGridView.Columns[5].HeaderText = "状態";
        }

        //一覧表示画面の設定メソッド
        private void BookListViewSetting()
        {
            // DataGridView初期化（データクリア）
            approvalGridView.Columns.Clear();

            //CheckBox列を追加する
            DataGridViewCheckBoxColumn column = new DataGridViewCheckBoxColumn();
            approvalGridView.Columns.Add(column);

            //チェックボックスのセルのサイズ指定
            approvalGridView.Columns[0].FillWeight = 40;

            //DataGridViewの表示幅に合わせて列幅自動調整
            approvalGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        //承認ボタンの処理
        private void ApprovalButton_Click(object sender, EventArgs e)
        {
            //ダイアログ表示
            DialogResult result = MessageBox.Show("承認しますか", "", MessageBoxButtons.OKCancel);

            //「いいえ」を選んだ場合
            if (result == DialogResult.Cancel)
            {
                return;
            }

            //string sLogin = "server=192.168.8.102; database=books; userid=bks; password=bksbooklist;";
            string sLogin = "server=localhost; database=books; userid=root; password=Oneok0927;";

            MySqlConnection cn = new MySqlConnection(sLogin);

            //承認する書籍を選択するチェックボックス
            Object checkBox = null;

            string sql;

            //1つでも☑があるかの確認
            bool Checked = false;

            //行のカウント
            //表の書籍データ分繰り返す
            for (int i = 0; i < approvalGridView.Rows.Count; i++)
            {

                //チェックボックスに☑が入っているか確認
                checkBox = ((DataGridViewCheckBoxCell)((DataGridViewRow)approvalGridView.Rows[i]).Cells[0]).Value;

                if (checkBox != null && (bool)checkBox == true)
                {
                    Checked = true;

                    sql = "START TRANSACTION; " +
                          "UPDATE books.books " +
                          "SET REQUEST_FLAG = '0' ," +
                          "APPROVAL_FLAG = '1' " +
                          "WHERE BOOK_ID = '" + approvalGridView.Rows[i].Cells[1].Value + "' ; "+
                          "COMMIT;";

                    DataTable dt = new DataTable();
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

                    //☑以外を読み取り専用にする
                    approvalGridView.Columns[1].ReadOnly = true;
                    approvalGridView.Columns[2].ReadOnly = true;
                    approvalGridView.Columns[3].ReadOnly = true;
                    approvalGridView.Columns[4].ReadOnly = true;
                    approvalGridView.Columns[5].ReadOnly = true;

                    // 更新画面で表示するカラム名を設定
                    approvalGridView.Columns[0].HeaderText = "選択";
                    approvalGridView.Columns[1].HeaderText = "書籍ID";
                    approvalGridView.Columns[2].HeaderText = "書籍名";
                    approvalGridView.Columns[3].HeaderText = "貸出日";
                    approvalGridView.Columns[4].HeaderText = "返却期日";
                    approvalGridView.Columns[5].HeaderText = "状態";
                }
            }

            //1つでも☑がなかった場合
            if (!Checked)
            {
                MessageBox.Show("ERROR : 貸出申請を承認する書籍を選択してください。");
                return;
            }
            updateApprovalList();
        }

        //「検索」ボタン
        private void SearchButton_Click(object sender, EventArgs e)
        {
            using (Search search = new Search())
            {
                //管理者
                search.adminiCheckBox.Checked = true;
                search.ShowDialog();     //画面表示
                search.Dispose();        //リソースの開放
            }
        }

        //承認画面再表示用メソッド
        public void updateApprovalList()
        {
            //string sLogin = "server=192.168.8.102; database=books; userid=bks; password=bksbooklist;";
            string sLogin = "server=localhost; database=books; userid=root; password=Oneok0927;";

            MySqlConnection cn = new MySqlConnection(sLogin);

            //現在日付取得
            DateTime dtn = DateTime.Now;
            string DateTimeNow = dtn.ToString("yyyy/MM/dd");

            string sql = "START TRANSACTION; " +
                         "SELECT BOOK_ID ,BOOK_NAME ,LOAN_DATE ,RETURN_DATE ," +
                         "CASE WHEN REQUEST_FLAG = 1 THEN '申請中' " +
                         "WHEN RETURN_DATE < '" + DateTimeNow + "' THEN '期限切れ' " +
                         "WHEN RETURN_DATE > '" + DateTimeNow + "' THEN '貸出中' " +
                         "ELSE ' ' END AS STATUS " +
                         "FROM books.books " +
                         "WHERE REQUEST_FLAG = 1 ; " +
                         "COMMIT;";

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

            //☑以外を読み取り専用にする
            approvalGridView.Columns[1].ReadOnly = true;
            approvalGridView.Columns[2].ReadOnly = true;
            approvalGridView.Columns[3].ReadOnly = true;
            approvalGridView.Columns[4].ReadOnly = true;
            approvalGridView.Columns[5].ReadOnly = true;

            // 更新画面で表示するカラム名を設定
            approvalGridView.Columns[0].HeaderText = "選択";
            approvalGridView.Columns[1].HeaderText = "書籍ID";
            approvalGridView.Columns[2].HeaderText = "書籍名";
            approvalGridView.Columns[3].HeaderText = "貸出日";
            approvalGridView.Columns[4].HeaderText = "返却期日";
            approvalGridView.Columns[5].HeaderText = "状態";
        }
    }
}
