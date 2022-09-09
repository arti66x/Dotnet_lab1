using System;
using System.Collections;
using System.Linq;

class Programm
{
    static void Main()
    {

        int step = 30;
        int count = 100;

        Hall hall = new(count);
        Princess princess = new();
        int points = 10;
        for (int i = 0; i < 100; i++)
        {
            Contender contender = hall.GetNextContender();
            bool isBetter = princess.CheckContender(contender);
            if (i > step && isBetter)
            {
                points = contender.Value >= count / 2 ? contender.Value : 0;
                break;
            }
        }
        Console.WriteLine(points);

    }
}

class Hall
{
    private readonly List<Contender> contenders;
    public Hall(int num = 100)
    {
        contenders = new List<Contender>();
        for (int i = 0; i < num; i++)
        {
            contenders.Add(new Contender("name" + i, i + 1));
        }
    }

    public Contender GetNextContender()
    {
        Random rnd = new Random();
        int count = contenders.Count;
        int randNum = rnd.Next(count);
        Contender randContender = contenders[randNum];
        contenders.RemoveAt(randNum);
        return randContender;
    }
}
class Princess
{
    private readonly Friend friend = new();
    public Contender? best = null;

    public bool CheckContender(Contender a)
    {
        if (best == null || friend.Compare(a, best))
        {
            best = a;
            return true;
        }
        else
        {
            return false;
        }
    }
}
class Contender
{
    public Contender(string name, int value)
    {
        this.Name = name;
        this.Value = value;
    }
    public string Name { get; set; }
    public int Value { get; set; }

}

class Friend
{
    public bool Compare(Contender a, Contender b)
    {
        return a.Value > b.Value;
    }
}