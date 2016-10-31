using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using lab2.Models;

namespace lab2.Controllers
{
    class controlls_controller
    {
        data_controller data;
        Label filename_Label;
        Label username_Label;
        Label userlevel_Label;
        Button user_button;
        TextBox username_textbox;
        Button read_button;
        Button write_button;
        TextBox filename_textbox;
        ComboBox user_level;
        DataGridView T;

        public controlls_controller(data_controller d)
        {
            data = d;
        }



        public DataGridView insert_table()
        {
            T = new DataGridView();
            T.Dock = DockStyle.Top;
            T.AutoResizeColumns();
            T.ColumnCount = 1;
            T.RowCount = data.Get_filecount + data.Get_usercount + 2;
            T.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            T.Rows[0].Cells[0].Value = "Суб'єкт-користувач";
            T.Rows[data.Get_usercount + 1].Cells[0].Value = "Об'єкт-файл";
            for (int i = 0; i < data.Get_usercount; i++)
            {
                T.Rows[i + 1].Cells[0].Value = data.get_user(i).Name + ": " + (data.get_user(i).Level.convert_marker());
            }
            for (int i = 0; i < data.Get_filecount; i++)
            {
                T.Rows[data.Get_usercount + i + 2].Cells[0].Value = data.get_file(i).Name + ": " + (data.get_file(i).Level.convert_marker());
            }
            
            return T;
        }

        public Label create_filename_label()
        {
            filename_Label = new Label();
            filename_Label.Text = "Файл";
            filename_Label.Top = 230;
            filename_Label.Left = 70;
            return filename_Label;
        }
        public Label create_userlevel_label()
        {
            userlevel_Label = new Label();
            userlevel_Label.Text = "Рівень доступу";
            userlevel_Label.Top = 175;
            userlevel_Label.Left = 335;
            return userlevel_Label;
        }
        public Label create_username_label()
        {
            username_Label = new Label();
            username_Label.Text = "Ідентифікатор";
            username_Label.Top = 230;
            username_Label.Left = 210;
            return username_Label;
        }
        public Button create_read_button()
        {
            read_button = new Button();
            read_button.Text = "Зчитати";
            read_button.Top = 170;
            read_button.Left = 20;
            read_button.Enabled = false;
            read_button.Click += read_button_click;
            return read_button;
        }
        public Button create_write_button()
        {
            write_button = new Button();
            write_button.Text = "Записати";
            write_button.Top = 170;
            write_button.Left = 100;
            write_button.Enabled = false;
            write_button.Click += write_button_click;
            return write_button;
        }
        public Button create_user_button()
        {
            user_button = new Button();
            user_button.Text = "Увійти";
            user_button.Top = 170;
            user_button.Left = 210;
            user_button.Click += user_button_click;

            return user_button;
        }
        public TextBox create_username__textbox()
        {
            username_textbox = new TextBox();
            username_textbox.Top = 200;
            username_textbox.Left = 200;
            return username_textbox;
        }
        public TextBox create_filename_textbox()
        {
            filename_textbox = new TextBox();
            filename_textbox.Top = 200;
            filename_textbox.Left = 40;
            filename_textbox.Enabled = false;
            return filename_textbox;
        }
        public ComboBox create_user_level()
        {
            user_level = new ComboBox();
            user_level.Text = string.Empty;
            user_level.Top = 200;
            user_level.Left = 320;
            user_level.Enabled = false;
            user_level.Items.Add("non confidential");
            user_level.Items.Add("confidential");
            user_level.Items.Add("secret");
            user_level.Items.Add("top secret");
            user_level.DropDownStyle = ComboBoxStyle.DropDownList;
            user_level.SelectionChangeCommitted += user_level_handler;
            return user_level;
        }

        private user user_insertion_correct()
        {
            for (int i = 0; i < data.Get_usercount; i++)
            {
                if (username_textbox.Text == data.get_user(i).Name)
                {
                    return data.get_user(i);
                }
            }
            return null;
        }

        private file file_insertion_correct()
        {
            for (int i = 0; i < data.Get_filecount; i++)
            {
                if (filename_textbox.Text == data.get_file(i).Name)
                {
                    return data.get_file(i);
                }
            }
            return null;
        }

        private void user_button_click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            if (user_insertion_correct() != null && b.Text == "Увійти")
            {

                b.Text = "Вийти";
                username_textbox.Enabled = false;
                MessageBox.Show("Вхід користувача " + user_insertion_correct().Name + " виконано \n");
                read_button.Enabled = true;
                write_button.Enabled = true;
                filename_textbox.Enabled = true;
                user_level.Enabled = true;
                user_level.Text = user_insertion_correct().Level.convert_marker();
            }
            else if (b.Text == "Вийти")
            {
                b.Text = "Увійти";
                MessageBox.Show("Вихід користувача " + user_insertion_correct().Name + " виконано");
                username_textbox.Enabled = true;
                username_textbox.Text = string.Empty;
                read_button.Enabled = false;
                write_button.Enabled = false;
                user_level.Text = string.Empty;
                user_level.Enabled = false;
                filename_textbox.Text = string.Empty;
                filename_textbox.Enabled = false;
                user_level.Text = string.Empty;
            }
            else
            {
                MessageBox.Show("Немає такого користувача!");
                username_textbox.Text = string.Empty;
            }
        }

        private void read_button_click(object sender, EventArgs e)
        {
            if(file_insertion_correct()!=null)
            {
                if(user_insertion_correct().Level>=file_insertion_correct().Level)
                {
                    MessageBox.Show("Користувач " + user_insertion_correct().Name + " має право на читання " + file_insertion_correct().Name);
                    filename_textbox.Text = string.Empty;
                }
                else
                {
                    MessageBox.Show("Користувач немає прав!");
                    filename_textbox.Text = string.Empty;
                }
            }
            else
            {
                MessageBox.Show("Немає такого файлу!");
                filename_textbox.Text = string.Empty;
            }
        }
        private void write_button_click(object sender, EventArgs e)
        {
            if (file_insertion_correct() != null)
            {
                if (user_insertion_correct().Level <= file_insertion_correct().Level)
                {
                    MessageBox.Show("Користувач " + user_insertion_correct().Name + " має право на запис в файл " + file_insertion_correct().Name);
                    filename_textbox.Text = string.Empty;
                }
                else
                {
                    MessageBox.Show("Користувач немає прав!");
                    filename_textbox.Text = string.Empty;
                }
            }
            else
            {
                MessageBox.Show("Немає такого файлу!");
                filename_textbox.Text = string.Empty;
            }
        }
        private void user_level_handler(object sender, EventArgs e)
        {
            marker temp = user_insertion_correct().Level;
            if (marker.convert_marker(user_level.Text)<= user_insertion_correct().Initial_level)
            {
                MessageBox.Show("Права користувача змінено!");
                user_insertion_correct().Level= marker.convert_marker(user_level.Text);
                T.Rows[user_insertion_correct().Number + 1].Cells[0].Value = data.get_user(user_insertion_correct().Number).Name + ": " + (data.get_user(user_insertion_correct().Number).Level.convert_marker());
            }
            else
            {
                MessageBox.Show("Користувачу неможливо надати такі права");
                user_level.Text = temp.convert_marker();
                user_insertion_correct().Level = temp;
            }
                
        }
    }
}
