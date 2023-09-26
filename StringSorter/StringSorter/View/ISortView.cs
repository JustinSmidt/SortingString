using StringSorter.View.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;

namespace StringSorter.View
{
    //This is the abstraction, and SortingStringView is its concrete implementation
    public interface ISortView
    {
        //Getting userInput from textbox
        string UserInput();

        //Getting selected algorithm from combobox
        string SortingAlgorithmSelected();

        //linking this to output label
        void Output(string str);

        //action method invoked when button clicked
        event Action Sort;


        //By adding this, I give access of IErrorHandlingService methods to controller,
        //so that I can call Display methods in controller
        //keeping components decoupled, as MessageBox display methods should remain a UI/View method.
        //Controller gets access to these methods via dependency injecting the ISortView abstraction into
        //the controllers constructor. 
        IErrorHandlingService ErrorHandlingService { get; }

        void ShowView();
    }
}
