using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using DataAccessLayer;

namespace Bl
{
    public class Logic
    {
/*        IRepository<Student> repository = new EntityFrameworkRepository<Student>();*/
        IRepository<Student> repository = new DapperRepository<Student>();

        public void AddStudent(string name, string speciality, string group)
        {
            if (String.IsNullOrWhiteSpace(name) & String.IsNullOrWhiteSpace(speciality) & String.IsNullOrWhiteSpace(group))
                return;

            repository.Create(new Student() { Name = name, Speciality = speciality, Group = group });
        }

        public void DeleteStudent(int id)
        {
            repository.Delete(id);
        }

        public List<string> AllStudents()
        {
            var studentsRepresentations = new List<string>();
            var AllStudents = repository.GetAll().ToList();

            foreach (var student in AllStudents)
            {
                studentsRepresentations.Add($"Id: {student.Id}, Имя: {student.Name}, специализация: {student.Speciality}, группа {student.Group}");
            }

            return studentsRepresentations;
        }

        public Dictionary<string, int> DistributionOfSpecialties()
        {
            var specialtiesDistribution = new Dictionary<string, int>();
            var AllStudents = repository.GetAll().ToList();

            foreach (var student in AllStudents)
            {
                if (specialtiesDistribution.ContainsKey(student.Speciality))
                    specialtiesDistribution[student.Speciality] += 1;

                else
                    specialtiesDistribution[student.Speciality] = 1;
            }

            return specialtiesDistribution;
        }

    }
}
