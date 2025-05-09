namespace SetecBackendCSharp.Data.DTO.Base
{
    public class CursorPagedDTO<T>
    {
        public IEnumerable<T> Data { get; set; } = [];
        public long? LastIdReturned { get; set; }
        public int PageSize { get; set; }
    }
}
