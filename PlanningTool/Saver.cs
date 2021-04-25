using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Collections;

namespace PlanningTool
{
    public class Saver<T>
    {
        private DateTime saveDate;
        private string saveName;
        private T saveObject;

        public Saver(T _saveObject, string _saveName)
        {
            saveObject = _saveObject;
            saveName = _saveName;
            saveDate = DateTime.Now.ToUniversalTime();
        }

        public void Save(string path)
        {
            if (saveDate == null || saveName == null || saveObject == null)
                throw new NullReferenceException("You're missing a reference.");
            FileStream fs = new FileStream(path, FileMode.OpenOrCreate);
            try
            {
                Hashtable ht = new Hashtable()
                {
                    { "Date", saveDate },
                    { "Name", saveName },
                    { "Object", saveObject }
                };
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(fs, ht);
            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show(e.Message, "Error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            finally
            {
                fs.Close();
            }
        }

        public static T Open(string path, out string projName, out DateTime lastSaved)
        {
            FileStream fs = new FileStream(path, FileMode.Open);
            try
            {
                BinaryFormatter formatter = new BinaryFormatter();
                Hashtable ht = (Hashtable)formatter.Deserialize(fs);
                fs.Position = 0;

                lastSaved = (DateTime)ht["Date"];
                projName = (string)ht["Name"];
                T obj = (T)ht["Object"];
                return obj;
            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show(e.Message, "Error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            finally { fs.Close(); }

            projName = null;
            lastSaved = DateTime.UtcNow;
            return default;
        }
    }
}
