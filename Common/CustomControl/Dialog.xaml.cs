using System.Windows;

namespace Common.CustomControl
{
    /// <summary>
    /// Dialog.xaml 的交互逻辑
    /// </summary>
    public partial class Dialog
    {
        public Dialog()
        {
            InitializeComponent();
        }

        public Dialog(string message, string positiveMsg, string negativeMsg) : this()
        {
            MessageTextBlock.Text = message;
            YesButton.Content = positiveMsg;
            NoButton.Content = negativeMsg;

            YesButton.Focus();
        }

        private void ChoiceButton_OnClick(object sender, RoutedEventArgs e)
        {
            FrameworkElement feSource = e.Source as FrameworkElement;
            switch (feSource?.Name)
            {
                case "YesButton":
                    DialogResult = true;
                    break;
                case "NoButton":
                    DialogResult = false;
                    break;
            }
            e.Handled = true;
        }
    }
}
