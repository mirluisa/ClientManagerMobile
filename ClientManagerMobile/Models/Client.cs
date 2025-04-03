namespace ClientManagerMobile.Models;

public class Client
{
    public int Id
    {
        get { return _id; }
        set { _id = value; }
    }
    public int Age
    {
        get { return _age; }
        set { _age = value; }
    }
    public string Name
    {
        get { return _name; }
        set { _name = value; }
    }
    public string Address
    {
        get { return _address; }
        set { _address = value; }
    }

    private int _id;
    private int _age;
    private string _name = string.Empty;
    private string _address = string.Empty;
}
