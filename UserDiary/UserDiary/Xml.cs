using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace UserDiary
{
    public class Xml<T> where T : class
    {
        public static void Serialize(T Item)
        {
            Type type = Item.GetType();
            try
            {
                XmlSerializer serializer = new XmlSerializer(Item.GetType());
                using (TextWriter writer = new StreamWriter(@$"{type}.xml"))
                {
                    serializer.Serialize(writer, Item);
                    writer.Close();
                }
            }
            catch (Exception ex)
            {
                string stException = string.Format("Exception: {0} \n Message: {1}", ex.StackTrace, ex.Message);
                //Console.WriteLine(stException);
            }

            //Console.WriteLine("\nXml Updated\n");
        }

        public static T Deserialize(T Item)
        {
            T XmlData = default(T);
            try
            {
                XmlSerializer deserializer = new XmlSerializer(Item.GetType());
                using (TextReader reader = new StreamReader(@$"{Item.GetType()}.xml"))
                {
                    object obj = deserializer.Deserialize(reader);
                    XmlData = (T)obj;
                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                string stException = string.Format("Exception: {0} \n Message: {1}", ex.StackTrace, ex.Message);
                //Console.WriteLine(stException);
            }

            return XmlData;
        }
    }
}
