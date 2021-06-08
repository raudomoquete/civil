using civil.Web.Data;
using civil.Web.Data.Entities;
using civil.Web.Helpers;
using civil.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace civil.Web.Controllers
{
    public class FormsController : Controller
    {
        private readonly DataContext _context;
        private readonly IConverterHelper _converterHelper;
        private readonly IImageHelper _imageHelper;

        public FormsController(DataContext context,
            IConverterHelper converterHelper,
            IImageHelper imageHelper)
        {
            _context = context;
            _converterHelper = converterHelper;
            _imageHelper = imageHelper;            
        }

        //GET: Forms

        public async Task<IActionResult> Index()
        {
            return View(await _context.Forms.ToListAsync());
        }

        //GET: Forms/Details
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var form = await _context.Forms
                .FirstOrDefaultAsync(m => m.Id == id);
            if(form == null)
            {
                return NotFound();
            }

            return View(form);
        }
             
        //GET: Forms/Create
        public IActionResult Create()
        {
            return View();
        }

        //POST: Forms/Create
        [HttpPost]
        public async Task<IActionResult> Create([Bind("Id, Date, Incident, Province, Description, Longitude, Latitude, ImageUrl, AffectedPeople," +
            "AffectedHomes, Deseased, Observation, Informant, Operator, CreatedAt, UpdatedAt")] Form form)
        {
            if (ModelState.IsValid)
            {
                _context.Add(form);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(form);
        }

        [HttpPost]
        public async Task<IActionResult> Create(FormViewModel model)
        {
            if (ModelState.IsValid)
            {
                var path = string.Empty;

                if(model.ImageFile != null)
                {
                    path = await _imageHelper.UploadImageAsync(model.ImageFile);
                }

                var form = await _converterHelper.ToFormAsync(model, path, true);
                _context.Forms.Add(form);
                await _context.SaveChangesAsync();
                return RedirectToAction($"Details/{model.FormId}");
            }

            return View(model);
        }

        //GET: Form/Edit
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var form = await _context.Forms.FindAsync(id);
            if (form == null)
            {
                return NotFound();
            }
            return View(form);
        }

        //POST: form/Edit
        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id, Date, Incident, Province, Description, Longitude, Latitude, Image, AffectedPeople," +
            "AffectedHomes, Deseased, Observation, Informant, Operator, CreatedAt, UpdatedAt")] Form form)
        {
            if (id != form.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(form);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!formExists(form.Id))
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
            return View(form);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(FormViewModel model)
        {
            if (ModelState.IsValid)
            {
                var path = model.ImageUrl;

                if (model.ImageFile != null)
                {
                    path = await _imageHelper.UploadImageAsync(model.ImageFile);
                }

                var form = await _converterHelper.ToFormAsync(model, path, false);
                _context.Forms.Update(form);
                await _context.SaveChangesAsync();
                return RedirectToAction($"Details/{model.FormId}");
            }

            return View(model);
        }
             
        //GET: Form/Delete
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var form = await _context.Forms
                .FirstOrDefaultAsync(m => m.Id == id);
            if (form == null)
            {
                return NotFound();
            }

            return View(form);
        }

        //POST: Form/Delete
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var form = await _context.Forms.FindAsync(id);
            _context.Forms.Remove(form);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool formExists(int id)
        {
            return _context.Forms.Any(e => e.Id == id);
        }

    }
}
