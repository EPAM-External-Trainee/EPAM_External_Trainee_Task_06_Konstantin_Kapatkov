namespace DAL.ORM.Interfaces.SessionInfo
{
    /// <summary>Interface describes session result model</summary>
    public interface ISessionResult
    {
        /// <summary>Id</summary>
        int Id { get; set; }

        /// <summary>Subject id</summary>
        int SubjectId { get; set; }

        /// <summary>Student id</summary>
        int StudentId { get; set; }

        /// <summary>Assessment</summary>
        string Assessment { get; set; }

        /// <summary>Session id</summary>
        int SessionId { get; set; }
    }
}