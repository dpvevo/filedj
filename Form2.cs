using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Media;
using System.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Diagnostics;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Runtime.CompilerServices;

namespace DPshare
{
    public partial class Player : Form
    {
        public Player()
        {
            InitializeComponent();
            player.MediaEnded += Player_MediaEnded;
            sql();
            UpdateMusicTable();

        }


        public void UpdateMusicTable()
        {
            var FilesFromDatabase = FetchFilesFromDatabase();
            UpdateListView(FilesFromDatabase);
        }

        public DataSet FetchFilesFromDatabase()
        {
            DataSet dataset = new DataSet();

            using (SQLiteConnection connection = new SQLiteConnection("Data Source=Database1.sqlite"))
            {
                SQLiteDataAdapter adapter = new SQLiteDataAdapter("SELECT * FROM file", connection);

                adapter.Fill(dataset);

                return dataset;
            }
        }

        public void UpdateListView(DataSet FilesFromDatabase)
        {

            listView1.BeginUpdate();
            listView1.Items.Clear();
            foreach (DataRow row in FilesFromDatabase.Tables[0].Rows)
            {
                listView1.Items.Add(new ListViewItem(new string[] { row["id"].ToString(), row["filename"].ToString(), row["userid"].ToString() }));
            }
            this.listView1.EndUpdate();
            listView1.CheckBoxes = true;
            listView1.GridLines = true;

        }


        public string filename;
        public byte[] file;
        static bool playing = false;
        bool fileloaded = false;
        public static MediaPlayer player = new MediaPlayer();
        public OpenFileDialog filepick = new OpenFileDialog();


        public void openfilepicker() //opens file picker
        {   //test
            filepick.InitialDirectory = @"C:\Users\User\Music";
            filepick.Filter = "wav files (*.wav)|*.wav|mp3 files (*.mp3*)|*.mp3*";
            filepick.FilterIndex = 2;
            DialogResult dialogresult = filepick.ShowDialog();
            if (dialogresult == DialogResult.OK)
            {
                filename = filepick.FileName;
                file = filedata(filename);
            }
            else if (dialogresult == DialogResult.Cancel)
            {

            }
        }

        public byte[] filedata(string filename)
        {
            byte[] file = System.IO.File.ReadAllBytes(filename);
            return file;
        }


        public void loadfile() //loads file and removes silly stuff from the title
        {

            if ((filename != "") && (filename != null))
            {
                player.Open(new Uri(filename));
                filename = filename.Replace(@"C:\Users\User\Music\", " ");
                filename = filename.Replace(".wav", " ");
                filename = filename.Replace(".mp3", " ");
                fileloaded = true;
            }
            else
            {
                fileloaded = false;
            }
        }

        private void importfile(object sender, EventArgs e) //user presses import file
        {
            openfilepicker();
            loadfile();
            if (fileloaded == true)
            {
                button1.Text = filename;
            }
            else
            {
                button1.Text = "Import File";
            }


        }


        private void Play_Click(object sender, EventArgs e) //play button
        {

            if (fileloaded == true)
            {
                if (playing == false)
                {
                    Play.Text = "▐▐";
                    player.Play();
                    playing = true;
                }
                else if (playing == true)
                {
                    player.Pause();
                    Play.Text = "▶️";
                    playing = false;

                }
            }
        }
        private void Player_MediaEnded(object sender, EventArgs e) //song has ended
        {
            playing = false;
            Play.Text = "▶";
            player.Stop();
        }
        private void Stop_Click(object sender, EventArgs e) //stop button
        {
            player.Stop();
            playing = false;
            Play.Text = "▶";
        }

        private async void volumeup(object sender, EventArgs e) // volume up
        {
            player.Volume = player.Volume + 0.1;
            volume.Text = (player.Volume * 100).ToString();
            volume.Visible = true;
            await Task.Delay(1500);
            volume.Visible = false;

        }

        private async void volumedown(object sender, EventArgs e) // volume down
        {
            player.Volume = player.Volume - 0.1;
            volume.Text = (player.Volume * 100).ToString();
            volume.Visible = true;
            await Task.Delay(1500);
            volume.Visible = false;
        }



        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void upload_Click(object sender, EventArgs e)
        {
            openfilepicker();
            loadfile();
            addtables(filename, 1, file);
            UpdateMusicTable();

        }

        private void Account_Click(object sender, EventArgs e)
        {
            
        }


        // private void table()
        // {
        //   int item = 0;
        //   using (var connection = new SQLiteConnection("Data Source=Database1.sqlite"))
        //   {
        // SQLiteDataAdapter adapter = new SQLiteDataAdapter("SELECT * FROM file", connection);
        // DataSet dataset = new DataSet();
        // adapter.Fill(dataset);

        // listView1.BeginUpdate();
        // listView1.Items.Clear();
        //     foreach (DataRow row in dataset.Tables[0].Rows)
        //    {
        // listView1.Items.Add(row["id"].ToString());
        // listView1.Items[item].SubItems.Add(row["filename"].ToString());
        //listView1.Items[item].SubItems.Add(row["userid"].ToString());
        //item = item + 1;
        // }



        //           this.listView1.EndUpdate();
        //         listView1.CheckBoxes = true;
        //   }

        //} 

        private void sql()
        {

            using (var connection = new SQLiteConnection("Data Source=Database1.sqlite"))
            {

                string user = "user";
                int userid = 1;
                var id = 0;
                connection.Open();
                createtables();

                int uc = checkuser(user);



                if (uc == 1) // user exists
                {
                    var command = connection.CreateCommand();
                    command.CommandText =
                    @"
                SELECT id, userid, filename FROM file;
                ";
                    command.Parameters.AddWithValue("$id", id);
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Debug.WriteLine(reader.GetInt32(0));
                        }
                    }
                }
                else if (uc == 0) // user doesnt exist 
                {
                    adduser(user);
                }




            }

        }

