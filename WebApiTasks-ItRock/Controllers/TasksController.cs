using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiTasks_ItRock.Context;
using WebApiTasks_ItRock.Models;
using Task = WebApiTasks_ItRock.Models.Task;

namespace WebApiTasks_ItRock.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly ApiDb _context;

        public TasksController(ApiDb context)
        {
            _context = context;
        }



        [HttpPost]
        public ActionResult PostTask(Task task)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    //se puede hacer asincrona pero al ser solo 2 endpoints no habria problema en hacerla sincrona ya que es bastante sencillo
                    return BadRequest(new { message = "Los datos enviados son invalidos, revise el formato de la tarea enviada.", errors = ModelState });
                }

                _context.Tasks.Add(task);
                _context.SaveChanges();

                return Ok(new { message = $"La tarea con el título '{task.Title}' se creó de manera correcta." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Hubo un error al crear la tarea : {ex.Message}");
            }
        }



        [HttpGet]
        public ActionResult GetTasks()
        {
            try
            {
                //se puede hacer asincrona pero al ser solo 2 endpoints no habria problema en hacerla sincrona ya que es bastante sencillo 
                var tasks = _context.Tasks.ToList(); 
                return Ok(tasks);

            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Hubo un error al crear la tarea : {ex.Message}");
            }
            
        }


        //agrego un endopoint para obtener una tarea filtrando por id ademas de los 2 solicitados
        [HttpGet("{id}")]
        public ActionResult<Task> GetTaskById(int id)
        {
            try
            {
                var task = _context.Tasks.FirstOrDefault(t => t.Id == id);

                if (task == null)
                {
                    return NotFound(new { message = $"No se encontró una tarea con el ID '{id}'" });
                }

                return Ok(task);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Hubo un error al obtener la tarea: {ex.Message}");
            }
        }




    }
}
