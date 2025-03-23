using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;

namespace udemyMAUI1.Models.DB
{
    [Table("Todos")]
    class Todo : BaseModel
    {
        [PrimaryKey("id")] public long Id { get; set; }
        [Column("created_at")] public DateTime CreatedAt { get; set; }
        [Column("name")] public string Name { get; set; }
        [Column("text")] public string Text { get; set; }
        [Column("done")] public bool Done { get; set; }
        [Column("notes")] public string Notes { get; set; }
        [Column("user_id")] public string UserId { get; set; }
    }
}
