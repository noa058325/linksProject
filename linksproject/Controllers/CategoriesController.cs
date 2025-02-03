using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using links.Entities;
using links.Core.Services;
using links.core.DTOs;


namespace linksproject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService; // שירות הקטגוריות
        private readonly IMapper _mapper; // אובייקט למיפוי בין ישויות ל-DTO

        public CategoriesController(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }

        /// <summary>
        /// מחזיר את כל הקטגוריות
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryDto>>> GetAsync()
        {
            var categories = await _categoryService.GetListAsync(); // שליפת כל הקטגוריות
            var categoryDtos = _mapper.Map<List<CategoryDto>>(categories); // מיפוי ל-DTO
            return Ok(categoryDtos); // מחזיר את הנתונים ללקוח
        }

        /// <summary>
        /// מחזיר קטגוריה לפי מזהה
        /// </summary>
        [HttpGet("{id}")]
        public async Task<ActionResult<CategoryDto>> GetById(int id)
        {
            var category = await _categoryService.GetByIdAsync(id); // שליפת קטגוריה לפי מזהה
            if (category == null)
            {
                return NotFound(); // אם הקטגוריה לא קיימת מחזירים 404
            }

            var categoryDto = _mapper.Map<CategoryDto>(category); // מיפוי ל-DTO
            return Ok(categoryDto); // מחזיר את הקטגוריה ללקוח
        }

        /// <summary>
        /// מוסיף קטגוריה חדשה
        /// </summary>
        [HttpPost]
        public async Task<ActionResult<CategoryDto>> Post([FromBody] CategoryDto categoryDto)
        {
            if (categoryDto == null || string.IsNullOrWhiteSpace(categoryDto.Name))
            {
                return BadRequest("שם הקטגוריה אינו תקין."); // בדיקה שהשם לא ריק
            }

            var category = _mapper.Map<Category>(categoryDto); // ממירים לישות
            await _categoryService.AddAsync(category); // הוספת קטגוריה
            var createdCategoryDto = _mapper.Map<CategoryDto>(category); // ממירים חזרה ל-DTO

            return CreatedAtAction(nameof(GetById), new { id = category.Id }, createdCategoryDto); // מחזירים תשובה עם כתובת הקטגוריה החדשה
        }

        /// <summary>
        /// מעדכן קטגוריה קיימת לפי מזהה
        /// </summary>
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] CategoryDto categoryDto)
        {
            if (categoryDto == null || id != categoryDto.Id)
            {
                return BadRequest("הקטגוריה לא תואמת את הנתונים שנשלחו.");
            }

            var category = _mapper.Map<Category>(categoryDto); // המרת DTO לישות
            var updatedCategory = await _categoryService.UpdateAsync(id, category); // עדכון קטגוריה

            if (updatedCategory == null)
            {
                return NotFound(); // אם הקטגוריה לא קיימת
            }

            return Ok(_mapper.Map<CategoryDto>(updatedCategory)); // מחזיר את הקטגוריה המעודכנת
        }

        /// <summary>
        /// מוחק קטגוריה לפי מזהה
        /// </summary>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var category = await _categoryService.GetByIdAsync(id);
            if (category == null)
            {
                return NotFound(); // אם הקטגוריה לא קיימת
            }

            await _categoryService.Delete(id); // מחיקה בפועל
            return NoContent(); // מחזירים הצלחה ללא תוכן
        }
    }
}
