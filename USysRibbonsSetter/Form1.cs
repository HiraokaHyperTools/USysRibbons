using kenjiuno.AutoHourglass;
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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void prepMdb_Click(object sender, EventArgs e)
        {
            if (ofdMdb.ShowDialog(this) != DialogResult.OK)
            {
                return;
            }

            using (var ah = new AH())
            using (var db = new OdbcConnection($"Driver={{Driver do Microsoft Access (*.mdb)}};Dbq={ofdMdb.FileName};"))
            {
                db.Open();

                var cmd = db.CreateCommand();
                cmd.CommandText = "create table USysRibbons(ID counter, RibbonName varchar(255), RibbonXml memo, CONSTRAINT [PrimaryKey] PRIMARY KEY ([ID]))";
                cmd.ExecuteNonQuery();

                MessageBox.Show("OK");
            }
        }

        private void editUSR_Click(object sender, EventArgs e)
        {
            if (ofdMdb.ShowDialog(this) != DialogResult.OK)
            {
                return;
            }

            var db = new OdbcConnection($"Driver={{Driver do Microsoft Access (*.mdb)}};Dbq={ofdMdb.FileName};");
            var form = new EditOdbcForm(db);
            form.Text = ofdMdb.FileName;
            form.Show(this);
        }
    }
}
