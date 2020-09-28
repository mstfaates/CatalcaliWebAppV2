

namespace CatalcaliWebAppV2.Repository
{
    public class Result<T>
    {
        public string Message { get; set; }
        public bool IsCompleted { get; set; }
        public T ProccesResult { get; set; }
    }
}
