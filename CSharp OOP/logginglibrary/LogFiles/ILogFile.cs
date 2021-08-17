namespace logginglibrary.LogFiles
{
    public interface ILogFile
    {
        long Size { get; }

        void Write(string message);
    }
}
