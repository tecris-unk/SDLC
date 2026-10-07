namespace lab1
{
    partial class MainForm
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

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.lblDefinition = new System.Windows.Forms.Label();
            this.lblResult = new System.Windows.Forms.Label();
            this.btnOpenInput = new System.Windows.Forms.Button();
            this.SuspendLayout();

            // lblDefinition
            this.lblDefinition.AutoSize = true;
            this.lblDefinition.Location = new System.Drawing.Point(20, 20);
            this.lblDefinition.Name = "lblDefinition";
            this.lblDefinition.Size = new System.Drawing.Size(300, 15);
            this.lblDefinition.TabIndex = 0;

            // lblResult
            this.lblResult.AutoSize = true;
            this.lblResult.Location = new System.Drawing.Point(20, 60);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(200, 15);
            this.lblResult.TabIndex = 1;

            // btnOpenInput
            this.btnOpenInput.Location = new System.Drawing.Point(20, 100);
            this.btnOpenInput.Name = "btnOpenInput";
            this.btnOpenInput.Size = new System.Drawing.Size(130, 30);
            this.btnOpenInput.TabIndex = 2;
            this.btnOpenInput.Text = "Ввести продукт";
            this.btnOpenInput.UseVisualStyleBackColor = true;
            this.btnOpenInput.Click += new System.EventHandler(this.btnOpenInput_Click);

            // MainForm
            this.ClientSize = new System.Drawing.Size(400, 160);
            this.Controls.Add(this.lblDefinition);
            this.Controls.Add(this.lblResult);
            this.Controls.Add(this.btnOpenInput);
            this.Name = "MainForm";
            this.Text = "Гликемический индекс";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblDefinition;
        private System.Windows.Forms.Label lblResult;
        private System.Windows.Forms.Button btnOpenInput;
    }
}