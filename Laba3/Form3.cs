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
    public partial class Form3 : Form
    {
        BD BD;
        public Form3(Form form2, BD Connection)
        {
            BD = Connection;
            InitializeComponent();
            form2.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (BD.Сomplaint(textBox1.Text)){
                MessageBox.Show("Данные обновлены", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else {
                MessageBox.Show("НЕА", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
