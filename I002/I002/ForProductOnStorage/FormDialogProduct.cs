using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace I002
{
    public partial class FormDialogProduct : Form
    {
        string IDProduct = null,NameProduct;
        DataGridView dataGridForProducts;

        public FormDialogProduct(DataGridView dataGrid)
        {
            InitializeComponent();
            dataGridForProducts = dataGrid;
        }

        private void TxtFindProduct_TextChanged(object sender, EventArgs e)
        {
            EntityProduct product = new EntityProduct();
            product.FindProduct(tableForProducts, TxtFindProduct.Text);
        }

        private void tableForProducts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                IDProduct = tableForProducts[0, e.RowIndex].Value.ToString();
                NameProduct = tableForProducts[1, e.RowIndex].Value.ToString();
            }
            catch { IDProduct = null; }
        }

        private void TxtQuantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            CheckSimbol.CheckInputSimbol(sender, e);
        }

        private void TxtPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            CheckSimbol.CheckInputSimbol(sender, e);
        }

        private void BtnAddProduct_Click(object sender, EventArgs e)
        {
            int Quantity;
            double Price;
            if (IDProduct != null)
            {
                if (TxtQuantity.Text != string.Empty && TxtPrice.Text != string.Empty)
                {
                    try
                    {
                        Quantity = Convert.ToInt32(TxtQuantity.Text);
                        try
                        {
                            Price = Convert.ToDouble(TxtPrice.Text);
                            bool check = false;
                            for (int i = 0; i < dataGridForProducts.Rows.Count;i++)
                            {
                                if (dataGridForProducts[0,i].Value.ToString() == IDProduct)
                                {
                                    dataGridForProducts[2, i].Value = TxtPrice.Text;
                                    dataGridForProducts[3, i].Value = Convert.ToInt32(dataGridForProducts[3, i].Value)+Convert.ToInt32(TxtQuantity.Text);
                                    check = true;
                                }
                            }

                            if (!check)
                            {
                                dataGridForProducts.Rows.Add(IDProduct, NameProduct, TxtPrice.Text, TxtQuantity.Text);
                            }
                            MessageBox.Show("Товар успешно добавлен!");
                            this.Close();
                            GC.Collect();
                        }
                        catch { MessageBox.Show("Введите корректную цену товара!"); }

                    }
                    catch { MessageBox.Show("Введите корректное количество товара!"); }
                }
                else MessageBox.Show("Введите данные!");
            }
            else MessageBox.Show("Выберите продукт!");
        }

        private void FormDialogProduct_Load(object sender, EventArgs e)
        {
            EntityProduct product = new EntityProduct();
            product.ReadProduct(tableForProducts);
        }

        private void ButtonBack_Click(object sender, EventArgs e)
        {
            this.Close();
            GC.Collect();
        }
    }
}
