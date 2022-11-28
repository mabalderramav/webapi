namespace webapi.Controllers;

using Microsoft.AspNetCore.Mvc;
using webapi.Models;
using webapi.Services;

[Route("api/[controller]")]
public class TaskController : ControllerBase
{
    ITaskService taskService;

    public TaskController(ITaskService taskService)
    {
        this.taskService = taskService;
    }

    [HttpGet]
    public IActionResult Get() => Ok(taskService.Get());

    [HttpPost]
    public IActionResult Post([FromBody] Task task)
    {
        taskService.Save(task);
        return Ok();
    }

    [HttpPut("{id}")]
    public IActionResult Put(Guid id, [FromBody] Task task)
    {
        taskService.Update(id, task);
        return Ok();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(Guid id)
    {
        taskService.Delete(id);
        return Ok();
    }
}