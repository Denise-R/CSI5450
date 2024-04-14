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

        public int GetStudentCount(Student student)
        {
            FilterDefinition<Student> filter = this.GetFilter(student);
            return _studentTable.Find(filter).ToList().Count();
        }

        public List<Student> GetStudents(int pageNumber, int take, Student student)
        {
			FilterDefinition<Student> filter = this.GetFilter(student);
            var students = _studentTable.Find(filter).Skip(pageNumber > 0 ?((pageNumber - 1)*take):0).Limit(take).ToList();
            return students;
		}

		private FilterDefinition<Student> GetFilter(Student student)
        {
            FilterDefinition<Student> filter = FilterDefinition<Student>.Empty;
            if (!string.IsNullOrEmpty(student.Name))
            {
                filter = Builders<Student>.Filter.Regex("Name", new MongoDB.Bson.BsonRegularExpression(student.Name));
            }
            if (!string.IsNullOrEmpty(student.Roll))
            {
				filter = Builders<Student>.Filter.Regex("Roll", new MongoDB.Bson.BsonRegularExpression(student.Roll));

			}
            if (student.AgeFilterType > 0)
            {
                if (student.AgeFilterType == 1)//Age Between
                {
                    filter &= Builders<Student>.Filter.Gte("Age", student.FromAge);
                    filter &= Builders<Student>.Filter.Lte("Age", student.ToAge);
				}
				else if (student.AgeFilterType == 2)//Age less than
				{
					filter &= Builders<Student>.Filter.Lt("Age", student.FromAge);
				}
				else if (student.AgeFilterType == 3)//Age greater than
				{
					filter &= Builders<Student>.Filter.Gt("Age", student.FromAge);
				}
				else if (student.AgeFilterType == 4)//Age equal to
				{
					filter &= Builders<Student>.Filter.Eq("Age", student.FromAge);
				}
			}
            return filter;
		}

        public void Save(Student student)
        {
            var students = new List<Student>();
            for (int i=1; i<=99; i++)
            {
                students.Add(new Student()
                {
                    Name = "Stu" + i,
                    Roll = "10" + i,
                    Age = this.GetRandomAge()
                });
            }
			_studentTable.InsertMany(students);
		}

        public int GetRandomAge()
        {
            var ages = new[] { 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30 };
            Random random = new Random();
            return ages[random.Next(ages.Length)];
        }
        //public string Delete(string studentID)
        //{
        //    _studentTable.DeleteOne(x => x.Id == studentID);
        //    return "Deleted";
        //}

        //public Student GetStudent(string studentID)
        //{
        //    return _studentTable.Find(x => x.Id == studentID).FirstOrDefault();
        //}

        //public List<Student> GetStudents()
        //{
        //    return _studentTable.Find(FilterDefinition<Student>.Empty).ToList();
        //}

        //public void SaveOrUpdate(Student student)
        //{
        //    var studentObj = _studentTable.Find(x => x.Id == student.Id).FirstOrDefault();
        //    if (studentObj == null)
        //    {
        //        _studentTable.InsertOne(student);
        //    }
        //    else
        //    {
        //        _studentTable.ReplaceOne(x => x.Id == student.Id, student);
        //    }
        //}
    }
}
