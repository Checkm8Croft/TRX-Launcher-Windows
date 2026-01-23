using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace TRX_Launcher
{
    public partial class MainWindow : Window
    {
        public TR1X TR1XPage { get; set; }
        public TR2X TR2XPage { get; set; }
        public TR3X TR3XPage { get; set; }

        public MainWindow()
        {
            InitializeComponent();

            // istanzio le pagine
            TR1XPage = new TR1X();
            TR2XPage = new TR2X(); // per ora può essere vuota o placeholder
            TR3XPage = new TR3X(); // idem

            // bind al DataContext
            this.DataContext = this;
        }
    }
}