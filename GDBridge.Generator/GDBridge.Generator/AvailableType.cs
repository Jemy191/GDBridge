namespace GDBridge.Generator;

class AvailableType
{
    public readonly string Name;
    public readonly string Namespace;
    public AvailableType(string name, string ns)
    {
        Name = name;
        Namespace = ns;
    }
}