using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using AsystentKonserwacji.Data;
using AsystentKonserwacji.Models;
using System.Threading.Tasks;

namespace AsystentKonserwacji.Pages.LubricationPoints
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public CreateModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public LubricationPoint LubricationPoint { get; set; }

        public IActionResult OnGet(int machineId)
        {
            LubricationPoint = new LubricationPoint
            {
                MachineId = machineId
            };
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.LubricationPoints.Add(LubricationPoint);
            await _context.SaveChangesAsync();

            return RedirectToPage("/Machines/Details", new { id = LubricationPoint.MachineId });
        }
    }
}