using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PipelineWebApplication.Data;
using PipelineWebApplication.Models;

namespace PipelineWebApplication.Controllers
{
    public class PipelineDatumsController : Controller
    {
        private readonly PipelineAccountingContext _context;

        public PipelineDatumsController(PipelineAccountingContext context)
        {
            _context = context;
        }

        // GET: PipelineDatums
        public async Task<IActionResult> Index()
        {
            var pipelineAccountingContext = _context.PipelineData.Include(p => p.Brigade).Include(p => p.Field).Include(p => p.RegionControl).Include(p => p.RegionEnd).Include(p => p.RegionStart).Where(q=>q.IsDeleted==false);
            return View(await pipelineAccountingContext.ToListAsync());
        }

        

     

        // GET: PipelineDatums/Create
        public IActionResult Create()
        {
            ViewData["BrigadeId"] = new SelectList(_context.Brigades.Include(q=>q.Unit.Owner), "Id", "FullName");
            ViewData["FieldId"] = new SelectList(_context.Fields, "Id", "Name");
            ViewData["RegionControlId"] = new SelectList(_context.Regions, "Id", "Name");
            ViewData["RegionEndId"] = new SelectList(_context.Regions, "Id", "Name");
            ViewData["RegionStartId"] = new SelectList(_context.Regions, "Id", "Name");
            return View();
        }

        // POST: PipelineDatums/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,BrigadeId,FieldId,RegionStartId,RegionEndId,RegionControlId,Name,SignDouble,TieInPlace,Length,OptimizedLength,Date,Purpose,TransportedMedium,Category,FlowsheetNumber,Note,DebitWater,DebitOil,State,Temperature,PFact,PCalculated")] PipelineDatum pipelineDatum)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pipelineDatum);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BrigadeId"] = new SelectList(_context.Brigades, "Id", "Id", pipelineDatum.BrigadeId);
            ViewData["FieldId"] = new SelectList(_context.Fields, "Id", "Id", pipelineDatum.FieldId);
            ViewData["RegionControlId"] = new SelectList(_context.Regions, "Id", "Id", pipelineDatum.RegionControlId);
            ViewData["RegionEndId"] = new SelectList(_context.Regions, "Id", "Id", pipelineDatum.RegionEndId);
            ViewData["RegionStartId"] = new SelectList(_context.Regions, "Id", "Id", pipelineDatum.RegionStartId);
            return View(pipelineDatum);
        }

        // GET: PipelineDatums/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.PipelineData == null)
            {
                return NotFound();
            }

            var pipelineDatum = await _context.PipelineData.FindAsync(id);
            if (pipelineDatum == null)
            {
                return NotFound();
            }
            ViewData["BrigadeId"] = new SelectList(_context.Brigades, "Id", "Id", pipelineDatum.BrigadeId);
            ViewData["FieldId"] = new SelectList(_context.Fields, "Id", "Id", pipelineDatum.FieldId);
            ViewData["RegionControlId"] = new SelectList(_context.Regions, "Id", "Id", pipelineDatum.RegionControlId);
            ViewData["RegionEndId"] = new SelectList(_context.Regions, "Id", "Id", pipelineDatum.RegionEndId);
            ViewData["RegionStartId"] = new SelectList(_context.Regions, "Id", "Id", pipelineDatum.RegionStartId);
            return View(pipelineDatum);
        }

        // POST: PipelineDatums/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,BrigadeId,FieldId,RegionStartId,RegionEndId,RegionControlId,Name,SignDouble,TieInPlace,Length,OptimizedLength,Date,Purpose,TransportedMedium,Category,FlowsheetNumber,Note,DebitWater,DebitOil,State,Temperature,PFact,PCalculated")] PipelineDatum pipelineDatum)
        {
            if (id != pipelineDatum.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pipelineDatum);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PipelineDatumExists(pipelineDatum.Id))
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
            ViewData["BrigadeId"] = new SelectList(_context.Brigades, "Id", "Id", pipelineDatum.BrigadeId);
            ViewData["FieldId"] = new SelectList(_context.Fields, "Id", "Id", pipelineDatum.FieldId);
            ViewData["RegionControlId"] = new SelectList(_context.Regions, "Id", "Id", pipelineDatum.RegionControlId);
            ViewData["RegionEndId"] = new SelectList(_context.Regions, "Id", "Id", pipelineDatum.RegionEndId);
            ViewData["RegionStartId"] = new SelectList(_context.Regions, "Id", "Id", pipelineDatum.RegionStartId);
            return View(pipelineDatum);
        }

        // GET: PipelineDatums/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.PipelineData == null)
            {
                return NotFound();
            }

            var pipelineDatum = await _context.PipelineData
                .Include(p => p.Brigade)
                .Include(p => p.Field)
                .Include(p => p.RegionControl)
                .Include(p => p.RegionEnd)
                .Include(p => p.RegionStart)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pipelineDatum == null)
            {
                return NotFound();
            }

            return View(pipelineDatum);
        }

        // POST: PipelineDatums/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.PipelineData == null)
            {
                return Problem("Entity set 'PipelineAccountingContext.PipelineData'  is null.");
            }
            var pipelineDatum = await _context.PipelineData.FindAsync(id);
           
            if (pipelineDatum != null)
            {
                pipelineDatum.IsDeleted = true;
                // _context.PipelineData.Remove(pipelineDatum);

            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PipelineDatumExists(int id)
        {
          return (_context.PipelineData?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
