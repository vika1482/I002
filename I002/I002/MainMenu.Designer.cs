
namespace I002
{
    partial class MainMenu
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.MainPanel = new System.Windows.Forms.Panel();
            this.BtnPurchase = new System.Windows.Forms.Button();
            this.BtnProcurement = new System.Windows.Forms.Button();
            this.BtnProduct = new System.Windows.Forms.Button();
            this.BtnProvider = new System.Windows.Forms.Button();
            this.BtnProductOnStorage = new System.Windows.Forms.Button();
            this.ButtonClose = new System.Windows.Forms.Button();
            this.MainPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainPanel
            // 
            this.MainPanel.Controls.Add(this.ButtonClose);
            this.MainPanel.Controls.Add(this.BtnPurchase);
            this.MainPanel.Controls.Add(this.BtnProcurement);
            this.MainPanel.Controls.Add(this.BtnProduct);
            this.MainPanel.Controls.Add(this.BtnProvider);
            this.MainPanel.Controls.Add(this.BtnProductOnStorage);
            this.MainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainPanel.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.MainPanel.Location = new System.Drawing.Point(0, 0);
            this.MainPanel.Margin = new System.Windows.Forms.Padding(4);
            this.MainPanel.Name = "MainPanel";
            this.MainPanel.Size = new System.Drawing.Size(515, 507);
            this.MainPanel.TabIndex = 0;
            // 
            // BtnPurchase
            // 
            this.BtnPurchase.BackColor = System.Drawing.Color.Silver;
            this.BtnPurchase.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnPurchase.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gainsboro;
            this.BtnPurchase.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnPurchase.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.BtnPurchase.ForeColor = System.Drawing.Color.Black;
            this.BtnPurchase.Location = new System.Drawing.Point(114, 301);
            this.BtnPurchase.Margin = new System.Windows.Forms.Padding(4);
            this.BtnPurchase.Name = "BtnPurchase";
            this.BtnPurchase.Size = new System.Drawing.Size(279, 45);
            this.BtnPurchase.TabIndex = 6;
            this.BtnPurchase.Text = "Продажи";
            this.BtnPurchase.UseVisualStyleBackColor = false;
            this.BtnPurchase.Click += new System.EventHandler(this.BtnPurchase_Click);
            // 
            // BtnProcurement
            // 
            this.BtnProcurement.BackColor = System.Drawing.Color.Silver;
            this.BtnProcurement.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnProcurement.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gainsboro;
            this.BtnProcurement.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnProcurement.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.BtnProcurement.ForeColor = System.Drawing.Color.Black;
            this.BtnProcurement.Location = new System.Drawing.Point(114, 231);
            this.BtnProcurement.Margin = new System.Windows.Forms.Padding(4);
            this.BtnProcurement.Name = "BtnProcurement";
            this.BtnProcurement.Size = new System.Drawing.Size(279, 45);
            this.BtnProcurement.TabIndex = 5;
            this.BtnProcurement.Text = "Закупки";
            this.BtnProcurement.UseVisualStyleBackColor = false;
            this.BtnProcurement.Click += new System.EventHandler(this.BtnProcurement_Click);
            // 
            // BtnProduct
            // 
            this.BtnProduct.BackColor = System.Drawing.Color.Silver;
            this.BtnProduct.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnProduct.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gainsboro;
            this.BtnProduct.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnProduct.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.BtnProduct.ForeColor = System.Drawing.Color.Black;
            this.BtnProduct.Location = new System.Drawing.Point(114, 370);
            this.BtnProduct.Margin = new System.Windows.Forms.Padding(4);
            this.BtnProduct.Name = "BtnProduct";
            this.BtnProduct.Size = new System.Drawing.Size(279, 45);
            this.BtnProduct.TabIndex = 3;
            this.BtnProduct.Text = "Товары";
            this.BtnProduct.UseVisualStyleBackColor = false;
            this.BtnProduct.Click += new System.EventHandler(this.BtnProduct_Click);
            // 
            // BtnProvider
            // 
            this.BtnProvider.BackColor = System.Drawing.Color.Silver;
            this.BtnProvider.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnProvider.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gainsboro;
            this.BtnProvider.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnProvider.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.BtnProvider.ForeColor = System.Drawing.Color.Black;
            this.BtnProvider.Location = new System.Drawing.Point(116, 161);
            this.BtnProvider.Margin = new System.Windows.Forms.Padding(4);
            this.BtnProvider.Name = "BtnProvider";
            this.BtnProvider.Size = new System.Drawing.Size(279, 45);
            this.BtnProvider.TabIndex = 2;
            this.BtnProvider.Text = "Контрагенты";
            this.BtnProvider.UseVisualStyleBackColor = false;
            this.BtnProvider.Click += new System.EventHandler(this.BtnProvider_Click);
            // 
            // BtnProductOnStorage
            // 
            this.BtnProductOnStorage.BackColor = System.Drawing.Color.Silver;
            this.BtnProductOnStorage.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnProductOnStorage.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gainsboro;
            this.BtnProductOnStorage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnProductOnStorage.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.BtnProductOnStorage.ForeColor = System.Drawing.Color.Black;
            this.BtnProductOnStorage.Location = new System.Drawing.Point(114, 95);
            this.BtnProductOnStorage.Margin = new System.Windows.Forms.Padding(4);
            this.BtnProductOnStorage.Name = "BtnProductOnStorage";
            this.BtnProductOnStorage.Size = new System.Drawing.Size(279, 45);
            this.BtnProductOnStorage.TabIndex = 0;
            this.BtnProductOnStorage.Text = "Товары на складе";
            this.BtnProductOnStorage.UseVisualStyleBackColor = false;
            this.BtnProductOnStorage.Click += new System.EventHandler(this.BtnProductOnStorage_Click);
            // 
            // ButtonClose
            // 
            this.ButtonClose.BackColor = System.Drawing.Color.Red;
            this.ButtonClose.Font = new System.Drawing.Font("Segoe UI Semibold", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ButtonClose.ForeColor = System.Drawing.Color.White;
            this.ButtonClose.Location = new System.Drawing.Point(458, 12);
            this.ButtonClose.Name = "ButtonClose";
            this.ButtonClose.Size = new System.Drawing.Size(45, 41);
            this.ButtonClose.TabIndex = 7;
            this.ButtonClose.Text = "X";
            this.ButtonClose.UseVisualStyleBackColor = false;
            this.ButtonClose.Click += new System.EventHandler(this.ButtonClose_Click);
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(515, 507);
            this.ControlBox = false;
            this.Controls.Add(this.MainPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MainMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Меню";
            this.MainPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel MainPanel;
        private System.Windows.Forms.Button BtnProductOnStorage;
        private System.Windows.Forms.Button BtnProvider;
        private System.Windows.Forms.Button BtnPurchase;
        private System.Windows.Forms.Button BtnProcurement;
        private System.Windows.Forms.Button BtnProduct;
        private System.Windows.Forms.Button ButtonClose;
    }
}

