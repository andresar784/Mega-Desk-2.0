using System.Windows.Forms;

namespace MegaDesk_Rodriguez
{
    partial class AddQuote
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.width = new System.Windows.Forms.TextBox();
            this.depth = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.customer = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.rush = new System.Windows.Forms.TextBox();
            this.createOrder = new System.Windows.Forms.Button();
            this.exit = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.date = new System.Windows.Forms.Label();
            this.material = new System.Windows.Forms.ComboBox();
            this.drawers = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // width
            // 
            this.width.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.width.Location = new System.Drawing.Point(82, 75);
            this.width.Name = "width";
            this.width.Size = new System.Drawing.Size(100, 20);
            this.width.TabIndex = 1;
            this.width.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.width.Validating += new System.ComponentModel.CancelEventHandler(this.Width_Validating);
            // 
            // depth
            // 
            this.depth.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.depth.Location = new System.Drawing.Point(82, 125);
            this.depth.Name = "depth";
            this.depth.Size = new System.Drawing.Size(100, 20);
            this.depth.TabIndex = 2;
            this.depth.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(79, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Enter the width ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(79, 109);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Enter the depth";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(79, 158);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Drawers";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(79, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Name Customer";
            // 
            // customer
            // 
            this.customer.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.customer.Location = new System.Drawing.Point(82, 25);
            this.customer.Name = "customer";
            this.customer.Size = new System.Drawing.Size(100, 20);
            this.customer.TabIndex = 0;
            this.customer.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(79, 208);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Material";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(79, 257);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(61, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Rush Order";
            // 
            // rush
            // 
            this.rush.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.rush.Location = new System.Drawing.Point(82, 273);
            this.rush.Name = "rush";
            this.rush.Size = new System.Drawing.Size(100, 20);
            this.rush.TabIndex = 5;
            this.rush.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // createOrder
            // 
            this.createOrder.Location = new System.Drawing.Point(131, 332);
            this.createOrder.Name = "createOrder";
            this.createOrder.Size = new System.Drawing.Size(75, 23);
            this.createOrder.TabIndex = 12;
            this.createOrder.Text = "Create Order";
            this.createOrder.UseVisualStyleBackColor = true;
            this.createOrder.Click += new System.EventHandler(this.CreateOrderButton_Click);
            // 
            // exit
            // 
            this.exit.Location = new System.Drawing.Point(50, 332);
            this.exit.Name = "exit";
            this.exit.Size = new System.Drawing.Size(75, 23);
            this.exit.TabIndex = 13;
            this.exit.Text = "Main Menu";
            this.exit.UseVisualStyleBackColor = true;
            this.exit.Click += new System.EventHandler(this.exit_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(66, 305);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(36, 13);
            this.label7.TabIndex = 14;
            this.label7.Text = "Date: ";
            // 
            // date
            // 
            this.date.AutoSize = true;
            this.date.Location = new System.Drawing.Point(115, 307);
            this.date.Name = "date";
            this.date.Size = new System.Drawing.Size(34, 13);
            this.date.TabIndex = 15;
            this.date.Text = "fecha";
            // 
            // material
            // 
            this.material.FormattingEnabled = true;
            this.material.Location = new System.Drawing.Point(82, 224);
            this.material.Name = "material";
            this.material.Size = new System.Drawing.Size(100, 21);
            this.material.TabIndex = 4;
            // 
            // drawers
            // 
            this.drawers.FormattingEnabled = true;
            this.drawers.Location = new System.Drawing.Point(82, 174);
            this.drawers.Name = "drawers";
            this.drawers.Size = new System.Drawing.Size(100, 21);
            this.drawers.TabIndex = 3;
            // 
            // AddQuote
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(283, 367);
            this.Controls.Add(this.drawers);
            this.Controls.Add(this.material);
            this.Controls.Add(this.date);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.exit);
            this.Controls.Add(this.createOrder);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.rush);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.customer);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.depth);
            this.Controls.Add(this.width);
            this.Name = "AddQuote";
            this.Text = "AddQuote";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox width;
        private System.Windows.Forms.TextBox depth;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private ErrorProvider errorProvider;
        private Label label3;
        private Label label4;
        private TextBox customer;
        private Label label5;
        private Label label6;
        private TextBox rush;
        private Button createOrder;
        private Button exit;
        private Label label7;
        private Label date;
        private ComboBox material;
        private ComboBox drawers;
    }
}