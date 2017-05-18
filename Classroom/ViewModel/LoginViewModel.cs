using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Common.Contract;
using Common.CustomControl;
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
                    Dialog dd = new Dialog("tes","yes","no");
                    dd.ShowDialog();

                    Common.Model.Classroom classroom = bmsMessage.Data as Common.Model.Classroom;
                    Dialog d = new Dialog(classroom.SchoolRoomImei);
                    d.ShowDialog();
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
