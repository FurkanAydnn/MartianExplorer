using MartianExplorer.Controller;
using MartianExplorer.Helpers;
using System;
using System.Text.RegularExpressions;

namespace MartianExplorer
{
    public class Program
    {
        static void Main(string[] args)
        {
            ConfigurationHelper.SetInitialConfiguration();
            MartianExplorerController mec = new MartianExplorerController();

            mec.GetInitialParameters();
            mec.ExploreMars();
        }
    }
}
