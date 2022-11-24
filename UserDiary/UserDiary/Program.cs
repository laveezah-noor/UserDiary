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
        cache.Logout();
        //User user = (User)res["Response"];
        //user.display();
    }
}