using Microsoft.EntityFrameworkCore;
using SchoolProject.Data.Entities;
using SchoolProject.Infrastructure.Abstracts;
using SchoolProject.Service.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Service.Implementations
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;

        public StudentService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public async Task<string> AddAsync(Student student)
        {
            var studentResult = _studentRepository.GetTableNoTracking()
                                                  .FirstOrDefault(x => x.Name == student.Name);
            if (studentResult != null)
                return "Exist";

            await _studentRepository.AddAsync(student);
            return "success";

        }

        public async Task<Student> GetStudentByIDAsync(int id)
        {
            //var student = await _studentRepository.GetByIdAsync(id);
            var student = _studentRepository.GetTableNoTracking()
                                            .Include(x => x.Department)
                                            .FirstOrDefault(x => x.StudID.Equals(id));
            return student;
        }

        public async Task<List<Student>> GetStudentsListAsync()
        {
            return await _studentRepository.GetStudentsListAsync();
        }
    }
}
