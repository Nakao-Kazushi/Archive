using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
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

        //SQLインジェクション対策含む
        //英数字と_以外にマッチする
        Regex reg = new Regex(@"[^0-9a-zA-Z_]");
        Regex regName = new Regex(@"[0-9!-/:-@[-`{-~]");  //左記の文字は入力不可

        //テキストボックス入力時の処理
        private void textChanged(object sender, EventArgs e)
        {
            //idの禁則文字チェック
            int i = this.user_id.SelectionStart;
            this.user_id.Text = reg.Replace(this.user_id.Text, "");
            this.user_id.SelectionStart = i;

            //nameの禁則文字チェック
            int j = this.user_name.SelectionStart;
            this.user_name.Text = regName.Replace(this.user_name.Text, "");
            this.user_name.SelectionStart = j;
        }

        private void pwTextChanged(object sender, EventArgs e)
        {
            //pwの禁則文字チェック
            int i = this.user_pw.SelectionStart;
            this.user_pw.Text = reg.Replace(this.user_pw.Text, "");
            this.user_pw.SelectionStart = i;

            //pw2の禁則文字チェック
            int j = this.user_pw2.SelectionStart;
            this.user_pw2.Text = reg.Replace(this.user_pw2.Text, "");
            this.user_pw2.SelectionStart = j;

            // パスワード入力時に表示する文字の設定を切り替える
            if (this.user_pw.PasswordChar == '\0')
            {
                this.user_pw.PasswordChar = '*';
            }

            // パスワード入力時に表示する文字の設定を切り替える
            if (this.user_pw2.PasswordChar == '\0')
            {
                this.user_pw2.PasswordChar = '*';
            }
        }

        private void userAddButton_Click(object sender, EventArgs e)
        {
            string department = this.department_comboBox.Text;
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

                if (!string.IsNullOrEmpty(department) && !string.IsNullOrEmpty(userId) && !string.IsNullOrEmpty(userName) && !string.IsNullOrEmpty(userPw))
                {

                    //ダイアログ表示
                    DialogResult result = MessageBox.Show("登録しますか", "", MessageBoxButtons.OKCancel);

                    //「いいえ」を選んだ場合
                    if (result == DialogResult.Cancel) return;

                    //SQL文実行
                    MySqlCommand cmd = new MySqlCommand(
                                            "START TRANSACTION; " +
                                            "insert into user value ('" + userId + "','" + userName + "','" + userPw + "',0,'" + department + "'); " +
                                            "COMMIT;", cn);
                    try
                    {
                        //DBとの接続
                        cmd.Connection.Open();

                        //処理実行
                        cmd.ExecuteNonQuery();

                        MessageBox.Show("登録完了");
                    }
                    catch (MySqlException me) when (me.Message.Contains("Duplicate entry"))//重複エラー
                    {
                        MessageBox.Show("このIDは既に登録されています", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    catch (MySqlException me)
                    {
                        MessageBox.Show("ERROR: " + me.Message);
                    }
                    finally
                    {
                        //DBとの接続をcloseする
                        cmd.Connection.Close();
                    }
                }
                else
                {
                    Error(userId,userName,userPw, department);
                    //MessageBox.Show("登録失敗");
                }
            }
            //一つ目のパスワードのみ入力されている時
            else if (string.IsNullOrEmpty(department) & string.IsNullOrEmpty(userId) & string.IsNullOrEmpty(userName) & string.IsNullOrEmpty(this.user_pw2.Text))
            {
                MessageBox.Show("必要項目を入力してください。");
            }
            //二つ目のパスワードのみ入力されている時
            else if (string.IsNullOrEmpty(department) & string.IsNullOrEmpty(userId) & string.IsNullOrEmpty(userName) & string.IsNullOrEmpty(userPw))
            {
                MessageBox.Show("必要項目を入力してください。");
            }
            
            //部署と一つ目のパスワード以外未入力の場合
            else if (string.IsNullOrEmpty(userId) & string.IsNullOrEmpty(userName) & string.IsNullOrEmpty(this.user_pw2.Text))
            {
                MessageBox.Show("ユーザーID、ユーザー名、パスワードが未入力です。");
            }
            //部署と二つ目のパスワード以外未入力の場合
            else if (string.IsNullOrEmpty(userId) & string.IsNullOrEmpty(userName) & string.IsNullOrEmpty(userPw))
            {
                MessageBox.Show("ユーザーID、ユーザー名、パスワードが未入力です。");
            }
            //ユーザーID、一つ目のパスワード以外未入力の場合
            else if (string.IsNullOrEmpty(department) & string.IsNullOrEmpty(userName) & string.IsNullOrEmpty(this.user_pw2.Text))
            {
                MessageBox.Show("部署、ユーザー名、パスワードが未入力です。");
            }
            //ユーザーID、二つ目のパスワード以外未入力の場合
            else if (string.IsNullOrEmpty(department) & string.IsNullOrEmpty(userName) & string.IsNullOrEmpty(userPw))
            {
                MessageBox.Show("部署、ユーザー名、パスワードが未入力です。");
            }
            //ユーザー名と一つ目のパスワード以外未入力の場合
            else if (string.IsNullOrEmpty(department) & string.IsNullOrEmpty(userId) & string.IsNullOrEmpty(this.user_pw2.Text))
            {
                MessageBox.Show("部署、ユーザーID、パスワードが未入力です。");
            }
            //ユーザー名と二つ目のパスワード以外未入力の場合
            else if (string.IsNullOrEmpty(department) & string.IsNullOrEmpty(userId) & string.IsNullOrEmpty(userPw))
            {
                MessageBox.Show("部署、ユーザーID、パスワードが未入力です。");
            }
            else if(!this.user_pw.Text.Equals(this.user_pw2.Text))
            {
                MessageBox.Show("ERROR : パスワードは2箇所同じものを入力してください。");
            }
        }

        public void Error(string userId,string userName,string userPw,string department)
        {
            //部署、ユーザーID,ユーザー名,パスワードがすべて未入力の場合
            if (string.IsNullOrEmpty(department) & string.IsNullOrEmpty(userId) & string.IsNullOrEmpty(userName) & string.IsNullOrEmpty(userPw) & string.IsNullOrEmpty(this.user_pw2.Text))
            {
                MessageBox.Show("必要項目を入力してください。");
            }
            //部署以外すべて未入力の場合
            else if (string.IsNullOrEmpty(userId) & string.IsNullOrEmpty(userName) & string.IsNullOrEmpty(userPw) & string.IsNullOrEmpty(this.user_pw2.Text))
            {
                MessageBox.Show("必要項目を入力してください。");
            }
            //ユーザーID以外すべて未入力の場合
            else if (string.IsNullOrEmpty(department) & string.IsNullOrEmpty(userName) & string.IsNullOrEmpty(userPw) & string.IsNullOrEmpty(this.user_pw2.Text))
            {
                MessageBox.Show("必要項目を入力してください。");
            }
            //ユーザー名以外すべて未入力の場合
            else if (string.IsNullOrEmpty(department) & string.IsNullOrEmpty(userId) & string.IsNullOrEmpty(userPw) & string.IsNullOrEmpty(this.user_pw2.Text))
            {
                MessageBox.Show("必要項目を入力してください。");
            }
            //一つ目のパスワード以外すべて未入力の場合
            else if (string.IsNullOrEmpty(department) & string.IsNullOrEmpty(userId) & string.IsNullOrEmpty(userName) & string.IsNullOrEmpty(this.user_pw2.Text))
            {
                MessageBox.Show("必要項目を入力してください。");
            }
            //二つ目のパスワード以外すべて未入力の場合
            else if (string.IsNullOrEmpty(department) & string.IsNullOrEmpty(userId) & string.IsNullOrEmpty(userName) & string.IsNullOrEmpty(userPw))
            {
                MessageBox.Show("必要項目を入力してください。");
            }

        //3箇所以上未入力があったときのエラー-------------------------------------------------------------------------------------
            //パスワード二か所以外未入力の場合
            else if (string.IsNullOrEmpty(department) & string.IsNullOrEmpty(userId) & string.IsNullOrEmpty(userName))
            {
                MessageBox.Show("部署、ユーザーID、ユーザー名が未入力です。");
            }
            //ユーザーID、ユーザー名以外未入力の場合
            else if (string.IsNullOrEmpty(department) & string.IsNullOrEmpty(userPw) & string.IsNullOrEmpty(this.user_pw2.Text))
            {
                MessageBox.Show("部署、パスワード二つが未入力です。");
            }
            //部署とユーザーID以外未入力の場合
            else if (string.IsNullOrEmpty(userName) & string.IsNullOrEmpty(userPw) & string.IsNullOrEmpty(this.user_pw2.Text))
            {
                MessageBox.Show("ユーザー名、パスワード二つが未入力です。");
            }
            //部署とユーザー名以外未入力の場合
            else if (string.IsNullOrEmpty(userId) & string.IsNullOrEmpty(userPw) & string.IsNullOrEmpty(this.user_pw2.Text))
            {
                MessageBox.Show("ユーザーID、パスワード二つが未入力です。");
            }

        //2箇所未入力があったときのエラー-------------------------------------------------------------------------------------
            else if (string.IsNullOrEmpty(department) & string.IsNullOrEmpty(userId))
            {
                MessageBox.Show("部署とユーザーIDが未入力です。");
            }
            else if (string.IsNullOrEmpty(department) & string.IsNullOrEmpty(userName))
            {
                MessageBox.Show("部署とユーザー名が未入力です。");
            }
            else if (string.IsNullOrEmpty(department) & string.IsNullOrEmpty(userPw))
            {
                MessageBox.Show("部署とパスワードが未入力です。");
            }
            else if (string.IsNullOrEmpty(userId) & string.IsNullOrEmpty(userName))
            {
                MessageBox.Show("ユーザーIDとユーザー名が未入力です。");
            }
            else if (string.IsNullOrEmpty(userId) & string.IsNullOrEmpty(userPw))
            {
                MessageBox.Show("ユーザーIDとパスワードが未入力です。");
            }
            else if (string.IsNullOrEmpty(userName) & string.IsNullOrEmpty(userPw))
            {
                MessageBox.Show("ユーザー名とパスワードが未入力です。");
            }

        //1箇所未入力の場合-------------------------------------------------------------------------------------
            else if (string.IsNullOrEmpty(department))
            {
                MessageBox.Show("部署が未入力です。");
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
            else
            {
                MessageBox.Show("必要項目を入力してください。");
            }
        }

        //「戻る」ボタン
        private void returnButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AddUser_Load(object sender, EventArgs e)
        {
            //「部署」の初期表示時は「空白」を表示
            department_comboBox.SelectedIndex = 0;
        }

        
    }
}
