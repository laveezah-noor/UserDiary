using System.ComponentModel;
using System.ComponentModel.Design;
using System.Xml.Linq;
using System.Xml;
using System.Xml.Serialization;
using UserDiary;

class Program
{


    public static void Main(string[] args)
    {
        UserDiary.Cache cache = UserDiary.Cache.getCache();
        //Console.WriteLine(cache);
        Dictionary<string, object> res = cache.UserLog("admin", "admin");
        Console.WriteLine(res["Status"]);
        Console.WriteLine(res["Response"]);
        Cache.getCache().DisplayFeed();
        //Cache.getCache().currentUser.CreateUser("user", "demo", "demo", "demo");
        //res = Cache.getCache().currentUser.CreateDiary("","");
        //Console.WriteLine(res["Status"]);
        //Console.WriteLine(res["Response"]);
        //res = Cache.getCache().currentUser.CreateDiary("hi", "hi");
        //Console.WriteLine(res["Status"]);
        //Console.WriteLine(res["Response"]);
        //Cache.getCache().currentUser.DisplayDiaries();
        //Console.Clear();
        //cache.currentUser.UpdateUser(cache.currentUser.Name, cache.currentUser.Password, "", "admin@diaries.com");
        cache.currentUser.display();
        cache.Logout();
        //res = cache.UserLog("demo", "demo");
        //Console.WriteLine(res["Status"]);
        //Console.WriteLine(res["Response"]);
        //Cache.getCache().currentUser.CreateUser("user", "demo", "demo", "demo");
        //res = Cache.getCache().currentUser.CreateDiary("", "");
        //Console.WriteLine(res["Status"]);
        //Console.WriteLine(res["Response"]);
        //res = Cache.getCache().currentUser.CreateDiary("hi", "hi");
        //Console.WriteLine(res["Status"]);
        //Console.WriteLine(res["Response"]);
        ////Cache.getCache().currentUser.DisplayDiaries();
        //cache.Logout();
        //res = cache.UserLog("admin", "admin");
        //Cache.getCache().currentUser.DisplayDiaries();

        //User user = (User)res["Response"];
        //user.display();
    }
}