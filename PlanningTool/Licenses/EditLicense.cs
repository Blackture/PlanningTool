using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MongoDB.Driver;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.IO;

namespace PlanningTool.Licenses
{
    public partial class EditLicense : Form
    {
        IMongoCollection<BsonDocument> userCollection;
        IMongoCollection<BsonDocument> licensesBson;
        IMongoCollection<BsonDocument> projectsBson;

        List<Project> projects = new List<Project>();
        List<User> users = new List<User>();
        List<License> keys = new List<License>();

        public EditLicense()
        {
            InitializeComponent();
            MongoClient dbClient = new MongoClient($"mongodb+srv://{Secrets.rwUsername}:{Secrets.rwPassword}@{Secrets.serverURL}/<dbname>?retryWrites=true&w=majority");
            IMongoDatabase database = dbClient.GetDatabase("bxs-admin");
            userCollection = database.GetCollection<BsonDocument>("users");
            licensesBson = database.GetCollection<BsonDocument>("licenses");
            projectsBson = database.GetCollection<BsonDocument>("projects");

            List<BsonDocument> keys = licensesBson.Find(new BsonDocument()).ToList();
            List<BsonDocument> users = userCollection.Find(new BsonDocument()).ToList();
            List<BsonDocument> projects = projectsBson.Find(new BsonDocument()).ToList();

            foreach (BsonDocument BD in projects) {
                Project project = BsonSerializer.Deserialize<Project>(BD);
                this.projects.Add(project);
            }

            cbUser.Items.Add("none");

            foreach (BsonDocument BD in users)
            {
                User usr = BsonSerializer.Deserialize<User>(BD);
                this.users.Add(usr);
            }

            cbUser.SelectedIndex = 0;
            cbUser.DropDownStyle = ComboBoxStyle.DropDownList;

            foreach (User u in this.users)
            {
                cbUser.Items.Add(u.email);
            }

            foreach (Project p in this.projects)
            {
                cbProject.Items.Add(p.name);
            }

            cbProject.SelectedIndex = 0;
            cbProject.DropDownStyle = ComboBoxStyle.DropDownList;

            foreach (BsonDocument keyBD in keys)
            {
                License license = BsonSerializer.Deserialize<License>(keyBD);
                this.keys.Add(license);
                cbKey.Items.Add(license.id.ToString());
            }

            cbKey.SelectedIndex = 0;
            cbKey.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void OnLicenseChange(object sender, EventArgs e)
        {
            string SelectedId = cbKey.Text;
            foreach (License l in keys)
            {
                if (l.id == new ObjectId(SelectedId))
                {
                    if (l.uuid == new ObjectId())
                    {
                        cbUser.SelectedIndex = 0;
                    }
                    else
                    {
                        User u = new User();
                        foreach (User usr in users)
                        {
                            if (usr.id == l.uuid)
                            {
                                u = usr;
                            }
                        }

                        int ui = cbUser.Items.IndexOf(u.email);
                        if (ui > -1) cbUser.SelectedIndex = ui;
                    }

                    Project p = new Project();
                    foreach (Project pro in projects)
                    {
                        if (pro.id == l.project)
                        {
                            p = pro;
                        }
                    }

                    int pi = cbProject.Items.IndexOf(p.name); //pi is project index
                    if (pi > -1) cbProject.SelectedIndex = pi;
                }
            }
        }

        private async void bnCreate_Click(object sender, EventArgs e)
        {
            string str = null;
            str = cbUser.Text;
            if (str == "none") str = null;
            string email = (str == null) ? "" : cbUser.Text;
            if (email != "")
            {
                foreach (User u in users)
                {
                    if (u.email == cbUser.Text)
                    {
                        str = u.id.ToString();
                    }
                }
            }

            ObjectId projectId = new ObjectId();
            foreach (Project project in projects)
            {
                if (project.name == cbProject.Text)
                {
                    projectId = project.id;
                }
            }

            License license = new License();
            license.id = new ObjectId(cbKey.Text);
            license.uuid = (str == null) ? new ObjectId() : new ObjectId(str);
            license.used = str == null ? false : true;
            license.project = projectId;
            license.filters = new string[]
            {
                cbProject.Text,
                email
            };

            var filter = Builders<BsonDocument>.Filter.Eq("id", new ObjectId());
            bool isFilterSet = false;
            foreach (License l in keys)
            {
                if (l.id == license.id)
                {
                    filter = Builders<BsonDocument>.Filter.Eq("_id", l.id);
                    isFilterSet = true;
                }
            }
            if (!isFilterSet)
            {
                MessageBox.Show("Filter could not be set!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            await licensesBson.DeleteOneAsync(filter);
            await licensesBson.InsertOneAsync(license.ToBsonDocument());

            DialogResult = DialogResult.OK;
            Close();
        }

        private void bnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
