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
    public partial class ProductOnStorage : Form
    {
        public ProductOnStorage()
        {
            InitializeComponent();
        }

        private void ProductOnStorage_Load(object sender, EventArgs e)
        {
            EntityProductOnStorage product = new EntityProductOnStorage();
            product.ReadProduct(tableForProducts);
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            BuyProduct product = new BuyProduct();
            product.Show();
            EntityProductOnStorage entityProduct = new EntityProductOnStorage();
            entityProduct.ReadProduct(tableForProducts);

        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            SellProductForm sellProductForm = new SellProductForm();
            sellProductForm.Show();
            EntityProductOnStorage entityProduct = new EntityProductOnStorage();
            entityProduct.ReadProduct(tableForProducts);
           
        }

        private void TxtFind_TextChanged(object sender, EventArgs e)
        {
            EntityProductOnStorage storage = new EntityProductOnStorage();
            storage.FindProduct(tableForProducts, TxtFind.Text);
        }

        private void ButtonClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void ButtonBack_Click(object sender, EventArgs e)
        {
            this.Close();
            GC.Collect();
            MainMenu mainMenu = new MainMenu();
            mainMenu.Show();
        }
    }
}
