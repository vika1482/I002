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
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
        }

        private void BtnProduct_Click(object sender, EventArgs e)
        {
            this.Hide();
            Products products = new Products();
            products.Show();
        }

        private void BtnProvider_Click(object sender, EventArgs e)
        {
            this.Hide();
            Counteragent counteragent = new Counteragent();
            counteragent.Show();
        }

        private void BtnProductOnStorage_Click(object sender, EventArgs e)
        {
            this.Hide();
            ProductOnStorage product = new ProductOnStorage();
            product.Show();
        }

        private void BtnPurchase_Click(object sender, EventArgs e)
        {
            FormPurchase formPurchase = new FormPurchase(2);
            formPurchase.ShowDialog();
        }

        private void BtnProcurement_Click(object sender, EventArgs e)
        {
            FormPurchase formPurchase = new FormPurchase(1);
            formPurchase.ShowDialog();
        }

        private void ButtonClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
