using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Laba3
{
    public partial class Form2 : Form
    {
        BD BD;
        public Form2(Form form1, BD Connection)
        {
            BD = Connection;
            InitializeComponent();
            form1.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (BD.AddComCon(GetSelectedRadioButtonText()))
            {
                //MessageBox.Show("Данные обновлены", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Form3 form3 = new Form3(this, BD);
                form3.Show();
            }
            else
            {
                MessageBox.Show("НЕА", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            
        }
        private string GetSelectedRadioButtonText()
        {
            if (radioButton1.Checked)
            {
                return radioButton1.Text;
            }
            else if (radioButton2.Checked)
            {
                return radioButton2.Text;
            }
            else if (radioButton3.Checked)
            {
                return radioButton3.Text;
            }
            else if (radioButton4.Checked)
            {
                return radioButton4.Text;
            }
            return "Ничего не выбрано";
        }
    }
}
