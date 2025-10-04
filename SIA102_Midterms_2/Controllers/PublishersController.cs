using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SIA102_Midterms_2.DTOs;
using SIA102_Midterms_2.Models;
using SIA102_Midterms_2.Repositories;
using System.Threading.Tasks;

namespace SIA102_Midterms_2.Controllers
{
    public class PublishersController : Controller
    {
        private readonly IPublisherRepository _publisherRepo;
        private readonly IMapper _mapper;

        public PublishersController(IPublisherRepository publisherRepo, IMapper mapper)
        {
            _publisherRepo = publisherRepo;
            _mapper = mapper;
            _publisherRepo.PublisherAdded += OnPublisherAdded;
        }

        private void OnPublisherAdded(Publisher publisher)
        {
            Console.WriteLine($"New publisher added: {publisher.PubName}");
        }

        public async Task<IActionResult> Index()
        {
            var publishers = await _publisherRepo.GetAllAsync();
            var dtos = _mapper.Map<List<PublisherReadDTO>>(publishers);
            return View(dtos);
        }

        public async Task<IActionResult> Details(string id)
        {
            var publisher = await _publisherRepo.GetByIdAsync(id);
            if (publisher == null) return NotFound();
            var dto = _mapper.Map<PublisherReadDTO>(publisher);
            return View(dto);
        }

        public IActionResult Create() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PublisherCreateDTO dto)
        {
            if (!ModelState.IsValid) return View(dto);

            var publisher = _mapper.Map<Publisher>(dto);
            await _publisherRepo.AddAsync(publisher);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(string id)
        {
            var publisher = await _publisherRepo.GetByIdAsync(id);
            if (publisher == null) return NotFound();
            var dto = _mapper.Map<PublisherUpdateDTO>(publisher);
            return View(dto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(PublisherUpdateDTO dto)
        {
            if (!ModelState.IsValid) return View(dto);

            var publisher = _mapper.Map<Publisher>(dto);
            await _publisherRepo.UpdateAsync(publisher);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(string id)
        {
            var publisher = await _publisherRepo.GetByIdAsync(id);
            if (publisher == null) return NotFound();
            var dto = _mapper.Map<PublisherDeleteDTO>(publisher);
            return View(dto);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(PublisherDeleteDTO dto)
        {
            await _publisherRepo.DeleteAsync(dto.PubId);
            return RedirectToAction(nameof(Index));
        }
    }
}
