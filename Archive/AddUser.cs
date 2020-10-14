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
   
        public AddUser()
        {
            InitializeComponent();
        }

        private void userAddButton_Click(object sender, EventArgs e)
        {
            string userId = this.user_id.Text;
            string userName = this.user_name.Text;
            string userPw = null;

            //パスワードが二つ同じ場合のみ実行
            if (this.user_pw.Text.Equals(this.user_pw2.Text))
            {
                userPw = this.user_pw.Text;

                //DBに接続する処理
                //string sLogin = "server=192.168.8.102; database=books; userid=bks; password=bksbooklist;";
                string sLogin = "server=localhost; database=books; userid=root; password=Oneok0927;";

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
                    Error(userId,userName,userPw);
                    //MessageBox.Show("登録失敗");
                }
            }
            //一つ目のパスワードのみ入力されている時
            else if (string.IsNullOrEmpty(userId) && string.IsNullOrEmpty(userName) && string.IsNullOrEmpty(this.user_pw2.Text))
            {
                MessageBox.Show("ユーザーIDとユーザー名が未入力です。");
            }
            //二つ目のパスワードのみ入力されている時
            else if (string.IsNullOrEmpty(userId) && string.IsNullOrEmpty(userName) && string.IsNullOrEmpty(this.user_pw.Text))
            {
                MessageBox.Show("ユーザーIDとユーザー名が未入力です。");
            }
            
            else if (string.IsNullOrEmpty(userId) && string.IsNullOrEmpty(this.user_pw2.Text))
            {
                MessageBox.Show("ユーザーIDと二つ目のパスワードが未入力です。");
            }
            
            else if (string.IsNullOrEmpty(userName) && string.IsNullOrEmpty(this.user_pw2.Text))
            {
                MessageBox.Show("ユーザー名と二つ目のパスワードが未入力です。");
            }
            else if(!this.user_pw.Text.Equals(this.user_pw2.Text))
            {
                MessageBox.Show("ERROR : パスワードは2箇所同じものを入力してください。");
            }
        }

        public void Error(string userId,string userName,string userPw)
        {
            //ユーザーID,ユーザー名,パスワードがすべて未入力の場合
            if (string.IsNullOrEmpty(userId) && string.IsNullOrEmpty(userName) && string.IsNullOrEmpty(userPw) && string.IsNullOrEmpty(this.user_pw2.Text))
            {
                MessageBox.Show("必要項目を入力してください。");
            }
            //
            else if (string.IsNullOrEmpty(userId) && string.IsNullOrEmpty(userName))
            {
                MessageBox.Show("ユーザーIDとユーザー名が未入力です。");
            }
            else if (string.IsNullOrEmpty(userName) && string.IsNullOrEmpty(userPw))
            {
                MessageBox.Show("ユーザー名とパスワードが未入力です。");
            }
            else if (string.IsNullOrEmpty(userId) && string.IsNullOrEmpty(userPw))
            {
                MessageBox.Show("ユーザーIDとパスワードが未入力です。");
            }
            else if (string.IsNullOrEmpty(userId))
            {
                MessageBox.Show("ユーザーIDが未入力です。");
            }
            else if (string.IsNullOrEmpty(userName))
            {
                MessageBox.Show("ユーザー名が未入力です。");
            }
            else if (string.IsNullOrEmpty(userPw))
            {
                MessageBox.Show("パスワードが未入力です。");
            }
        }
    }
}
