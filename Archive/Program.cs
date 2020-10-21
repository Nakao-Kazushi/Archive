using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Archive
{
    static class Program
    {
        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //(new 最初に実行するメソッド)
            //Application.Run(new Add());           //書籍登録
            //Application.Run(new Search());        //書籍検索
            //Application.Run(new Request());       //申請画面
            //Application.Run(new Approval());      //承認画面
            //Application.Run(new AddUser());       //ユーザー登録画面
            //Application.Run(new Login());           //ログイン画面
            Application.Run(new Reference());
        }
    }
}
