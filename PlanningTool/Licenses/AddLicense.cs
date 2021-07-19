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

namespace PlanningTool.Licenses
{
    public partial class AddLicense : Form
    {
        IMongoCollection<BsonDocument> userCollection;
        IMongoCollection<BsonDocument> licensesBson;
        IMongoCollection<BsonDocument> projectsBson;

        List<Project> projects = new List<Project>();
        List<User> users = new List<User>();

        public AddLicense()
        {
            InitializeComponent();
            MongoClient dbClient = new MongoClient($"mongodb+srv://{Secrets.rwUsername}:{Secrets.rwPassword}@{Secrets.serverURL}/<dbname>?retryWrites=true&w=majority");
            IMongoDatabase database = dbClient.GetDatabase("bxs-admin");
            userCollection = database.GetCollection<BsonDocument>("users");
            licensesBson = database.GetCollection<BsonDocument>("licenses");
            projectsBson = database.GetCollection<BsonDocument>("projects");

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
        }

        private async void bnCreate_Click(object sender, EventArgs e)
        {
            string str = null;
            str = cbUser.Text;
            if (str == "none") str = null;

            ObjectId projectId = new ObjectId();
            foreach (Project project in projects)
            {
                if (project.name == cbProject.Text)
                {
                    projectId = project._id;
                }
            }

            License license = new License();
            license._id = new ObjectId();
            license.uuid = (str == null) ? new ObjectId() : new ObjectId(str);
            license.used = str == null ? false : true;
            license.project = projectId;
            license.filters = new string[]
            {
                cbProject.Text,
                ""
            };

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
