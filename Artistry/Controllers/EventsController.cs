#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Artistry.Models;
using Artistry.Core.Repositories;
using Artistry.Persistance.Repositories;

namespace Artistry.Controllers
{
    public class EventsController : Controller
    {
       
        private IEventRepository eventRepository;
        private IResourceRepository resourceRepository;
        private IUserRepository userRepository;

        public EventsController(ArtistryContext context)
        {
            this.eventRepository = new EventRepository(new ArtistryContext());
            this.resourceRepository = new ResourceRepository(new ArtistryContext());
            this.userRepository = new UserRepository(new ArtistryContext());
        }

        // GET: Events
        public async Task<IActionResult> Index()
        {
            var events = from e in eventRepository.GetEvents()
                         select e;
            return View(events);
            
        }

        // GET: Events/Details/5
        public async Task<IActionResult> Details(int id)
        {

            Event ev = eventRepository.GetEvent(id);
            return View(ev);
        }

        // GET: Events/Create
        public IActionResult Create()
        {
            ViewData["ResourceId"] = new SelectList(resourceRepository.GetResources(), "Id", "Id");
            ViewData["UserId"] = new SelectList(userRepository.GetUsers(), "Id", "Id");
            return View();
        }

        // POST: Events/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ResourceId,UserId,Date")] Event @event)
        {
            if (ModelState.IsValid)
            {
                eventRepository.InsertEvent(@event);
                return RedirectToAction(nameof(Index));
            }
            ViewData["ResourceId"] = new SelectList(resourceRepository.GetResources(), "Id", "Id", @event.ResourceId);
            ViewData["UserId"] = new SelectList(userRepository.GetUsers(), "Id", "Id", @event.UserId);
            return View(@event);
        }

        // GET: Events/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Event ev = eventRepository.GetEvent(id);
            if (ev == null)
            {
                return NotFound();
            }
            ViewData["ResourceId"] = new SelectList(resourceRepository.GetResources(), "Id", "Id", ev.ResourceId);
            ViewData["UserId"] = new SelectList(userRepository.GetUsers(), "Id", "Id", ev.UserId);
            return View(ev);
        }

        // POST: Events/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ResourceId,UserId,Date")] Event @event)
        {
            if (id != @event.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    eventRepository.UpdateEvent(@event);
                    eventRepository.Save();
                    return RedirectToAction("Index");
                }
                catch (DbUpdateConcurrencyException)
                {
                    
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["ResourceId"] = new SelectList(resourceRepository.GetResources(), "Id", "Id", @event.ResourceId);
            ViewData["UserId"] = new SelectList(userRepository.GetUsers(), "Id", "Id", @event.UserId);
            return View(@event);
        }

        // GET: Events/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Event ev = eventRepository.GetEvent(id);
            if (ev == null)
            {
                return NotFound();
            }

            return View(ev);
        }

        // POST: Events/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            Event ev = eventRepository.GetEvent(id);
            eventRepository.DeleteEvent(id);
            eventRepository.Save();
            return RedirectToAction(nameof(Index));
        }

        protected override void Dispose(bool disposing)
        {
            eventRepository.Dispose();
            base.Dispose(disposing);
        }

    }
}
