using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace UserDiary
{

    [XmlRoot("Users")]
    public class DefaultUserList
    {
        [XmlAttribute("ID")]
        public int Id { get; set; }

        [XmlElement("User")]
        public List<User> UsersList { get; set; }

        [XmlIgnore]
        public int Count
        {
            get;
            set;
        }

        public DefaultUserList()
        {
            this.UsersList = new List<User>();
            Count = this.UsersList.Count;
        }

        public void AddUser(User user)
        {
            this.UsersList.Add(user);
            Count = this.UsersList.Count;
            Cache.getCache().UpdateUserList();
            Cache.getCache().UsernameList = Cache.getCache().GetUsernameList();
            Cache.getCache().defaultAdminList = Cache.getCache().GetAdminList();
            //this.UsersList = Cache.getCache().UserList.UsersList;
        }

        public void UpdateUser(User user)
        {
            if (FindUser(user.Id) != null)
            {
                DisplayUsers();
                int index = this.UsersList.FindIndex(userItem => userItem.Id == user.Id);
                Console.WriteLine(index);
                this.UsersList[index] = user;
                DisplayUsers();

            }
        }
            public bool DeleteUser(int userId)
        {
            if (FindUser(userId) != null)
            {
                this.UsersList.Remove(FindUser(userId));
                Count = this.UsersList.Count;
                Cache.getCache().UpdateUserList();
                Cache.getCache().UsernameList = Cache.getCache().GetUsernameList();
                Cache.getCache().defaultAdminList = Cache.getCache().GetAdminList();
                return true;
            }
            else { 
                //Console.Clear(); Console.WriteLine("\nNo user available of this Id!\n"); 
                return false; }
        }

        public User FindUser(int userId)
        {
            foreach (User user in this.UsersList)
            {
                if (user.Id == userId)
                {
                    return user;
                }
            }
            return null;
        }
        public User FindUser(string userName)
        {
            foreach (User user in this.UsersList)
            {
                if (user.UserName == userName)
                {
                    return user;
                }
            }
            return null;
        }
        //public int FindUserIndex(int userId)
        //{
        //    foreach (User user in this.UsersList)
        //    {
        //        if (user.Id == userId)
        //        {
        //            return 
        //        }
        //    }
        //    return null;
        //}
        public void DisplayUsers(List<User> list)
        {
            //Console.WriteLine(list.Count);
            foreach (User user in list)
            {
                //Console.WriteLine($"ID: {user.Id}\n" +
                //    $"Name: {user.Name}\n" +
                //    $"UserName: {user.UserName}\n" +
                //    $"Type: {user.Type}\n" +
                //    $"Status: {user.Status}\n" +
                //    $"Phone: {user.phone}\n" +
                //    $"Email: {user.email}\n");
            }
        }

        public void DisplayUsers()
        {
            foreach (User user in this.UsersList)
            {
                Console.WriteLine($"ID: {user.Id}\n" +
                    $"Name: {user.Name}\n" +
                    $"UserName: {user.UserName}\n" +
                    $"Type: {user.Type}\n" +
                    $"Status: {user.Status}\n" +
                    $"Phone: {user.phone}\n" +
                    $"Email: {user.email}\n");
            }
        }
        public override string ToString()
        {
            string us = "";
            foreach (User user in this.UsersList)
            { 
                us += $"ID: {user.Id}\n" +
                    $"name: {user.Name}\n" +
                    $"username: {user.UserName}\n" +
                    $"type: {user.Type}\n" +
                    $"status: {user.Status}\n" +
                    $"phone: {user.phone}\n" +
                    $"email: {user.email}\n";
                if (user.userDiaries is not null)
                {
                    user.userDiaries.DisplayDiaries();
                    foreach (Diary diary in user.userDiaries.diaries)
                    {
                    us += $"name: {diary.Name}\n" +
                    $"username: {diary.Content}\n";

                    }
                }
            }
            return us;
        }
    }
}
