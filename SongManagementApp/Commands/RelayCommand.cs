using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SongManagementApp.Commands
{
    public class RelayCommand : ICommand
    {
        public event EventHandler? CanExecuteChanged;
        private Action<object> _Excute { get; set; }
        private Predicate<object> _CanExecute { get; set; }
        public RelayCommand(Action<object> ExcuteMethod, Predicate<object> CanExcuteMethod)
        {
            _Excute = ExcuteMethod;
            _CanExecute = CanExcuteMethod;
        }

        public bool CanExecute(object? parameter)
        {
            return _CanExecute(parameter);
        }

        public void Execute(object? parameter)
        {
            _Excute(parameter);
        }
    }
}
