public class Keys
{
    public KeyType Key { get; private set; }

    public bool Pressed { get; set; }

    public Keys(KeyType key)
    {
        Key = key;
    }
}

public enum KeyType
{
    Q, E
}
