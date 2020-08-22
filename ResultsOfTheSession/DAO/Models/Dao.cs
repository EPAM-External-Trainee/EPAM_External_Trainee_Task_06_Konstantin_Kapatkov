using ResultsOfTheSession.DAO.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResultsOfTheSession.DAO.Models
{
    public class Dao<T> : IDao<T>
    {
        private string _connectionString;

        public Dao(string connectionString) => _connectionString = connectionString;

        public void Create(T data)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public T Read(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> ReadAll()
        {
            throw new NotImplementedException();
        }

        public void Update(T data)
        {
            throw new NotImplementedException();
        }
    }
}