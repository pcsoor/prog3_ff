namespace NBA.WPFApp.VM
{
    using CommonServiceLocator;
    using GalaSoft.MvvmLight;
    using GalaSoft.MvvmLight.Command;
    using NBA.WPFApp.BL;
    using NBA.WPFApp.Data;
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Input;

    class MainViewModel : ViewModelBase
    {
        IPlayerLogic logic;

        public ObservableCollection<PlayerUI> Team { get; private set; }
        PlayerUI teamSelected;
        public PlayerUI TeamSelected
        {
            get { return teamSelected; }
            set { Set(ref teamSelected, value); }
        }

        public ICommand AddCmd { get; private set; }

        public ICommand ModCmd { get; private set; }

        public ICommand DelCmd { get; private set; }

        public MainViewModel(IPlayerLogic logic) // Dependency Injection
        {
            this.logic = logic;

            Team = new ObservableCollection<PlayerUI>();

            if (IsInDesignMode)
            {
                PlayerUI p1 = new PlayerUI() { Name = "Test Test", Birth = new DateTime(1984, 12, 20), Height = 206, Weight = 113, Number = 23, Post = "SF/PF", Salary = 37436858 };
                PlayerUI p2 = new PlayerUI() { Name = "Test2 Test2", Birth = new DateTime(1988, 09, 29), Height = 208, Weight = 109, Number = 35, Post = "SF/PF", Salary = 37199000 };
                Team.Add(p1);
                Team.Add(p2);
            }

            AddCmd = new RelayCommand(() => this.logic.AddPlayer(Team));
            //DelCmd = new RelayCommand(() => this.logic.DelPlayer(Team, TeamSelected));
            ModCmd = new RelayCommand(() => this.logic.ModPlayer(TeamSelected));
        }

        public MainViewModel()
            : this(IsInDesignModeStatic ? null : ServiceLocator.Current.GetInstance<IPlayerLogic>())
        {

        }
        // IoC
    }
}
