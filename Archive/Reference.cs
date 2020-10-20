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
        public Reference()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

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
    }
}
