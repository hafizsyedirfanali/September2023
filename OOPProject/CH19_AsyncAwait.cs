namespace OOPProject;
/// <summary>
/// async and await are keywords used simultaneously
/// async keyword helps in getting result from a awaitable task
/// CancellationToken cancellationToken is a system generated token that is passed to a Task to cancel if 
/// main UI thread is stopped.
/// </summary>
public class CH19_AsyncAwait
{
    public async void Test()
    {
        //1. Calling Asynchronous function/task
        //Method1
        //Task t1 =  AddAsync(10, 20);
        //t1.Wait();
        //Method2
        var result = await AddAsync(10, 20);
        Console.WriteLine(result);

        //2. Converting Synchronous Method into Asynchronous method or task
        await Task.Run(() => Add(10, 20));
    }

    public int Add(int x, int y)
    {
        return x + y;
    }
    
    public async Task<int> AddAsync(int x, int y)
    {
        return await Task.FromResult(x + y);
    }
}
