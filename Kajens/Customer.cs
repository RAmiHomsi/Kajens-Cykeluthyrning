
namespace Kajens;

public class Customer
{
    public string Name { get; }
    public int Age { get; }
    public bool IsMember { get; }

    public Customer(string name, int age, bool isMember)
    {
        Name = name;
        Age = age;
        IsMember = isMember;
    }
}
