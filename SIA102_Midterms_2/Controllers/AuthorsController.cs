using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SIA102_Midterms_2.Delegates;
using SIA102_Midterms_2.DTOs;
using SIA102_Midterms_2.Extensions;
using SIA102_Midterms_2.Models;
using SIA102_Midterms_2.Repositories;
using System.Threading.Tasks;

namespace SIA102_Midterms_2.Controllers
{
    public class AuthorsController : Controller
    {
        private readonly IAuthorRepository _authorRepo;
        private readonly IMapper _mapper;

        public AuthorsController(IAuthorRepository authorRepo, IMapper mapper)
        {
            _authorRepo = authorRepo;
            _mapper = mapper;

            _authorRepo.AuthorAdded += OnAuthorAdded;
        }

        // EVENT: authoradded
        private void OnAuthorAdded(Author author)
        {
            Console.WriteLine($"New author added: {author.FullName()}");
            // Could also log to database, send an email, etc.
        }

        // GET: Authors
        public async Task<IActionResult> Index()
        {
            var authors = await _authorRepo.GetAllAsync();
            var dtos = _mapper.Map<List<AuthorReadDTO>>(authors);
            return View(dtos);
        }

        // GET: Authors/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null) return NotFound();

            var author = await _authorRepo.GetByIdAsync(id);
            if (author == null) return NotFound();

            // Use the extension method
            var fullName = author.FullName();

            // Optionally pass it to the view
            ViewBag.FullName = fullName;

            var dto = _mapper.Map<AuthorReadDTO>(author);
            return View(dto);
        }


        // GET: Authors/Create
        public IActionResult Create() => View();

        // POST: Authors/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AuthorCreateDTO dto)
        {
            if (!ModelState.IsValid) return View(dto);

            var author = _mapper.Map<Author>(dto);
            await _authorRepo.AddAsync(author);
            return RedirectToAction(nameof(Index));
        }

        // GET: Authors/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (string.IsNullOrEmpty(id)) return NotFound();

            var author = await _authorRepo.GetByIdAsync(id);
            if (author == null) return NotFound();

            var dto = _mapper.Map<AuthorUpdateDTO>(author);
            return View(dto);
        }

        // POST: Authors/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, AuthorUpdateDTO dto)
        {
            if (id != dto.AuId) return NotFound();
            if (!ModelState.IsValid) return View(dto);

            var author = await _authorRepo.GetByIdAsync(id);
            if (author == null) return NotFound();

            _mapper.Map(dto, author); // Maps DTO properties into existing entity
            await _authorRepo.UpdateAsync(author);

            return RedirectToAction(nameof(Index));
        }

        // GET: Authors/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (string.IsNullOrEmpty(id)) return NotFound();

            var author = await _authorRepo.GetByIdAsync(id);
            if (author == null) return NotFound();

            var dto = _mapper.Map<AuthorReadDTO>(author);
            return View(dto);
        }

        // POST: Authors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            await _authorRepo.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

        // DELEGATE
        public async Task<IActionResult> ContractedAuthors()
        {
            // Delegate with lambda expression
            AuthorFilter contractFilter = a => a.Contract;

            var authors = await _authorRepo.GetFilteredAuthorsAsync(contractFilter);
            var dtos = _mapper.Map<List<AuthorReadDTO>>(authors);

            return View(dtos);
        }

        public async Task<IActionResult> NonContractedAuthors()
        {
            // Delegate with lambda expression for non-contracted authors
            AuthorFilter nonContractFilter = a => !a.Contract;

            var authors = await _authorRepo.GetFilteredAuthorsAsync(nonContractFilter);
            var dtos = _mapper.Map<List<AuthorReadDTO>>(authors);

            return View(dtos);
        }

    }
}
