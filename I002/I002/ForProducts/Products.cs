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
    public partial class Products : Form
    {
        string IDProduct = null,NameProduct;
        public Products()
        {
            InitializeComponent();
        }

        private void Products_Load(object sender, EventArgs e)
        {
            EntityProduct product = new EntityProduct();
            product.ReadProduct(tableForProducts);
        }

        private void TxtFind_TextChanged(object sender, EventArgs e)
        {
            EntityProduct product = new EntityProduct();
            product.FindProduct(tableForProducts,TxtFind.Text);
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            FormAddProduct addProduct = new FormAddProduct();
            addProduct.ShowDialog();
            EntityProduct product = new EntityProduct();
            product.ReadProduct(tableForProducts);
        }

        private void BtnCha_Click(object sender, EventArgs e)
        {
            if(IDProduct!=null)
            {
                ChangeProduct changeProduct = new ChangeProduct(IDProduct,NameProduct);
                changeProduct.ShowDialog();
                EntityProduct product = new EntityProduct();
                product.ReadProduct(tableForProducts);
                IDProduct = null;
            }
            else
            {
                MessageBox.Show("Вы не выбрали продукт для редактирования!\n\nНажмите на соответствующий продукт в таблице");
            }
            
        }

        private void tableForProducts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                IDProduct = tableForProducts[0, e.RowIndex].Value.ToString();
                NameProduct = tableForProducts[1, e.RowIndex].Value.ToString();
            }
            catch
            {
                tableForProducts.ClearSelection();
                IDProduct = null;
            }
        }

        private void ButtonBack_Click(object sender, EventArgs e)
        {
            this.Close();
            GC.Collect();
            MainMenu mainMenu = new MainMenu();
            mainMenu.Show();
        }

        private void ButtonClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (IDProduct != null)
            {
                DialogResult result = MessageBox.Show(
                "Вы действительно хотите удалить этот товар?",
                "Сообщение",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Information);
                if (result == DialogResult.Yes)
                {
                    EntityProduct product = new EntityProduct();
                    product.DeleteProduct(Convert.ToInt32(IDProduct));
                    product.ReadProduct(tableForProducts);
                }
                tableForProducts.ClearSelection();
                IDProduct = null;
            }
            else
            {
                MessageBox.Show("Вы не выбрали продукт для удаления!\n\nНажмите на соответствующий продукт в таблице");
            }
        }

       
    }
}
