namespace FitTakSis
{
    partial class Yonetici_Panel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Yonetici_Panel));
            this.btnUyeleriGoster = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnUyeleriGoster
            // 
            this.btnUyeleriGoster.FlatAppearance.BorderSize = 2;
            this.btnUyeleriGoster.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUyeleriGoster.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnUyeleriGoster.Image = ((System.Drawing.Image)(resources.GetObject("btnUyeleriGoster.Image")));
            this.btnUyeleriGoster.Location = new System.Drawing.Point(12, 77);
            this.btnUyeleriGoster.Name = "btnUyeleriGoster";
            this.btnUyeleriGoster.Size = new System.Drawing.Size(232, 95);
            this.btnUyeleriGoster.TabIndex = 0;
            this.btnUyeleriGoster.Text = "     Üyeler";
            this.btnUyeleriGoster.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnUyeleriGoster.UseVisualStyleBackColor = true;
            this.btnUyeleriGoster.Click += new System.EventHandler(this.btnUyeleriGoster_Click);
            // 
            // button1
            // 
            this.button1.FlatAppearance.BorderSize = 2;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.Location = new System.Drawing.Point(250, 77);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(232, 95);
            this.button1.TabIndex = 1;
            this.button1.Text = "     Üye Giriş Zamanı Takibi";
            this.button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.FlatAppearance.BorderSize = 2;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button2.Image = ((System.Drawing.Image)(resources.GetObject("button2.Image")));
            this.button2.Location = new System.Drawing.Point(490, 77);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(232, 95);
            this.button2.TabIndex = 2;
            this.button2.Text = "     Mağaza";
            this.button2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.FlatAppearance.BorderSize = 2;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold);
            this.button3.Image = ((System.Drawing.Image)(resources.GetObject("button3.Image")));
            this.button3.Location = new System.Drawing.Point(522, 212);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(200, 62);
            this.button3.TabIndex = 7;
            this.button3.Text = "    Çıkış Yap";
            this.button3.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // Yonetici_Panel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(734, 286);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnUyeleriGoster);
            this.Name = "Yonetici_Panel";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Yönetici Paneli";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnUyeleriGoster;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;

    }
}