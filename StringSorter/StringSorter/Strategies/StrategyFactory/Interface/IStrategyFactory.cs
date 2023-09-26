using StringSorter.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringSorter.Strategies.StrategyFactory.Interface
{
    public interface IStrategyFactory
    {
        //using fatory pattern to create the required sorting strategy, and then Dependency injecting it
        //in controller to further decouple and seperate strategy creation from controller
        //This interface defines a contrat for a factory that creates instances of sorting strategies based
        //on input
        IStringSorter SelectStrategy(string sortMethod);

    }
}
