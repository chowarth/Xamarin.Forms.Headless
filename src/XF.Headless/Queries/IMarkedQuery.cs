namespace XF.Headless.Queries
{
    public interface IMarkedQuery
    {
        ElementQuery Marked(string identifier);
    }
}
