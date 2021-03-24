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
    public partial class Counteragent : Form
    {
        int RoleId = 1;
        string IdCounteragent= null;
        string Surname, CName, MiddleName, Inn, Adress, Phone;

        public Counteragent()
        {
            InitializeComponent();
        }

        private void Counteragent_Load(object sender, EventArgs e)
        {
            EntityCounteragent counteragent = new EntityCounteragent();
            counteragent.ReadCounteragent(tableForCounteragents, RoleId);
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (IdCounteragent != null)
            {
                DialogResult result = MessageBox.Show(
               "Вы действительно хотите удалить эту запись?",
               "Сообщение",
               MessageBoxButtons.YesNo,
               MessageBoxIcon.Information);
                if (result == DialogResult.Yes)
                {
                    EntityCounteragent entityCounteragent = new EntityCounteragent();
                    entityCounteragent.DeleteCounteragent(IdCounteragent);
                    entityCounteragent.ReadCounteragent(tableForCounteragents, RoleId);
                    IdCounteragent = null;
                }
            }
            else
            {
                MessageBox.Show("Вы не выбрали контрагента для удаления!\n\nНажмите на соответствующую запись в таблице");
            }
        }

        private void radioProvider_Click(object sender, EventArgs e)
        {
            radioProvider.Checked = true;
            radioBuyer.Checked = false;
            RoleId = 1;
            EntityCounteragent counteragent = new EntityCounteragent();
            counteragent.ReadCounteragent(tableForCounteragents, RoleId);
        }


        private void radioBuyer_Click(object sender, EventArgs e)
        {
            radioBuyer.Checked = true;
            radioProvider.Checked = false;
            RoleId = 2;
            EntityCounteragent counteragent = new EntityCounteragent();
            counteragent.ReadCounteragent(tableForCounteragents, RoleId);
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

        private void TxtFind_TextChanged(object sender, EventArgs e)
        {
            EntityCounteragent counteragent = new EntityCounteragent();
            counteragent.FindCounteragent(tableForCounteragents,RoleId,TxtFind.Text);
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            ChangeAndAddCounteragent counteragent = new ChangeAndAddCounteragent(1, RoleId);
            counteragent.ShowDialog();
            EntityCounteragent entityCounteragent = new EntityCounteragent();
            entityCounteragent.ReadCounteragent(tableForCounteragents, RoleId);
        }

        private void BtnChange_Click(object sender, EventArgs e)
        {
            if (IdCounteragent != null)
            {
                ChangeAndAddCounteragent counteragent = new ChangeAndAddCounteragent(2, RoleId,IdCounteragent,Surname,CName,MiddleName,Inn,Adress,Phone);
                counteragent.ShowDialog();
                EntityCounteragent entityCounteragent = new EntityCounteragent();
                entityCounteragent.ReadCounteragent(tableForCounteragents, RoleId);
                IdCounteragent = null;
            }
            else
            {
                MessageBox.Show("Вы не выбрали контрагента для редактирования!\n\nНажмите на соответствующую запись в таблице");
            }
        }

        private void tableForCounteragents_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                IdCounteragent = tableForCounteragents[0, e.RowIndex].Value.ToString();
                Surname = tableForCounteragents[1, e.RowIndex].Value.ToString();
                CName = tableForCounteragents[2, e.RowIndex].Value.ToString();
                MiddleName = tableForCounteragents[3, e.RowIndex].Value.ToString();
                Inn = tableForCounteragents[4, e.RowIndex].Value.ToString();
                Adress = tableForCounteragents[5, e.RowIndex].Value.ToString();
                Phone = tableForCounteragents[6, e.RowIndex].Value.ToString();
            }
            catch
            {
                tableForCounteragents.ClearSelection();
                IdCounteragent = null;
            }
                    }

        private void MainPanel_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
