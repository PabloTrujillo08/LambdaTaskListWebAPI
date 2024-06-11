using LambdaTaskListWebAPI.Models;
using System.Diagnostics;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace LambdaTaskListWebAPI.Interface
{
    public interface ITaskListService
    {
        Task<Dictionary<string, bool>> GetItemsTaskList();
        Task AddItemTaskList(TaskListModel taskList);
        Task RemoveItem(string name);
    }
}