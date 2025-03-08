using Microsoft.AspNetCore.Mvc;
using links.Entities;
using AutoMapper;
using links.Core.Services;
using linksproject.Models;


namespace links.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RecommendController : ControllerBase
    {
        private readonly IRecommendService _recommendService;
        private readonly IMapper _mapper;

        public RecommendController(IRecommendService recommendService, IMapper mapper)
        {
            _recommendService = recommendService;
            _mapper = mapper;
        }

        // מחזיר את כל ההמלצות
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Recommend>>> Get()
        {
            var recommends = await _recommendService.GetListAsync();
            var recommendDto = _mapper.Map<List<Recommend>>(recommends);
            return Ok(recommendDto);
        }

        // מחזיר המלצה לפי מזהה
        [HttpGet("{id}")]
        public ActionResult<Recommend> GetById(int id)
        {
            var recommend = _recommendService.GetById(id);
            if (recommend == null)
                return NotFound();

            return Ok(recommend);
        }

        // מוסיף המלצה חדשה
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] RecommendPostModel recommend)
        {
            await _recommendService.AddAsync(_mapper.Map<Recommend>(recommend));
            return CreatedAtAction(nameof(GetById), new { id = recommend.Id }, recommend);
        }

        // מעדכן המלצה קיימת
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Recommend recommend)
        {
            if (id != recommend.Id)
                return BadRequest();

            _recommendService.UpdateRecommend(recommend);
            return NoContent();
        }

        // מוחק המלצה לפי מזהה
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _recommendService.DeleteRecommendAsync(id);
            return NoContent();
        }
    }
}
