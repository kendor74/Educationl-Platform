﻿namespace EducationlPlatform.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TutorController : ControllerBase
    {
        private readonly Services<Tutor> _service;
        public TutorController(Services<Tutor> service)
        {
            _service = service;
        }

        [HttpGet("GetTutors")]
        public async Task<IActionResult> GetAll() 
        {
            var Tutors = await _service.GetAll(q => q.Include(u => u.User).Include(d => d.Department));

            return Ok(Tutors);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var Tutor = await _service.FindById(id, q => q.Include(u => u.User).Include(d=>d.Department));
            return (Tutor != null)? Ok(Tutor) : BadRequest("This Entity does not Exist !");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTutor(Tutor tutor , int id)
        {

            if (!await _service.IsExist(id))
                return BadRequest("TutorId is not valid !");
            if (tutor.DepartmentId == 0)
                return BadRequest("Invalid Field !");

            var Tutor = await _service.Update(id , tutor);
            
            return Ok(Tutor);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTutor(int id)
        {
            var Tutor = await _service.Delete(id);
            return Ok(Tutor);
        }
    }
}
