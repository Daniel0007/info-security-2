using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using lab2.Models;

namespace lab2.Controllers
{
    class data_controller
    {
        private user[] users;
        private file[] files;
        public int Get_filecount { get; set; }
        public int Get_usercount { get; set; }

        Random r = new Random((int)DateTime.Now.Ticks);
        public data_controller(int u_c,int f_c)
        {
            Get_filecount = f_c;
            Get_usercount = u_c;
            users = new user[u_c];
            users[0] = new user("Адміністратор", new marker(3),0);
            for(int i = 1;i<u_c;i++)
            {
                users[i] = new user("Користувач "+i.ToString(), new marker(r.Next(0,4)),i);
            }
            files = new file[f_c];
            for (int i = 0; i < f_c; i++)
            {
                files[i] = new file("файл " + (i+1).ToString(), new marker(r.Next(0, 4)));
            }
        }
        public user get_user(int i)
        {
            return users[i];
        }
        public file get_file(int i)
        {
            return files[i];
        }
    }
}
