using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace I002
{
    class EntityReport
    {
        public void MadeReportPurchase(DataGridView tableForReport)
        {
            using (SqlConnection conn = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=I002;User ID=student;Password=Passw0rd"))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT pur.IDPurchase,pur.DatePurchase,con.Surname,con.Name, con.MiddleName, con.INN FROM Purchase AS pur INNER JOIN Сounteragent AS con" +
                        " ON pur.IDCounteragent = con.IdСounteragent ";
                    SqlCommand ReadProduct = new SqlCommand(query, conn);
                    SqlDataReader reader = ReadProduct.ExecuteReader();
                    DataTable table = new DataTable();
                    table.Load(reader);
                    tableForReport.DataSource = table;
                    tableForReport.Update();
                    tableForReport.Columns[0].Visible = false;
                    tableForReport.Columns[1].Width = 120;
                    tableForReport.Columns[2].Width = 140;
                    tableForReport.Columns[3].Width = 140;
                    tableForReport.Columns[4].Width = 140;
                    tableForReport.Columns[5].Width = 188;
                    tableForReport.Columns[1].HeaderText = "Дата продажи";
                    tableForReport.Columns[2].HeaderText = "Фамилия";
                    tableForReport.Columns[3].HeaderText = "Имя";
                    tableForReport.Columns[4].HeaderText = "Отчество";
                    tableForReport.Columns[5].HeaderText = "INN";
                    tableForReport.ClearSelection();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        public void MadeReportComing(DataGridView tableForReport)
        {
            using (SqlConnection conn = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=I002;User ID=student;Password=Passw0rd"))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT com.IDComing,com.DateComing,con.Surname,con.Name, con.MiddleName, con.INN FROM Coming AS com INNER JOIN Сounteragent AS con" +
                        " ON com.IDСounteragent = con.IdСounteragent   ";
                    SqlCommand ReadProduct = new SqlCommand(query, conn);
                    SqlDataReader reader = ReadProduct.ExecuteReader();
                    DataTable table = new DataTable();
                    table.Load(reader);
                    tableForReport.DataSource = table;
                    tableForReport.Update();
                    tableForReport.Columns[0].Visible = false;
                    tableForReport.Columns[1].Width = 120;
                    tableForReport.Columns[2].Width = 140;
                    tableForReport.Columns[3].Width = 140;
                    tableForReport.Columns[4].Width = 140;
                    tableForReport.Columns[5].Width = 170;
                    tableForReport.Columns[1].HeaderText = "Дата закупки";
                    tableForReport.Columns[2].HeaderText = "Фамилия";
                    tableForReport.Columns[3].HeaderText = "Имя";
                    tableForReport.Columns[4].HeaderText = "Отчество";
                    tableForReport.Columns[5].HeaderText = "INN";
                    tableForReport.ClearSelection();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        public void CopmositionForProvider(DataGridView tableForProduct, string IDComing)
        {
            using (SqlConnection conn = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=I002;User ID=student;Password=Passw0rd"))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT p.Name,PrCom.Price, PrCom.Quantity FROM ProductComing AS PrCom INNER JOIN Product  AS p" +
                        " ON PrCom.IDProduct = p.ArticleNumber Where [IDComing] = @IDComing";
                    SqlCommand ReadProduct = new SqlCommand(query, conn);
                    ReadProduct.Parameters.AddWithValue(@"IDComing", IDComing);
                    SqlDataReader reader = ReadProduct.ExecuteReader();
                    DataTable table = new DataTable();
                    table.Load(reader);
                    for (int i = 0; i < table.Rows.Count; i++)
                    {
                        table.Rows[i][1] = Math.Round(Convert.ToDouble(table.Rows[i][1]), 2);
                    }
                    tableForProduct.DataSource = table;
                    tableForProduct.Update();
                    tableForProduct.Columns[0].HeaderText = "Наименование";
                    tableForProduct.Columns[1].HeaderText = "Цена,руб.партия";
                    tableForProduct.Columns[2].HeaderText = "Количество";
                    tableForProduct.ClearSelection();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                finally
                {
                    conn.Close();
                }
            }
        }
   
        public void CopmositionForPurchase(DataGridView tableForProduct, string IdPurchase)
        {
            using (SqlConnection conn = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=I002;User ID=student;Password=Passw0rd"))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT p.Name,PrPur.Price, PrPur.Quantity FROM ProductPurchase AS PrPur INNER JOIN Product  AS p" +
                        " ON PrPur.IDProduct = p.ArticleNumber Where [IDPurchase] = @IdPurchase";
                    SqlCommand ReadProduct = new SqlCommand(query, conn);
                    ReadProduct.Parameters.AddWithValue(@"IdPurchase", IdPurchase);
                    SqlDataReader reader = ReadProduct.ExecuteReader();
                    DataTable table = new DataTable();
                    table.Load(reader);
                    for(int i = 0;i< table.Rows.Count;i++)
                    {
                        table.Rows[i][1] = Math.Round(Convert.ToDouble(table.Rows[i][1]),2);
                    }
                    tableForProduct.DataSource = table;
                    tableForProduct.Update();
                    tableForProduct.Columns[0].HeaderText = "Наименование";
                    tableForProduct.Columns[1].HeaderText = "Цена,руб.партия";
                    tableForProduct.Columns[2].HeaderText = "Количество";
                    tableForProduct.ClearSelection();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                finally
                {
                    conn.Close();
                }
            }
        }

    }
}
