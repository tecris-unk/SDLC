using System;
using System.Windows.Forms;

namespace lab1
{
    public partial class MainForm : Form
    {
        private readonly GiModel _model = new();
        private readonly GiController _controller;

        public MainForm()
        {
            InitializeComponent();
            _controller = new GiController(_model);

            // Текст определения ГИ
            lblDefinition.Text = "Гликемический индекс (ГИ) — показатель влияния продуктов на уровень сахара в крови.";

            // Подписка View на активную модель
            _model.OnDataChanged += () => lblResult.Text = $"Продукт: {_model.LastProduct} | ГИ: {_model.CurrentGi}";
            _model.OnError += err => MessageBox.Show(err, "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnOpenInput_Click(object sender, EventArgs e)
        {
            using var inputDlg = new InputForm(_model.LastProduct);
            if (inputDlg.ShowDialog() == DialogResult.OK)
            {
                _controller.HandleSearch(inputDlg.EnteredProduct);
            }
        }
    }
}