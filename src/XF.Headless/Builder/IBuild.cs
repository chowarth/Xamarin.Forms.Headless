namespace XF.Headless
{
    public interface IBuild
    {
        /// <summary>
        /// Creates the headless application
        /// </summary>
        /// <returns>An object representing the headless application</returns>
        public IHeadlessApp Build();
    }
}
