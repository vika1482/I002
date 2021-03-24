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
    class EntityCounteragent
    {
        public void ReadCounteragent(DataGridView tableForCounteragent,int Role)
        {
            using (SqlConnection conn = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=I002;User ID=student;Password=Passw0rd"))
            {
                SqlDataReader reader = null;
                try
                {
                    conn.Open();
                    string query = "SELECT IdСounteragent,Surname,Name,MiddleName,INN,Adress,Phone FROM Сounteragent WHERE Removed = @Rem and Role = @RoleId ";
                    SqlCommand ReadCounteragent = new SqlCommand(query, conn);
                    ReadCounteragent.Parameters.AddWithValue(@"Rem", 0);
                    ReadCounteragent.Parameters.AddWithValue(@"RoleId", Role);
                    reader = ReadCounteragent.ExecuteReader();
                    DataTable table = new DataTable();
                    table.Load(reader);
                    tableForCounteragent.DataSource = table;
                    tableForCounteragent.Update();
                    tableForCounteragent.Columns[0].Visible = false;
                    tableForCounteragent.Columns[1].HeaderText = "Фамилия";
                    tableForCounteragent.Columns[2].HeaderText = "Имя";
                    tableForCounteragent.Columns[3].HeaderText = "Отчество";
                    tableForCounteragent.Columns[4].HeaderText = "Инн";
                    tableForCounteragent.Columns[5].HeaderText = "Адрес";
                    tableForCounteragent.Columns[6].HeaderText = "Телефон";
                    tableForCounteragent.ClearSelection();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                finally
                {
                    reader.Close();
                    conn.Close();
                }
            }
        }

        public void AddCounteragent(string Surname,string Name,string MiddleName, string INN, string Adress,string Phone,int RoleId)
        {
            using (SqlConnection conn = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=I002;User ID=student;Password=Passw0rd"))
            {
                try
                {
                    conn.Open();
                    string query = "Insert into Сounteragent values (@Surname,@Name,@MiddleName,@INN,@Adress,@Phone,@RoleId,@Rem) ";
                    SqlCommand AddProduct = new SqlCommand(query, conn);
                    AddProduct.Parameters.AddWithValue(@"Surname", Surname);
                    AddProduct.Parameters.AddWithValue(@"Name", Name);
                    AddProduct.Parameters.AddWithValue(@"MiddleName", MiddleName);
                    AddProduct.Parameters.AddWithValue(@"INN", INN);
                    AddProduct.Parameters.AddWithValue(@"Adress", Adress);
                    AddProduct.Parameters.AddWithValue(@"Phone", Phone);
                    AddProduct.Parameters.AddWithValue(@"RoleId", RoleId);
                    AddProduct.Parameters.AddWithValue(@"Rem", 0);
                    try
                    {
                        AddProduct.ExecuteNonQuery();
                        MessageBox.Show("Запись успешно добавлена!");
                    }
                    catch
                    {
                        MessageBox.Show("Такой пользователь уже существует!");
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

        public void ChangeCounteragent(string Surname, string Name, string MiddleName, string INN, string Adress, string Phone,string Id)
        {
            using (SqlConnection conn = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=I002;User ID=student;Password=Passw0rd"))
            {
                try
                {
                    conn.Open();
                    string query = "Update Сounteragent  Set Surname = @Surname, Name = @Name, MiddleName = @MiddleName, INN = @INN, Adress = @Adress, Phone = @Phone WHERE IdСounteragent = @Id ";
                    SqlCommand AddProduct = new SqlCommand(query, conn);
                    AddProduct.Parameters.AddWithValue(@"Surname", Surname);
                    AddProduct.Parameters.AddWithValue(@"Name", Name);
                    AddProduct.Parameters.AddWithValue(@"MiddleName", MiddleName);
                    AddProduct.Parameters.AddWithValue(@"INN", INN);
                    AddProduct.Parameters.AddWithValue(@"Adress", Adress);
                    AddProduct.Parameters.AddWithValue(@"Phone", Phone);
                    AddProduct.Parameters.AddWithValue(@"Id", Id);
                    AddProduct.ExecuteNonQuery();
                    MessageBox.Show("Запись успешно изменена!");
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

        public void DeleteCounteragent(string number)
        {
            using (SqlConnection conn = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=I002;User ID=student;Password=Passw0rd"))
            {
                try
                {
                    conn.Open();
                    string query = "Update Сounteragent set Removed = @Rem WHERE IdСounteragent = @number ";
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

        public void FindCounteragent(DataGridView tableForCounteragent,int Role, string find)
        {
            using (SqlConnection conn = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=I002;User ID=student;Password=Passw0rd"))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT IdСounteragent,Surname,Name,MiddleName,INN,Adress,Phone FROM Сounteragent WHERE Removed = @Rem and Role =@RoleId and (Surname like '%" + find + "%' or Name like '%" + find + "%' or MiddleName like '%" + find + "%' or INN like '%" + find + "%' or Adress like'%" + find + "%' or Phone like'%" + find + "%')  ";
                    SqlCommand ReadCounteragent = new SqlCommand(query, conn);
                    ReadCounteragent.Parameters.AddWithValue(@"Rem", 0);
                    ReadCounteragent.Parameters.AddWithValue(@"RoleId", Role);
                    SqlDataReader reader = ReadCounteragent.ExecuteReader();
                    DataTable table = new DataTable();
                    table.Load(reader);
                    tableForCounteragent.DataSource = table;
                    tableForCounteragent.Update();
                    tableForCounteragent.Columns[0].Visible = false;
                    tableForCounteragent.Columns[1].HeaderText = "Фамилия";
                    tableForCounteragent.Columns[2].HeaderText = "Имя";
                    tableForCounteragent.Columns[3].HeaderText = "Отчество";
                    tableForCounteragent.Columns[4].HeaderText = "Инн";
                    tableForCounteragent.Columns[5].HeaderText = "Адрес";
                    tableForCounteragent.Columns[6].HeaderText = "Телефон";
                    tableForCounteragent.ClearSelection();
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
