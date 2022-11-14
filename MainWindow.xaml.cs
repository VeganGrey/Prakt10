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
using System.Collections;
using System.Diagnostics;

namespace Prakt10
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<int> mas = new List<int>();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Добавить(object sender, RoutedEventArgs e)
        {
            try
            {
                Int32.TryParse(Chisl.Text, out int chisl);
                if (chisl < -100 || chisl > 100) throw new ArgumentException("Не попадает в интервал");
                foreach (int i in mas) if (chisl == i)
                {
                        Chisl.Text = null;
                        throw new ArgumentException("Повторяющееся число");
                }
                mas.Add(chisl);
                listBox.Items.Add(chisl);
                Chisl.Text = null;
                Chisl.Focus();
            }
            catch
            {
                MessageBox.Show("Число не подходит");
            }
        }

        private void Расчет(object sender, RoutedEventArgs e)
        {
            string final = "";
            int kolPolozhit = 0;
            int kolOtric = 0;
            foreach (int i in mas)
                if (i % 2 == 0) kolPolozhit++;
                else kolOtric++;
            final = $"Четных {kolPolozhit}\nНечетных {kolOtric}";
            Itog.Text = final;
        }

        private void Удалить(object sender, RoutedEventArgs e)
        {
            int indx = listBox.SelectedIndex;
            listBox.Items.RemoveAt(indx);
            mas.RemoveAt(indx);
        }

        private void Spravka(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Калитин С.А. ИСП-31\nВариант 13 Задание:\nДан массив в диапазоне [-100;100] найти количество четных и нечетных");
        }

        private void Support(object sender, RoutedEventArgs e)
        {
            string target = "https://t.me/Doctorfleks";
            System.Diagnostics.Process.Start(target);
        }

        private void Quit(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Clear(object sender, RoutedEventArgs e)
        {
            mas.Clear();
            listBox.Items.Clear();
            Itog.Clear();
        }
    }
}
