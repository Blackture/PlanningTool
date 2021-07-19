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
using System.Text.RegularExpressions;

namespace PlanningTool.Licenses
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        IMongoCollection<BsonDocument> userCollection;

        private async void bnLogin_Click(object sender, EventArgs e)
        {
            if (tbEmail.Text == "" || tbEmail.Text == null || tbPw.Text == "" || tbPw.Text == null)
            {
                MessageBox.Show("Type in your pass and your email!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            MongoClient dbClient = new MongoClient($"mongodb+srv://{Secrets.standardUsername}:{Secrets.standardPassword}@{Secrets.serverURL}/<dbname>?retryWrites=true&w=majority");
            IMongoDatabase database = dbClient.GetDatabase("bxs-admin");
            userCollection = database.GetCollection<BsonDocument>("users");

            bool res = await SignIn(tbEmail.Text, tbPw.Text);

            if (!res)
            {
                bnCancel.PerformClick();
            }

            DialogResult = DialogResult.OK;
            Close();
        }

        private void bnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        public async Task<bool> SignIn(string email, string pw)
        {
            User user = await GetUser(email, pw);

            if (user == null || user.accountLevel > 1) return false;

            (Owner as Form1).isUserAdmin = true;
            return true;
        }

        public async Task<User> GetUser(string email, string pw)
        {
            var allUersTask = userCollection.FindAsync(new BsonDocument("email", email));
            var usersAwaitet = await allUersTask;
            List<BsonDocument> docs = usersAwaitet.ToList();

            if (docs.Count <= 0)
            {
                MessageBox.Show("Sry but a user with that email doesn't exist", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            else if (docs.Count == 1)
            {
                User user = null;
                foreach (var u in docs)
                {
                    user = Deserialize(u.ToString(), pw);
                }
                return user;
            }
            else
            {
                MessageBox.Show("Somehow two users with the same email adress are existing!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        private User Deserialize(string usersAwaitet, string pw)
        {
            string _usersAwaitet = Regex.Replace(usersAwaitet, "{ | }", "");
            string[] data = _usersAwaitet.Split(',');
            User user = new User();
            foreach (string s in data)
            {
                string[] _data = s.Split(':');
                if (_data[0].Trim() == "\"_id\"")
                {
                    string id = Regex.Replace(_data[1].Trim(), "(\\bObjectId\\b[(]\")|(\"[)])", "");
                    user.id = new ObjectId(id);
                }
                else if (_data[0].Trim() == "\"title\"")
                {
                    user.title = _data[1].Trim().Replace("\"", "");
                }
                else if (_data[0].Trim() == "\"profileIMG\"")
                {
                    user.profileIMG = _data[1].Trim().Replace("\"", "");
                }
                else if (_data[0].Trim() == "\"username\"")
                {
                    user.username = _data[1].Trim().Replace("\"", "");
                }
                else if (_data[0].Trim() == "\"date\"")
                {
                    string t = Regex.Replace((_data[1].Trim().Replace("\"", "") + ":" + _data[2] + ":" + _data[3].Trim().Replace("\"", "")), "ISODate[(]|[)]", "");
                    user.date = System.DateTime.Parse(t);
                }
                else if (_data[0].Trim() == "\"projectAccess\"")
                {
                    user.projectAccess = _data[1].Trim().Replace("\"", "");
                }
                else if (_data[0].Trim() == "\"accountType\"")
                {
                    int accountLvl = (Regex.Replace(_data[1].Trim(), "\"", "") == "owner") ? 0 : (_data[0].Trim() == "admin") ? 1 : (_data[0].Trim() == "developer") ? 2 : (_data[0].Trim() == "mod") ? 3 : (_data[0].Trim() == "tester") ? 4 : (_data[0].Trim() == "t-sub/yt-member") ? 5 : (_data[0].Trim() == "t-follower/yt-sub") ? 6 : (_data[0].Trim() == "five-year-member") ? 7 : (_data[0].Trim() == "one-year-member") ? 8 : (_data[0].Trim() == "normal") ? 9 : 10;
                    user.accountLevel = accountLvl;
                }
                else if (_data[0].Trim() == "\"password\"")
                {
                    string pwg = _data[1].Trim().Replace("\"", "");
                    bool correct = BCrypt.Net.BCrypt.Verify(pw, pwg);
                    if (!correct)
                    {
                        MessageBox.Show("That's not the user's password!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return null;
                    }
                }
            }

            return user;
        }


    }
}
