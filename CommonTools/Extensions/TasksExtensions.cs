/// <summary>
/// Extension of existing Task functions
/// Created: 2022-02-12
/// </summary>

namespace worldwidewhat.CommonTools.Extensions;
public static partial class TasksExtensions
{
    /// <summary>
    /// Extens task with a timeout function
    /// </summary>
    /// <typeparam name="T">Object type</typeparam>
    /// <param name="task">Task</param>
    /// <param name="time">Timeout time</param>
    /// <returns>Task</returns>
    /// <exception cref="System.OperationCanceledException"></exception>
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
