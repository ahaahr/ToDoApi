using System;
using Microsoft.AspNetCore.Mvc;
using ToDoApi.Interfaces;
using ToDoApi.Models;

namespace ToDoApi.Controllers
{
    [Route("api")]
    public class ToDoItemsController : Controller
    {
        private readonly IToDoRepository toDoRepository;

        public ToDoItemsController(IToDoRepository toDoRepository)
        {
            this.toDoRepository = toDoRepository;
        }

        [HttpGet("list")]
        public IActionResult List()
        {
            return Ok(toDoRepository.All);
        }

        [HttpGet("exists/{id}")]
        public IActionResult Exists(String id)
        {
            return Ok(toDoRepository.DoesItemExist(id));
        }
        
        [HttpGet("find/{id}")]
        public IActionResult Find(String id)
        {
            var item = toDoRepository.Find(id);            
            if (item == null)
            {
                return NotFound("Item with id " + id + " was not found");
            }
            else
            {
                return Ok(item);
            }
        }

        [HttpPut("insert")]
        public IActionResult Insert([FromBody] ToDoItem item)
        {
            if (item == null)
            {
                return BadRequest("No item data provided");
            }
            if (item.Name == null)
            {
                return BadRequest("Item must have a name");
            }
            if (item.Notes == null)
            {
                return BadRequest("The field Notes must not be null");
            }
            item.ID = Guid.NewGuid().ToString();
            toDoRepository.Insert(item);
            return Ok();
        }

        [HttpPost("update")]
        public IActionResult Update([FromBody] ToDoItem item)
        {
            if (item == null)
            {
                return BadRequest("No item data provided");
            }
            if (item.ID == null)
            {
                return BadRequest("ID must not be null");
            }
            if (item.Name == null)
            {
                return BadRequest("Item must have a name");
            }
            if (item.Notes == null)
            {
                return BadRequest("The field Notes must not be null");
            }
            if (!toDoRepository.DoesItemExist(item.ID))
            {
                return NotFound("Item with id " + item.ID + " was not found");
            }
            toDoRepository.Update(item);   
            return Ok();
        }

        [HttpDelete("delete/{id}")]
        public IActionResult Delete(String id)
        {         
            if (id == null)     
            {
                return BadRequest("ID must not be null");
            }
            if (!toDoRepository.DoesItemExist(id))
            {
                return NotFound("Item with id " + id + " was not found");
            }
            toDoRepository.Delete(id);
            return Ok();
        }
    }
}
