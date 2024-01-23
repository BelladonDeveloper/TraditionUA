namespace Tasks
{
    public interface ITaskManager
    {
        /// <summary>
        /// Start a new task with the type and call Start in the task
        /// </summary>
        /// <param name="type"></param>
        void StartTask(TaskType type);

        /// <summary>
        /// Finish the task and call Finish
        /// </summary>
        /// <param name="type"></param>
        void FinishTask(TaskType type);

        /// <summary>
        /// Return current Task
        /// May be it won`t be necessary
        /// </summary>
        TaskForPlayer GetCurrentTask();

        /// <summary>
        /// Set current task as None
        /// May be it won`t be necessary
        /// </summary>
        void ReturnToEmptyState();
    }
}
