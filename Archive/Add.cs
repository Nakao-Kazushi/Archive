using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

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

        //英数字と_以外にマッチする
        Regex reg = new Regex(@"[^0-9a-zA-Z_]");

        //文字が入力されたときの処理
        private void Book_idTextChanged(object sender, EventArgs e)
        {
            //カーソル位置
            int i = this.book_id.SelectionStart;

            //英数字_以外は消す
            this.book_id.Text = reg.Replace(this.book_id.Text, "");

            //カーソル位置を入力前の位置に戻す
            this.book_id.SelectionStart = i;
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
                MySqlCommand cmd = new MySqlCommand("insert into books value ('" + book_id + "','" + book_name + "',null,null,0,0,0)", cn);

                try
                {
                    //DBとの接続
                    cmd.Connection.Open();

                    //処理実行
                    cmd.ExecuteNonQuery();

                    //DBとの接続をcloseする
                    cmd.Connection.Close();

                    MessageBox.Show("登録完了");

                    //登録画面を閉じる
                    this.Close();
                }
                catch (MySqlException me)when(me.Message.Contains("Duplicate entry"))//重複エラー
                {                    
                    MessageBox.Show("このIDは既に登録されています", "", MessageBoxButtons.OK, MessageBoxIcon.Error);                                       
                }
                catch(MySqlException me)
                {
                    MessageBox.Show("ERROR: " + me.Message);
                }
            }
            else
            {
                MessageBox.Show("登録失敗");
            }
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("検索ボタン");

            ////検索画面を表示
            //using (Search s = new Search())
            //{
            //    s.ShowDialog();     //画面表示
            //    s.Dispose();        //リソースの開放
            //}

            //登録ボタンを閉じる
            this.Close();
        }       
    }
}
