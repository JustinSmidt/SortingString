using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringSorter.View.Validations
{
    public interface IErrorHandlingService
    {
        bool IsValidInput(string input);

        void DisplayZeroTextBoxError();

        void DisplayInvalidInputError();

        void DisplayError(string message);
    }
}
