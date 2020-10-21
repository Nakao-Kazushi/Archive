using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Archive
{
   
    public partial class Reference : Form
    {      
        //ユーザーID
        private string userId;        
        
        public Reference()
        {
            InitializeComponent();

            //user_idテキストボックスを非表示
            this.user_id.Visible = false;

            //利用状況表示画面の設定
            UsageStateViewSetting();            

            //TextBoxに表示された値を設定
            userId = this.user_id.Text;

            //テスト用（後で削除）
            userId = "4";

            //DBに接続する処理
            string sLogin = "server=localhost; database=books; userid=bks2; password=bksbooklist;";

            MySqlConnection cn = new MySqlConnection(sLogin);

            //現在日付取得
            DateTime dtn = DateTime.Now;
            string DateTimeNow = dtn.ToString("yyyy/MM/dd");

            //SQL文作成
            string sql = "SELECT BOOK_ID ,BOOK_NAME ,LOAN_DATE ,RETURN_DATE , " +
                         "CASE WHEN REQUEST_FLAG = 1 THEN '申請中' " +
                         "WHEN RETURN_DATE < '" + DateTimeNow + "' THEN '期限切れ' " +
                         "WHEN RETURN_DATE >= '" + DateTimeNow + "' THEN '貸出中' " +
                         "ELSE ' ' END AS STATUS " +
                         "FROM books.books " +
                         "WHERE USER_ID = " + userId;

            //処理実行
            DataTable dt = new DataTable();

            //SQL文実行
            MySqlDataAdapter da = new MySqlDataAdapter(sql, cn);

            try
            {
                cn.Open();

                da.Fill(dt);

                //検索結果表示画面の設定メソッド実行
                UsageStateViewSetting();

                //画面表示用のDataGridViewに取得データを設定
                usageStateView.DataSource = dt;

                //DBとの接続をcloseする
                cn.Close();
            }
            catch (MySqlException me)
            {
                MessageBox.Show("ERROR: " + me.Message);
            }
            // 表示するカラム名を設定
            usageStateView.Columns[0].HeaderText = "選択";
            usageStateView.Columns[1].HeaderText = "書籍ID";
            usageStateView.Columns[2].HeaderText = "書籍名";
            usageStateView.Columns[3].HeaderText = "貸出日";
            usageStateView.Columns[4].HeaderText = "返却期日";
            usageStateView.Columns[5].HeaderText = "状態";

            usageStateView.Columns[0].FillWeight = 40;

            //DataGridViewの表示幅に合わせて列幅自動調整
            usageStateView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            //列幅をユーザーが変更できないようにする
            usageStateView.Columns[0].Resizable = DataGridViewTriState.False;
            usageStateView.Columns[3].Resizable = DataGridViewTriState.False;
            usageStateView.Columns[4].Resizable = DataGridViewTriState.False;
            usageStateView.Columns[5].Resizable = DataGridViewTriState.False;
            usageStateView.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            usageStateView.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;

            //☑以外を読み取り専用にする
            usageStateView.Columns[1].ReadOnly = true;
            usageStateView.Columns[2].ReadOnly = true;
            usageStateView.Columns[3].ReadOnly = true;
            usageStateView.Columns[4].ReadOnly = true;
            usageStateView.Columns[5].ReadOnly = true;

            //日付のフォーマット指定
            this.usageStateView.Columns[3].DefaultCellStyle.Format = "yyyy/MM/dd";
            this.usageStateView.Columns[4].DefaultCellStyle.Format = "yyyy/MM/dd";
        }

        //利用状況表示画面の設定メソッド
        private void UsageStateViewSetting()
        {
            // DataGridView初期化（データクリア）
            usageStateView.Columns.Clear();

            //CheckBox列を追加する
            DataGridViewCheckBoxColumn column = new DataGridViewCheckBoxColumn();
            usageStateView.Columns.Add(column);

            //ヘッダーとすべてのセルの内容に合わせて、列の幅を自動調整する
            usageStateView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            //ヘッダーとすべてのセルの内容に合わせて、行の高さを自動調整する
            usageStateView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
        }


        private void searchButton_Clicked(object sender, EventArgs e)
        {
            //検索画面を表示
            using (Search search = new Search())
            {
                search.ShowDialog();     //画面表示
                search.Dispose();        //リソースの開放                
            }

        }

        private void RetturnButton_Clicked(object sender, EventArgs e)
        {
            //DBに接続する処理
            string sLogin = "server=localhost; database=books; userid=bks2; password=bksbooklist;";

            MySqlConnection cn = new MySqlConnection(sLogin);
            DataTable dt = new DataTable();

            //1つでも☑があるかの確認
            bool Checked = false;

            //行のカウント
            for (int i = 0; i < usageStateView.Rows.Count; i++)
            {
                Object checkBox = ((DataGridViewCheckBoxCell)((DataGridViewRow)usageStateView.Rows[i]).Cells[0]).Value;

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

            //☑の入った書籍id
            string book_ids = "''";

            //☑のついてるidを取得
            for (int i = 0; i < usageStateView.Rows.Count; i++)
            {
                Object checkBox = ((DataGridViewCheckBoxCell)((DataGridViewRow)usageStateView.Rows[i]).Cells[0]).Value;

                if ((checkBox != null) && ((bool)checkBox == true))
                {
                    book_ids += ",'" + this.usageStateView.Rows[i].Cells[1].Value?.ToString() + "'";
                }
            }

            string sql = "UPDATE books.books " +
                "SET LOAN_DATE = NULL,RETURN_DATE = NULL,REQUEST_FLAG = 0,APPROVAL_FLAG = 0,USER_ID = 0 "+
                "WHERE BOOK_ID IN (" + book_ids + ")";

            //SQL文実行
            MySqlDataAdapter da = new MySqlDataAdapter(sql, cn);

            try
            {
                cn.Open();

                da.Fill(dt);

                MessageBox.Show("返却完了");

                //DBとの接続をcloseする
                cn.Close();

                //データ更新する
                
            }
            catch (MySqlException me)
            {
                MessageBox.Show("ERROR: " + me.Message);
            }


        }
    }

}
