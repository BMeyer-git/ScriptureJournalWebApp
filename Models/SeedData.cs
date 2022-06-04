using Microsoft.EntityFrameworkCore;
using ScriptureJournal.Data;

namespace ScriptureJournal.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ScriptureJournalContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<ScriptureJournalContext>>()))
            {
                if (context == null || context.Entry == null)
                {
                    throw new ArgumentNullException("Null RazorPagesMovieContext");
                }

                // Look for any movies.
                if (context.Entry.Any())
                {
                    return;   // DB has been seeded
                }

                context.Entry.AddRange(
                    new Entry
                    {
                        Book = "1 Nephi",
                        Chapter= "2",
                        Verse = "3",
                        Notes = "This is my favorite verse"
                    },

                    new Entry
                    {
                        Book = "2 Nephi",
                        Chapter= "1",
                        Verse = "4",
                        Notes = "This is my 2nd favorite verse"
                    }

                );
                context.SaveChanges();
            }
        }
    }
}