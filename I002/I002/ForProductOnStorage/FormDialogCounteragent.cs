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
    public partial class FormDialogCounteragent : Form
    {
        string IDCounteragent = null, Surname,CounterName, MiddleName,Inn;
        int Role;
        public FormDialogCounteragent(int role)
        {
            InitializeComponent();
            Role = role;
        }

        private void ButtonBack_Click(object sender, EventArgs e)
        {
            this.Close();
            GC.Collect();
        }

        private void TxtFindCounteragent_TextChanged(object sender, EventArgs e)
        {
            EntityCounteragent entityCounteragent = new EntityCounteragent();
            entityCounteragent.FindCounteragent(tableForCounteragents, Role, TxtFindCounteragent.Text);
        }

        private void FormDialogCounteragent_Load(object sender, EventArgs e)
        {
            EntityCounteragent entityCounteragent = new EntityCounteragent();
            entityCounteragent.ReadCounteragent(tableForCounteragents, Role);
        }

        private void tableForCounteragents_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                IDCounteragent = tableForCounteragents[0, e.RowIndex].Value.ToString();
                Surname = tableForCounteragents[1, e.RowIndex].Value.ToString();
                CounterName = tableForCounteragents[2, e.RowIndex].Value.ToString();
                MiddleName = tableForCounteragents[3, e.RowIndex].Value.ToString();
                Inn = tableForCounteragents[4, e.RowIndex].Value.ToString();

            }
            catch { IDCounteragent = null; }
        }

        private void BtnChoose_Click(object sender, EventArgs e)
        {
            if(Role == 1)
            {
                Program.DialogProduct.ReadCounteragent(IDCounteragent, Surname, CounterName, MiddleName, Inn);
                this.Close();
                GC.Collect();
            }
            else
            {
                Program.DialogCounteragent.ReadCounteragent(IDCounteragent, Surname, CounterName, MiddleName, Inn);
                this.Close();
                GC.Collect();
            }
            
        }
    }
}
