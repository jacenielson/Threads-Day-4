namespace Threads_Day_4;

class Locks
{
    public Dictionary<int, object> forkLocks = new();
}
class Professor
{
    int count;
    int id;
    int forkLeft;
    int forkRight;

    public Professor(int in_id)
    {
        count = 0;
        id = in_id;
        if(id!=0){
        forkLeft = id-1;
        forkRight = id+1;
        }
        if(id == 0)
        {
    
        }
    }
    public void Eat(int forkLeft, int forkRight)
    {
        lock (Program.c.forkLocks[forkLeft])
        {
            lock (Program.c.forkLocks[forkRight])
            {
                count++;
            }
        }
    }
    
}
class Program
{
    public static Locks c = new();
    static void Main(string[] args)
    {
        int forkCount = 5;
        for(int i=0;i<forkCount;i++)
        {
        Professor p = new Professor(i);
        }
        
    }
}
