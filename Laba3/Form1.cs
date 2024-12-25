using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Laba3
{
    public partial class Form1 : Form
    {
        
        BD Connection = new BD();
        public Form1()
        {
            InitializeComponent();
            //BD Connection = new BD();
            Console.WriteLine("хай");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string login = textBox1.Text;
            string password = textBox2.Text;

            // Select User FROM user WHERE Login = text AND Password = text;
            //Form2 form2 = new Form2(this);
            //form2.Show();
            //BD Connection = new BD();
            if (Connection.IsUserBD(login, password))
            {
                Form2 form2 = new Form2(this, Connection);
                form2.Show();
            }
            else
            {
                MessageBox.Show("Пользоватяля с такими данными не существует", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
