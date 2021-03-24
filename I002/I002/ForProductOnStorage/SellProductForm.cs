using I002.ForProductOnStorage;
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
    public partial class SellProductForm : Form
    {
        string  IDCounteragent = null;
        public SellProductForm()
        {
            InitializeComponent();
            tableForProducts.Columns[1].ReadOnly = true;
            Program.DialogCounteragent = this;

        }
        public void ReadCounteragent(string counteragent, string surname, string name, string middleName, string Inn)
        {
            if (counteragent != null)
            {
                TxtCounteeragent.Text = "";
                IDCounteragent = counteragent;
                TxtCounteeragent.Text += surname + " ";
                TxtCounteeragent.Text += name + " ";
                TxtCounteeragent.Text += middleName + "  ИНН:";
                TxtCounteeragent.Text += Inn;
            }

        }

        private void SellProductForm_Load(object sender, EventArgs e)
        {
           
        }

        private void TxtFindCounteragent_TextChanged(object sender, EventArgs e)
        {
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            if(IDCounteragent!=null)
            {
                //EntityProductOnStorage entityProductOnStorage = new EntityProductOnStorage();
               // entityProductOnStorage.SellProduct(IDCounteragent, IDProduct, Convert.ToDouble(TxtPrice.Text), Convert.ToInt32(TxtQuantity.Value));
            }
            else MessageBox.Show("Вы не выбрали контрагента!\n\nНажмите на нужную запись в талице!");
        }

        private void ChooseCounteragent_Click(object sender, EventArgs e)
        {
            FormDialogCounteragent counteragent = new FormDialogCounteragent(2);
            counteragent.ShowDialog();
        }

        private void tableForCounteragents_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void BtnAddProduct_Click(object sender, EventArgs e)
        {
            SellProductDialog sellProduct = new SellProductDialog(tableForProducts);
            sellProduct.ShowDialog();
        }

        private void BtnSell_Click(object sender, EventArgs e)
        {
            if (IDCounteragent != null)
            {
                if (tableForProducts.Rows.Count > 0)
                {
                    EntityProductOnStorage storage = new EntityProductOnStorage();
                    storage.SellProduct(IDCounteragent, tableForProducts);
                    this.Close();
                    GC.Collect();
                    ProductOnStorage product = new ProductOnStorage();
                    product.Visible = true;
                }
                else MessageBox.Show("Вы не выбрали товар!");
            }
            else MessageBox.Show("Вы не выбрали контрагента!");
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (tableForProducts.SelectedRows.Count == 1)
            {
                for (int i = 0; i < tableForProducts.Rows.Count; i++)
                {
                    if (tableForProducts.Rows[i].Selected)
                    {
                        tableForProducts.Rows.RemoveAt(i);
                    }
                }
            }
            else
            {
                MessageBox.Show("Вы не выбрали товар для удаления!");
            }
        }

        private void CloseBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void ButtonBack_Click(object sender, EventArgs e)
        {
            this.Close();
            GC.Collect();
            ProductOnStorage storage = new ProductOnStorage();
            storage.Visible = true;
        }

        private void ButtonClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
