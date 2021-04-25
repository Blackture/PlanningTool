using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PlanningTool.Storage
{
    public partial class AddGenre : Form
    {
        public AddGenre()
        {
            InitializeComponent();
        }

        private void Add(object sender, EventArgs e)
        {
            AddFilm addFilm = this.Owner as AddFilm;
            addFilm.tmp_genres.Add((Film.F_GENRE)comboBox1.SelectedIndex);
            addFilm.txGenre.Text += (addFilm.txGenre.Text == "") ? comboBox1.Text : ", " + comboBox1.Text;
            Close();
        }
    }
}
