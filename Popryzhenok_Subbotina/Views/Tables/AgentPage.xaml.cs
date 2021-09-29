using Popryzhenok_Subbotina.Models;
using Popryzhenok_Subbotina.Utils;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Popryzhenok_Subbotina.Views.Tables
{
    /// <summary>
    /// Interaction logic for AgentPage.xaml
    /// </summary>
    public partial class AgentPage : Page
    {
        /// <summary>
        /// Инициализация компонентов
        /// </summary>
        public AgentPage()
        {
            InitializeComponent();
        }

        #region Отображение данных
        /// <summary>
        /// При открытии страницы отображает данные в таблице
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            SortBox.SelectedIndex = 0;
            FilterBox.Items.Add("Все типы");
            foreach (AgentType type in AppData.db.AgentTypes.ToList())
            {
                FilterBox.Items.Add(type);
            }
            FilterBox.SelectedIndex = 0;
            GetAgents(SortBox.Text);
        }
        /// <summary>
        /// Возвращает список агентов по заданным параметрам
        /// </summary>
        /// <param name="sort">Порядок сортировки</param>
        /// <param name="filter">Фильтр по приоритету</param>
        /// <param name="search">Строка поиска</param>
        private void GetAgents(string sort = "По возрастанию приоритета агента", string filter = "Все типы", string search = "")
        {
            List<Agent> listAgents = AppData.db.Agents.ToList();
            switch (sort)
            {
                case "По возрастанию приоритета агента":
                    {
                        listAgents = listAgents.OrderBy(c => c.Priority).ToList();
                        break;
                    }

                case "По убыванию приоритета агента":
                    {
                        listAgents = listAgents.OrderByDescending(c => c.Priority).ToList();
                        break;
                    }

                case "По наименованию, от А до Я":
                    {
                        listAgents = listAgents.OrderBy(c => c.Title).ToList();
                        break;
                    }

                case "По наименованию, от Я до А":
                    {
                        listAgents = listAgents.OrderByDescending(c => c.Title).ToList();
                        break;
                    }

                default:
                    break;
            }
            switch (filter)
            {
                case "МКК":
                    listAgents = listAgents.Where(c => c.AgentType.Title == "МКК").ToList();
                    break;

                case "ОАО":
                    listAgents = listAgents.Where(c => c.AgentType.Title == "ОАО").ToList();
                    break;

                case "ООО":
                    listAgents = listAgents.Where(c => c.AgentType.Title == "ООО").ToList();
                    break;

                case "ЗАО":
                    listAgents = listAgents.Where(c => c.AgentType.Title == "ЗАО").ToList();
                    break;

                case "МФО":
                    listAgents = listAgents.Where(c => c.AgentType.Title == "МФО").ToList();
                    break;

                case "ПАО":
                    listAgents = listAgents.Where(c => c.AgentType.Title == "ПАО").ToList();
                    break;

                default:
                    break;
            }

            if (!string.IsNullOrEmpty(search) && !string.IsNullOrWhiteSpace(search))
            {
                listAgents = listAgents.Where(c => c.Title.ToLower().Contains(search.ToLower()) || 
                c.Email.ToLower().Contains(search.ToLower()) || c.Phone.Contains(search)).ToList();
            }
            AgentGrid.ItemsSource = listAgents;
        }
        #endregion

        #region Поиск данных
        /// <summary>
        /// При изменении текста в поле поиска отображает соответсвующие данные
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SearchBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            GetAgents(SortBox.Text, FilterBox.Text, SearchBox.Text);
        }
        /// <summary>
        /// При изменении выбора в поле фильтрации отображает соответсвующие данные
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FilterBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            GetAgents(SortBox.Text, (FilterBox.SelectedValue).ToString(), SearchBox.Text);
        }
        /// <summary>
        /// При изменении выбора в поле сортировки отображает соответсвующие данные
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SortBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            GetAgents(((ComboBoxItem)SortBox.SelectedValue).Content.ToString(), FilterBox.Text, SearchBox.Text);
        }
        #endregion

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}