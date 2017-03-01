namespace Common
{
    public interface IProblem
    {
        string Execute();
        int Number { get; }
    }
}
