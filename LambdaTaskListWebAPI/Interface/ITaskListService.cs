using LambdaTaskListWebAPI.Models;

namespace LambdaTaskListWebAPI.Interface
{
    public interface ITaskListService
    {
        Dictionary<string, bool> GetItemsTaskList();
        void AddItemToTaskList(TaskListModel taskList);
        void RemoveItem(string name);
    }
}