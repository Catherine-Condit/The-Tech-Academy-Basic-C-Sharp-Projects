using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity; 

namespace EFCodeFirstStudentApp
{
    internal class StudentContext :DbContext
    {
        public StudentContext() : base("StudentDbConnection") { }

        public DbSet<Student> Students { get; set; }
    }
}
