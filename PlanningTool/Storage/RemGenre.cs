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
    public partial class RemGenre : Form
    {
        public RemGenre()
        {
            InitializeComponent();
        }

        private void bnRem_Click(object sender, EventArgs e)
        {
            if (int.TryParse(textBox1.Text, out int input))
            {
                AddFilm addFilm = this.Owner as AddFilm;
                addFilm.tmp_genres.RemoveAt(input - 1);
                List<string> genres = addFilm.txGenre.Text.Replace(" ", "").Split(',').ToList();
                genres.RemoveAt(input - 1);
                string genreString = "";
                foreach (string s in genres)
                {
                    genreString += (genreString == "") ? s : ", " + s;
                }
                addFilm.txGenre.Text = genreString;
                Close();
            }
            else
            {
                MessageBox.Show($"Invalid input: {textBox1.Text}.\nThe input needs to be an integer between 1 and the count of the selected genres.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
