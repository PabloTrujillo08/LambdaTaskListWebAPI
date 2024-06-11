using LambdaTaskListWebAPI.Interface;
using LambdaTaskListWebAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
        public IActionResult GetItemsTaskList()
        {
            var result = _taskListService.GetItemsTaskList();
            return Ok(result);
        }

        [HttpPost]
        public IActionResult AddItemToTaskList([FromBody] TaskListModel taskList)
        {
            _taskListService.AddItemToTaskList(taskList);
            return Ok();
        }

        [HttpDelete]
        public IActionResult RemoveItem([FromQuery] TaskListModel taskList)
        {
            _taskListService.RemoveItem(taskList.Name!);
            return Ok();
        }
    }
}
