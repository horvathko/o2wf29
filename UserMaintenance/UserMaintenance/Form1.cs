using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UserMaintenance.Entities;

namespace UserMaintenance
{
    public partial class Form1 : Form
    {
        BindingList<User> users = new BindingList<User>();
        public Form1()
        {
            InitializeComponent();
            listBox1.DataSource = users;
            listBox1.ValueMember = "ID";
            listBox1.DisplayMember = "FullName";
            label2.Text = Resource1.LastName;
            button1.Text = Resource1.Add;
            button2.Text = Resource1.Wirte;
            button3.Text = Resource1.Delete;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            User u = new User() {FullName = textBox2.Text };
            users.Add(u);
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SaveFileDialog of = new SaveFileDialog();

            of.DefaultExt = "csv";
            if (of.ShowDialog()==DialogResult.OK)
            {
                using (StreamWriter sw = new StreamWriter(of.FileName))
                {

                    for (int i = 0; i < users.Count(); i++)
                    {
                        sw.Write(users[i].ID);
                        sw.Write(";");

                        sw.Write(users[i].FullName);
                        sw.WriteLine();

                    }


                }
            }
          
        }

        private void button3_Click(object sender, EventArgs e)
        {
            User u = new User();
            u.ID =  Guid.Parse(listBox1.SelectedValue.ToString());
            u.FullName = listBox1.SelectedItem.ToString();
           
            for (int i = 0; i < users.Count(); i++)
            {
                if (users[i].ID == u.ID)
                {
                    users.RemoveAt(i);
                }
            }
        }
    }
}
