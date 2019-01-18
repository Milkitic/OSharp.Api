namespace CSharpOsu.V1
{
    public class Key
    {
        public Key(string value)
        {
            _value = value;
        }

        private readonly string _value;

        public static implicit operator Key(string value) => new Key(value);
        public static implicit operator string(Key key) => key.ToString();

        public override string ToString()
        {
            return _value;
        }
    }
}
