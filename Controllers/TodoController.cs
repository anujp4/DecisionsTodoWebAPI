using DecisionsTodoWebAPI.Data;
using DecisionsTodoWebAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DecisionsTodoWebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class TodoController : ControllerBase
	{
		public readonly ApplicationDbContext dbContext;
		public TodoController(ApplicationDbContext dbContext)
		{
			this.dbContext = dbContext;
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
				return BadRequest(ex.Message);
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
					return NotFound();
				}
				return Ok(employee);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}
		[HttpPost]
		public IActionResult AddTodo(AddTodoModel addTodoModel)
		{
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
				return Ok();
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}
		[HttpPut]
		[Route("{id:guid}")]
		public IActionResult UpdateTodo(Guid id, UpdateTodoModel updateTodoModel)
		{
			try
			{
				var todoEntity = dbContext.TododataDbset.Find(id);
				if (todoEntity == null)
				{
					return NotFound("todoEntity does not exist");
				}
				todoEntity.priority = updateTodoModel.priority;
				todoEntity.description = updateTodoModel.description;
				todoEntity.profile = updateTodoModel.profile;
				dbContext.SaveChanges();
				return Ok(todoEntity);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
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
					return NotFound();
				}
				dbContext.TododataDbset.Remove(employee);
				dbContext.SaveChanges();
				return Ok();
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}
	}
}
