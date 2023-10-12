namespace MegaDesk_Rodriguez
{
    partial class DisplayQuote
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
            this.button1 = new System.Windows.Forms.Button();
            this.price = new System.Windows.Forms.Label();
            this.width = new System.Windows.Forms.Label();
            this.depth = new System.Windows.Forms.Label();
            this.customer = new System.Windows.Forms.Label();
            this.material = new System.Windows.Forms.Label();
            this.drawers = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(49, 233);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Back";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // price
            // 
            this.price.AutoSize = true;
            this.price.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.price.Location = new System.Drawing.Point(85, 185);
            this.price.Name = "price";
            this.price.Size = new System.Drawing.Size(39, 17);
            this.price.TabIndex = 2;
            this.price.Text = "price";
            // 
            // width
            // 
            this.width.AutoSize = true;
            this.width.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.width.Location = new System.Drawing.Point(85, 63);
            this.width.Name = "width";
            this.width.Size = new System.Drawing.Size(40, 17);
            this.width.TabIndex = 3;
            this.width.Text = "width";
            // 
            // depth
            // 
            this.depth.AutoSize = true;
            this.depth.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.depth.Location = new System.Drawing.Point(85, 92);
            this.depth.Name = "depth";
            this.depth.Size = new System.Drawing.Size(44, 17);
            this.depth.TabIndex = 4;
            this.depth.Text = "depth";
            // 
            // customer
            // 
            this.customer.AutoSize = true;
            this.customer.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.customer.Location = new System.Drawing.Point(85, 33);
            this.customer.Name = "customer";
            this.customer.Size = new System.Drawing.Size(66, 17);
            this.customer.TabIndex = 5;
            this.customer.Text = "customer";
            // 
            // material
            // 
            this.material.AutoSize = true;
            this.material.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.material.Location = new System.Drawing.Point(85, 122);
            this.material.Name = "material";
            this.material.Size = new System.Drawing.Size(58, 17);
            this.material.TabIndex = 6;
            this.material.Text = "material";
            // 
            // drawers
            // 
            this.drawers.AutoSize = true;
            this.drawers.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.drawers.Location = new System.Drawing.Point(85, 156);
            this.drawers.Name = "drawers";
            this.drawers.Size = new System.Drawing.Size(58, 17);
            this.drawers.TabIndex = 7;
            this.drawers.Text = "drawers";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(164, 233);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 8;
            this.button2.Text = "Save";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.saveToFile);
            // 
            // DisplayQuote
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(328, 268);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.drawers);
            this.Controls.Add(this.material);
            this.Controls.Add(this.customer);
            this.Controls.Add(this.depth);
            this.Controls.Add(this.width);
            this.Controls.Add(this.price);
            this.Controls.Add(this.button1);
            this.Name = "DisplayQuote";
            this.Text = "DisplayQuote";
            this.Load += new System.EventHandler(this.DisplayQuote_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label price;
        private System.Windows.Forms.Label width;
        private System.Windows.Forms.Label depth;
        private System.Windows.Forms.Label customer;
        private System.Windows.Forms.Label material;
        private System.Windows.Forms.Label drawers;
        private System.Windows.Forms.Button button2;
    }
}