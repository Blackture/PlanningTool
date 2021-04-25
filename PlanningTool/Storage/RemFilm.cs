using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PlanningTool.Storage
{
    public partial class RemFilm : Form
    {
        public RemFilm()
        {
            InitializeComponent();
        }

        private void bnRem_Click(object sender, EventArgs e)
        {
            Form1 form = (Form1)this.Owner;
            Film f = null;
            int counter = 0;
            for (int i = 0; i < form.storage.films.Count; i++)
            {
                if (form.storage.films[i].ID == textBox1.Text)
                {
                    f = (Film)form.storage.films[i];
                    counter = i;
                }
            }

            form.storage.films.Remove(f);
            form.f_dt.Rows.RemoveAt(form.f_dt.Rows.Count - counter - 1);
            Close();
        }
    }
}
