using System;
using Bl;

namespace sem3lab1
{
    class Program
    {
        static public Logic logic = new Logic();

        static public void AddStudent()
        {
            Console.WriteLine();

            Console.WriteLine("Имя студента:");
            Console.WriteLine();
            var createName = Console.ReadLine();
            Console.WriteLine();

            Console.WriteLine("Специальность студента:");
            Console.WriteLine();
            var createSpeciality = Console.ReadLine();
            Console.WriteLine();

            Console.WriteLine("Группа студента:");
            Console.WriteLine();
            var createGroup = Console.ReadLine();
            Console.WriteLine();

            logic.AddStudent(createName, createSpeciality, createGroup);
        }

        static public void DeleteStudent()
        {
            Console.WriteLine();
            Console.WriteLine("Индекс для удаления:");
            try
            {
                var id = int.Parse((Console.ReadLine()));

                logic.DeleteStudent(id);
            }
            catch (Exception e)
            {
                Console.WriteLine("Индекс должен быть целым числом!");
            }
        }

        static public void ListStudents()
        {
            Console.WriteLine();
            Console.WriteLine("Список студентов:");

            foreach (var studentRepr in logic.AllStudents())
            {
                Console.WriteLine();
                Console.WriteLine(studentRepr);
            }

            Console.WriteLine();
            Console.ReadKey();
        }

        static public void MakeStudentsGraph()
        {
            Console.WriteLine();
            var distributionOfSpecialties = logic.DistributionOfSpecialties();

            foreach (var key in distributionOfSpecialties.Keys)
            {
                Console.Write(key);

                for (int i = 0; i < distributionOfSpecialties[key]; i++)
                {
                    Console.Write(" []");
                }

                Console.WriteLine();
            }

            Console.ReadKey();
        }

        static void Main(string[] args)
        {
            var stop = false;

            while (stop != true)
            {
                Console.Clear();
                Console.WriteLine();
                Console.WriteLine("0 - выйти");
                Console.WriteLine("1 - добавить студента");
                Console.WriteLine("2 - удалить студента");
                Console.WriteLine("3 - вывести список студентов");
                Console.WriteLine("4 - график специализаций");
                Console.WriteLine();

                var command = Console.ReadLine();

                switch (command)
                {
                    case "0":
                        stop = true;
                        break;

                    case "1":
                        AddStudent();
                        break;

                    case "2":
                        DeleteStudent();
                        break;

                    case "3":
                        ListStudents();
                        break;

                    case "4":
                        MakeStudentsGraph();
                        break;

                    default:
                        Console.WriteLine();
                        Console.WriteLine("Такой команды нет!");
                        break;

                }
            }
        }
    }
}
