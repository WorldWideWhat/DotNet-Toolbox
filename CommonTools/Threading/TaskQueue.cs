namespace worldwidewhat.CommonTools.Threading
{
    /// <summary>
    /// TaskQueue class
    /// Created: 2022-02-12
    /// </summary>
    public class TaskQueue : ITaskQueue
    {
        /// <summary> Previous task object </summary>
        private Task _previous = Task.FromResult(false);

        /// <summary> Lock key object </summary>
        private readonly object _key = new();

        /// <summary> Add task element to queue with return value </summary>
        /// <param name="task">Function/task to run</param>
        /// <typeparam name="T">Return type</typeparam>
        /// <returns>Return value</returns>
        public Task<T> Enqueue<T>(Func<Task<T>> task)
        {
            lock (_key)
            {
                var n_next = _previous.ContinueWith(t => task()).Unwrap();
                _previous = n_next;
                return n_next;
            }
        }

        /// <summary> Add task element to queue with no return value </summary>
        /// <param name="task">Task to run</param>
        public Task Enqueue(Func<Task> task)
        {
            lock (_key)
            {
                var n_next = _previous.ContinueWith(t => task()).Unwrap();
                _previous = n_next;
                return n_next;
            }
        }

    }
}
