namespace StockExchange.Core.Models
{
    public class User
    {
        private User(Guid id, string name,
            string passwordHash, string email)
        {
            Id = id;
            Name = name;
            PasswordHash = passwordHash;
            Email = email;
        }
        public Guid Id { get; }  
        public string Name { get;}
        public string PasswordHash { get; }
        public string Email { get; }
        public static User Creater(Guid id, string name,
            string passwordHash, string email)
        {
            return new User(id,  name, passwordHash,  email);
        }
    }
}
