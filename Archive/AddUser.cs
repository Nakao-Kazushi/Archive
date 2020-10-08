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
    public partial class AddUser : Form
    {
        //谷更新１
        public AddUser()
        {
            InitializeComponent();
        }

        //ユーザー登録画面(Test)
        private void userAddButton_Click(object sender, EventArgs e)
        {
            string userId = this.user_id.Text;
            string userName = this.user_name.Text;
            string userPw = null;

            if (this.user_pw.Text.Equals(this.user_pw2.Text))
            {
                userPw = this.user_pw.Text;
            }
            else
            {
                MessageBox.Show("ERROR : パスワードは2箇所同じものを入力してください。");
            }

            //DBに接続する処理
            string sLogin = "server=192.168.8.102; database=books; userid=bks; password=bksbooklist;";

            MySqlConnection cn = new MySqlConnection(sLogin);

            if ((!string.IsNullOrEmpty(userId)) && (!string.IsNullOrEmpty(userName)) && (!string.IsNullOrEmpty(userPw)))
            {
                //SQL文実行
                MySqlCommand cmd = new MySqlCommand(
                                        "insert into user value ('" + userId + "','" + userName + "','" + userPw + "',0)", cn);

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
    }
}
