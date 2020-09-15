namespace DAL.ORM.Interfaces
{
    /// <summary>Interface describes subject model</summary>
    public interface ISubject
    {
        /// <summary>Id</summary>
        int Id { get; set; }

        /// <summary>Name</summary>
        string Name { get; set; }
    }
}