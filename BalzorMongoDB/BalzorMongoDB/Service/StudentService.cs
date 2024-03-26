using BalzorMongoDB.Data;
using BalzorMongoDB.IService;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BalzorMongoDB.Service
{
    public class StudentService: IStudentService
    {
        private MongoClient _mongoClient = null;
        private IMongoDatabase _database = null;
        private IMongoCollection<Student> _studentTable = null;
        public StudentService()
        {
            _mongoClient = new MongoClient("mongodb://127.0.0.1:27017/");
            _database = _mongoClient.GetDatabase("SchoolDB");
            _studentTable = _database.GetCollection<Student>("Students");
        }
        public string Delete(string studentID)
        {
            _studentTable.DeleteOne(x => x.Id == studentID);
            return "Deleted";
        }

        public Student GetStudent(string studentID)
        {
            return _studentTable.Find(x => x.Id == studentID).FirstOrDefault();
        }

        public List<Student> GetStudents()
        {
            return _studentTable.Find(FilterDefinition<Student>.Empty).ToList();
        }

        public void SaveOrUpdate(Student student)
        {
            var studentObj = _studentTable.Find(x => x.Id == student.Id).FirstOrDefault();
            if (studentObj == null)
            {
                _studentTable.InsertOne(student);
            }
            else
            {
                _studentTable.ReplaceOne(x => x.Id == student.Id, student);
            }
        }
    }
}
