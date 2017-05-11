using Classroom.ViewModel;
using Common.CustomControl;
using Common.Helper;

namespace Classroom.View
{
    /// <summary>
    /// LoginView.xaml 的交互逻辑
    /// </summary>
    public partial class LoginView : BaseWindow
    {
        public LoginView()
        {
            InitializeComponent();
            DataContext = DependencyResolver.Current.GetService<LoginViewModel>();
        }
    }
}
