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
using System.Windows.Navigation;
using System.Windows.Shapes;
using TestTask.Controls.ViewModelsControls;

namespace TestTask.Controls.ViewControls
{
    /// <summary>
    /// Логика взаимодействия для UserControlPart.xaml
    /// </summary>
    public partial class UserControlPart : UserControl
    {
        public UserControlPart()
        {
            InitializeComponent();
            DataContext = new UserControlCode();
        }
    }
}
