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
/// <summary>
/// /
/// </summary>
namespace dotNetWPF_03_0535_6349
{
    /// <summary>
    /// Interaction logic for PrinterUserControl.xaml
    /// </summary>
    public partial class PrinterUserControl : UserControl
    {
        static int printerId=1;
        const double MAX_INK = 100, MIN_ADD_INK=10.0, MAX_PRINT_INK=50.0;
        const int MAX_PAGES = 400, MIN_ADD_PAGES = 40, MAX_PRINT_PAGES = 200;

        protected string printerName;
        public string PrinterName { get; set; }

        protected double inkCount;
        public double InkCount { get; set; }

        protected int pageCount;
        public int PageCount { get; set; }

        static Random rand = new Random();

        public PrinterUserControl()
        {
            InitializeComponent();
            printerNameLabel.Content = "Printer " + printerId++;
        }

        //returns the percent for ink
        public double getPercent(double current)
        {
            return (MAX_PRINT_INK / current) * 100;
        }
        //returns the percent for pages
        public double getPercent(int current)
        {
            return (MAX_PRINT_PAGES / current) * 100;
        }

        public void printing()
        {
            //tells me how much pages and ink i will use now in this printing.
            double currentPrintIntRequest   = rand.NextDouble() * (MAX_PRINT_INK - MIN_ADD_INK) + MIN_ADD_INK;
            int currentPrintPageRequest = rand.Next(MIN_ADD_PAGES, MAX_PRINT_PAGES);


            //there is enoght ink?
            if ((inkCount - currentPrintIntRequest)>=0)
            {
                inkCount -= currentPrintIntRequest;
            }
            else //i don't have enoght ink
            {
                //send event.
                addRandomInk();
            }

            double currentPercentInk = getPercent(inkCount);
            //double currentPercentPage = getPercent(pageCount);

            if (currentPercentInk <0.15 && currentPercentInk >=0.10)
            {
                printerNameLabel.Foreground = Brushes.Yellow;
                //send event
            }
            else if (currentPercentInk < 0.10 && currentPercentInk >= 0.01)
            {
                printerNameLabel.Foreground = Brushes.Orange;
                //send event
            }
            else if (currentPercentInk < 0.01)
            {
                printerNameLabel.Foreground = Brushes.Red;
                //send crucial event
            }

            if (pageCount == 0)
            {
                printerNameLabel.Foreground = Brushes.Red;
                //send crucial event
            }
        }

        public void addRandomInk() //this func adds random amount of ink.
        {
            inkCount += rand.NextDouble() * (MAX_PRINT_INK - MIN_ADD_INK) + MIN_ADD_INK;
        }
        
        public void addRadomPage() //this func adds random amount of pages.
        {
            pageCount += rand.Next(MIN_ADD_PAGES, MAX_PRINT_PAGES);
        }
    }
}
