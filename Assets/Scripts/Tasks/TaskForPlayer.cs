namespace Tasks
{
    /// <summary>
    /// Class for the inheritance
    /// </summary>
    public class TaskForPlayer
    {
        private readonly TaskType _type;

        public TaskForPlayer() { }

        /// <summary>
        /// Use it in the TaskManager for create a new task
        /// </summary>
        /// <param name="type"></param>
        public TaskForPlayer(TaskType type)
        {
            _type = type;
        }

        public TaskType GetTaskType() => _type;

        /// <summary>
        /// The method should be called from the TaskManager
        /// If create a new TaskForPlayer and need the MonoBehaviour - create a new GameObject
        /// I hope you doesn`t need the MonoBehaviour class :)
        /// </summary>
        public virtual void Start()
        {

        }

        /// <summary>
        /// Finish the task at all
        /// Unsubscribe and dispose here
        /// </summary>
        public virtual void Finish()
        {

        }
    }
}
