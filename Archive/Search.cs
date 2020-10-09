﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Archive
{
    public partial class Search : Form
    {
        //Dがsearchを変更
        //BがSearchを変更（１）
        　 
        public Search() //親Form
        {
            InitializeComponent();
        }

        //検索結果表示画面の設定メソッド
        private void BookListViewSetting()
        {
            // DataGridView初期化（データクリア）
            bookListView.Columns.Clear();

            //CheckBox列を追加する
            DataGridViewCheckBoxColumn column = new DataGridViewCheckBoxColumn();
            bookListView.Columns.Add(column);

            //ヘッダーとすべてのセルの内容に合わせて、列の幅を自動調整する
            bookListView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            //ヘッダーとすべてのセルの内容に合わせて、行の高さを自動調整する
            bookListView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
        }

    //チェックボックスのture,false判定-----------------------------------------------------------------------------
        //CurrentCellDirtyStateChangedイベントハンドラ-1,3
        private void bookListView_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (bookListView.CurrentCellAddress.X == 0 && bookListView.IsCurrentCellDirty)
            {
                //コミットする
                bookListView.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        //CellValueChangedイベントハンドラ-2
        private void bookListView_CellValueChanged(object sender, DataGridViewCellEventArgs e){}
    //---------------------------------------------------------------------------------------------------------

        //検索処理
        private void searchButton_Click(object sender, EventArgs e)
        {
            //TextBoxに入力した値を受け取る。
            string book_id = this.book_id.Text;
            string book_name = this.book_name.Text;

            //DBに接続する処理
            string sLogin = "server=192.168.8.102; database=books; userid=bks; password=bksbooklist;";

            MySqlConnection cn = new MySqlConnection(sLogin);

            //現在日付取得
            DateTime dtn = DateTime.Now;
            string DateTimeNow = dtn.ToString("yyyy/MM/dd");

            //SQL文作成
            string sql = "SELECT BOOK_ID ,BOOK_NAME ,LOAN_DATE ,RETURN_DATE , " +
                         "CASE WHEN REQUEST_FLAG = 1 THEN '申請中' " +
                         "WHEN RETURN_DATE < '" + DateTimeNow + "' THEN '期限切れ' " +
                         "WHEN RETURN_DATE > '" + DateTimeNow + "' THEN '貸出中' " +
                         "ELSE ' ' END AS STATUS " +
                         "FROM books.books ";

            //返却期限切れの書籍を取り出す処理
            if (expiredCheckBox.Checked == true)
            {
                //SQL　条件分岐
                if ((!string.IsNullOrEmpty(book_id)) && (!string.IsNullOrEmpty(book_name)))
                {
                    sql = sql + "WHERE BOOK_ID LIKE '" + book_id + "%' AND BOOK_NAME LIKE '%" + book_name + "%' AND RETURN_DATE < '" + DateTimeNow + "'";
                }

                else if (!string.IsNullOrEmpty(book_id))
                {
                    sql = sql + "WHERE BOOK_ID LIKE '" + book_id + "%' AND RETURN_DATE < '" + DateTimeNow + "'";
                }

                else if (!string.IsNullOrEmpty(book_name))
                {
                    sql = sql + "WHERE BOOK_NAME LIKE '%" + book_name + "%' AND RETURN_DATE < '" + DateTimeNow + "'";
                }

                else
                {
                    sql = sql + "WHERE RETURN_DATE < '" + DateTimeNow + "'";
                }
            }

            //返却期限のチェックが入ってない時の処理
            else if (expiredCheckBox.Checked == false)
            {
                //SQL　条件分岐
                if ((!string.IsNullOrEmpty(book_id)) && (!string.IsNullOrEmpty(book_name)))
                {
                    sql = sql + "WHERE BOOK_ID LIKE '" + book_id + "%' AND BOOK_NAME LIKE '%" + book_name + "%'";
                }

                else if (!string.IsNullOrEmpty(book_id))
                {
                    sql = sql + "WHERE BOOK_ID LIKE '" + book_id + "%'";
                }

                else if (!string.IsNullOrEmpty(book_name))
                {
                    sql = sql + "WHERE BOOK_NAME LIKE '%" + book_name + "%'";
                }
            }

            //処理実行
            DataTable dt = new DataTable();

            //SQL文実行
            MySqlDataAdapter da = new MySqlDataAdapter(sql, cn);

            try
            {
                cn.Open();

                da.Fill(dt);

                MessageBox.Show("検索完了");

                //検索結果表示画面の設定メソッド実行
                BookListViewSetting();

                //画面表示用のDataGridViewに取得データを設定
                bookListView.DataSource = dt;

                //DBとの接続をcloseする
                cn.Close();
            }
            catch (MySqlException me)
            {
                MessageBox.Show("ERROR: " + me.Message);
            }

            //☑以外を読み取り専用にする
            bookListView.Columns[1].ReadOnly = true;
            bookListView.Columns[2].ReadOnly = true;
            bookListView.Columns[3].ReadOnly = true;
            bookListView.Columns[4].ReadOnly = true;
            bookListView.Columns[5].ReadOnly = true;

            //日付のフォーマット指定
            this.bookListView.Columns[3].DefaultCellStyle.Format = "yyyy/MM/dd";
            this.bookListView.Columns[4].DefaultCellStyle.Format = "yyyy/MM/dd";
        }

        //申請処理
        private void requestButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("申請画面表示します。");

            //申請用画面を表示
            using (Request r = new Request())
            {
                //申請画面に何も表示されていない場合
                if (r.requestGridView.Columns.Count == 0)
                {
                    //配列の中身を取り出し、申請画面用のDataGridViewに追加する
                    foreach (DataGridViewColumn dgvc in bookListView.Columns)
                    {
                        r.requestGridView.Columns.Add(dgvc.Clone() as DataGridViewColumn);
                    }
                }

                DataGridViewRow row = new DataGridViewRow();

                //行のカウント
                for (int i = 0; i < bookListView.Rows.Count; i++)
                {
                    row = (DataGridViewRow)bookListView.Rows[i].Clone();

                    //row[i][intColIndex]
                    int intColIndex = 0;

                    //チェックボックスに☑が入っているか確認
                    Object checkBox = ((DataGridViewCheckBoxCell)((DataGridViewRow)bookListView.Rows[i]).Cells[0]).Value;
                    //MessageBox.Show("☑判定：" + checkBox);

                    if ((checkBox != null) && ((bool)checkBox == true))
                    {
                        //列のコピー
                        foreach (DataGridViewCell cell in bookListView.Rows[i].Cells)
                        {
                            //セルの値を1つずつコピーする
                            row.Cells[intColIndex].Value = cell.Value;
                            //MessageBox.Show("row.Cells[intColIndex].Value : " + row.Cells[intColIndex].Value);
            
                            intColIndex++;
                            //MessageBox.Show("リスト追加 " + intColIndex);
                        }
                        r.requestGridView.Rows.Add(row);
                    }
                }
                r.requestGridView.AllowUserToAddRows = false;
                r.requestGridView.Refresh();
                r.ShowDialog();     //画面表示
                r.Dispose();        //リソースの開放
            }
        }

        private void editButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("編集ボタン");

            //更新用画面を表示
            using (Edit ed = new Edit())
            {               
                //申請画面に何も表示されていない場合
                if (ed.editGridView.Columns.Count == 0)
                {
                    //配列の中身を取り出し、申請画面用のDataGridViewに追加する
                    foreach (DataGridViewColumn dgvc in bookListView.Columns)
                    {
                        ed.editGridView.Columns.Add(dgvc.Clone() as DataGridViewColumn);
                    }
                }

                DataGridViewRow row = new DataGridViewRow();

                //行のカウント
                for (int i = 0; i < bookListView.Rows.Count; i++)
                {
                    row = (DataGridViewRow)bookListView.Rows[i].Clone();

                    //row[i][intColIndex]
                    int intColIndex = 0;

                    //チェックボックスに☑が入っているか確認
                    Object checkBox = ((DataGridViewCheckBoxCell)((DataGridViewRow)bookListView.Rows[i]).Cells[0]).Value;
                    //MessageBox.Show("☑判定：" + checkBox);

                    if ((checkBox != null) && ((bool)checkBox == true))
                    {
                        //列のコピー
                        foreach (DataGridViewCell cell in bookListView.Rows[i].Cells)
                        {
                            //セルの値を1つずつコピーする
                            row.Cells[intColIndex].Value = cell.Value;
                            //MessageBox.Show("row.Cells[intColIndex].Value : " + row.Cells[intColIndex].Value);

                            intColIndex++;
                            //MessageBox.Show("リスト追加 " + intColIndex);
                        }
                        ed.editGridView.Rows.Add(row);
                    }
                    //各データを編集可能に設定する
                    //ed.editGridView.Columns[i].ReadOnly = false;
                }
                ed.editGridView.AllowUserToAddRows = false;
                ed.editGridView.Refresh();
                ed.ShowDialog();     //画面表示
                ed.Dispose();        //リソースの開放
            }
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("登録ボタン");

            //検索画面を表示
            using (Add add = new Add())
            {
                add.ShowDialog();     //画面表示
                add.Dispose();        //リソースの開放
            }
        }

        private void approvalButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("承認ボタン");

            //検索画面を表示
            using (Approval a = new Approval())
            {
                a.ShowDialog();     //画面表示
                a.Dispose();        //リソースの開放
            }
        }

        private void Search_Load(object sender, EventArgs e)
        {
            adminiCheckBox.Visible = false;

            //管理者権限でログインしていない時(ユーザーの時)
            if (adminiCheckBox.Checked == false)
            {
                addButton.Visible = false;          //登録ボタン非表示
                editButton.Visible = false;         //更新ボタン非表示
                deleteButton.Visible = false;       //削除ボタン非表示
                approvalButton.Visible = false;     //承認ボタン非表示

            }
        }   
    }
}