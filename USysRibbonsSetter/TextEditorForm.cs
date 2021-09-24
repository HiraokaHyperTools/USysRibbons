using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace USysRibbonsSetter
{
    public partial class TextEditorForm : Form
    {
        public TextEditorForm(string note)
        {
            InitializeComponent();

            textBox1.Text = note;
        }

        internal string Note => textBox1.Text;

        private void save_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
