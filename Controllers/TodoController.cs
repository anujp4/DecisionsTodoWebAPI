using DecisionsTodoWebAPI.Data;
using DecisionsTodoWebAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DecisionsTodoWebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class TodoController : ControllerBase
	{
		private readonly ApplicationDbContext dbContext;
		private readonly ILogger<TodoController> logger;

		public TodoController(ApplicationDbContext dbContext, ILogger<TodoController> logger)
		{
			this.dbContext = dbContext;
			this.logger = logger;
		}

		[HttpGet]
		public IActionResult GetAllTodos()
		{
			try
			{
				var allEmps = dbContext.TododataDbset.ToList();
				return Ok(allEmps);
			}
			catch (Exception ex)
			{
				logger.LogError(ex, "Error retrieving all todos.");
				return StatusCode(StatusCodes.Status500InternalServerError, new
				{
					error = "An unexpected error occurred while retrieving todos."
				});
			}
		}

		[HttpGet]
		[Route("{id:guid}")]
		public IActionResult GetTodoById(Guid id)
		{
			try
			{
				var employee = dbContext.TododataDbset.Find(id);
				if (employee == null)
				{
					return NotFound(new { error = "Todo item not found." });
				}
				return Ok(employee);
			}
			catch (Exception ex)
			{
				logger.LogError(ex, $"Error retrieving todo with id {id}.");
				return StatusCode(StatusCodes.Status500InternalServerError, new
				{
					error = "An unexpected error occurred while retrieving the todo item."
				});
			}
		}

		[HttpPost]
		public IActionResult AddTodo(AddTodoModel addTodoModel)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(new { error = "Invalid input.", details = ModelState });
			}

			try
			{
				var todoEntity = new Tododata()
				{
					priority = addTodoModel.priority,
					description = addTodoModel.description,
					profile = addTodoModel.profile
				};
				dbContext.TododataDbset.Add(todoEntity);
				dbContext.SaveChanges();
				return Ok(todoEntity);
			}
			catch (Exception ex)
			{
				logger.LogError(ex, "Error adding new todo.");
				return StatusCode(StatusCodes.Status500InternalServerError, new
				{
					error = "An unexpected error occurred while adding the todo item."
				});
			}
		}

		[HttpPut]
		[Route("{id:guid}")]
		public IActionResult UpdateTodo(Guid id, UpdateTodoModel updateTodoModel)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(new { error = "Invalid input.", details = ModelState });
			}

			try
			{
				var todoEntity = dbContext.TododataDbset.Find(id);
				if (todoEntity == null)
				{
					return NotFound(new { error = "Todo item not found." });
				}
				todoEntity.priority = updateTodoModel.priority;
				todoEntity.description = updateTodoModel.description;
				todoEntity.profile = updateTodoModel.profile;
				dbContext.SaveChanges();
				return Ok(todoEntity);
			}
			catch (Exception ex)
			{
				logger.LogError(ex, $"Error updating todo with id {id}.");
				return StatusCode(StatusCodes.Status500InternalServerError, new
				{
					error = "An unexpected error occurred while updating the todo item."
				});
			}
		}

		[HttpDelete]
		[Route("{id:guid}")]
		public IActionResult DeleteTodo(Guid id)
		{
			try
			{
				var employee = dbContext.TododataDbset.Find(id);
				if (employee == null)
				{
					return NotFound(new { error = "Todo item not found." });
				}
				dbContext.TododataDbset.Remove(employee);
				dbContext.SaveChanges();
				return Ok(new { message = "Todo item deleted successfully." });
			}
			catch (Exception ex)
			{
				logger.LogError(ex, $"Error deleting todo with id {id}.");
				return StatusCode(StatusCodes.Status500InternalServerError, new
				{
					error = "An unexpected error occurred while deleting the todo item."
				});
			}
		}
	}
}
