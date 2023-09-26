using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StringSorter.View.Validations
{
    public class ErrorHandlingService :IErrorHandlingService
    {
        //encapsulating errorHandling in its own class, promoting Single Responsibility Principle, and can also 
        //be reused

        //Checks if given input is a valid in terms of not being empty 
        public bool IsValidInput(string input)
        {
            //returns false if input is null or empty          
           if(string.IsNullOrEmpty(input))
            {
                return false;
                
            }
           //if valid, returns true
            return true;
        }

        //Displays message if textbox is empty
        public void DisplayZeroTextBoxError()
        {
            MessageBox.Show("Please provide text", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        //Displays message if input is not a valid string letter, called in controller
        public void DisplayInvalidInputError()
        {
            MessageBox.Show("Please provide valid string letters only, avoid empty spaces", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        //Displays exception message
        public void DisplayError(string message)
        {
            MessageBox.Show(message,"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
            
    }
}
