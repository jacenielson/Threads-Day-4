namespace Threads_Day_4;

class Locks
{
    public Dictionary<int, object> forkLocks = new();

    public Locks(int forks = 5)
    {
        for (int i = 0; i < forks; i++)
        {
            forkLocks[i] = new object();
        }
    }
}
class Philosopher
{
    int count;
    int id;
    int forkLeft;
    int forkRight;

    public Philosopher(int in_id)
    {
        count = 0;
        id = in_id;
    }

    public void Eat()
    {
        forkLeft = id;
        forkRight = (id + 1) % 5;

        if (id < 4)
        {
            while (count < 100)
            {

                lock (Program.c.forkLocks[forkLeft])
                {
                    lock (Program.c.forkLocks[forkRight])
                    {
                        count++;
                    }
                }
                Thread.Sleep(10);
            }
            Console.WriteLine($"Philosopher {id} finished eating \n");
        }
        else
        {
            while (count < 100)
            {
                lock (Program.c.forkLocks[forkRight])
                {
                    lock (Program.c.forkLocks[forkLeft])
                    {
                        count++;
                    }
                }
                Thread.Sleep(10);
            }
            Console.WriteLine($"Philosopher {id} finished eating \n");
        }
    }
}

class Program
{
    public static Locks c = new();
    static void Main(string[] args)
    {
        int forkCount = 5;
        List<Thread> threads = new();

        for (int i = 0; i < forkCount; i++)
        {
            Philosopher p = new Philosopher(i);
            Thread t = new Thread(p.Eat);
            threads.Add(t);
            t.Start();
        }

        foreach (var t in threads)
            t.Join();

        Console.WriteLine("All Philosophers finished.\n");
    }
}
