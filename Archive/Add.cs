using MySql.Data.MySqlClient;
using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Archive
{
    public partial class Add : Form
    {
        
        //コンストラクタ
        //Add.Designer.csのメソッド呼出し、イベントを作成する。
        public Add() 
        {
            InitializeComponent();
        }

        //英数字と_以外
        Regex regId = new Regex(@"[^0-9a-zA-Z_]");

        //#以外の記号
        Regex regName = new Regex(@"[!-"":-@[$-/:-@[-`{-~ ]");

        //書籍IDの禁則処理
        private void Book_id_TextChanged(object sender, EventArgs e)
        {            
            int i = this.book_id.SelectionStart;           
            this.book_id.Text = regId.Replace(this.book_id.Text, "");                      
            this.book_id.SelectionStart = i;                   
        }

        //書籍名の禁則処理
        private void Book_name_TextChanged(object sender, EventArgs e)
        {
            int j = this.book_name.SelectionStart;
            this.book_name.Text = regName.Replace(this.book_name.Text, "");
            this.book_name.SelectionStart = j;
        }

        //「登録」ボタン押下した後の処理
        private void addButtonClicked(object sender, EventArgs e)
        {
            //ダイアログ表示
            DialogResult result = MessageBox.Show("登録しますか", "", MessageBoxButtons.OKCancel);

            //「いいえ」を選んだ場合
            if (result == DialogResult.Cancel) return;
            
            //TextBoxに入力した値を受け取る。
            string book_id = this.book_id.Text;
            string book_name = this.book_name.Text;

            //DBに接続する処理
            string sLogin = "server=localhost; database=books; userid=bks2; password=bksbooklist;";

            MySqlConnection cn = new MySqlConnection(sLogin);

            if ((!string.IsNullOrEmpty(book_id)) && (!string.IsNullOrEmpty(book_name)))
            {              
                //SQL文実行
                MySqlCommand cmd = new MySqlCommand("START TRANSACTION; " + "insert into books value ('" + book_id + "','" + book_name + "',null,null,0,0,0); " + "COMMIT;", cn);

                try
                {
                    //DBとの接続
                    cmd.Connection.Open();

                    //処理実行
                    cmd.ExecuteNonQuery();

                    //DBとの接続をcloseする
                    cmd.Connection.Close();

                    MessageBox.Show("登録完了");                   
                }
                catch (MySqlException me)when(me.Message.Contains("Duplicate entry"))//重複エラー
                {                    
                    MessageBox.Show("このIDは既に登録されています", "", MessageBoxButtons.OK, MessageBoxIcon.Error);                                       
                }
                catch(MySqlException me)
                {
                    MessageBox.Show("ERROR: " + me.Message);
                }
                finally
                {
                    //登録画面を閉じる
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("登録失敗");
            }
        }

        private void searchButton_Click(object sender, EventArgs e)
        {           
            //登録ボタンを閉じる
            this.Close();
        }       
    }
}
