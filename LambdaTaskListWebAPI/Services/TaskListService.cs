using Amazon.DynamoDBv2.Model;
using Amazon.DynamoDBv2;
using LambdaTaskListWebAPI.Interface;
using LambdaTaskListWebAPI.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace LambdaTaskListWebAPI.Services
{
    public class TaskListService : ITaskListService
    {
        private readonly AmazonDynamoDBClient _dynamoDbClient;
        private readonly string _tableName = "TaskList";

        public TaskListService()
        {
            var config = new AmazonDynamoDBConfig { ServiceURL = "http://localhost:8000" };
            _dynamoDbClient = new AmazonDynamoDBClient(config);
        }

        public async Task AddItemTaskList(TaskListModel taskList)
        {
            var request = new PutItemRequest
            {
                TableName = _tableName,
                Item = new Dictionary<string, AttributeValue>
             {
                 { "name", new AttributeValue { S = taskList.Name } },
                 { "isComplete", new AttributeValue { BOOL = taskList.isComplete } }
             }
            };
            await _dynamoDbClient.PutItemAsync(request);
        }

        public async Task<Dictionary<string, bool>> GetItemsTaskList()
        {
            var request = new ScanRequest
            {
                TableName = _tableName
            };

            var response = await _dynamoDbClient.ScanAsync(request);

            var taskList = new Dictionary<string, bool>();
            foreach (var item in response.Items)
            {
                var name = item["name"].S;
                var isComplete = item["isComplete"].BOOL;
                taskList.Add(name, isComplete);
            }
            return taskList;
        }

        public async Task RemoveItem(string name)
        {
            var request = new DeleteItemRequest
            {
                TableName = _tableName,
                Key = new Dictionary<string, AttributeValue>
             {
                 { "name", new AttributeValue { S = name } }
             }
            };
            await _dynamoDbClient.DeleteItemAsync(request);
        }
    }
}