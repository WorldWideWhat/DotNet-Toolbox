namespace worldwidewhat.CommonTools.Threading
{
    /// <summary>
    /// Interface to the TaskQueue
    /// Created: 2022-02-12
    /// </summary>
    public interface ITaskQueue
    {
        /// <summary> Add task element to queue with return value </summary>
        /// <param name="task">Function/task to run</param>
        /// <typeparam name="T">Return type</typeparam>
        /// <returns>Return value</returns>
        public Task<T> Enqueue<T>(Func<Task<T>> task);

        /// <summary> Add task element to queue with no return value </summary>
        /// <param name="task">Task to run</param>
        public Task Enqueue(Func<Task> task);
    }
}
