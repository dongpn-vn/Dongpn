

[System.AttributeUsage(System.AttributeTargets.Class)]
public class PrefabsFactory : System.Attribute
{
    public string PrimaryKey;

    public PrefabsFactory(string key)
    {
        this.PrimaryKey = key;       
    }
}
