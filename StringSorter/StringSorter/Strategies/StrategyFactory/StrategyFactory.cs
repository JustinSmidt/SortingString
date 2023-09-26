using StringSorter.Repositories;
using StringSorter.Repositories.Interface;
using StringSorter.Strategies.StrategyFactory.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringSorter.Strategies.StrategyFactory
{
    public class StrategyFactory : IStrategyFactory
    {
        //the concrete implementation of IStrategyFactory that creates instances of sorting strategies
        //based on a string identifier
        //This makes it easier to add more strategies of needed , by just adding additional implementation for IStringSorter
        //and updating this factory to recognise it
        public IStringSorter SelectStrategy(string sortMethod)
        {
            switch (sortMethod)
            {
                case "BubbleSort":
                    return new BubbleSort();
                case "QuickSort":
                    return new QuickSort();
                default:
                    throw new ArgumentException("Invalid sort method");
            }
        }
    }
}
