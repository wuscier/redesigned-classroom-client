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
            LoginingCommand = DelegateCommand.FromAsyncHandler(LoginingAsync);
        }

        private async Task LoginingAsync()
        {

            await GetClassroom();
        }

        private async Task GetClassroom()
        {
            try
            {
                IBms bmsService = DependencyResolver.Current.GetService<IBms>();
                BmsMessage bmsMessage = await bmsService.GetClassroomAsync("BOX408D5CAF922E");

                if (bmsMessage.HasError)
                {
                    //
                }
                else
                {
                    Console.WriteLine(bmsMessage.Data);
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }



        public ICommand LoginingCommand { get; set; }
    }
}
