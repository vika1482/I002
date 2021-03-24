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
    public partial class CompositionForm : Form
    {
        string Id;
        int Role;
        public CompositionForm(int role,string id)
        {
            InitializeComponent();
            Role = role;
            Id = id;
            EntityReport report = new EntityReport();
            if (Role==1)
            {
                report.CopmositionForProvider(tableForProducts, Id);
            }
            else
            {
                report.CopmositionForPurchase(tableForProducts, Id);
            }
        }

        private void CompositionForm_Load(object sender, EventArgs e)
        {
           
           
        }

        private void ButtonBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