        private int checkuser(string username)
        {
            using (var connection = new SQLiteConnection("Data Source=Database1.sqlite"))
            {
                connection.Open();
                var checkuser = connection.CreateCommand();
                checkuser.CommandText =
                @"
                SELECT * FROM users WHERE username = $username
                ";
                checkuser.Parameters.AddWithValue("$username", username);
                var usercheck = (checkuser.ExecuteNonQuery());
                return usercheck;


            }

        }

        private void createtables()
        {
            using (var connection = new SQLiteConnection("Data Source=Database1.sqlite"))
            {
                connection.Open();
                var createtables = connection.CreateCommand();
                createtables.CommandText =
                @"
                CREATE TABLE IF NOT EXISTS file(id INTEGER PRIMARY KEY, userid INTEGER NOT NULL, filename STRING, filedata STRING, FOREIGN KEY (userid) REFERENCES users(id));
                CREATE TABLE IF NOT EXISTS users(id INTEGER PRIMARY KEY, username STRING UNIQUE NOT NULL, password STRING, imagedata STRING);
                ";
                createtables.ExecuteNonQuery();
            }

        }

        private void addtables(string filename, int userid, byte[] filedata)
        {
            using (var connection = new SQLiteConnection("Data Source=Database1.sqlite"))
            {

                connection.Open();
                var addtables = connection.CreateCommand();
                addtables.CommandText =
                @"
                INSERT INTO file (filename, userid, filedata)
                VALUES ($filename, $userid, $filedata);
                ";

                addtables.Parameters.AddWithValue("$filename", filename);
                addtables.Parameters.AddWithValue("$userid", userid);
                addtables.Parameters.AddWithValue("$filedata", filedata);
                addtables.ExecuteNonQuery();
            }

        }


        private void adduser(string username)
        {
            using (var connection = new SQLiteConnection("Data Source=Database1.sqlite"))
            {

                connection.Open();
                var adduser = connection.CreateCommand();
                adduser.CommandText =
                @"
                INSERT INTO users (username)
                VALUES ($username);
                ";

                adduser.Parameters.AddWithValue("$username", username);
                adduser.ExecuteNonQuery();
            }

        }



        private void deletefile(int id)
        {
            using (var connection = new SQLiteConnection("Data Source=Database1.sqlite"))
            {

                connection.Open();
                var eletefile = connection.CreateCommand();
                eletefile.CommandText =
                @"
                DELETE FROM file WHERE id = $inputid;
                ";

                eletefile.Parameters.AddWithValue("$inputid", id);
                eletefile.ExecuteNonQuery();
            }

        }

        private byte[] searchdatabaseforfiledata(string row, byte[] filedata, out string filename)
        {
            filename = "";
            using (var connection = new SQLiteConnection("Data Source=Database1.sqlite"))
            {

                connection.Open();
                var searchdatabaseforfiledata = connection.CreateCommand();
                searchdatabaseforfiledata.CommandText =
                @"
                SELECT filename, filedata FROM file WHERE id = $row
                ";
                searchdatabaseforfiledata.Parameters.AddWithValue("$row", row);
                byte[] buffer = new byte[1000000000];
                using (var reader = searchdatabaseforfiledata.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        filename = reader.GetString(0);
                        label2.Text = "Saved file" + filename + ".";

                        long filedatalong = reader.GetBytes(1, 0, buffer, 0, 1000000000);

                    }
                }
                filedata = buffer;
                searchdatabaseforfiledata.ExecuteNonQuery();

            }
            return filedata;
        }

        private void Player_Load(object sender, EventArgs e)
        {

        }

        private void export_Click(object sender, EventArgs e)
        {
            int i = 0;
            int[] checkedids = SeeWhatIDsChecked();
            foreach (int id in checkedids)
            {
                if (id == 1)
                {
                    ListViewItem row = listView1.Items[i];
                    string fileinfo = row.Text;
                    byte[] file = new byte[0];
                    string filename = "";
                    file = searchdatabaseforfiledata(fileinfo, file, out filename);
                    File.WriteAllBytes(@"C:\Users\User\Music\" + filename + ".mp3", file);
                }
                i = i + 1;

            }


        }

        private int[] SeeWhatIDsChecked()
        {
            List<int> checkedids = new List<int>();


            int item = 0;
            while (item < listView1.Items.Count)
            {
                ListViewItem currentitem = listView1.Items[item];

                if (currentitem.Checked == true)
                {
                    checkedids.Add(1);
                }
                else if (currentitem.Checked == false) 
                {
                    checkedids.Add(0);
                }
                item++;
            }
            int[] checkedidsint = checkedids.ToArray();
            return checkedidsint;


        }



        private void Search_TextChanged(object sender, EventArgs e)
        {


        }
        private void button3_Click(object sender, EventArgs e)
        {

            ListViewItem searchitem = listView1.FindItemWithText(Search.Text);
            if (searchitem != null)
            {
                MessageBox.Show("Calling FindItemWithText passing " + searchitem.ToString());

            }
            else
            {
                MessageBox.Show("File Not Found");
            }
        }
    }
}
