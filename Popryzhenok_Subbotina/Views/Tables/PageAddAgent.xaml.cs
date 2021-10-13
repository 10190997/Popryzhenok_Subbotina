using Popryzhenok_Subbotina.Models;
using Popryzhenok_Subbotina.Utils;
using System.Linq;
using System.Windows.Controls;
using Microsoft.Win32;
using System.IO;
using System;
using System.Windows.Media.Imaging;

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
            NewAgent = agent;
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
    }
}