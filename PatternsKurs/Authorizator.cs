using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PatternsKurs
{
    class Authorizator
    {
        public bool authorizate(string username, string passwd)
        {
            MyDbContext db = MyDbContext.getInstance();
            FamilyMember member = db.FamilyMembers.Where(f => f.Name == username && f.Password == passwd).FirstOrDefault();

            if (member == null)
                return false;
            else
                return true;            
        }

        public bool addUser(string username, string passwd)
        {
            MyDbContext db = MyDbContext.getInstance();

            if (username != "")
            {
                FamilyMember member = new FamilyMember();
                member.Name = username;
                member.Password = passwd;

                db.FamilyMembers.Add(member);
                db.SaveChanges();

                MessageBox.Show("Новый пользователь создан!");
                return true;
            }
            else
            {
                MessageBox.Show("Имя пользователя не может быть пустым!");
                return false;
            }
        }
    }
} 
