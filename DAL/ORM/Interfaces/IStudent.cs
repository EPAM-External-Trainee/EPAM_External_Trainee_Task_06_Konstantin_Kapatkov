using System;

namespace DAL.ORM.Interfaces
{
    /// <summary>Interface describes student model</summary>
    public interface IStudent
    {
        /// <summary>Id</summary>
        int Id { get; set; }

        /// <summary>Name</summary>
        string Name { get; set; }

        /// <summary>Surname</summary>
        string Surname { get; set; }

        /// <summary>Patronymic</summary>
        string Patronymic { get; set; }

        /// <summary>Gender id</summary>
        int GenderId { get; set; }

        /// <summary>Birthday</summary>
        DateTime Birthday { get; set; }

        /// <summary>Group id</summary>
        int GroupId { get; set; }
    }
}