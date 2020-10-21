using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Archive
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        //英数字と_以外にマッチする
        Regex reg = new Regex(@"[^0-9a-zA-Z_]");

        //禁則文字チェック
        private void userIdTextChanged(object sender, EventArgs e)
        {
            //カーソル位置
            int i = this.user_id.SelectionStart;

            //英数字_以外は消す
            this.user_id.Text = reg.Replace(this.user_id.Text, "");

            //カーソル位置を入力前の位置に戻す
            this.user_id.SelectionStart = i;

        }

        //禁則文字チェック
        private void pwTextChanged(object sender, EventArgs e)
        {
            //カーソル位置
            int i = this.user_pw.SelectionStart;

            //英数字_以外は消す
            this.user_pw.Text = reg.Replace(this.user_pw.Text, "");

            //カーソル位置を入力前の位置に戻す
            this.user_pw.SelectionStart = i;

            // パスワード入力時に表示する文字の設定を切り替える
            if (this.user_pw.PasswordChar == '\0')
            {
                this.user_pw.PasswordChar = '*';
            }
        }

        //一般ユーザーのログイン画面
        private void LoginButton_Click(object sender, EventArgs e)
        {
            string department = this.department_comboBox.Text;
            string userId = this.user_id.Text;
            string userPw = this.user_pw.Text;
            bool Administrator = AdministratorCheckBox.Checked;
            
            //DBに接続する処理
            //string sLogin = "server=192.168.8.102; database=books; userid=bks; password=bksbooklist;";
            string sLogin = "server=localhost; database=books; userid=root; password=Oneok0927;";

            MySqlConnection cn = new MySqlConnection(sLogin);

            string sql = null;

            //処理実行
            DataTable dt = new DataTable();

            //SQL　条件分岐
            if ((!string.IsNullOrEmpty(department)) && (!string.IsNullOrEmpty(userId)) && (!string.IsNullOrEmpty(userPw)))
            {
                sql = "SELECT USER_ID FROM books.user " +
                      "WHERE USER_ID = '" + userId + "' AND USER_PW = '" + userPw + "' AND DEPARTMENT = '" + department + "' ";
                
                //管理者の☑が入っている時にSQL文に検索条件追加
                if (Administrator == true)
                {
                    sql = sql + "AND ADMINISTRATOR_FLAG = '1'";            
                }
                
                //SQL文実行
                MySqlDataAdapter da = new MySqlDataAdapter(sql, cn);

                try
                {
                    cn.Open();
                    da.Fill(dt);
                    cn.Close(); //DBとの接続をcloseする

                    int count = dt.Rows.Count;

                    if (count == 1)
                    {
                        MessageBox.Show("ログイン完了");

                        //管理者
                        if (Administrator == true)
                        {
                            //承認画面を表示
                            using (Approval a = new Approval())
                            {
                                a.ShowDialog();     //画面表示
                                a.Dispose();        //リソースの開放
                            }
                        }
                        //一般ユーザー
                        else
                        {
                            //利用照会画面を表示
                            using (Reference reference = new Reference())
                            {
                                //reference.user_id.Text = userId;
                                reference.ShowDialog();     //画面表示
                                reference.Dispose();        //リソースの開放
                            }
                        }
                    }
                    else if (count == 0)
                    {
                        MessageBox.Show("ERROR : そのユーザーは登録されていません。");
                    }
                    else
                    {
                        MessageBox.Show("ERROR : ログイン失敗");
                    }   
                }
                catch (MySqlException me)
                {
                    MessageBox.Show("ERROR : " + me.Message);
                }
            }
            else
            {
                Error(userId, userPw, department);
            }
        }

        //アカウント登録ボタン
        private void AddUserButton_Click(object sender, EventArgs e)
        {
            //承認画面を表示
            using (AddUser adduser = new AddUser())
            {
                adduser.ShowDialog();     //画面表示
                adduser.Dispose();        //リソースの開放
            }
        }

        public void Error(string userId, string userPw, string department)
        {
            //部署、ユーザーID,パスワードがすべて未入力の場合
            if (string.IsNullOrEmpty(department) & string.IsNullOrEmpty(userId) & string.IsNullOrEmpty(userPw))
            {
                MessageBox.Show("すべての必要項目を入力してください。");
            }

            //2箇所未入力があったときのエラー-------------------------------------------------------------------------------------
            else if (string.IsNullOrEmpty(department) & string.IsNullOrEmpty(userId))
            {
                MessageBox.Show("部署とユーザーIDが未入力です。");
            }
            else if (string.IsNullOrEmpty(department) & string.IsNullOrEmpty(userPw))
            {
                MessageBox.Show("部署とパスワードが未入力です。");
            }
            else if (string.IsNullOrEmpty(userId) & string.IsNullOrEmpty(userPw))
            {
                MessageBox.Show("ユーザーIDとパスワードが未入力です。");
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
            else if (string.IsNullOrEmpty(userPw))
            {
                MessageBox.Show("パスワードが未入力です。");
            }
            else
            {
                MessageBox.Show("必要項目を入力してください。");
            }
        }
    }
}
