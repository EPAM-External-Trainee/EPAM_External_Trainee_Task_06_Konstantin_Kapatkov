namespace DAL.ORM.Interfaces
{
    /// <summary>Interface describes gender model</summary>
    public interface IGender
    {
        /// <summary>Id</summary>
        int Id { get; set; }

        /// <summary>Gender type name</summary>
        string GenderType { get; set; }
    }
}