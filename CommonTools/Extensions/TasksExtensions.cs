public static partial class TasksExtensions
{
    public static async Task<T> Timeout<T>(this Task<T> task, int time)
    {
        var cts = new CancellationTokenSource(time);
        var tcs = new TaskCompletionSource<bool>();
        using (cts.Token.Register(s => ((TaskCompletionSource<bool>)s).TrySetResult(true), tcs))
        {
            if (task != await Task.WhenAny(task, tcs.Task))
                throw new System.OperationCanceledException();
        }
        return await task;
    }
}
