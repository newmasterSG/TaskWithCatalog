using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TaskGeeksForLess.Models;

namespace TaskGeeksForLess.Data
{
    public class TaskGeeksForLessContext : DbContext
    {
        public TaskGeeksForLessContext (DbContextOptions<TaskGeeksForLessContext> options)
            : base(options)
        {
        }

        public DbSet<TaskGeeksForLess.Models.Folder> Folders { get; set; } = default!;
    }
}
