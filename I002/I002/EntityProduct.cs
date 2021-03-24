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
    public class EntityProduct
    {

        public void ReadProduct(DataGridView tableForProduct)
        {
            using(SqlConnection conn = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=I002;User ID=student;Password=Passw0rd"))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT * FROM Product WHERE Removed = @Rem ";
                    SqlCommand ReadProduct = new SqlCommand(query, conn);
                    ReadProduct.Parameters.AddWithValue(@"Rem",0);
                    SqlDataReader reader = ReadProduct.ExecuteReader();
                    DataTable table = new DataTable();
                    table.Load(reader);
                    tableForProduct.DataSource = table;
                    tableForProduct.Update();
                    tableForProduct.Columns[1].HeaderText = "Наименование";
                    tableForProduct.Columns[0].Visible = false;
                    tableForProduct.Columns[2].Visible = false;
                    tableForProduct.ClearSelection();
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        public void AddProduct(string name)
        {
            using (SqlConnection conn = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=I002;User ID=student;Password=Passw0rd"))
            {
                try
                {
                    conn.Open();
                    string query = "Insert into Product values (@Name,@Rem) ";
                    SqlCommand AddProduct = new SqlCommand(query, conn);
                    AddProduct.Parameters.AddWithValue(@"Name", name);
                    AddProduct.Parameters.AddWithValue(@"Rem", 0);
                    try
                    {
                        AddProduct.ExecuteNonQuery();
                        MessageBox.Show("Продукт успешно добавлен!");
                    }
                    catch
                    {
                        MessageBox.Show("Такой продукт уже существует!");
                    }
                   
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

        public void ChangeProduct(string name, int number)
        {
            using (SqlConnection conn = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=I002;User ID=student;Password=Passw0rd"))
            {
                try
                {
                    conn.Open();
                    string query = "Update Product set Name = @Name WHERE ArticleNumber = @number ";
                    SqlCommand AddProduct = new SqlCommand(query, conn);
                    AddProduct.Parameters.AddWithValue(@"Name", name);
                    AddProduct.Parameters.AddWithValue(@"number", number);
                    AddProduct.ExecuteNonQuery();
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

        public void DeleteProduct(int number)
        {
            using (SqlConnection conn = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=I002;User ID=student;Password=Passw0rd"))
            {
                try
                {
                    conn.Open();
                    string query = "Update Product set Removed = @Rem WHERE ArticleNumber = @number ";
                    SqlCommand AddProduct = new SqlCommand(query, conn);
                    AddProduct.Parameters.AddWithValue(@"Rem", 1);
                    AddProduct.Parameters.AddWithValue(@"number", number);
                    AddProduct.ExecuteNonQuery();
                    MessageBox.Show("Запись успешно заархивирована!");
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

        public void FindProduct(DataGridView tableForProduct, string find)
        {
            using (SqlConnection conn = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=I002;User ID=student;Password=Passw0rd"))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT ArticleNumber, Name FROM Product Where Name like'%" + find + "%' and Removed = @Rem ";
                    SqlCommand ReadProduct = new SqlCommand(query, conn);
                    ReadProduct.Parameters.AddWithValue(@"Rem", 0);
                    SqlDataReader reader = ReadProduct.ExecuteReader();
                    DataTable table = new DataTable();
                    table.Load(reader);
                    tableForProduct.DataSource = table;
                    tableForProduct.Update();
                    tableForProduct.Columns[1].HeaderText = "Наименование";
                    tableForProduct.Columns[0].Visible = false;
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
