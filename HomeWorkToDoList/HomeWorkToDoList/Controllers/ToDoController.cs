using HomeWorkToDoList.DataAccessLayer;
using HomeWorkToDoList.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HomeWorkToDoList.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ToDoController : ControllerBase
    { 
        private readonly ILogger<ToDoController> _logger;
        private readonly ToDoListContext _context;

        public ToDoController(ILogger<ToDoController> logger, ToDoListContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet]
        public async Task<IEnumerable<ToDo>> List()
        {
            return await _context.ToDoList
                .OrderBy(todo => todo.Date)
                .ToListAsync();
        }

        [HttpPost]
        public async Task<Guid> Create([FromBody] ToDo toDo)
        {
            if (toDo.Id == Guid.Empty)
                toDo.Id = Guid.NewGuid();

            await _context.ToDoList.AddAsync(toDo);
            await _context.SaveChangesAsync();
            return toDo.Id;
        }

        [HttpPut]
        public async Task Update([FromBody] ToDo toDo)
        {
            var foundedToDo = await _context.ToDoList.FirstOrDefaultAsync(t => t.Id == toDo.Id) 
                ?? throw new Exception("todo not found");
            foundedToDo.Date = toDo.Date;
            foundedToDo.Note = toDo.Note; 
            await _context.SaveChangesAsync(); 
        }
    }
}
