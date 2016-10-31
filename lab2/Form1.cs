using System;
using System.Windows.Forms;
using lab2.Controllers;
namespace lab2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label1.Hide();
            label2.Hide();
            textBox1.Hide();
            textBox2.Hide();
            button1.Hide();
            
            int file_count = Int32.Parse(textBox1.Text);
            int user_count = Int32.Parse(textBox2.Text);

            data_controller d = new data_controller(user_count,file_count);
            controlls_controller c = new controlls_controller(d);
            Controls.Add(c.insert_table());
            MessageBox.Show("Введіть ідентифікатор!");
            Controls.Add(c.create_username_label());
            Controls.Add(c.create_filename_label());
            Controls.Add(c.create_read_button());
            Controls.Add(c.create_write_button());
            Controls.Add(c.create_user_button());
            Controls.Add(c.create_username__textbox());
            Controls.Add(c.create_filename_textbox());
            Controls.Add(c.create_user_level());
            Controls.Add(c.create_userlevel_label());
        }
    }
}
