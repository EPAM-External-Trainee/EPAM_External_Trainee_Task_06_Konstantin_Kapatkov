namespace DAL.ORM.Interfaces.SessionInfo
{
    /// <summary>Interface describes session model</summary>
    public interface ISession
    {
        /// <summary>Id</summary>
        int Id { get; set; }

        /// <summary>Name</summary>
        string Name { get; set; }

        /// <summary>AcademicYear</summary>
        string AcademicYear { get; set; }
    }
}
