namespace links.Entities
{
    public class Recommend
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        //יחיד לרבים (הרבים 
        public int idUser { get; set; }
        public User User { get; set; } // קשר למשתמש
    }
}
