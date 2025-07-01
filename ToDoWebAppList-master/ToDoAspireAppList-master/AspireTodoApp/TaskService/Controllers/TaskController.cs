using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace TaskService.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize] // ✅ Requires valid JWT token
public class TaskController : ControllerBase
{
    // Simulated in-memory task list
    private static readonly Dictionary<string, List<string>> _userTasks = new();

    [HttpGet]
    public IActionResult GetTasks()
    {
        var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value
                     ?? User.FindFirst("sub")?.Value;

        if (string.IsNullOrEmpty(userId))
            return Unauthorized("User ID not found in token.");

        if (!_userTasks.ContainsKey(userId))
            return Ok(new List<string>()); // No tasks for user yet

        return Ok(_userTasks[userId]);
    }

    [HttpPost]
    public IActionResult AddTask([FromBody] string task)
    {
        var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value
                     ?? User.FindFirst("sub")?.Value;

        if (string.IsNullOrEmpty(userId))
            return Unauthorized("User ID not found in token.");

        if (!_userTasks.ContainsKey(userId))
            _userTasks[userId] = new List<string>();

        _userTasks[userId].Add(task);

        return Ok(new { message = $"Task added for user {userId}", task });
    }
}
