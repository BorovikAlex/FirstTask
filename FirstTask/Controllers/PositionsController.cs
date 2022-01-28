using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

using Logic.IServices;
using Logic.DTOModels;

namespace FirstTask.Controllers
{
    public class PositionsController : Controller
    {

        private readonly IPositionService _service;
        public PositionsController(IPositionService positionService)
        {
            _service = positionService;
        }

        // GET: Positions
        public async Task<IActionResult> Index()
        {
            var positions = await _service.GetPositions();
            return View(positions);
        }

        public async Task<IActionResult> Details(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var position = await _service.GetPositionDetails(id);

            if (position == null)
            {
                return NotFound();
            }

            return View(position);
        }


        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PositionID,PositionName")] PositionDTO position)
        {

            if (ModelState.IsValid)
            {

                var newPosition = await _service.CreatePosition(position);
                return RedirectToAction(nameof(Index));

            }
            return View(position);
        }

        public async Task<IActionResult> Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var position = await _service.FindById(id);
            if (position == null)
            {
                return NotFound();
            }
            return View(position);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([Bind("PositionID,PositionName")] PositionDTO position)
        {

            if (ModelState.IsValid)
            {

                await _service.EditPosition(position);

                return RedirectToAction(nameof(Index));
            }
            return View(position);
        }

        public async Task<IActionResult> Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var position = await _service.FindById(id);
            if (position == null)
            {
                return NotFound();
            }

            return View(position);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var position = await _service.DeletePosition(id);
            return RedirectToAction(nameof(Index));
        }

      
    }
}
