using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringSorter.Controller.Validations
{
    public class Validations : IValidations
    {
        //Checks if given input is a valid string in terms of only containing letters        
        public bool isValidString(string input)
        {
            //Ensures and only contains letters
            //I did this in controller as i believe it is a business rule, seperating it from
            //UI validations
            if(!input.All(char.IsLetter) )
            {
                return false;
            }
            return true;
        }
    }
}
