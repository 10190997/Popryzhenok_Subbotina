using Popryzhenok_Subbotina.Models;
using System.Windows.Controls;

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
        }
    }
}