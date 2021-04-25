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
    public partial class EditByID : Form
    {
        public EditByID()
        {
            InitializeComponent();
        }

        private void bnEdit_Click(object sender, EventArgs e)
        {
            Form1 form1 = (Form1)this.Owner;
            for (int i = 0; i < form1.storage.films.Count; i++)
            {
                if (form1.storage.films[i].ID == textBox1.Text)
                {
                    AddFilm editFilm = new AddFilm();
                    editFilm.ID = textBox1.Text;
                    editFilm.index = i;
                    editFilm.form1 = form1;
                    editFilm.LoadVars();
                    editFilm.ShowDialog(form1);
                    Close();
                }
            }
        }
    }
}
