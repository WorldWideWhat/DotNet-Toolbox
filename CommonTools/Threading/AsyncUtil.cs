namespace worldwidewhat.CommonTools.Threading
{
    /// <summary>
    /// Asyn Utils
    /// Created: 2022-02-12
    /// </summary>
    public static class AsyncUtil
    {
        private static readonly TaskFactory _taskFactory = new TaskFactory(
                                                            CancellationToken.None,
                                                            TaskCreationOptions.None,
                                                            TaskContinuationOptions.None,
                                                            TaskScheduler.Default);
        /// <summary> Run async function with no return values (a void function) </summary>
        /// <param name="task">Function to run</param>
        public static void RunSync(Func<Task> task) =>
            _taskFactory.StartNew(task).Unwrap().GetAwaiter().GetResult();

        /// <summary> Run async function with return values </summary>
        /// <param name="task">Function to run</param>
        /// <typeparam name="T">Return data type</typeparam>
        /// <returns>Return value</returns>
        public static T RunSync<T>(Func<Task<T>> task) =>
            _taskFactory.StartNew(task).Unwrap().GetAwaiter().GetResult();
    }
}
