using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserDiary
{
    public class Cache
    {
        static Cache? instance;
        public List<string> UsernameList;
        public List<Diary_List> defaultDiaryList;
        public DefaultUserList UserList;

        public List<User> defaultAdminList;
        
        public User? currentUser;

        public static Cache getCache()
        {
            if (instance == null)
            {
                instance = new Cache();
            };
            return instance;
        }

        Cache()
        {

            UserList =  new DefaultUserList();
            UsernameList = new List<string>();
            defaultDiaryList = new List<Diary_List>();

            UserList = Xml<DefaultUserList>.Deserialize(UserList);
            if (UserList == null)
            {
                UserList = new DefaultUserList();
                Xml<DefaultUserList>.Serialize(UserList);
                User admin = new ("admin", "Admin", "admin","admin","active", "", "");
                admin.display();
                UserList.AddUser(admin);

            }
            //defaultEmpList = GetEmpList();
            defaultAdminList = GetAdminList();
            defaultDiaryList = GetDefaultDiaryList();
            UsernameList = GetUsernameList();
            
        }

        public List<User> GetAdminList()
        {
            defaultAdminList = new List<User>();
            for (int i = 0; i < UserList.UsersList.Count; i++)
            {
                var item = UserList.UsersList[i];
                if (item.Type == Types.admin.ToString())
                {
                    defaultAdminList.Add(item);
                }
            }
            return defaultAdminList;
        }

        // Gets the DiaryList from the UserList
        List<Diary_List> GetDefaultDiaryList()
        {
            for (int i = 0; i < UserList.UsersList.Count; i++)
            {
                var item = UserList.UsersList[i];
                if (item.userDiaries is not null)
                {
                    defaultDiaryList.Add(item.userDiaries);
                }
            }
            return defaultDiaryList;
        }

        public List<string> GetUsernameList()
        {
            for (int i = 0; i < UserList.UsersList.Count; i++)
            {
                var item = UserList.UsersList[i];
                UsernameList.Add(item.UserName);

            }
            return UsernameList;
        }
        

        // Displays User Diaries with id and count
        public void DisplayDiaryList()
        {
            //Console.WriteLine($"\nDiary List Count: {defaultDiaryList.Count} out of {UserList.Count} \n");

            foreach (var item in Cache.getCache().defaultDiaryList)
            {

                //Console.WriteLine($"UserId: {item.user}, UserDiariesCount: {item.diaryCount()}");
            }
        }
        
        public Dictionary<string,object> Register(string name, string username, string passcode, string email, string phone)
        {
            if (Utility.ValidateUsername(username))
            {
            User emp = new User(username, name, passcode, Types.user.ToString(), Statuses.pending.ToString(), phone, email);
            UserList.AddUser(emp);
                return new Dictionary<string, object>(){
                            { "Status", 200 },
                            { "Response", "Account Created!"} };
            }
            else return new Dictionary<string, object>(){
                            { "Status", 400 },
                            { "Response", "Username exists!"} };

        }
        // To Login
        public dynamic UserLog(string username, string password)
        {
            if (currentUser == null)
            {
                User user = UserList.FindUser(username);
                if (user is not null)
                {
                    if (user.Login(username, password))
                    {
                        currentUser = user;
                        UpdateUserList();
                        return new Dictionary<string, object>(){
                            { "Status", 200 },
                            { "Response", currentUser} };
                    }
                    //Console.Clear();
                    //Console.WriteLine("\nIncorrect Credentials\n");
                    return new Dictionary<string, object>(){
                        { "Status", 400 },
                        { "Response", "Incorrect Credentials"} };
                    
                }

                return new Dictionary<string, object>(){
                            { "Status", 400 },
                            { "Response", "User not Found!"} };
            }
            //else Console.WriteLine("Already Logged In");
            return new Dictionary<string, object>(){
                            { "Status", 400 },
                            { "Response", "Already Logged In"} };
        }

        // To Logout
        public void Logout()
        {
            if (currentUser != null)
            {
                User user = UserList.FindUser(currentUser.UserName);
                user.Logout();
                UpdateUserList();
                currentUser = null;
            }

        }

        //To update the XML DiaryList
        public void UpdateDiaryList()
        {
            UpdateUserList();
        }
        //To update the XML UserList
        public void UpdateUserList()
        {
            Xml<DefaultUserList>.Serialize(Cache.getCache().UserList);
            UserList = Xml<DefaultUserList>.Deserialize(UserList);

        }

    }

}
