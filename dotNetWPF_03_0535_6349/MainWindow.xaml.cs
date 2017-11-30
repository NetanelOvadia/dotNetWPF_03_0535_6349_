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

namespace dotNetWPF_03_0535_6349
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        PrinterUserControl CourrentPrinter;
        Queue<PrinterUserControl> queue;

        public MainWindow()
        {
            InitializeComponent();

            queue = new Queue<PrinterUserControl>();

            foreach (Control item in prinderGrid.Children)
            {
                if (item is PrinterUserControl)
                {
                    PrinterUserControl printer = item as PrinterUserControl;
                    queue.Enqueue(printer);
                }
            }
            CourrentPrinter = queue.Dequeue();
        }

        //זה יפעל כאשר לוחצים על הכפתור
        private void printButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }

    public delegate void EventHandler(object sender, EventArgs args);

    public class PrinerEventArgs : EventArgs
    {
        public readonly bool isCrucial;
        public readonly DateTime dateTime;
        public readonly string errMsg;
        public readonly string printerName;

        public PrinerEventArgs(bool IsCrucial, string ErrMsg, string PrinterName)
        {
            isCrucial = IsCrucial;
            dateTime = DateTime.Today;
            errMsg = ErrMsg;
            printerName = PrinterName;
        }
    }
}
