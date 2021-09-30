using Popryzhenok_Subbotina.Models;
using Popryzhenok_Subbotina.Utils;
using System.Linq;
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
            cbType.ItemsSource = AppData.db.AgentTypes.ToList();
            cbType.SelectedIndex = 0;
        }
    }
}