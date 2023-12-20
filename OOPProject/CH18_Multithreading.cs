namespace OOPProject;
/// <summary>
/// When we execute our code, it goes to Memory then CPU processes it.
/// Operating System has number of threads, which are virtual queues for using CPU.
/// When we execute our code we request a thread, which is assigned by OS and CPU processes it.
/// In multithreading we can request the CPU for multiple threads.
/// When we execute our code we are assigned a main thread called UI thread and if we request more threads
/// then we get more threads other than UI thread.
/// </summary>
public class CH18_Multithreading
{
    public void Test()
    {
        ///In the following we made Task1 to run synchronously then task2,3,4 to run asynchronously.
        Task.Run(() => Task1()).Wait();
        var t2 = Task.Run(() => Task2());
        var t3 = Task.Run(() => Task3());
        var t4 = Task.Run(() => Task4());
        Task.WaitAll(t2, t3, t4);
    }
    public void Task1()
    {
        //Thread.Sleep(1000);
        Task.Delay(8000).Wait();
        Console.WriteLine("Task 1 completed");
    }
    public void Task2()
    {
        Task.Delay(4000).Wait();
        Console.WriteLine("Task 2 completed");
    }
    public void Task3()
    {
        Task.Delay(6000).Wait();
        Console.WriteLine("Task 3 completed");
    }
    public void Task4()
    {
        Task.Delay(2000).Wait();
        Console.WriteLine("Task 4 completed");
    }
}
