using EcommerceApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceApplication.Services.Infrastructure
{
    public interface ILesson
    {
        IEnumerable<Lesson> GetAll();

        Lesson GetById(int id);

        void Insert(Lesson lesson);

        void Update(Lesson lesson);

        void Delete(int id);

        int Count();

        void Save();
    }
}