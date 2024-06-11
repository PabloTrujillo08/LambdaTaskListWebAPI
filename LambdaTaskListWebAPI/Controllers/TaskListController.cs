using LambdaTaskListWebAPI.Interface;
using LambdaTaskListWebAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace LambdaTaskListWebAPI.Controllers
{
    [Route("v1/taskList")]
    [ApiController]
    public class TaskListController : ControllerBase
    {
        private readonly ITaskListService _taskListService;

        public TaskListController(ITaskListService taskListService)
        {
            _taskListService = taskListService;
        }

        [HttpGet]
        public async Task<IActionResult> GetItemsTaskList()
        {
            var items = await _taskListService.GetItemsTaskList();
            return Ok(items);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] TaskListModel taskList)
        {
            await _taskListService.AddItemTaskList(taskList);
            return Ok();
        }

        [HttpDelete("{name}")]
        public async Task<IActionResult> Delete(string name)
        {
            await _taskListService.RemoveItem(name);
            return Ok();
        }
    }
}