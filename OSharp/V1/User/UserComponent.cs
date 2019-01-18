namespace OSharp.V1.User
{
    public sealed class UserId : UserComponent
    {
        public UserId(long id) : base(id.ToString(), Type.Id)
        {
        }
        public UserId(string id) : base(id, Type.Id)
        {
        }
    }

    public sealed class UserName : UserComponent
    {
        public UserName(string name) : base(name, Type.Name)
        {
        }
    }

    public class UserComponent
    {
        protected UserComponent(string idOrName, Type idType)
        {
            IdOrName = idOrName;
            IdType = idType;
        }

        public string IdOrName { get; }
        public Type IdType { get; }

        public static UserComponent FromAll(string idOrName) => new UserComponent(idOrName, Type.Auto);
        public static UserId FromUserId(long id) => new UserId(id);
        public static UserId FromUserId(string id) => new UserId(id);
        public static UserName FromUserName(string name) => new UserName(name);

        public enum Type
        {
            Name, Id, Auto
        }

        public override string ToString()
        {
            return IdOrName;
        }
    }
}
