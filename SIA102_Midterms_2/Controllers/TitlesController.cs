using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SIA102_Midterms_2.DTOs;
using SIA102_Midterms_2.Models;
using SIA102_Midterms_2.Repositories;
using System.Threading.Tasks;

namespace SIA102_Midterms_2.Controllers
{
    public class TitlesController : Controller
    {
        private readonly ITitleRepository _titleRepo;
        private readonly IMapper _mapper;
        private readonly pubsContext _context;

        public TitlesController(ITitleRepository titleRepo, IMapper mapper, pubsContext context)
        {
            _titleRepo = titleRepo;
            _mapper = mapper;
            _context = context;
        }

        // GET: Titles
        public async Task<IActionResult> Index()
        {
            var titles = await _titleRepo.GetAllAsync();
            var dtos = _mapper.Map<IEnumerable<TitleReadDTO>>(titles);
            return View(dtos);
        }

        // GET: Details
        public async Task<IActionResult> Details(string id)
        {
            if (id == null) return NotFound();

            var title = await _titleRepo.GetByIdAsync(id);
            if (title == null) return NotFound();

            return View(_mapper.Map<TitleReadDTO>(title));
        }

        // GET: Create
        public IActionResult Create()
        {
            ViewData["PubId"] = new SelectList(_context.Publishers, "PubId", "PubName");
            return View();
        }

        // POST: Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TitleCreateDTO dto)
        {
            if (!ModelState.IsValid) return View(dto);

            var title = _mapper.Map<Title>(dto);
            await _titleRepo.AddAsync(title);
            return RedirectToAction(nameof(Index));
        }

        // GET: Edit
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null) return NotFound();

            var title = await _titleRepo.GetByIdAsync(id);
            if (title == null) return NotFound();

            ViewData["PubId"] = new SelectList(_context.Publishers, "PubId", "PubName", title.PubId);
            return View(_mapper.Map<TitleUpdateDTO>(title));
        }

        // POST: Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, TitleUpdateDTO dto)
        {
            if (!ModelState.IsValid) return View(dto);
            if (id != dto.TitleId) return NotFound();

            var title = _mapper.Map<Title>(dto);
            await _titleRepo.UpdateAsync(title);
            return RedirectToAction(nameof(Index));
        }

        // GET: Delete
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null) return NotFound();

            var title = await _titleRepo.GetByIdAsync(id);
            if (title == null) return NotFound();

            return View(_mapper.Map<TitleReadDTO>(title));
        }

        [HttpPost, ActionName("DeleteConfirmed")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string TitleId)
        {
            await _titleRepo.DeleteAsync(TitleId);
            return RedirectToAction(nameof(Index));
        }
    }
}
