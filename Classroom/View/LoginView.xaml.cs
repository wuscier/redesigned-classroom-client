using Classroom.ViewModel;
using Common.CustomControl;
using Common.Helper;

namespace Classroom.View
{
    /// <summary>
    /// LoginView.xaml 的交互逻辑
    /// </summary>
    public partial class LoginView
    {
        public LoginView()
        {
            InitializeComponent();
            DataContext = new LoginViewModel();
        }
    }
}
