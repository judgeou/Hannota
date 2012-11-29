using System;
using System.Windows.Forms;

namespace 汉诺塔
{
    public partial class SetLayers : Form
    {
        public SetLayers()
        {
            InitializeComponent();
            layerValue.Text = Form1.layers.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Form1.layers = Byte.Parse( layerValue.Text);
            Dispose();
        }
    }
}
