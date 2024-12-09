using AspNetCoreHero.ToastNotification.Abstractions;
using AutoMapper;
using Internet_1.Models;
using Internet_1.Repositories;
using Internet_1.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Internet_1.Controllers
{
    //[Authorize]
    public class SurwayController : Controller
    {
        private readonly SurwayRepository _SurwayRepository;
        private readonly SurwayQuestionsRepository _SurwayQuestionsRepository;
        private readonly IMapper _mapper;
        private readonly INotyfService _notyf;

        public SurwayController(SurwayRepository SurwayRepository, SurwayQuestionsRepository SurwayQuestionsRepository, IMapper mapper, INotyfService notyf)
        {
            _SurwayRepository = SurwayRepository;
            _SurwayQuestionsRepository = SurwayQuestionsRepository;
            _mapper = mapper;
            _notyf = notyf;
        }

        public async Task<IActionResult> Index()
        {
            var Surways = await _SurwayRepository.GetAllAsync();
            var SurwayModels = _mapper.Map<List<SurwayModel>>(Surways);
            return View(SurwayModels);
        }
        public async Task<IActionResult> Add()
        {
            var SurwayQuestions = await _SurwayQuestionsRepository.GetAllAsync();

            var SurwayQuestionsSelectList = SurwayQuestions.Select(x => new SelectListItem()
            {
                Text = x.Name,
                Value = x.Id.ToString()
            });
            ViewBag.SurwayQuestions = SurwayQuestionsSelectList;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(SurwayModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var Surway = _mapper.Map<Surway>(model);
            Surway.Created = DateTime.Now;
            Surway.Updated = DateTime.Now;
            await _SurwayRepository.AddAsync(Surway);
            _notyf.Success("Anket Eklendi...");
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Update(int id)
        {

            var SurwayQuestions = await _SurwayQuestionsRepository.GetAllAsync();

            var SurwayQuestionsSelectList = SurwayQuestions.Select(x => new SelectListItem()
            {
                Text = x.Name,
                Value = x.Id.ToString()
            });
            ViewBag.SurwayQuestions = SurwayQuestionsSelectList;
            var Surway = await _SurwayRepository.GetByIdAsync(id);
            var SurwayModel = _mapper.Map<SurwayModel>(Surway);
            return View(SurwayModel);
        }

        [HttpPost]
        public async Task<IActionResult> Update(SurwayModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var Surway = await _SurwayRepository.GetByIdAsync(model.Id);
            Surway.Name = model.Name;
            Surway.Description = model.Description;
            Surway.Price = model.Price;
            Surway.IsActive = model.IsActive;
            Surway.SurwayQuestionsId = model.SurwayQuestionsId;
            Surway.Updated = DateTime.Now;

            await _SurwayRepository.UpdateAsync(Surway);
            _notyf.Success("Anket Güncellendi...");
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Delete(int id)
        {
            var Surway = await _SurwayRepository.GetByIdAsync(id);
            var SurwayModel = _mapper.Map<SurwayModel>(Surway);
            return View(SurwayModel);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(SurwayModel model)
        {

            await _SurwayRepository.DeleteAsync(model.Id);
            _notyf.Success("Anket Silindi...");
            return RedirectToAction("Index");
        }
    }
}
