using Popryzhenok_Subbotina.Models;
using Popryzhenok_Subbotina.Utils;
using System.Linq;
using System.Windows.Controls;
using Microsoft.Win32;
using System.IO;
using System;
using System.Windows.Media.Imaging;
using System.Windows;

namespace Popryzhenok_Subbotina
{
    /// <summary>
    /// Логика взаимодействия для PageAddAgent.xaml
    /// </summary>
    public partial class PageAddAgent : Page
    {
        public Agent NewAgent { get; set; }
        public PageAddAgent(Agent agent)
        {
            InitializeComponent();
            if (agent != null)
            {
                NewAgent = agent;
                if (NewAgent.Logo != null)
                {
                    photo.Source = new BitmapImage(new Uri(Directory.GetParent(Environment.CurrentDirectory).Parent.FullName + NewAgent.LogoAgent));
                }
            }
            DataContext = NewAgent;
            cbType.ItemsSource = AppData.db.AgentTypes.ToList();
            cbType.SelectedIndex = 0;
        }

        private void buttonLogo_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            string workingDirectory = Environment.CurrentDirectory;
            string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
            OpenFileDialog openFileDialog = new OpenFileDialog()
            {
                DefaultExt = ".png",
                FileName = "picture.png",
                Filter = "Image Files(*.BMP;*.JPG;*.PNG)|*.BMP;*.JPG;*.PNG",
                InitialDirectory = projectDirectory + @"\Popryzhenok_Subbotina\agents\"            
            };
            bool? result = openFileDialog.ShowDialog();

            if (result == true)
            {
                string filename = openFileDialog.FileName;
                photo.Source = new BitmapImage(new Uri(filename));
                tbLogo.Text = Path.GetFileName(filename);
            }
        }

        private void btnSave_Click(object sender, System.Windows.RoutedEventArgs e)
        {

        }

        private void btnCancel_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void btnDelete_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (NewAgent != null)
            {
                if (MessageBox.Show("Вы уверены?", "Подтверждение", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    try
                    {
                        AppData.db.Agents.Remove(NewAgent);
                        AppData.db.SaveChanges();
                        MessageBox.Show("Успешно удалено");
                        NavigationService.GoBack();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.ToString());
                    }
                }
            }
        }
    }
}