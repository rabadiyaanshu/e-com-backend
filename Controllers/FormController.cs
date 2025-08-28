using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebLoginRegisterApi.Data;
using WebLoginRegisterApi.Model;

[ApiController]
[Route("api/[controller]")]
public class GeneralFormController : ControllerBase
{
    private readonly GeneralFormContext _context;

    public GeneralFormController(GeneralFormContext context)
    {
        _context = context;
    }

    [HttpPost]
    public async Task<IActionResult> PostForm(GeneralForm model)
    {
        _context.Forms.Add(model);
        await _context.SaveChangesAsync();
        return Ok(model);
    }

    [HttpGet]
    public async Task<ActionResult<List<GeneralForm>>> GetForms()
    {
        var forms = await _context.Forms.ToListAsync();
        return Ok(forms);
    }

    [HttpDelete("{id}")] 
    public async Task<IActionResult> DeleteForm(int id)
    {
        var form = await _context.Forms.FindAsync(id);
        if (form == null)
        {
            return NotFound(); // 404
        }

        _context.Forms.Remove(form);
        await _context.SaveChangesAsync();
        return NoContent(); // 204
    }
}
