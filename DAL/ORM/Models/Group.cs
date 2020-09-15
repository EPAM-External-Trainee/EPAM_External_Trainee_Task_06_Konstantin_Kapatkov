using DAL.ORM.Interfaces;

namespace DAL.ORM.Models
{
    /// <summary>Class describes group model</summary>
    public class Group : IGroup
    {
        /// <summary>Default constructor</summary>
        public Group()
        {
        }

        /// <summary>Creating an instance of <see cref="Group"/> via name</summary>
        /// <param name="name">Group name</param>
        public Group(string name) => Name = name;

        /// <summary>Creating an instance of <see cref="Group"/> via id, name and group specialty id</summary>
        /// <param name="id">Group id</param>
        /// <param name="name">Group name</param>
        public Group(int id, string name) => (Id, Name) = (id, name);

        /// <inheritdoc cref="IGroup.Id"/>
        public int Id { get; set; }

        /// <inheritdoc cref="IGroup.Name"/>
        public string Name { get; set; }
    }
}