
using StringSorter.Controller.Validations;
using StringSorter.Model;
using StringSorter.Repositories;
using StringSorter.Repositories.Interface;
using StringSorter.Strategies.StrategyFactory.Interface;
using StringSorter.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace StringSorter.Controller
{
    public class SortingAlgorithmController
    {
        private readonly StringSortingModel model;
        private readonly ISortView view;
        private readonly IStrategyFactory strategyFactory;
        private readonly IValidations stringValidation;

        //As the controller facilitates the interaction between model and view, I dependency injected its
        //relevant dependencies to facilitate this interaction in a decoupled way
        public SortingAlgorithmController(StringSortingModel model, ISortView view, IStrategyFactory strategyFactory, IValidations stringValidation) 
        {
            this.model = model;
            this.view = view;
            this.strategyFactory = strategyFactory;
            this.stringValidation = stringValidation;

            //when view raises Sort event, call SortingRequested. 
            //Observer patter - controller(observer) is whatching for changes or actions on the view(subject)
            //without the two being directly coupled
            view.Sort += SortingRequested;
        }

        //event handler
        private void SortingRequested()
        {
            
            //first checking if input is valid letters
            if (!stringValidation.isValidString(view.UserInput()))
            {
                view.ErrorHandlingService.DisplayInvalidInputError();              
            }
            else
            {
                //setting user input from view and storing it in model. view.UserInput retrieves input
                //model.UserInput receives it
                model.UserInput = view.UserInput();

                //fetches selected sorting algorithm from combobox. The strategyFactory.SelectedStrategy
                //returns appropriate sorting strategy based on selected algorithm
                var algorithm = strategyFactory.SelectStrategy(view.SortingAlgorithmSelected());

                //user input is sorted, and then stored into model
                model.SortedOutput = algorithm.SortString(model.UserInput);

                //sorted string from model is passed to view to be dispplayed to user
                view.Output(model.SortedOutput);
            }
                           
           
        }

        public void Run()
        {
            view.ShowView();
        }

    }
}
