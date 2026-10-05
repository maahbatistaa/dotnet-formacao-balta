using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Paymentcontext.Domain.Entities;

namespace Paymentcontext.Domain.Queries
{
    public static class StudentQuerie
    {
        public static Expression<Func<Student, bool>> GetStudentInfo(string document)
        {
            return x => x.Document.Number == document;
        }
    }
}