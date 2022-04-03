using System;
using System.Collections.Generic;
using PlanningTool.Licenses;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MongoDB.Driver;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;

namespace PlanningTool
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            main.Enabled = true;
            main.Start();
            this.FormClosing += OnExit;
        }

        private void OnExit(object sender, FormClosingEventArgs e)
        {
            if (CheckForChanges())
            {
                DialogResult res = MessageBox.Show("You have unsaved changes.\nAre you sure you want to quit?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (res == DialogResult.Yes)
                {
                    e.Cancel = false;
                }
                else if (res == DialogResult.No )
                {
                    e.Cancel = true;
                }
            }
            else
            {
                e.Cancel = false;
            }
        }

        private void Exit(object sender, EventArgs e)
        {
            Close();
        }

        ToolStripMenuItem tsStorage;
        object active = null;
        public Storage.Storage storage;
        GroupBox films;
        public DataTable f_dt;
        bool saved;
        bool stopCycle = false;

        public bool isUserAdmin = false;
        
        public enum TYPE
        {
            STORAGE,
            ROLEPLAY,
            BXS_LICENSES
        }

        public TYPE type;

        private void NewStorage(object sender, EventArgs e)
        {
            if (active == null)
            {
                type = TYPE.STORAGE;

                msMain.Items.Remove(tsStorage);
                tsStorage = new ToolStripMenuItem("Storage");
                ToolStripMenuItem tsddb = new ToolStripMenuItem("Add");
                ToolStripMenuItem tsddb2 = new ToolStripMenuItem("Film Table");
                tsddb2.Click += AddFilmTable;
                tsddb.DropDownItems.Add(tsddb2);
                tsStorage.DropDownItems.Add(tsddb);
                msMain.Items.Add(tsStorage);

                //------------------------------------------------------------------
                storage = new Storage.Storage();
                active = storage;

                this.Text = $"Planning Tool - Unknown* - {DateTime.Now.ToLocalTime()}";
            }
            else
            {
                ToolStripLabel lbl = new ToolStripLabel("Storage Module Already Existing");
                statusMain.Items.Add(lbl);
                Destroy destroy = new Destroy(1000, lbl);
                destroy.onDestroy += new EventHandler<object>(RemoveObjectStatusMain);
            }
        }

        private void AddFilmTable(object sender, EventArgs e)
        {
            if (storage.films != null)
            {
                ToolStripLabel lbl = new ToolStripLabel("Film Table Already Existing");
                statusMain.Items.Add(lbl);
                Destroy destroy = new Destroy(5000, lbl);
                destroy.onDestroy += new EventHandler<object>(RemoveObjectStatusMain);
            }
            else
            {
                storage.films = new List<Storage.StorageItem>();
                CreateFilmView();
            }
        }

        private void CreateFilmView()
        {
            films = new GroupBox();
            films.Text = "Films";
            films.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
            films.Size = new Size(this.Size.Width - 40, (this.Size.Height - 64) / 2);
            films.Location = new Point(12, 27);
            this.Controls.Add(films);

            DataGridView dgv = new DataGridView();

            f_dt = new DataTable();
            f_dt.Columns.Add(new DataColumn("ID", typeof(string)));
            f_dt.Columns.Add(new DataColumn("Title", typeof(string)));
            f_dt.Columns.Add(new DataColumn("Genre", typeof(string)));
            f_dt.Columns.Add(new DataColumn("Duration", typeof(string)));
            f_dt.Columns.Add(new DataColumn("ReleaseDate", typeof(DateTime)));
            f_dt.Columns.Add(new DataColumn("Location", typeof(string)));
            f_dt.Rows.Clear();

            dgv.DataSource = f_dt;
            dgv.Location = new Point(6, 19);
            dgv.Size = new Size(films.Size.Width - 12, films.Size.Height - 25);
            dgv.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
            dgv.ReadOnly = true;

            films.Controls.Add(dgv);

            foreach (DataGridViewColumn col in dgv.Columns)
            {
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }

            dgv.Dock = DockStyle.Fill;

            ToolStripMenuItem table = new ToolStripMenuItem("Films Table");
            ToolStripMenuItem tableAdd = new ToolStripMenuItem("Add Film");
            ToolStripMenuItem tableEdit = new ToolStripMenuItem("Edit Film");
            ToolStripMenuItem tableRem = new ToolStripMenuItem("Remove Film");
            tableAdd.Click += AddFilm;
            tableEdit.Click += EditFilm;
            tableRem.Click += RemoveFilm;
            table.DropDownItems.Add(tableAdd);
            table.DropDownItems.Add(tableEdit);
            table.DropDownItems.Add(tableRem);
            tsStorage.DropDownItems.Add(table);
        }

        private void RemoveFilm(object sender, EventArgs e)
        {
            Storage.RemFilm remFilm = new Storage.RemFilm();
            remFilm.ShowDialog(this);
        }

        private void RemoveObjectStatusMain(object sender, object e)
        {
            statusMain.Items.Remove(e as ToolStripLabel);
        }

        private void AddFilm(object sender, EventArgs e)
        {
            Storage.AddFilm addFilm = new Storage.AddFilm();
            addFilm.ShowDialog(this);
        }

        private void EditFilm(object sender, EventArgs e)
        {
            Storage.EditByID editByID = new Storage.EditByID();
            editByID.ShowDialog(this);
        }

        private void Save(object sender, EventArgs e)
        {
            if (active != null)
            {
                stopCycle = true;

                if (saved && type == TYPE.STORAGE)
                {
                    string[] get = this.Text.Split('-');

                    for (int i = 0; i < storage.films.Count; i++)
                    {
                        (storage.films[i] as Storage.Film).edited = false;
                    }

                    Saver<Storage.Storage> saver = new Saver<Storage.Storage>(storage, get[1].Trim().Replace("*", ""));
                    saver.Save(System.IO.Path.GetFullPath(get[1].Trim().Replace("*", "")));
                    this.Text = $"Planning Tool - {get[1].Trim().Replace("*", "")} - Last Saving {DateTime.Now.ToLocalTime()}";
                    saved = true;
                }
                else if (saved && type == TYPE.BXS_LICENSES)
                {

                }
                else
                {
                    SaveAs(sender, e);
                }
                stopCycle = false;
            }
        }

        private void SaveAs(object sender, EventArgs e)
        {
            if (active != null)
            {
                stopCycle = true;
                SaveFileDialog saveFile = new SaveFileDialog()
                {
                    Title = "Save",
                    Filter = "pts files (*.pts)|*.pts",
                    FilterIndex = 1,
                    DefaultExt = "pts",
                    CheckPathExists = true,
                };

                DialogResult result = saveFile.ShowDialog();
                if (result == DialogResult.OK)
                {
                    for (int i = 0; i < storage.films.Count; i++)
                    {
                        (storage.films[i] as Storage.Film).edited = false;
                    }

                    if (type == TYPE.STORAGE)
                    {
                        Saver<Storage.Storage> saver = new Saver<Storage.Storage>(storage, saveFile.FileName);
                        saver.Save(System.IO.Path.GetFullPath(saveFile.FileName));
                        this.Text = $"Planning Tool - {saveFile.FileName} - Last Saving {DateTime.Now.ToLocalTime()}";
                        saved = true;
                    }
                }
                stopCycle = false;
            }
        }

        private void Open(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog()
            {
                Title = "Open",
                Filter = "pts files (*.pts)|*.pts",
                FilterIndex = 1,
                DefaultExt = "pts",
                CheckPathExists = true,
            };

            DialogResult result = openFile.ShowDialog();
            if (result == DialogResult.OK && (sender as ToolStripMenuItem).Text == "Storage")
            {
                type = TYPE.STORAGE;

                NewStorage(null, null);

                storage = Saver<Storage.Storage>.Open(System.IO.Path.GetFullPath(openFile.FileName), out string pn, out DateTime ls);
                this.Text = $"Planning Tool - {pn} - Last Saving {ls.ToLocalTime()}";

                CreateFilmView();

                if (storage.films.Count > 0)
                {
                    foreach (Storage.Film tmp in this.storage.films)
                    {
                        DataRow dr = this.f_dt.NewRow();
                        dr[0] = tmp.ID;
                        dr[1] = tmp.Title;
                        dr[2] = tmp.GetGenres();
                        dr[3] = tmp.Duration;
                        dr[4] = tmp.ReleaseDate;
                        dr[5] = tmp.Location;
                        this.f_dt.Rows.InsertAt(dr, 0);
                    }
                }
                saved = true;
            }
            else if (result == DialogResult.OK && (sender as ToolStripMenuItem).Text == "Licenses")
            {
                type = TYPE.BXS_LICENSES;
            }
        }

        private bool CheckForChanges() //true if it has changes
        {
            if (this.Text.Length > 13)
            {
                string[] get = this.Text.Split('-');
                if (saved)
                {
                    Storage.Storage _storage = Saver<Storage.Storage>.Open(System.IO.Path.GetFullPath(get[1].Replace("*", "").Trim()), out string pn, out DateTime ls);
                    if (_storage.films.Count != storage.films.Count)
                    {
                        this.Text = $"Planning Tool - {pn}* - Last Saving {ls.ToLocalTime()}";
                        return true;
                    }
                    else
                    {
                        if (_storage.films.Count > 0)
                        {
                            for (int i = 0; i < _storage.films.Count; i++)
                            {
                                if ((storage.films[i] as Storage.Film).edited)
                                {
                                    this.Text = $"Planning Tool - {pn}* - Last Saving {ls.ToLocalTime()}";
                                    return true;
                                }
                            }
                            return false;
                        }
                        return false;
                    }
                }
                else return true;
            }
            return false;
        }

        private void Tick(object sender, EventArgs e)
        {
            if (!stopCycle)
            {
                CheckForChanges();
            }
        }

        private DataTable licenseDataTable = new DataTable();
        private DataGridView dgv;

        private void NewLicensesWindow(object sender, EventArgs e)
        {
            Licenses.Login login = new Licenses.Login();
       
            DialogResult res = login.ShowDialog(this);

            if (isUserAdmin && res == DialogResult.OK)
            {
                CreateLicenseView();
                CreateLicenseMenuStrip();
            }
        }

        ToolStripMenuItem tsLicenses;

        private void CreateLicenseMenuStrip()
        {
            tsLicenses = new ToolStripMenuItem("License Management");
            ToolStripMenuItem tableAdd = new ToolStripMenuItem("Add License");
            ToolStripMenuItem tableEdit = new ToolStripMenuItem("Edit License");
            ToolStripMenuItem tableRem = new ToolStripMenuItem("Remove License");
            ToolStripMenuItem tableUpdate = new ToolStripMenuItem("Sync with DB");
            tableAdd.Click += AddLicense;
            tableEdit.Click += EditLicense;
            tableRem.Click += RemoveLicense;
            tableUpdate.Click += SyncWithDB;
            tsLicenses.DropDownItems.Add(tableAdd);
            tsLicenses.DropDownItems.Add(tableEdit);
            tsLicenses.DropDownItems.Add(tableRem);
            tsLicenses.DropDownItems.Add(tableUpdate);
            msMain.Items.Add(tsLicenses);
        }

        private void AddLicense(object sender, EventArgs e)
        {
            AddLicense addLicense = new AddLicense();
            addLicense.ShowDialog(this);
            UpdateLicenseDataTable();
        }

        private void EditLicense(object sender, EventArgs e)
        {
            EditLicense editLicense = new EditLicense();
            editLicense.ShowDialog(this);
            UpdateLicenseDataTable();
        }

        private void RemoveLicense(object sender, EventArgs e)
        {
            RemoveLicense removeLicense = new RemoveLicense();
            removeLicense.ShowDialog(this);
            UpdateLicenseDataTable();
        }

        private void SyncWithDB(object sender, EventArgs e)
        {
            UpdateLicenseDataTable();
        }

        private void CreateLicenseView()
        {
            GroupBox licenses = new GroupBox();
            licenses.Text = "Licenses";
            licenses.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
            licenses.Size = new Size(this.Size.Width - 40, (this.Size.Height - 64) / 2);
            licenses.Location = new Point(12, 27);

            dgv = new DataGridView();

            licenseDataTable = new DataTable();
            licenseDataTable.Columns.Add(new DataColumn("License Key", typeof(string)));
            licenseDataTable.Columns.Add(new DataColumn("Associated UUID", typeof(string)));
            licenseDataTable.Columns.Add(new DataColumn("Associated Project", typeof(string)));
            licenseDataTable.Columns.Add(new DataColumn("Is the key used?", typeof(bool)));
            licenseDataTable.Columns.Add(new DataColumn("Filters", typeof(string)));
            licenseDataTable.Rows.Clear();

            UpdateLicenseDataTable();

            dgv.DataSource = licenseDataTable;
            dgv.Location = new Point(6, 19);
            dgv.Size = new Size(licenses.Size.Width - 12, licenses.Size.Height - 25);
            dgv.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
            dgv.ReadOnly = true;

            licenses.Controls.Add(dgv);
            this.Controls.Add(licenses);

            foreach (DataGridViewColumn col in dgv.Columns)
            {
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }

            dgv.Dock = DockStyle.Fill;
        }

        private void UpdateLicenseDataTable()
        {
            MongoClient dbClient = new MongoClient($"mongodb+srv://{Secrets.standardUsername}:{Secrets.standardPassword}@{Secrets.serverURL}/<dbname>?retryWrites=true&w=majority");
            IMongoDatabase database = dbClient.GetDatabase("bxs-admin");
            IMongoCollection<BsonDocument> licenseCollection = database.GetCollection<BsonDocument>("licenses");

            List<License> licenses = new List<License>();
            List<BsonDocument> bsonElements = licenseCollection.Find(new BsonDocument()).ToList();

            foreach (BsonDocument doc in bsonElements)
            {
                License l = BsonSerializer.Deserialize<License>(doc);
                licenses.Add(l);
            }

            licenseDataTable.Clear();

            foreach (License l in licenses)
            {
                DataRow row = licenseDataTable.NewRow();
                row[0] = l.id.ToString();
                row[1] = l.uuid.ToString();
                row[2] = l.project.ToString();
                row[3] = l.used;
                row[4] = l.filters[0] + "    -    " + l.filters[1];
                licenseDataTable.Rows.InsertAt(row, 0);
            }

            foreach (DataGridViewColumn col in dgv.Columns)
            {
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
        }
    }
}
