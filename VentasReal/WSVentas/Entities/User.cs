namespace WSVentas.Entities
{
    public class User
    {
        public User(int id, string name, string telfono) 
        {
            this.id = id;
            this.name = name;
            this.telfono = telfono;
               
        }
        
        public int id { get; set; }
        public string name { get; set; }
        public string telfono { get; set; }
    }
}