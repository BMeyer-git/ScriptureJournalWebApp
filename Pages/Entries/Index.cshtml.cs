using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ScriptureJournal.Models;
using ScriptureJournal.Data;

namespace ScriptureJournal.Pages_Entries
{
    public class IndexModel : PageModel
    {
        private readonly ScriptureJournalContext _context;

        public IndexModel(ScriptureJournalContext context)
        {
            _context = context;
        }

        public IList<Entry> Entry { get;set; } = default!;

        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }

        [BindProperty(SupportsGet = true)]
        public string NoteString { get; set; }
        public SelectList Books { get; set; }
        
        [BindProperty(SupportsGet = true)]
        public string EntryBook { get; set; }

        public async Task OnGetAsync()
        {
            // Use LINQ to get list of books.
            IQueryable<string> bookQuery = from e in _context.Entry
                                            orderby e.Book
                                            select e.Book;

            var entries = from e in _context.Entry
                 select e;
            if (!string.IsNullOrEmpty(SearchString))
            {
                entries = entries.Where(s => s.Chapter.Contains(SearchString));
            }

            if (!string.IsNullOrEmpty(NoteString))
            {
                entries = entries.Where(s => s.Notes.Contains(NoteString));
            }

            if (!string.IsNullOrEmpty(EntryBook))
            {
                entries = entries.Where(x => x.Book == EntryBook);
            }


            Books = new SelectList(await bookQuery.Distinct().ToListAsync());
            Entry = await entries.ToListAsync();
        }
    }
}
