using StringSorter.Controller;
using StringSorter.Controller.Validations;
using StringSorter.Model;
using StringSorter.Strategies.StrategyFactory;
using StringSorter.Strategies.StrategyFactory.Interface;
using StringSorter.View;
using StringSorter.View.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StringSorter
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
           
            //Dependency Injection operations

            StringSortingModel model = new StringSortingModel();

            IErrorHandlingService errorHandlingService = new ErrorHandlingService();
            ISortView view = new SortingStringView(errorHandlingService);

            IStrategyFactory strategyFactory = new StrategyFactory();
            IValidations validations = new Validations();

            SortingAlgorithmController controller = new SortingAlgorithmController(model, view, strategyFactory, validations);

            controller.Run();
        }
    }
}
