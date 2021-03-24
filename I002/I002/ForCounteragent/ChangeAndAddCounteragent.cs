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
    public partial class ChangeAndAddCounteragent : Form
    {
        int Action,RoleId;
        string IdCounterAgent;

        public ChangeAndAddCounteragent(int action, int roleId, string Id, string surname,string name,string middlename, string inn, string adress,string phone)
        {
            InitializeComponent();
            Action = action;
            RoleId = roleId;
            IdCounterAgent = Id;
            TxtSurname.Text = surname;
            TxtName.Text = name;
            TxtMiddleName.Text = middlename;
            TxtInn.Text = inn;
            TxtAdress.Text = adress;
            TxtPhone.Text = phone;
            if (Action == 1)
            {
                BtnForAction.Text = "Добавить";
                if (RoleId == 1) { this.Text = "Добавление поставщика"; }
                else { this.Text = "Добавление покупателя"; }
            }
            else
            {
                BtnForAction.Text = "Изменить";
                if (RoleId == 1) { this.Text = "Редактирование поставщика"; }
                else { this.Text = "Редактирование покупателя"; }
            }
        }
        public ChangeAndAddCounteragent(int action, int roleId)
        {
            InitializeComponent();
            Action = action;
            RoleId = roleId;
            if (Action == 1)
            {
                BtnForAction.Text = "Добавить";
                if (RoleId == 1) { this.Text = "Добавление поставщика"; }
                else { this.Text = "Добавление покупателя"; }
            }
            else
            {
                BtnForAction.Text = "Изменить";
                if (RoleId == 1) { this.Text = "Редактирование поставщика"; }
                else { this.Text = "Редактирование покупателя"; }
            }
        }

        private void ButtonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnForAction_Click(object sender, EventArgs e)
        {
            if (TxtSurname.Text!=string.Empty && TxtName.Text != string.Empty && TxtInn.Text != string.Empty && TxtAdress.Text != string.Empty && TxtPhone.Text != string.Empty )
            {
                if (Action == 1) //Добавление пользователя
                {
                    EntityCounteragent counteragent = new EntityCounteragent();
                    counteragent.AddCounteragent(TxtSurname.Text, TxtName.Text, TxtMiddleName.Text, TxtInn.Text, TxtAdress.Text, TxtPhone.Text, RoleId);
                    this.Close();
                
                }
                else //Редактирование пользователя
                {
                    EntityCounteragent counteragent = new EntityCounteragent();
                    counteragent.ChangeCounteragent(TxtSurname.Text, TxtName.Text, TxtMiddleName.Text, TxtInn.Text, TxtAdress.Text, TxtPhone.Text, IdCounterAgent);
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("Введите данные!");
            }
        }

       
    }
}
