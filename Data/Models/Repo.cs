using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace rewrite_repo.Data.Models
{
    public class Repo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? Amount { get; set; }
        public DateTime DateAdded { get; set; }

    }
}
