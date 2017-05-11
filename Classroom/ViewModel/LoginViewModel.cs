using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Common.Contract;
using Common.Helper;
using Prism.Commands;

namespace Classroom.ViewModel
{
    public class LoginViewModel
    {
        public LoginViewModel()
        {
            LoginingCommand = new DelegateCommand(Logining);
        }

        private async void Logining()
        {
            await GetClassroom();
        }

        private async Task GetClassroom()
        {
            IBms bmsService = DependencyResolver.Current.GetService<IBms>();
            Common.Model.Classroom classroom = await bmsService.GetClassroomAsync("BOX408D5CAF922E");

            Console.WriteLine(classroom);
        }



        public ICommand LoginingCommand { get; set; }
    }
}
