using AspNetCoreHero.ToastNotification.Abstractions;
using AutoMapper;
using Internet_1.Models;
using Internet_1.Repositories;
using Internet_1.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Internet_1.Controllers
{
    //[Authorize]
    public class SurwayQuestionsController : Controller
    {
        private readonly SurwayQuestionsRepository _SurwayQuestionsRepository;
        private readonly SurwayRepository _SurwayRepository;
        private readonly INotyfService _notyf;
        private readonly IMapper _mapper;

        public SurwayQuestionsController(SurwayQuestionsRepository SurwayQuestionsRepository, INotyfService notyf, SurwayRepository SurwayRepository, IMapper mapper)
        {
            _SurwayQuestionsRepository = SurwayQuestionsRepository;
            _notyf = notyf;
            _SurwayRepository = SurwayRepository;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var SurwaysQuestionss = await _SurwayQuestionsRepository.GetAllAsync();
            var SurwayQuestionsModels = _mapper.Map<List<SurwayQuestionsModel>>(SurwaysQuestionss);
            return View(SurwayQuestionsModels);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(SurwayQuestionsModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var SurwayQuestions = _mapper.Map<SurwayQuestions>(model);
            SurwayQuestions.Created = DateTime.Now;
            SurwayQuestions.Updated = DateTime.Now;
            await _SurwayQuestionsRepository.AddAsync(SurwayQuestions);
            _notyf.Success("Cevap Eklendi...");
            return RedirectToAction("Index");
        }


        public async Task<IActionResult> Update(int id)
        {
            var SurwayQuestions = await _SurwayQuestionsRepository.GetByIdAsync(id);
            var SurwayQuestionsModel = _mapper.Map<SurwayQuestionsModel>(SurwayQuestions);
            return View(SurwayQuestionsModel);
        }

        [HttpPost]
        public async Task<IActionResult> Update(SurwayQuestionsModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var SurwayQuestions = await _SurwayQuestionsRepository.GetByIdAsync(model.Id);
            SurwayQuestions.Name = model.Name;
            SurwayQuestions.IsActive = model.IsActive;
            SurwayQuestions.Updated = DateTime.Now;
            await _SurwayQuestionsRepository.UpdateAsync(SurwayQuestions);
            _notyf.Success("Cevap Güncellendi...");
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Delete(int id)
        {
            var SurwayQuestions = await _SurwayQuestionsRepository.GetByIdAsync(id);
            var SurwayQuestionsModel = _mapper.Map<SurwayQuestionsModel>(SurwayQuestions);
            return View(SurwayQuestionsModel);
        }


        [HttpPost]
        public async Task<IActionResult> Delete(SurwayQuestionsModel model)
        {

            var Surways = await _SurwayRepository.GetAllAsync();
            if (Surways.Count(c => c.SurwayQuestionsId == model.Id) > 0)
            {
                _notyf.Error("Üzerinde Ürün Kayıtlı Olan Cevap Silinemez!");
                return RedirectToAction("Index");
            }

            await _SurwayQuestionsRepository.DeleteAsync(model.Id);
            _notyf.Success("Cevap Silindi...");
            return RedirectToAction("Index");

        }
    }
}
