namespace lab1
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

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.txtProduct = new System.Windows.Forms.TextBox();
            this.btnOk = new System.Windows.Forms.Button();
            this.SuspendLayout();

            // txtProduct
            this.txtProduct.Location = new System.Drawing.Point(20, 20);
            this.txtProduct.Name = "txtProduct";
            this.txtProduct.Size = new System.Drawing.Size(200, 23);
            this.txtProduct.TabIndex = 0;

            // btnOk
            this.btnOk.Location = new System.Drawing.Point(20, 55);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(80, 25);
            this.btnOk.TabIndex = 1;
            this.btnOk.Text = "ОК";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);

            // InputForm
            this.ClientSize = new System.Drawing.Size(250, 100);
            this.Controls.Add(this.txtProduct);
            this.Controls.Add(this.btnOk);
            this.Name = "InputForm";
            this.Text = "Ввод продукта";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.TextBox txtProduct;
        private System.Windows.Forms.Button btnOk;
    }
}