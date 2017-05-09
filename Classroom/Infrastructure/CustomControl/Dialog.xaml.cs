using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Classroom
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
