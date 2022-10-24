using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Model;

namespace DataAccessLayer
{
    public class DapperRepository<T>: IRepository<T> where T: class, IDomainObject
    {
        static string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Иван\source\repos\Semester3Laboratory1\DataAccessLayer\Database1.mdf;Integrated Security=True";
        IDbConnection db = new SqlConnection(connectionString);
        public IEnumerable<T> GetAll()
        {
            return db.Query<T>("select * from Students").ToList();
        }
        public void Create(T t)
        {
            var sqlQuery = "insert into Students (Name, [Group], Speciality) values(@Name, @Group, @Speciality); select cast(scope_identity() as int)";
            int id = db.Query<int>(sqlQuery, t).FirstOrDefault();
            t.Id = id;
        }
        public void Save()
        {

        }

        public void Delete(int id)
        {
            var sqlQuery = "delete from Students where Id = @id";
            db.Execute(sqlQuery, new { id });
        }
        public T GetById(int id)
        {
            return db.Query<T>("select * from Students where Id = @id", new { id }).FirstOrDefault();
        }
    }
}
