namespace SchoolWebApi.src.Dto
{
    public abstract class FullAuditDto<T>
    {
        public T Id { get; set; }
        public DateTime CreationTime { get; set; }
        public DateTime? LastModificationTime { get; set; }
        public bool? isDeleted { get; set; } = false;
    }
}
