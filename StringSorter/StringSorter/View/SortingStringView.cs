using StringSorter.View.Validations;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StringSorter.View
{
    
    //I created an Interface called ISortView, that the form inherits. This is done to decouple the controller
    //from the concrete implementation (SortingStringView) of the view. This ensures more maintainable, flexible
    //and testable code. It adhered to SOLID, partically Dependency Inversion Principle, as controller now depends
    //on abstration rather than concrete implementations
    public partial class SortingStringView : Form, ISortView
    {
        
       //Implementing the IErrorHandlingService from ISortView interface             
        public IErrorHandlingService ErrorHandlingService { get; private set; }
        
       //Ation event that is invoked when button is clicked
        public event Action Sort;

        //Dependency Injectiong IErrorHandlingService in constructor
        public SortingStringView(IErrorHandlingService errorHandlingService)
        {
            InitializeComponent();
            //setting combobox options 
            cmbSortingOption.Items.Add("BubbleSort");
            cmbSortingOption.Items.Add("QuickSort");
            cmbSortingOption.SelectedIndex= 0;

           
            this.ErrorHandlingService = errorHandlingService;
        }


        //Checks if the input received from textbox is valid in terms of not being empty
        private bool IsValid()
        {
            if(!ErrorHandlingService.IsValidInput(txtInputString.Text))
            {
                ErrorHandlingService.DisplayZeroTextBoxError();
                return false;
            }
            return true;
        }

        //Assigning input received from user(txtInput.Text) to UserInput
        public string UserInput() => txtInputString.Text;
        
         //Assigning the algorithm selected by user in combo box to SortingAlgorithmSelected  
        public string SortingAlgorithmSelected() => cmbSortingOption.SelectedItem.ToString();

        //Connecting label where ouput is displayed to Output
        public void Output(string str)
        {
            lbOutputString.Text = str;
        }


        //Button click event , that first checks if input received is not empty
        //If it is valid(There is input), then sort event will be invoked, else
        //a display message will be given
        private void btnSort_Click(object sender, EventArgs e)
        {
            try
            {
                if (IsValid())
                {
                    Sort?.Invoke();    //Event null check using the ? operator
                }
            }
            catch(Exception ex)
            {
                ErrorHandlingService.DisplayError($"An error occured: {ex.Message}");
            }          
            
        }

        public void ShowView()
        {
            Application.Run(this);
        }
    }
}
