using MartianExplorer.Controller;
using MartianExplorer.Helpers;

namespace MartianExplorer
{
    public class Program
    {
        static void Main(string[] args)
        {
            int explorerCount = 2;
            ConfigurationHelper.SetInitialConfiguration();
            MartianExplorerController mec = new MartianExplorerController();

            mec.GetInitialParameters();
            mec.ExploreMars(explorerCount);
        }
    }
}