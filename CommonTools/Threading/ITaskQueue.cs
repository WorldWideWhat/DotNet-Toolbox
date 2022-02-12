namespace worldwidewhat.CommonTools.Threading
{
    public interface ITaskQueue
    {
        public Task<T> Enqueue<T>(Func<Task<T>> task);
        public Task Enqueue(Func<Task> task);
    }
}
