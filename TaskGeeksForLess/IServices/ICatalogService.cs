namespace TaskGeeksForLess.IServices
{
    public interface ICatalogService
    {
        public void PrintDirectoryTree(string directory, int lvl, string[] excludedFolders = null, string lvlSeperator = "");
    }
}
