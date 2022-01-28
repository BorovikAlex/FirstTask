using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DataAccess.Data;
using DataAccess.Models;
using Microsoft.Extensions.Logging;
using Logic.IServices;
using Logic.DTOModels;
using System.Collections;

namespace FirstTask.Controllers
{
    public class ProgrammersController : Controller
    {
        private readonly IProgrammerService _service;
        private readonly IPositionService _servicePosition;
        public ProgrammersController(IProgrammerService programmerService, IPositionService positionService)
        {
            _service = programmerService;
            _servicePosition = positionService;
        }

        // GET: Positions
        public async Task<IActionResult> Index()
        {
            var programmers = await _service.GetProgrammers();
            return View(programmers);
        }

        public async Task<IActionResult> Details(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var programmer = await _service.GetProgrammerDetails(id);

            if (programmer == null)
            {
                return NotFound();
            }

            return View(programmer);
        }

        public IActionResult Create()
        {
            var positionsList = _servicePosition.GetPositionsList();
            SelectList positions = new SelectList(positionsList, "PositionID", "PositionName");
            ViewBag.Positions = positions;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProgrammerDTO programmer)
        {

            if (ModelState.IsValid)
            {

                var newPosition = await _service.CreateProgrammer(programmer);
            
                return RedirectToAction(nameof(Index));

            }
            return View(programmer);
        }

        public async Task<IActionResult> Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var programmer = await _service.FindById(id);

            var positionsList = _servicePosition.GetPositionsList();
            SelectList positions = new SelectList(positionsList, "PositionID", "PositionName");
            ViewBag.Positions = positions;
            if (programmer == null)
            {
                return NotFound();
            }
            return View(programmer);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ProgrammerDTO programmer)
        {

            if (ModelState.IsValid)
            {

                await _service.EditProgrammer(programmer);

                return RedirectToAction(nameof(Index));
            }
            return View(programmer);
        }

        public async Task<IActionResult> Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var programmer = await _service.FindById(id);
            if (programmer == null)
            {
                return NotFound();
            }

            return View(programmer);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var programmer = await _service.DeleteProgrammer(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
