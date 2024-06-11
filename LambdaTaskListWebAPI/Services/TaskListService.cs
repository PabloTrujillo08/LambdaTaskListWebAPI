using LambdaTaskListWebAPI.Interface;
using LambdaTaskListWebAPI.Models;

namespace LambdaTaskListWebAPI.Services
{
    public class TaskListService : ITaskListService
    {

        private Dictionary<string, bool> _taskListStorage = new Dictionary<string, bool>();

        public void AddItemToTaskList(TaskListModel taskList)
        {
            _taskListStorage.Add(taskList.Name!, taskList.isComplete);
        }

        public Dictionary<string, bool> GetItemsTaskList()
        {
            return _taskListStorage;
        }

        public void RemoveItem(string name)
        {
            _taskListStorage.Remove(name);
        }
    }
}
