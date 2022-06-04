using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace ScriptureJournal.Models
{
    public class Entry
    {
        public int ID { get; set; }

        [Required]
        public string Book { get; set; } = string.Empty;

        [Required]
        public string Chapter { get; set; } = string.Empty;

        [Required]
        public string Verse { get; set; } = string.Empty;
        public string Notes { get; set; } = string.Empty;
    }
}