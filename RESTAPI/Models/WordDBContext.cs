using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RESTAPI.Models
{
    public class WordDBContext :DbContext
    {
        public DbSet<Word> Words { get; set; }

        public WordDBContext(DbContextOptions<WordDBContext> options)
            : base(options)
        {

        }
    }
}
