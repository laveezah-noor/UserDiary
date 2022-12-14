using System.Xml.Serialization;

namespace UserDiary
{
    public class Diary
    {
        [XmlAttribute("DiaryID")]
        public int Id;
        public string Name;
        public string Content { get; set; }
        public DateTime CreatedAt;
        public DateTime LastUpdate { get; set; }
        public bool privacy { get; set; }
        public int userId;

        public Diary() { }

        public Diary(int count, string Name)
        {
            this.Id = count;
            this.Name = Name;
            this.Content = "";
            this.CreatedAt = DateTime.Now;
            this.LastUpdate = DateTime.Now;
            this.privacy = false;
        }

        public Diary(int count, string Name, bool privacy, int userId)
        {
            this.Id = count;
            this.Name = Name;
            this.Content = "";
            this.CreatedAt = DateTime.Now;
            this.LastUpdate = DateTime.Now;
            this.privacy = privacy;
            this.userId = userId;
        }

        // To create a new diary
        public void Create(string Content)
        {
            this.Content = Content;
        }

        // To update name of the diary
        public void UpdateName(string text)
        {
            this.Name = text;
            this.LastUpdate = DateTime.Now;
        }

        // To update content of the diary
        public void UpdateContent(string text)
        {
            this.Content = text;
            this.LastUpdate = DateTime.Now;
        }

        // To display the diary
        public string Display(int user)
        {
            return $"ID: {this.Id} ,Title: {this.Name}, Content: {this.Content}, UserID: {user}";
        }

        public string Display()
        {
            return $"ID: {this.Id} ,Title: {this.Name}, Content: {this.Content}, UserID: {userId}";
        }

        internal void UpdatePrivacy(bool privacy)
        {
            this.privacy = privacy;
        }
    }
}
