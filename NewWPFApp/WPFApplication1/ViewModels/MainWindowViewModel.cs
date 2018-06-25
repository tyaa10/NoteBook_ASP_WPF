namespace WPFApplication1.ViewModels
{
    using Catel.Data;
    using Catel.MVVM;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Net;
    using System.Threading.Tasks;
    using WPFApplication1.Models;

    public class MainWindowViewModel : ViewModelBase
    {

        public MainWindowViewModel()
        {
            //States = new ObservableCollection<State> {
            //    new State{Id = 1, Name = "created"}
            //    , new State{Id = 1, Name = "fullfilled"}
            //};

            States = new ObservableCollection<State> { };


            //RunAsync2().Wait();
            

            //foreach (var item in ApiConnector.result.PagesData)
            //{
            //    Console.WriteLine($"id = {item.Id}; name = {item.Name}");
            //}

            // TODO: Move code below to constructor
            AddState = new Command(OnaddStateExecute);
            // TODO: Move code above to constructor
            DelState = new Command(OndelStateExecute);
            // TODO: Move code below to constructor
            RefreshStates = new Command(OnRefreshStatesExecute);
            // TODO: Move code above to constructor
            ApiConnector.PostData(States, "action=states","");
            /*var result = ApiConnector.PostData();
            Console.WriteLine(result.Result);
            foreach (var item in result.Result.PagesData)
            {
                States.Add(item);
                Console.WriteLine($"id = {item.Id}; name = {item.Name}");
            }*/
        }

        public override string Title { get { return "WPFApplication1"; } }

        [Model]
        public State StateObject
        {
            get { return GetValue<State>(StateObjectProperty); }
            set { SetValue(StateObjectProperty, value); }
        }
        public static readonly PropertyData StateObjectProperty =
            RegisterProperty("StateObject", typeof(State));


        [ViewModelToModel(nameof(StateObject), "id")]
        public int Id
        {
            get { return GetValue<int>(idProperty); }
            set { SetValue(idProperty, value); }
        }

        public static readonly PropertyData idProperty =
            RegisterProperty(nameof(Id), typeof(int));


        [ViewModelToModel(nameof(StateObject), "name")]
        public string Name
        {
            get { return GetValue<string>(nameProperty); }
            set { SetValue(nameProperty, value); }
        }

        public static readonly PropertyData nameProperty =
            RegisterProperty(nameof(Name), typeof(string));

        public ObservableCollection<State> States
        {
            get { return GetValue<ObservableCollection<State>>(statesProperty); }
            set { SetValue(statesProperty, value); }
        }

        public static readonly PropertyData statesProperty = RegisterProperty(nameof(States), typeof(ObservableCollection<State>), null);

        // TODO: Register models with the vmpropmodel codesnippet
        // TODO: Register view model properties with the vmprop or vmpropviewmodeltomodel codesnippets
        // TODO: Register commands with the vmcommand or vmcommandwithcanexecute codesnippets
        public State SelState
        {
            get { return GetValue<State>(SelStateProperty); }
            set { SetValue(SelStateProperty, value); }
        }

        public static readonly PropertyData SelStateProperty = RegisterProperty(nameof(SelState), typeof(State), null);

        public Command AddState { get; private set; }

        private void OnaddStateExecute()
        {
            //States.Add(new State() { Id = Id, Name = Name });
            Console.WriteLine(Name);
            States.Clear();
            ApiConnector.PostData(States, "action=state-add&name=" + Name,"");
            //ApiConnector.PostData(States, "action=states");
        }


        public Command DelState { get; private set; }

        private void OndelStateExecute()
        {
            // TODO: Handle command logic here
            // States.Remove(SelState);
            
            try
            {
                //ApiConnector.PostData(States, "action=state-del&states=" + SelState.Id, "{states:[\"" + SelState.Id + "\"]}");
                int deletedStateId = SelState.Id;
                ApiConnector.PostData(States, "action=state-del&states=" + deletedStateId, "{}");
                States.Clear();
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
            //States.Clear();
        }


        public Command RefreshStates { get; private set; }

        

        private void OnRefreshStatesExecute()
        {
            try
            {
                Console.WriteLine("test");
                //ApiConnector.PostData();
                //Console.WriteLine(result);
                //?
                //result.
                /*foreach (var item in result.Result.PagesData)
                {
                    States.Add(item);
                    Console.WriteLine($"id = {item.Id}; name = {item.Name}");
                }*/
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        protected override async Task InitializeAsync()
        {
            await base.InitializeAsync();


        }

        protected override async Task CloseAsync()
        {
            // TODO: unsubscribe from events here

            await base.CloseAsync();
        }

        /*static async Task RunAsync()
        {
            try
            {
                // var result = await ApiConnector.GetStatesAsync("states");
                
                //Console.WriteLine("done");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }*/

        async Task RunAsync2()
        {
            /*try
            {
                Console.WriteLine("test");
                var result = await ApiConnector.PostData();
                Console.WriteLine(result);
                foreach (var item in result.PagesData)
                {
                    States.Add(item);
                    Console.WriteLine($"id = {item.Id}; name = {item.Name}");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }*/
        }
    }
}
