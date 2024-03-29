﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PipelineWebApplication.Data;
using PipelineWebApplication.Models;
using PipelineWebApplication.Models.ViewModel;

namespace PipelineWebApplication.Controllers
{
    /// <summary>
    /// Контроллер участка трубопровода
    /// </summary>
    public class PipelinePassportsController : Controller
    {
        private readonly PipelineAccountingContext _context;

        public PipelinePassportsController(PipelineAccountingContext context)
        {
            _context = context;
        }
        private void pipelineDataSelect()
        {
            ViewData["PipelineDataId"] = new SelectList(_context.PipelineData.Where(q => q.IsDeleted == false).OrderByDescending(q => q.Id), "Id", "Name");
        }
        // Выполненяет Get запрос Index
        // GET: PipelinePassports
        [Authorize]
        public async Task<IActionResult> Index(int? id)
        {
            // передает данные в представление для раскрывающегося списка
            pipelineDataSelect();

            IQueryable<PipelinePassport> pipelineAccountingContext = _context.PipelinePassports.
                Include(p => p.BuildingCompany).Include(p => p.FactoryMpt).Include(p => p.FactoryPipe)
                 .Include(p => p.InternalCoating).Include(p => p.Material).Include(p => p.PipeType)
                 .Include(p => p.PipelineData);
            // получаем данные по участкам в трубопроводе      
            if (id == null)
            {
                var a = pipelineAccountingContext.FirstOrDefault();
                List<PipelinePassport> pipelinePassports= new List<PipelinePassport>() {a};
                return View(pipelinePassports);
            }
            else
            {
                pipelineAccountingContext = pipelineAccountingContext.Where(p => p.PipelineDataId == id);
            }
            return View(await pipelineAccountingContext.ToListAsync());
        }
        [HttpPost]
        // Выполняет Post запрос Index. Производит фильтрацию данных и выводит отфильтрованные данные в представление
        public async Task<IActionResult> Index(string PipelineName, bool notUsed)
        {
            int id = Convert.ToInt32(PipelineName);
            pipelineDataSelect();
            IQueryable<PipelinePassport> pipelineAccountingContext = _context.PipelinePassports
                .Include(p => p.BuildingCompany).Include(p => p.FactoryMpt).Include(p => p.FactoryPipe)
                 .Include(p => p.InternalCoating).Include(p => p.Material).Include(p => p.PipeType)
                 .Include(p => p.PipelineData).Where(q=>q.PipelineDataId == id);
            return View(await pipelineAccountingContext.ToListAsync());
        }

        // GET: PipelinePassports/Details/5
        [Authorize]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.PipelinePassports == null)
            {
                return NotFound();
            }

