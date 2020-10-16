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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        //一般ユーザーのログイン画面
        private void LoginButton_Click(object sender, EventArgs e)
        {
            string userName = this.user_name.Text;
            string userPw = this.user_pw.Text;
            bool Administrator = AdministratorCheckBox.Checked;

            //DBに接続する処理
            string sLogin = "server=192.168.8.102; database=books; userid=bks; password=bksbooklist;";
            

            MySqlConnection cn = new MySqlConnection(sLogin);

            string sql = null;

            //処理実行
            DataTable dt = new DataTable();

            //SQL　条件分岐
            if ((!string.IsNullOrEmpty(userName)) && (!string.IsNullOrEmpty(userPw)))
            {
                sql = "SELECT USER_ID FROM books.user " +
                      "WHERE USER_NAME = '" + userName + "' AND USER_PW = '" + userPw + "' ";
                
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

                    //DBとの接続をcloseする
                    cn.Close();

                    int count = dt.Rows.Count;
                    //MessageBox.Show("件数 : " + count);

                    MessageBox.Show(" " + dt.Rows[0][0].ToString() + " ");

                    if (count == 1)
                    {
                        MessageBox.Show("ログイン完了");
                   
                        //検索画面を表示
                        using (Search s = new Search())
                        {
                            //管理者の☑が入っている時
                            if (Administrator == true)
                            {
                                //MessageBox.Show("管理者");
                                s.adminiCheckBox.Checked = true;
                            }

                            s.ShowDialog();     //画面表示
                            s.Dispose();        //リソースの開放
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
                MessageBox.Show("ERROR : ユーザー名またはPWが未入力です。");
            }
        }
    }
}
