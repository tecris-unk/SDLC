using System;
using System.Windows.Forms;

namespace lab1
{
    public partial class InputForm : Form
    {
        public string EnteredProduct => txtProduct.Text;

        public InputForm(string previousInput)
        {
            InitializeComponent();
            txtProduct.Text = previousInput;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}