using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PlanningTool.Licenses
{
    public partial class RemoveLicense : Form
    {
        IMongoCollection<BsonDocument> licensesBson;

        public RemoveLicense()
        {
            InitializeComponent();
            tbKey.Text = "Enter key here...";
            tbKey.GotFocus += RemoveText;
            tbKey.LostFocus += AddText;

            MongoClient dbClient = new MongoClient($"mongodb+srv://{Secrets.rwUsername}:{Secrets.rwPassword}@{Secrets.serverURL}/<dbname>?retryWrites=true&w=majority");
            IMongoDatabase database = dbClient.GetDatabase("bxs-admin");
            licensesBson = database.GetCollection<BsonDocument>("licenses");
        }
        
        

        public void RemoveText(object sender, EventArgs e)
        {
            tbKey.Text = "";
        }

        public void AddText(object sender, EventArgs e)
        {
            if (tbKey.Text == "")
                tbKey.Text = "Enter key here...";
        }

        private void bnDelete_Click(object sender, EventArgs e)
        {
            if (tbKey.Text == "" || tbKey.Text == "Enter key here...")
            {
                MessageBox.Show("Specify a license key for deletion");
                return;
            }

            var filter = Builders<BsonDocument>.Filter.Eq("_id", new ObjectId(tbKey.Text));

            try
            {
                licensesBson.FindOneAndDelete(filter);
            }
            catch (Exception err)
            {
                MessageBox.Show(err.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Close();
        }

        private void bnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
