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
    public partial class AddFilm : Form
    {
        public AddFilm()
        {
            InitializeComponent();
        }

        public string ID = null;
        public int index = 0;
        public Form1 form1;

        public void LoadVars()
        {
            Film f = (Film)form1.storage.films[index];
            txDuration.Text = f.Duration;
            txGenre.Text = f.GetGenres();
            txLocation.Text = f.Location;
            txTitle.Text = f.Title;
            dtpReleaseDate.Value = f.ReleaseDate;
            tmp_genres = f.genres;
            this.Text = $"Edit Film - {ID}";
            this.btnAdd.Text = "Edit";
        }

        public List<Film.F_GENRE> tmp_genres = new List<Film.F_GENRE>();

        public void Add(object sender, EventArgs e)
        {
            if (txTitle.Text == "" || txGenre.Text == "") return;
            if (ID == null)
            {
                Form1 form1 = (Form1)this.Owner;

                Film tmp = new Film(tmp_genres);
                tmp.Title = txTitle.Text;
                tmp.Duration = txDuration.Text;
                tmp.ReleaseDate = dtpReleaseDate.Value;
                tmp.Location = txLocation.Text;

                form1.storage.Add(tmp);

                DataRow dr = form1.f_dt.NewRow();
                dr[0] = tmp.ID;
                dr[1] = tmp.Title;
                dr[2] = tmp.GetGenres();
                dr[3] = tmp.Duration;
                dr[4] = tmp.ReleaseDate;
                dr[5] = tmp.Location;

                form1.f_dt.Rows.InsertAt(dr, 0);
            }
            else
            {
                Film tmp = new Film(tmp_genres, ID);
                tmp.Title = txTitle.Text;
                tmp.Duration = txDuration.Text;
                tmp.ReleaseDate = dtpReleaseDate.Value;
                tmp.Location = txLocation.Text;
                tmp.edited = true;

                form1.storage.films[index] = tmp;

                DataRow dr = form1.f_dt.NewRow();
                dr[0] = tmp.ID;
                dr[1] = tmp.Title;
                dr[2] = tmp.GetGenres();
                dr[3] = tmp.Duration;
                dr[4] = tmp.ReleaseDate;
                dr[5] = tmp.Location;

                form1.f_dt.Rows.InsertAt(dr, index);
                form1.f_dt.Rows.RemoveAt(index + 1);

            }
            ID = "";
            Close();
        }

        private void bnAddGenre_Click(object sender, EventArgs e)
        {
            AddGenre addGenre = new AddGenre();
            addGenre.ShowDialog(this);
        }

        private void bnRemove_Click(object sender, EventArgs e)
        {
            RemGenre remGenre = new RemGenre();
            remGenre.ShowDialog(this);
        }
    }
}
