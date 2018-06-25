namespace WPFApplication1.ViewModels
{
    using Catel.Data;
    using Catel.MVVM;
    using System.Collections.ObjectModel;
    using System.Threading.Tasks;
    using WPFApplication1.Models;

    public class MainWindowViewModel : ViewModelBase
    {
        public MainWindowViewModel()
        {
            States = new ObservableCollection<State> {
                new State{id = 1, name = "created"}
                , new State{id = 1, name = "fullfilled"}
            };

            // TODO: Move code below to constructor
            addState = new Command(OnaddStateExecute);
            // TODO: Move code above to constructor
            delState = new Command(OndelStateExecute);
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
        public int id
        {
            get { return GetValue<int>(idProperty); }
            set { SetValue(idProperty, value); }
        }

        public static readonly PropertyData idProperty =
            RegisterProperty(nameof(id), typeof(int));


        [ViewModelToModel(nameof(StateObject), "name")]
        public string name
        {
            get { return GetValue<string>(nameProperty); }
            set { SetValue(nameProperty, value); }
        }

        public static readonly PropertyData nameProperty =
            RegisterProperty(nameof(name), typeof(string));

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

        public Command addState { get; private set; }

        private void OnaddStateExecute()
        {
            States.Add(new State() {id = id, name = name });
        }


        public Command delState { get; private set; }

        private void OndelStateExecute()
        {
            // TODO: Handle command logic here
            States.Remove(SelState);
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
    }
}
