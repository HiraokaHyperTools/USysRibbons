using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Odbc;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace USysRibbonsSetter
{
    public partial class EditOdbcForm : Form
    {
        private readonly OdbcConnection db;
        private readonly OdbcDataAdapter da;
        private readonly OdbcCommandBuilder cb;
        private readonly DataTable dt;

        public EditOdbcForm(OdbcConnection db)
        {
            InitializeComponent();

            this.db = db;
            this.da = new OdbcDataAdapter("select * from [USysRibbons];", db);
            this.cb = new OdbcCommandBuilder(da);
            this.dt = new DataTable();
            bindingSource1.DataSource = dt;
        }

        private void save_Click(object sender, EventArgs e)
        {
            bindingSource1.EndEdit();
            da.Update(dt);
            MessageBox.Show("Changes saved.");
        }

        private void EditOdbcForm_Load(object sender, EventArgs e)
        {
            da.Fill(dt);
            grid.AutoGenerateColumns = true;
        }

        private void editXml_Click(object sender, EventArgs e)
        {
            var drv = (DataRowView)bindingSource1.Current;
            if (drv != null)
            {
                var RibbonXml = "" + drv["RibbonXml"];
                var form = new TextEditorForm(RibbonXml);
                if (form.ShowDialog(this) == DialogResult.OK)
                {
                    drv["RibbonXml"] = form.Note;
                    drv.EndEdit();
                }
            }
        }

        private void EditOdbcForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            cb?.Dispose();
            da?.Dispose();
            db?.Dispose();
            dt?.Dispose();
        }
    }
}
