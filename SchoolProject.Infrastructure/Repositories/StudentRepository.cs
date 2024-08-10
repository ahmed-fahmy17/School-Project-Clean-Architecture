using Microsoft.EntityFrameworkCore;
using SchoolProject.Data.Entities;
using SchoolProject.Infrastructure.Abstracts;
using SchoolProject.Infrastructure.Data;
using SchoolProject.Infrastructure.InfrastructureBases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Infrastructure.Repositories
{
    public class StudentRepository : GenericRepositoryAsync<Student>,IStudentRepository
    {
        //private readonly ApplicationDBContext _dbContext;

        public StudentRepository(ApplicationDBContext dBContext):base(dBContext)
        {
            //_dbContext = dBContext;
        }
        public async Task<List<Student>> GetStudentsListAsync()
        {
            return await _dbContext.students.Include(x => x.Department).ToListAsync();
        }
    }
}
