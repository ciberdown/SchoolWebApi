namespace SchoolWebApi.src.Dto
{
    public class FullAuditDto<T>
    {
        public T Id { get; set; }
        public DateTime CreationTime { get; set; }
        public DateTime? LastModificationTime { get; set; }
    }
}
