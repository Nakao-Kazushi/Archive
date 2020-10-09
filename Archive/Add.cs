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
    public partial class Add : Form
    {
        
        //コンストラクタ
        //Add.Designer.csのメソッド呼出し、イベントを作成する。
        public Add() 
        {
            InitializeComponent();
        }

        //「登録」ボタン押下した後の処理
        private void addButtonClicked(object sender, EventArgs e)
        {
            //TextBoxに入力した値を受け取る。
            string book_id = this.book_id.Text;
            string book_name = this.book_name.Text;

            //DBに接続する処理
            string sLogin = "server=192.168.8.102; database=books; userid=bks; password=bksbooklist;";

            MySqlConnection cn = new MySqlConnection(sLogin);

            if ((!string.IsNullOrEmpty(book_id)) && (!string.IsNullOrEmpty(book_name)))
            {
                //SQL文実行
                MySqlCommand cmd = new MySqlCommand("insert into books value ('" + book_id + "','" + book_name + "',null,null,0,0)", cn);

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
                catch (MySqlException me)
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

            //検索画面を表示
            using (Search s = new Search())
            {
                s.ShowDialog();     //画面表示
                s.Dispose();        //リソースの開放
            }
        }
    }
}