            var pipelinePassport = await _context.PipelinePassports
                .Include(p => p.BuildingCompany)
                .Include(p => p.FactoryMpt)
                .Include(p => p.FactoryPipe)
                .Include(p => p.InternalCoating)
                .Include(p => p.Material)
                .Include(p => p.PipeType)
                .Include(p => p.PipelineData)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pipelinePassport == null)
            {
                return NotFound();
            }

            return View(pipelinePassport);
        }

        // GET: PipelinePassports/Create
        [Authorize]
        public IActionResult Create()
        {

            ViewData["BuildingCompanyId"] = new SelectList(_context.BuildingСompanies, "Id", "Name");
            ViewData["FactoryMptid"] = new SelectList(_context.Factories, "Id", "Name");
            ViewData["FactoryPipeId"] = new SelectList(_context.Factories, "Id", "Name");
            ViewData["InternalCoatingId"] = new SelectList(_context.InternalСoatings, "Id", "Name");
            ViewData["MaterialId"] = new SelectList(_context.Materials, "Id", "Name");
            ViewData["PipeTypeId"] = new SelectList(_context.PipeTypes, "Id", "Name");
            ViewData["PipelineDataId"] = new SelectList(_context.PipelineData, "Id", "Name");
            return View();
        }

        // POST: PipelinePassports/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FactoryMptid,FactoryPipeId,BuildingCompanyId,MaterialId,InternalCoatingId,PipeTypeId,PipelineDataId,PlotStart,PlotEnd,Lenght,Date,Status,Diameter,WallThickness,PavingDepth,DateInternalCoating,OutdoorCoating,TypeOfConstruction,Deviation,ConstructionCost,Note,JointReplacement1,JointReplacement2,Amount,JointReplacementDate")] PipelinePassport pipelinePassport)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pipelinePassport);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BuildingCompanyId"] = new SelectList(_context.BuildingСompanies, "Id", "Id", pipelinePassport.BuildingCompanyId);
            ViewData["FactoryMptid"] = new SelectList(_context.Factories, "Id", "Id", pipelinePassport.FactoryMptid);
            ViewData["FactoryPipeId"] = new SelectList(_context.Factories, "Id", "Id", pipelinePassport.FactoryPipeId);
            ViewData["InternalCoatingId"] = new SelectList(_context.InternalСoatings, "Id", "Id", pipelinePassport.InternalCoatingId);
            ViewData["MaterialId"] = new SelectList(_context.Materials, "Id", "Id", pipelinePassport.MaterialId);
            ViewData["PipeTypeId"] = new SelectList(_context.PipeTypes, "Id", "Id", pipelinePassport.PipeTypeId);
            ViewData["PipelineDataId"] = new SelectList(_context.PipelineData, "Id", "Id", pipelinePassport.PipelineDataId);
            return View(pipelinePassport);
        }

        // GET: PipelinePassports/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.PipelinePassports == null)
            {
                return NotFound();
            }

            var pipelinePassport = await _context.PipelinePassports.FindAsync(id);
            if (pipelinePassport == null)
            {
                return NotFound();
            }
            ViewData["BuildingCompanyId"] = new SelectList(_context.BuildingСompanies, "Id", "Name", pipelinePassport.BuildingCompanyId);
            ViewData["FactoryMptid"] = new SelectList(_context.Factories, "Id", "Name", pipelinePassport.FactoryMptid);
            ViewData["FactoryPipeId"] = new SelectList(_context.Factories, "Id", "Name", pipelinePassport.FactoryPipeId);
            ViewData["InternalCoatingId"] = new SelectList(_context.InternalСoatings, "Id", "Name", pipelinePassport.InternalCoatingId);
            ViewData["MaterialId"] = new SelectList(_context.Materials, "Id", "Name", pipelinePassport.MaterialId);
            ViewData["PipeTypeId"] = new SelectList(_context.PipeTypes, "Id", "Name", pipelinePassport.PipeTypeId);
            ViewData["PipelineDataId"] = new SelectList(_context.PipelineData, "Id", "Name", pipelinePassport.PipelineDataId);
            return View(pipelinePassport);
        }

        // POST: PipelinePassports/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FactoryMptid,FactoryPipeId,BuildingCompanyId,MaterialId,InternalCoatingId,PipeTypeId,PipelineDataId,PlotStart,PlotEnd,Lenght,Date,Status,Diameter,WallThickness,PavingDepth,DateInternalCoating,OutdoorCoating,TypeOfConstruction,Deviation,ConstructionCost,Note,JointReplacement1,JointReplacement2,Amount,JointReplacementDate")] PipelinePassport pipelinePassport)
        {
            if (id != pipelinePassport.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pipelinePassport);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PipelinePassportExists(pipelinePassport.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["BuildingCompanyId"] = new SelectList(_context.BuildingСompanies, "Id", "Id", pipelinePassport.BuildingCompanyId);
            ViewData["FactoryMptid"] = new SelectList(_context.Factories, "Id", "Id", pipelinePassport.FactoryMptid);
            ViewData["FactoryPipeId"] = new SelectList(_context.Factories, "Id", "Id", pipelinePassport.FactoryPipeId);
            ViewData["InternalCoatingId"] = new SelectList(_context.InternalСoatings, "Id", "Id", pipelinePassport.InternalCoatingId);
            ViewData["MaterialId"] = new SelectList(_context.Materials, "Id", "Id", pipelinePassport.MaterialId);
            ViewData["PipeTypeId"] = new SelectList(_context.PipeTypes, "Id", "Id", pipelinePassport.PipeTypeId);
            ViewData["PipelineDataId"] = new SelectList(_context.PipelineData, "Id", "Id", pipelinePassport.PipelineDataId);
            return View(pipelinePassport);
        }

        // GET: PipelinePassports/Delete/5
        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.PipelinePassports == null)
            {
                return NotFound();
            }

            var pipelinePassport = await _context.PipelinePassports
                .Include(p => p.BuildingCompany)
                .Include(p => p.FactoryMpt)
                .Include(p => p.FactoryPipe)
                .Include(p => p.InternalCoating)
                .Include(p => p.Material)
                .Include(p => p.PipeType)
                .Include(p => p.PipelineData)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pipelinePassport == null)
            {
                return NotFound();
            }

            return View(pipelinePassport);
        }

        // POST: PipelinePassports/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.PipelinePassports == null)
            {
                return Problem("Entity set 'PipelineAccountingContext.PipelinePassports'  is null.");
            }
            var pipelinePassport = await _context.PipelinePassports.FindAsync(id);
            if (pipelinePassport != null)
            {
                _context.PipelinePassports.Remove(pipelinePassport);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PipelinePassportExists(int id)
        {
          return (_context.PipelinePassports?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
