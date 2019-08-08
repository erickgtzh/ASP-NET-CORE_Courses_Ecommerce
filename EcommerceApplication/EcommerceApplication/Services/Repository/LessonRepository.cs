using EcommerceApplication.DataContext;
using EcommerceApplication.Models;
using EcommerceApplication.Services.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceApplication.Services.Repository
{
    public class LessonRepository : ILesson
    {
        private readonly MyContext _db;

        public LessonRepository(MyContext db)
        {
            _db = db;
        }

        public int Count()
        {
            return _db.OrderLine.Count();
        }

        public void Delete(int id)
        {
            var lesson = GetById(id);
            if (lesson != null)
            {
                _db.Lessons.Remove(lesson);
            }
        }

        public IEnumerable<Lesson> GetAll()
        {
            return _db.Lessons.Select(l => l);
        }

        public Lesson GetById(int id)
        {
            return _db.Lessons.FirstOrDefault(l => l.LessonId == id);
        }

        public void Insert(Lesson lesson)
        {
            _db.Lessons.Add(lesson);
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        public void Update(Lesson lesson)
        {
            _db.Lessons.Update(lesson);
        }
    }
}
