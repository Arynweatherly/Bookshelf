using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Bookshelf35.Data;
using Bookshelf35.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace Bookshelf35.Controllers
{
    [Authorize]
    public class CommentsController : Controller
    {
        private readonly ApplicationDbContext _context;

        private readonly UserManager<ApplicationUser> _userManager;

        public CommentsController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
    {
            _context = context;
            _userManager = userManager;
        }

        // GET: Comments
        public async Task<IActionResult> Index()
        {
            var user = await GetCurrentUserAsync();
            var applicationDbContext = _context.Comment
                .Where(b => b.ApplicationUserId == user.Id)
                .Include(c => c.ApplicationUser)
                .Include(c => c.Book);
            return View(await applicationDbContext.ToListAsync());
        }


        // GET: Comments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var comment = await _context.Comment
                .Include(c => c.ApplicationUser)
                .Include(c => c.Book)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (comment == null)
            {
                return NotFound();
            }

            return View(comment);
        }


        // GET: Comments/Create
        //comments controller the create form function and the book id
        [HttpGet("Comments/Create/{bookId}")]
        public async Task<IActionResult> Create(int bookId)
        {
            if (bookId == null)
            {
                var user = await GetCurrentUserAsync();
            }
                return View();
        }

        // POST: Comments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost("Comments/Create/{bookId}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([FromRoute] int bookId, [Bind("Id,Text,ApplicationUserId,BookId")] Comment comment)
        {
            var user = await GetCurrentUserAsync();
            comment.ApplicationUserId = user.Id;
            if (bookId != null)
            {
                comment.BookId = bookId;
            }

            if (ModelState.IsValid)
            {
                _context.Add(comment);
                await _context.SaveChangesAsync();
                return RedirectToAction("Details", "Books", new { id = bookId});
            }
            ViewData["BookId"] = new SelectList(_context.Book
                .Where(b => b.ApplicationUserId == user.Id),
                "Id", "Title", comment.BookId);
            return View(comment);
        }

        // GET: Comments/Edit/5
        [HttpGet("Comments/Edit/{id}")]
        public async Task<IActionResult> Edit(int? id, int bookId)
        {
            if (id == null)
            {
                return NotFound();
            }

            var comment = await _context.Comment.FindAsync(id);

            var user = await GetCurrentUserAsync();
            if (comment == null)
            {
                return NotFound();
            }
            ViewData["BookId"] = new SelectList(_context.Book, "Id", "Id", comment.BookId);
            return View(comment);
        }

        // POST: Comments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost("Comments/Edit/{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Text,ApplicationUserId,BookId")] Comment comment)
        {
            if (id != comment.Id)
            {
                return NotFound();
            }

            var user = await GetCurrentUserAsync();

            comment.ApplicationUserId = user.Id;

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(comment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CommentExists(comment.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Details", "Books", new { id = comment.BookId });
            }
            ViewData["BookId"] = new SelectList(_context.Book, "Id", "Id", comment.BookId);
            return View(comment);
        }

        // GET: Comments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var comment = await _context.Comment
                .Include(c => c.ApplicationUser)
                .Include(c => c.Book)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (comment == null)
            {
                return NotFound();
            }

            return View(comment);
        }

        // POST: Comments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var comment = await _context.Comment.FindAsync(id);
            _context.Comment.Remove(comment);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Books");
        }

        private bool CommentExists(int id)
        {
            return _context.Comment.Any(e => e.Id == id);
        }

        private Task<ApplicationUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);
    }
}
