﻿using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Archive
{
    public partial class Search : Form
    {
        //ユーザーID
        private string userId;
        public Search() //親Form
        {
            InitializeComponent();

            //user_idテキストボックスを非表示
            this.user_id.Visible = false;
        }

        //英数字と_以外
        Regex regId = new Regex(@"[^0-9a-zA-Z_]");

        //#以外の記号
        Regex regName = new Regex(@"[!-"":-@[$-/:-@[-`{-~ ]");


        //書籍IDの禁則処理
        private void book_id_TextChanged(object sender, EventArgs e)
        {            
            int i = this.book_id.SelectionStart;            
            this.book_id.Text = regId.Replace(this.book_id.Text, "");            
            this.book_id.SelectionStart = i;
        }

        //書籍名の禁則処理
        private void Book_name_TextChanged(object sender, EventArgs e)
        {
            int j = this.book_name.SelectionStart;
            this.book_name.Text = regName.Replace(this.book_name.Text, "");
            this.book_name.SelectionStart = j;
        }

        //検索結果表示画面の設定メソッド
        private void BookListViewSetting()
        {
            // DataGridView初期化（データクリア）
            bookListView.Columns.Clear();

            //CheckBox列を追加する
            DataGridViewCheckBoxColumn column = new DataGridViewCheckBoxColumn();
            bookListView.Columns.Add(column);

            bookListView.Columns[0].FillWeight = 40;

            //DataGridViewの表示幅に合わせて列幅自動調整
            bookListView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        //チェックボックスのtrue,false判定-----------------------------------------------------------------------------
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
        private void bookListView_CellValueChanged(object sender, DataGridViewCellEventArgs e) { }
        //---------------------------------------------------------------------------------------------------------

        //検索処理
        private void searchButton_Click(object sender, EventArgs e)
        {
            //TextBoxに入力した値を受け取る。
            string book_id = this.book_id.Text;
            string book_name = this.book_name.Text;

            //DBに接続する処理
            string sLogin = "server=localhost; database=books; userid=bks2; password=bksbooklist;";

            MySqlConnection cn = new MySqlConnection(sLogin);

            //現在日付取得
            DateTime dtn = DateTime.Now;
            string DateTimeNow = dtn.ToString("yyyy/MM/dd");

            //SQL文作成
            string sql = "START TRANSACTION; " +
                         "SELECT BOOK_ID ,BOOK_NAME ,LOAN_DATE ,RETURN_DATE , " +
                         "CASE WHEN REQUEST_FLAG = 1 THEN '申請中' " +
                         "WHEN RETURN_DATE < '" + DateTimeNow + "' THEN '期限切れ' " +
                         "WHEN RETURN_DATE >= '" + DateTimeNow + "' THEN '貸出中' " +
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
                //貸出可能のチェックが入っている時の処理
                if (canBorrowCheckBox.Checked == true)
                {
                    if ((!string.IsNullOrEmpty(book_id)) && (!string.IsNullOrEmpty(book_name)))
                    {
                        sql = sql + "WHERE BOOK_ID LIKE '" + book_id + "%' AND BOOK_NAME LIKE '%" + book_name + "%' AND REQUEST_FLAG = 0 AND APPROVAL_FLAG = 0";
                    }

                    else if (!string.IsNullOrEmpty(book_id))
                    {
                        sql = sql + "WHERE BOOK_ID LIKE '" + book_id + "%'AND REQUEST_FLAG = 0 AND APPROVAL_FLAG = 0";
                    }

                    else if (!string.IsNullOrEmpty(book_name))
                    {
                        sql = sql + "WHERE BOOK_NAME LIKE '%" + book_name + "%' AND REQUEST_FLAG = 0 AND APPROVAL_FLAG = 0";
                    }

                    else sql = sql + "WHERE REQUEST_FLAG = 0 AND APPROVAL_FLAG = 0";
                }
                else
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
            }
            sql = sql +"; " + "COMMIT;";

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
            }
            catch (MySqlException me)
            {
                MessageBox.Show("ERROR: " + me.Message);
            }
            finally
            {
                //DBとの接続をcloseする
                cn.Close();
            }
            // 検索画面で表示するカラム名を設定
            bookListView.Columns[0].HeaderText = "選択";
            bookListView.Columns[1].HeaderText = "書籍ID";
            bookListView.Columns[2].HeaderText = "書籍名";
            bookListView.Columns[3].HeaderText = "貸出日";
            bookListView.Columns[4].HeaderText = "返却期日";
            bookListView.Columns[5].HeaderText = "状態";       

            //☑以外を読み取り専用にする
            bookListView.Columns[1].ReadOnly = true;
            bookListView.Columns[2].ReadOnly = true;
            bookListView.Columns[3].ReadOnly = true;
            bookListView.Columns[4].ReadOnly = true;
            bookListView.Columns[5].ReadOnly = true;

            //日付のフォーマット指定
            this.bookListView.Columns[3].DefaultCellStyle.Format = "yyyy/MM/dd";
            this.bookListView.Columns[4].DefaultCellStyle.Format = "yyyy/MM/dd";

            //期限切れの行を着色する
            this.ExpiredRowsBackColorChange();
        }

        //期限切れの行を着色する
        private void ExpiredRowsBackColorChange()
        {
            for (int i = 0; i < bookListView.Rows.Count; i++)
            {
                if (this.bookListView.Rows[i].Cells[5].Value?.ToString() == "期限切れ")
                {
                    bookListView.Rows[i].DefaultCellStyle.BackColor = Color.LightPink;
                }
            }
        }

        //ソート完了時の処理
        private void bookListView_Sorted(object sender, EventArgs e)
        {
            ExpiredRowsBackColorChange();
        }        

        //申請処理
        private void requestButton_Click(object sender, EventArgs e)
        {
            //1つでも☑があるかの確認
            bool Checked = false;

            //行のカウント
            for (int i = 0; i < bookListView.Rows.Count; i++)
            {
                Object checkBox = ((DataGridViewCheckBoxCell)((DataGridViewRow)bookListView.Rows[i]).Cells[0]).Value;

                if ((checkBox != null) && ((bool)checkBox == true))
                {
                    Checked = true;

                    //貸出日、返却期日、状態がすべて空欄でない場合
                    if (!(this.bookListView.Rows[i].Cells[3].Value?.ToString() == "" && this.bookListView.Rows[i].Cells[4].Value?.ToString() == "" &&
                        this.bookListView.Rows[i].Cells[3].Value?.ToString() == ""))
                    {
                        MessageBox.Show("貸出中のため申請できません");
                        return;
                    }
                }
            }

            //1つでも☑がなかった場合
            if (!Checked)
            {
                MessageBox.Show("１つ以上選択してください");
                return;
            }

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

                r.requestGridView.Columns[0].FillWeight = 40;
                //requestGridviewの表示幅に合わせてデータが出るようにする
                r.requestGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                //申請画面で表示するカラム名を設定
                r.requestGridView.Columns[0].HeaderText = "選択";
                r.requestGridView.Columns[1].HeaderText = "書籍ID";
                r.requestGridView.Columns[2].HeaderText = "書籍名";
                r.requestGridView.Columns[3].HeaderText = "貸出日";
                r.requestGridView.Columns[4].HeaderText = "返却期日";
                r.requestGridView.Columns[5].HeaderText = "状態";

                //申請画面のソートモードを解除する
                r.requestGridView.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;
                r.requestGridView.Columns[1].SortMode = DataGridViewColumnSortMode.NotSortable;
                r.requestGridView.Columns[2].SortMode = DataGridViewColumnSortMode.NotSortable;
                r.requestGridView.Columns[3].SortMode = DataGridViewColumnSortMode.NotSortable;
                r.requestGridView.Columns[4].SortMode = DataGridViewColumnSortMode.NotSortable;
                r.requestGridView.Columns[5].SortMode = DataGridViewColumnSortMode.NotSortable;

                r.requestGridView.AllowUserToAddRows = false;
                r.requestGridView.Refresh();

                r.user_id.Text = userId;

                r.ShowDialog();     //画面表示
                r.Dispose();        //リソースの開放
            }
            //検索結果を更新           
            updateBookListView();
        }

        // 更新処理
        private void editButton_Click(object sender, EventArgs e)
        {
            //1つでも☑があるかの確認
            bool Checked = false;

            //行のカウント
            for (int i = 0; i < bookListView.Rows.Count; i++)
            {
                Object checkBox = ((DataGridViewCheckBoxCell)((DataGridViewRow)bookListView.Rows[i]).Cells[0]).Value;

                if ((checkBox != null) && ((bool)checkBox == true))
                {
                    Checked = true;

                    //貸出日、返却期日、状態がすべて空欄でない場合
                    if (!(this.bookListView.Rows[i].Cells[3].Value?.ToString() == "" && this.bookListView.Rows[i].Cells[4].Value?.ToString() == "" &&
                        this.bookListView.Rows[i].Cells[3].Value?.ToString() == ""))
                    {
                        MessageBox.Show("貸出中のため編集できません");
                        return;
                    }
                }
            }

            //1つでも☑がなかった場合
            if (!Checked)
            {
                MessageBox.Show("１つ以上選択してください");
                return;
            }

            MessageBox.Show("編集画面表示します");


            //更新用画面を表示
            using (Edit ed = new Edit())
            {
                //更新画面に何も表示されていない場合
                if (ed.editGridView.Columns.Count == 0)
                {
                    //配列の中身を取り出し、更新画面用のDataGridViewに追加する
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
                //書籍名のみ編集可能に設定する
                ed.editGridView.Columns[2].ReadOnly = false;

                ed.editGridView.Columns[0].FillWeight = 40;
                //edidGridviewの表示幅に合わせてデータが出るようにする
                ed.editGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                // 更新画面で表示するカラム名を設定
                ed.editGridView.Columns[0].HeaderText = "選択";
                ed.editGridView.Columns[1].HeaderText = "書籍ID";
                ed.editGridView.Columns[2].HeaderText = "書籍名";
                ed.editGridView.Columns[3].HeaderText = "貸出日";
                ed.editGridView.Columns[4].HeaderText = "返却期日";
                ed.editGridView.Columns[5].HeaderText = "状態";

                // ユーザー側の操作で行を追加できないように設定
                ed.editGridView.AllowUserToAddRows = false;
                ed.editGridView.Refresh();
                ed.ShowDialog();     //画面表示
                ed.Dispose();        //リソースの開放
            }
            //検索結果を更新           
            updateBookListView();
        }

        //登録処理
        private void addButton_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("登録ボタン");

            //検索画面を表示
            using (Add add = new Add())
            {
                add.ShowDialog();     //画面表示
                add.Dispose();        //リソースの開放                
            }

            //検索結果を更新           
            updateBookListView();
        }        

        //削除処理

        private void deleteButton_Click(object sender, EventArgs e)
        {
            //1つでも☑があるかの確認
            bool Checked = false;

            //行カウント
            for (int i = 0; i < bookListView.Rows.Count; i++)
            {
                Object checkBox = ((DataGridViewCheckBoxCell)((DataGridViewRow)bookListView.Rows[i]).Cells[0]).Value;

                if ((checkBox != null) && ((bool)checkBox == true))
                {
                    Checked = true;
                }
            }

            //1つでも☑がなかった場合
            if (!Checked)
            {
                MessageBox.Show("１つ以上選択してください");
                return;
            }

            DialogResult result = MessageBox.Show("削除しますか", "", MessageBoxButtons.OKCancel);

            //「はい」を選んだ場合
            if (result == DialogResult.OK)
            {
                string book_ids = "''";

                //☑のついてるidを取得
                for (int i = 0; i < bookListView.Rows.Count; i++)
                {
                    Object checkBox = ((DataGridViewCheckBoxCell)((DataGridViewRow)bookListView.Rows[i]).Cells[0]).Value;

                    if ((checkBox != null) && ((bool)checkBox == true))
                    {
                        book_ids += ",'" + this.bookListView.Rows[i].Cells[1].Value?.ToString() + "'";
                    }
                }

                //DBに接続する処理
                string sLogin = "server=localhost; database=books; userid=bks2; password=bksbooklist;";

                MySqlConnection cn = new MySqlConnection(sLogin);

                //SQL文作成
                string sql = "START TRANSACTION; " + "DELETE FROM books.books WHERE BOOK_ID IN (" + book_ids + "); " + "COMMIT;";

                //処理実行
                DataTable dt = new DataTable();

                //SQL文実行
                MySqlCommand cmd = new MySqlCommand(sql, cn);

                try
                {
                    //DBとの接続
                    cmd.Connection.Open();

                    //処理実行
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("削除完了");
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
                //検索結果を更新                       
                updateBookListView();

            }//「いいえ」を選んだ場合
            else if (result == DialogResult.Cancel)
            {
                return;
            }
        }

        //検索画面読み込み
        private void Search_Load(object sender, EventArgs e)
        {
            
            adminiCheckBox.Visible = false;

            //管理者権限でログインしていない時(ユーザーの時)
            if (adminiCheckBox.Checked == false)
            {
                addButton.Visible = false;          //登録ボタン非表示
                editButton.Visible = false;         //更新ボタン非表示
                deleteButton.Visible = false;       //削除ボタン非表示
                //approvalButton.Visible = false;     //承認ボタン非表示
                //AdduserButton.Visible = false;      //ユーザー登録ボタン非表示

            }
        }

        //検索結果一覧を更新する
        private void updateBookListView()
        {
            //TextBoxに入力した値を受け取る。
            string book_id = this.book_id.Text;
            string book_name = this.book_name.Text;

            //DBに接続する処理
            string sLogin = "server=localhost; database=books; userid=bks2; password=bksbooklist;";

            MySqlConnection cn = new MySqlConnection(sLogin);

            //現在日付取得
            DateTime dtn = DateTime.Now;
            string DateTimeNow = dtn.ToString("yyyy/MM/dd");

            //SQL文作成
            string sql = "START TRANSACTION; " +
                         "SELECT BOOK_ID ,BOOK_NAME ,LOAN_DATE ,RETURN_DATE , " +
                         "CASE WHEN REQUEST_FLAG = 1 THEN '申請中' " +
                         "WHEN RETURN_DATE < '" + DateTimeNow + "' THEN '期限切れ' " +
                         "WHEN RETURN_DATE >= '" + DateTimeNow + "' THEN '貸出中' " +
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
                //貸出可能のチェックが入っている時の処理
                if (canBorrowCheckBox.Checked == true)
                {
                    if ((!string.IsNullOrEmpty(book_id)) && (!string.IsNullOrEmpty(book_name)))
                    {
                        sql = sql + "WHERE BOOK_ID LIKE '" + book_id + "%' AND BOOK_NAME LIKE '%" + book_name + "%' AND REQUEST_FLAG = 0 AND APPROVAL_FLAG = 0";
                    }

                    else if (!string.IsNullOrEmpty(book_id))
                    {
                        sql = sql + "WHERE BOOK_ID LIKE '" + book_id + "%'AND REQUEST_FLAG = 0 AND APPROVAL_FLAG = 0";
                    }

                    else if (!string.IsNullOrEmpty(book_name))
                    {
                        sql = sql + "WHERE BOOK_NAME LIKE '%" + book_name + "%' AND REQUEST_FLAG = 0 AND APPROVAL_FLAG = 0";
                    }

                    else sql = sql + "WHERE REQUEST_FLAG = 0 AND APPROVAL_FLAG = 0";
                }
                else
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
            }
            sql = sql + "; " + "COMMIT;";

            //処理実行
            DataTable dt = new DataTable();

            //SQL文実行
            MySqlDataAdapter da = new MySqlDataAdapter(sql, cn);

            try
            {
                cn.Open();

                da.Fill(dt);

                //検索結果表示画面の設定メソッド実行
                BookListViewSetting();

                //画面表示用のDataGridViewに取得データを設定
                bookListView.DataSource = dt;                
            }
            catch (MySqlException me)
            {
                MessageBox.Show("ERROR: " + me.Message);
            }
            finally
            {
                //DBとの接続をcloseする
                cn.Close();
            }

            // 検索画面で表示するカラム名を設定
            bookListView.Columns[0].HeaderText = "選択";
            bookListView.Columns[1].HeaderText = "書籍ID";
            bookListView.Columns[2].HeaderText = "書籍名";
            bookListView.Columns[3].HeaderText = "貸出日";
            bookListView.Columns[4].HeaderText = "返却期日";
            bookListView.Columns[5].HeaderText = "状態";

            //☑以外を読み取り専用にする
            bookListView.Columns[1].ReadOnly = true;
            bookListView.Columns[2].ReadOnly = true;
            bookListView.Columns[3].ReadOnly = true;
            bookListView.Columns[4].ReadOnly = true;
            bookListView.Columns[5].ReadOnly = true;

            //日付のフォーマット指定
            this.bookListView.Columns[3].DefaultCellStyle.Format = "yyyy/MM/dd";
            this.bookListView.Columns[4].DefaultCellStyle.Format = "yyyy/MM/dd";

            //期限切れの行を着色する
            this.ExpiredRowsBackColorChange();
        }
        private void canBorrowcheckBox_Changed(object sender, EventArgs e)
        {
            //貸出可能に☑が入っている時は、期限切れのチェックボックスを操作不可   
            if (canBorrowCheckBox.Checked == true)
            {
                expiredCheckBox.Enabled = false;
            }

            //☑が外れたら、☑できるようにする
            else if (canBorrowCheckBox.Checked == false)
            {
                expiredCheckBox.Enabled = true;
            }
        }

        private void expiredCheckBox_Changed(object sender, EventArgs e)
        {

            //期限切れに☑が入っている時は、貸出可能のチェックボックスを操作不可
            if (expiredCheckBox.Checked == true)
            {
                canBorrowCheckBox.Enabled = false;
            }

            //☑が外れたら、☑できるようにする
            else if (expiredCheckBox.Checked == false)
            {
                canBorrowCheckBox.Enabled = true;
            }
        }

        //Search.csから渡されたuserIdがテキストボックスに反映された時
        private void use_id_Changed(object sender, EventArgs e)
        {
            userId = this.user_id.Text;
        }        
    }
}
