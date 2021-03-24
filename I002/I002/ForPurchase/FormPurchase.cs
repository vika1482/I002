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
    public partial class FormPurchase : Form
    {
        int Role;
        public FormPurchase(int action)
        {
            InitializeComponent();
            Role = action;
            if (Role == 2) this.Text = "Отчёт о продажах";
            else this.Text = "Отчёт о закупках";
            LabHeader.Text = this.Text;
        }

        private void FormPurchase_Load(object sender, EventArgs e)
        {
            if(Role == 1)
            {
                EntityReport entityReport = new EntityReport();
                entityReport.MadeReportComing(tableForReport);
            }
            else
            {
                EntityReport entityRep = new EntityReport();
                entityRep.MadeReportPurchase(tableForReport);
            }
            
        }

        private void tableForReport_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string Id = tableForReport[0, e.RowIndex].Value.ToString();
            CompositionForm compositionForm = new CompositionForm(Role, Id);
            compositionForm.ShowDialog();
        }

        private void ButtonBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ButtonClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
