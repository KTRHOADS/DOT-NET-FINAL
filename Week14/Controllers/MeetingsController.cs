using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Week14.Models;

namespace Week14.Controllers
{
    public class MeetingsController : Controller
    {
        private readonly Week14Context _context;

        public MeetingsController(Week14Context context)
        {
            _context = context;
        }

        // GET: Meetings
        public async Task<IActionResult> Index()
        {
            var week14Context = _context.Meeting.Include(m => m.Benediction).Include(m => m.ClosingHymn).Include(m => m.Conducting).Include(m => m.FirstSpeaker).Include(m => m.InterHymn).Include(m => m.Invocation).Include(m => m.LastSpeaker).Include(m => m.MiddleSpeaker).Include(m => m.OpeningHymn).Include(m => m.SacramentHymn);
            return View(await week14Context.ToListAsync());
        }

        // GET: Meetings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var meeting = await _context.Meeting
                .Include(m => m.Benediction)
                .Include(m => m.ClosingHymn)
                .Include(m => m.Conducting)
                .Include(m => m.FirstSpeaker)
                .Include(m => m.InterHymn)
                .Include(m => m.Invocation)
                .Include(m => m.LastSpeaker)
                .Include(m => m.MiddleSpeaker)
                .Include(m => m.OpeningHymn)
                .Include(m => m.SacramentHymn)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (meeting == null)
            {
                return NotFound();
            }

            return View(meeting);
        }

        // GET: Meetings/Create
        public IActionResult Create()
        {
            ViewData["BenedictionID"] = new SelectList(_context.Member, "ID", "FirstMidName");
            ViewData["ClosingHymnID"] = new SelectList(_context.Hymn, "ID", "Title");
            ViewData["ConductingID"] = new SelectList(_context.Bishopric, "ID", "Name");
            ViewData["FirstSpeakerID"] = new SelectList(_context.Member, "ID", "FirstMidName");
            ViewData["InterHymnID"] = new SelectList(_context.Hymn, "ID", "Title");
            ViewData["InvocationID"] = new SelectList(_context.Member, "ID", "FirstMidName");
            ViewData["LastSpeakerID"] = new SelectList(_context.Member, "ID", "FirstMidName");
            ViewData["MiddleSpeakerID"] = new SelectList(_context.Member, "ID", "FirstMidName");
            ViewData["OpeningHymnID"] = new SelectList(_context.Hymn, "ID", "Title");
            ViewData["SacramentHymnID"] = new SelectList(_context.Hymn, "ID", "Title");
            return View();
        }

        // POST: Meetings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Date,ConductingID,OpeningHymnID,SacramentHymnID,InterHymnID,ClosingHymnID,InvocationID,BenedictionID,IsFastSunday,FirstTopic,SecondTopic,ThirdTopic,RowVersion,MiddleSpeakerID,LastSpeakerID,FirstSpeakerID")] Meeting meeting)
        {
            if (ModelState.IsValid)
            {
                _context.Add(meeting);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BenedictionID"] = new SelectList(_context.Member, "ID", "FirstMidName", meeting.BenedictionID);
            ViewData["ClosingHymnID"] = new SelectList(_context.Hymn, "ID", "ID", meeting.ClosingHymnID);
            ViewData["ConductingID"] = new SelectList(_context.Bishopric, "ID", "Name", meeting.ConductingID);
            ViewData["FirstSpeakerID"] = new SelectList(_context.Member, "ID", "FirstMidName", meeting.FirstSpeakerID);
            ViewData["InterHymnID"] = new SelectList(_context.Hymn, "ID", "Title", meeting.InterHymnID);
            ViewData["InvocationID"] = new SelectList(_context.Member, "ID", "FirstMidName", meeting.InvocationID);
            ViewData["LastSpeakerID"] = new SelectList(_context.Member, "ID", "FirstMidName", meeting.LastSpeakerID);
            ViewData["MiddleSpeakerID"] = new SelectList(_context.Member, "ID", "FirstMidName", meeting.MiddleSpeakerID);
            ViewData["OpeningHymnID"] = new SelectList(_context.Hymn, "ID", "Title", meeting.OpeningHymnID);
            ViewData["SacramentHymnID"] = new SelectList(_context.Hymn, "ID", "Title", meeting.SacramentHymnID);
            return View(meeting);
        }

        // GET: Meetings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var meeting = await _context.Meeting.FindAsync(id);
            if (meeting == null)
            {
                return NotFound();
            }
            ViewData["BenedictionID"] = new SelectList(_context.Member, "ID", "FullName", meeting.BenedictionID);
            ViewData["ClosingHymnID"] = new SelectList(_context.Hymn, "ID", "Title", meeting.ClosingHymnID);
            ViewData["ConductingID"] = new SelectList(_context.Bishopric, "ID", "Name", meeting.ConductingID);
            ViewData["FirstSpeakerID"] = new SelectList(_context.Member, "ID", "FullName", meeting.FirstSpeakerID);
            ViewData["InterHymnID"] = new SelectList(_context.Hymn, "ID", "Title", meeting.InterHymnID);
            ViewData["InvocationID"] = new SelectList(_context.Member, "ID", "FullName", meeting.InvocationID);
            ViewData["LastSpeakerID"] = new SelectList(_context.Member, "ID", "FullName", meeting.LastSpeakerID);
            ViewData["MiddleSpeakerID"] = new SelectList(_context.Member, "ID", "FullName", meeting.MiddleSpeakerID);
            ViewData["OpeningHymnID"] = new SelectList(_context.Hymn, "ID", "Title", meeting.OpeningHymnID);
            ViewData["SacramentHymnID"] = new SelectList(_context.Hymn, "ID", "Title", meeting.SacramentHymnID);
            return View(meeting);
        }

