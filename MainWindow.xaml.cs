using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Homework_WpfApp5._2
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (drawing.EditingMode != InkCanvasEditingMode.Ink)
            {
                drawing.EditingMode = InkCanvasEditingMode.Ink;
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (drawing.EditingMode != InkCanvasEditingMode.EraseByPoint)
            {
                drawing.EditingMode = InkCanvasEditingMode.EraseByPoint;
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            drawing.DefaultDrawingAttributes.Color = Colors.White;
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            drawing.DefaultDrawingAttributes.Color = Colors.Black;
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            drawing.DefaultDrawingAttributes.Color = Colors.Red;
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            drawing.DefaultDrawingAttributes.Color = Colors.Orange;
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            drawing.DefaultDrawingAttributes.Color = Colors.Yellow;
        }

        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            drawing.DefaultDrawingAttributes.Color = Colors.Green;
        }

        private void Button_Click_8(object sender, RoutedEventArgs e)
        {
            drawing.DefaultDrawingAttributes.Color = Colors.Blue;
        }

        private void Button_Click_9(object sender, RoutedEventArgs e)
        {
            drawing.DefaultDrawingAttributes.Color = Colors.DarkBlue;
        }

        private void Button_Click_10(object sender, RoutedEventArgs e)
        {
            drawing.DefaultDrawingAttributes.Color = Colors.Purple;
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            double lineWidth = Convert.ToDouble(((sender as ComboBox).SelectedItem as TextBlock).Text);
            if (drawing!=null)
            {
                drawing.DefaultDrawingAttributes.Width = lineWidth;
                drawing.DefaultDrawingAttributes.Height = lineWidth;
            }
        }

        private void Button_Click_11(object sender, RoutedEventArgs e)
        {
            drawing.Strokes.Clear();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "InkCanvasFormat (*.sandy)|*.sandy|Все файлы (*.*)|(*.*)";
            if (openFile.ShowDialog() == true)
            {
                var fs = new FileStream(openFile.FileName, FileMode.OpenOrCreate);
                StrokeCollection strokes = new StrokeCollection(fs);
                drawing.Strokes = strokes;
            }
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.Filter = "InkCanvasFormat (*.sandy)|*.sandy|Все файлы (*.*)|(*.*)";
            if (saveFile.ShowDialog() == true)
            {
                FileStream fs = File.Open(saveFile.FileName, FileMode.OpenOrCreate);
                drawing.Strokes.Save(fs);
                fs.Close();
            }
        }

        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
