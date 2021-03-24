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
    class EntityProductOnStorage
    {
        public void ReadProduct(DataGridView tableForProduct)
        {
            using (SqlConnection conn = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=I002;User ID=student;Password=Passw0rd"))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT PrSt.IdProductOnStorage,PrSt.IdProduct, Pr.Name, PrSt.Quantity, PrSt.Price FROM ProductOnStorage AS PrSt INNER JOIN Product AS Pr ON PrSt.IdProduct = Pr.ArticleNumber  ";
                    SqlCommand ReadProduct = new SqlCommand(query, conn);
                    SqlDataReader reader = ReadProduct.ExecuteReader();
                    DataTable table = new DataTable();
                    table.Load(reader);
                    for(int i =0; i< table.Rows.Count;i++)
                    {
                        table.Rows[i][4] = Math.Round(Convert.ToDouble(table.Rows[i][4]), 2);
                    }
                    tableForProduct.DataSource = table;
                    tableForProduct.Update();
                    tableForProduct.Columns[0].Visible = false;
                    tableForProduct.Columns[1].Visible = false;
                    tableForProduct.Columns[2].HeaderText = "Наименование";
                    tableForProduct.Columns[3].HeaderText = "Количество";
                    tableForProduct.Columns[4].HeaderText = "Цена (руб.партия)";
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

        public void BuyProduct(string IDCounteragent, DataGridView tableForProduct)
        {
            using (SqlConnection conn = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=I002;User ID=student;Password=Passw0rd"))
            {

                DateTime dateTime = DateTime.Today;
                int MaxComing;
                try
                {
                    conn.Open();
                    string insertComing = "INSERT INTO Coming values(@IdCounteragent,@date)";
                    string selectMaxComing = "SELECT Max(IDComing) FROM Coming";
                    string insertComingProduct = "INSERT INTO ProductComing values(@IDComing,@IDProduct,@Price,@Quantity)";
                    SqlCommand InsertComing = new SqlCommand(insertComing, conn);
                    InsertComing.Parameters.AddWithValue(@"IdCounteragent", IDCounteragent);
                    InsertComing.Parameters.AddWithValue(@"date", dateTime);
                    InsertComing.ExecuteNonQuery();
                    SqlCommand SelectMaxComing = new SqlCommand(selectMaxComing, conn);
                    MaxComing = Convert.ToInt32(SelectMaxComing.ExecuteScalar());
                    for(int i = 0; i< tableForProduct.Rows.Count;i++)
                    {
                        SqlCommand InsertComingProduct = new SqlCommand(insertComingProduct, conn);
                        InsertComingProduct.Parameters.AddWithValue(@"IDComing", MaxComing);
                        InsertComingProduct.Parameters.AddWithValue(@"IDProduct", tableForProduct[0,i].Value.ToString());
                        InsertComingProduct.Parameters.AddWithValue(@"Price", tableForProduct[2, i].Value.ToString());
                        InsertComingProduct.Parameters.AddWithValue(@"Quantity", tableForProduct[3, i].Value.ToString());
                        InsertComingProduct.ExecuteNonQuery();
                    }
                    for(int i = 0; i < tableForProduct.Rows.Count; i++)
                    {
                        if (CheckProductOnStorage(tableForProduct[0, i].Value.ToString()))
                        {
                            double Price = Convert.ToDouble(tableForProduct[2, i].Value);
                            Price += (Convert.ToDouble(tableForProduct[2, i].Value) * 0.05);
                            int Quantity = Convert.ToInt32(tableForProduct[3, i].Value);
                            string selectQuantityOnStorage = "SELECT Quantity FROM ProductOnStorage WHERE IdProduct = @IdProduct";
                            SqlCommand SelectQuantityOnStorage = new SqlCommand(selectQuantityOnStorage, conn);
                            SelectQuantityOnStorage.Parameters.AddWithValue(@"IdProduct", tableForProduct[0, i].Value.ToString());
                            int QuantityOnStorage = Convert.ToInt32(SelectQuantityOnStorage.ExecuteScalar());
                            QuantityOnStorage += Quantity;
                            string insertProductOnStorage = "Update ProductOnStorage set Quantity = @Quantity, Price = @Price WHERE IdProduct = @IdProduct ";
                            SqlCommand InsertProductOnStorage = new SqlCommand(insertProductOnStorage, conn);
                            InsertProductOnStorage.Parameters.AddWithValue(@"IdProduct", tableForProduct[0, i].Value.ToString());
                            InsertProductOnStorage.Parameters.AddWithValue(@"Quantity", QuantityOnStorage);
                            InsertProductOnStorage.Parameters.AddWithValue(@"Price", Price);
                            InsertProductOnStorage.ExecuteNonQuery();
                            
                        }
                        else
                        {
                            double Price = Convert.ToDouble(tableForProduct[2, i].Value);
                            Price += Convert.ToDouble(tableForProduct[2, i].Value) * 0.05;
                            string insertProductOnStorage = "INSERT INTO ProductOnStorage values(@IdProduct,@Quantity,@Price)";
                            SqlCommand InsertProductOnStorage = new SqlCommand(insertProductOnStorage, conn);
                            InsertProductOnStorage.Parameters.AddWithValue(@"IdProduct", tableForProduct[0, i].Value.ToString());
                            InsertProductOnStorage.Parameters.AddWithValue(@"Quantity", tableForProduct[3, i].Value.ToString());
                            InsertProductOnStorage.Parameters.AddWithValue(@"Price", Price);
                            InsertProductOnStorage.ExecuteNonQuery();
                            
                        }
                        
                    }
                    MessageBox.Show("Товар успешно закуплен!");

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

        public bool CheckProductOnStorage(string IdProduct)
        {
            bool result = false;
            using (SqlConnection conn = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=I002;User ID=student;Password=Passw0rd"))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT IdProductOnStorage FROM ProductOnStorage WHERE IdProduct = @IdProduct";
                    SqlCommand SelectProduct = new SqlCommand(query, conn);
                    SelectProduct.Parameters.AddWithValue(@"IdProduct", IdProduct);
                    if (SelectProduct.ExecuteScalar() != null) result = true;
                    else result = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                finally
                {
                    conn.Close();
                }
                return result;
            }
        }
       
        public void SellProduct(string IDCounteragent, DataGridView tableForProduct)
        {
            using (SqlConnection conn = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=I002;User ID=student;Password=Passw0rd"))
            {
                DateTime dateTime = DateTime.Today;
                int MaxPurchase;
                try
                {
                    conn.Open();
                    string insertPurchase = "INSERT INTO Purchase values(@IdCounteragent,@date)";
                    string selectMaxPurchase = "SELECT Max(IDPurchase) FROM Purchase";
                    string insertProductPurchase = "INSERT INTO ProductPurchase values(@IDPurchase,@IDProduct,@Price,@Quantity)";
                    SqlCommand InsertPurchase = new SqlCommand(insertPurchase, conn);
                    InsertPurchase.Parameters.AddWithValue(@"IdCounteragent", IDCounteragent);
                    InsertPurchase.Parameters.AddWithValue(@"date", dateTime);
                    InsertPurchase.ExecuteNonQuery();
                    SqlCommand SelectMaxPurchase = new SqlCommand(selectMaxPurchase, conn);
                    MaxPurchase = Convert.ToInt32(SelectMaxPurchase.ExecuteScalar());
                    for (int i = 0; i < tableForProduct.Rows.Count; i++)
                    {
                        SqlCommand InsertComingProduct = new SqlCommand(insertProductPurchase, conn);
                        InsertComingProduct.Parameters.AddWithValue(@"IDPurchase", MaxPurchase);
                        InsertComingProduct.Parameters.AddWithValue(@"IDProduct", tableForProduct[0, i].Value.ToString());
                        InsertComingProduct.Parameters.AddWithValue(@"Price", tableForProduct[2, i].Value.ToString());
                        InsertComingProduct.Parameters.AddWithValue(@"Quantity", tableForProduct[3, i].Value.ToString());
                        InsertComingProduct.ExecuteNonQuery();
                    }
                    for (int i = 0; i < tableForProduct.Rows.Count; i++)
                    {
                        int Quantity = Convert.ToInt32(tableForProduct[3, i].Value.ToString());
                        string selectQuantityOnStorage = "SELECT Quantity FROM ProductOnStorage WHERE IdProduct = @IdProduct";
                        SqlCommand SelectQuantityOnStorage = new SqlCommand(selectQuantityOnStorage, conn);
                        SelectQuantityOnStorage.Parameters.AddWithValue(@"IdProduct", tableForProduct[0, i].Value.ToString());
                        int QuantityOnStorage = Convert.ToInt32(SelectQuantityOnStorage.ExecuteScalar());
                        QuantityOnStorage -= Quantity;
                        if (QuantityOnStorage != 0)
                        {
                            string insertProductOnStorage = "Update ProductOnStorage set Quantity = @Quantity WHERE IdProduct = @IdProduct ";
                            SqlCommand InsertProductOnStorage = new SqlCommand(insertProductOnStorage, conn);
                            InsertProductOnStorage.Parameters.AddWithValue(@"IdProduct", tableForProduct[0, i].Value.ToString());
                            InsertProductOnStorage.Parameters.AddWithValue(@"Quantity", QuantityOnStorage);
                            InsertProductOnStorage.ExecuteNonQuery();
                            MessageBox.Show("Товар успешно продан!");
                        }
                        else
                        {
                            string DeleteProductOnStorage = "Delete From ProductOnStorage Where IdProduct = @IdProduct";
                            SqlCommand InsertProductOnStorage = new SqlCommand(DeleteProductOnStorage, conn);
                            InsertProductOnStorage.Parameters.AddWithValue(@"IdProduct", tableForProduct[0, i].Value.ToString());
                            InsertProductOnStorage.ExecuteNonQuery();
                            MessageBox.Show("Товар успешно продан!\n\nПокупатель забрал последнюю партию товара, на складе он закончился,\n рекомендуем закупить еще!");

                        }

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

        public void FindProduct(DataGridView tableForProduct, string find)
        {
            using (SqlConnection conn = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=I002;User ID=student;Password=Passw0rd"))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT PrSt.IdProductOnStorage,PrSt.IdProduct, Pr.Name, PrSt.Quantity, PrSt.Price FROM ProductOnStorage AS PrSt INNER JOIN Product AS Pr ON PrSt.IdProduct = Pr.ArticleNumber Where Pr.Name like '%"+find+ "%' OR PrSt.Quantity like '%" + find + "%' OR PrSt.Price like '%" + find + "%' ";
                    SqlCommand ReadProduct = new SqlCommand(query, conn);
                    SqlDataReader reader = ReadProduct.ExecuteReader();
                    DataTable table = new DataTable();
                    table.Load(reader);
                    for (int i = 0; i < table.Rows.Count; i++)
                    {
                        table.Rows[i][4] = Math.Round(Convert.ToDouble(table.Rows[i][4]), 2);
                    }
                    tableForProduct.DataSource = table;
                    tableForProduct.Update();
                    tableForProduct.Columns[0].Visible = false;
                    tableForProduct.Columns[1].Visible = false;
                    tableForProduct.Columns[2].HeaderText = "Наименование";
                    tableForProduct.Columns[3].HeaderText = "Количество";
                    tableForProduct.Columns[4].HeaderText = "Цена (руб.партия)";
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
