using BalzorMongoDB.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BalzorMongoDB.IService
{
    public interface IStudentService
    {
        void SaveOrUpdate(Student student);
        Student GetStudent(string studentID);
        List<Student> GetStudents();
        string Delete(string studentID);
    }
}
