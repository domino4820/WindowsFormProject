namespace LauncherGames
{
    partial class InputForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            lblPayerId = new Label();
            txtPayerId = new TextBox();
            btnOk = new Button();
            SuspendLayout();
            // 
            // lblPayerId
            // 
            lblPayerId.AutoSize = true;
            lblPayerId.Location = new Point(16, 14);
            lblPayerId.Margin = new Padding(4, 0, 4, 0);
            lblPayerId.Name = "lblPayerId";
            lblPayerId.Size = new Size(66, 20);
            lblPayerId.TabIndex = 0;
            lblPayerId.Text = "Payer ID:";
            // 
            // txtPayerId
            // 
            txtPayerId.Location = new Point(20, 38);
            txtPayerId.Margin = new Padding(4, 5, 4, 5);
            txtPayerId.Name = "txtPayerId";
            txtPayerId.Size = new Size(341, 27);
            txtPayerId.TabIndex = 1;
            // 
            // btnOk
            // 
            btnOk.Location = new Point(263, 78);
            btnOk.Margin = new Padding(4, 5, 4, 5);
            btnOk.Name = "btnOk";
            btnOk.Size = new Size(100, 35);
            btnOk.TabIndex = 2;
            btnOk.Text = "OK";
            btnOk.UseVisualStyleBackColor = true;
            btnOk.Click += btnOk_Click;
            // 
            // InputForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(379, 132);
            Controls.Add(btnOk);
            Controls.Add(txtPayerId);
            Controls.Add(lblPayerId);
            Margin = new Padding(4, 5, 4, 5);
            Name = "InputForm";
            Text = "Nhập Payer ID";
            ResumeLayout(false);
            PerformLayout();
        }

        private System.Windows.Forms.Label lblPayerId;
        private System.Windows.Forms.TextBox txtPayerId;
        private System.Windows.Forms.Button btnOk;
    }
}