        // POST: Meetings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Date,ConductingID,OpeningHymnID,SacramentHymnID,InterHymnID,ClosingHymnID,InvocationID,BenedictionID,IsFastSunday,FirstTopic,SecondTopic,ThirdTopic,MiddleSpeakerID,LastSpeakerID,FirstSpeakerID")] Meeting meeting)
        {
            if (id != meeting.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(meeting);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MeetingExists(meeting.ID))
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
            ViewData["BenedictionID"] = new SelectList(_context.Member, "ID", "FullName", meeting.BenedictionID);
            ViewData["ClosingHymnID"] = new SelectList(_context.Hymn, "ID", "Title", meeting.ClosingHymnID);
            ViewData["ConductingID"] = new SelectList(_context.Bishopric, "ID", "Name", meeting.ConductingID);
            ViewData["FirstSpeakerID"] = new SelectList(_context.Member, "ID", "FullName", meeting.FirstSpeakerID);
            ViewData["InterHymnID"] = new SelectList(_context.Hymn, "ID", "Title", meeting.InterHymnID);
            ViewData["InvocationID"] = new SelectList(_context.Member, "ID", "FullName", meeting.InvocationID);
            ViewData["LastSpeakerID"] = new SelectList(_context.Member, "ID", "FullName", meeting.LastSpeakerID);
            ViewData["MiddleSpeakerID"] = new SelectList(_context.Member, "ID", "FullName", meeting.MiddleSpeakerID);
            ViewData["OpeningHymnID"] = new SelectList(_context.Hymn, "ID", "Title", meeting.OpeningHymnID);
            ViewData["SacramentHymnID"] = new SelectList(_context.Hymn, "ID", "Title", meeting.SacramentHymnID);
            return View(meeting);
        }

        // GET: Meetings/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var meeting = await _context.Meeting
                .Include(m => m.Benediction)
                .Include(m => m.ClosingHymn)
                .Include(m => m.Conducting)
                .Include(m => m.FirstSpeaker)
                .Include(m => m.InterHymn)
                .Include(m => m.Invocation)
                .Include(m => m.LastSpeaker)
                .Include(m => m.MiddleSpeaker)
                .Include(m => m.OpeningHymn)
                .Include(m => m.SacramentHymn)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (meeting == null)
            {
                return NotFound();
            }

            return View(meeting);
        }

        // POST: Meetings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var meeting = await _context.Meeting.FindAsync(id);
            _context.Meeting.Remove(meeting);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MeetingExists(int id)
        {
            return _context.Meeting.Any(e => e.ID == id);
        }
    }
}
