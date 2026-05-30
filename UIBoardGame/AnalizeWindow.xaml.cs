using Model.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace UIBoardGame
{
    /// <summary>
    /// Interaction logic for AnalizeWindow.xaml
    /// </summary>
    public partial class AnalizeWindow : Window
    {
        private IGameCatalog _catalog;
        public AnalizeWindow(IGameCatalog catalog)
        {
            InitializeComponent();
            _catalog = catalog;
            datagrid.ItemsSource = _catalog.Catalog;
            numbercards.Visibility = Visibility.Collapsed;
            numbercardseachplayer.Visibility = Visibility.Collapsed;
            resourcetypes.Visibility = Visibility.Collapsed;
            storagecapacity.Visibility = Visibility.Collapsed;
            duration.Visibility = Visibility.Collapsed;
            isteambased.Visibility = Visibility.Collapsed;
            mainboard.IsEnabled = false;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            BoardGame game = datagrid.SelectedItem as BoardGame;
            GameCatalog newcatalog = new GameCatalog();
            if (game != null)
            {
                foreach(var i in datagrid.ItemsSource)
                {
                    BoardGame tmp = i as BoardGame;
                    if (tmp == null) continue;
                    if (tmp.Name == game.Name) continue;
                    newcatalog.Add(tmp);
                }
                newcatalog.Serialize();
                datagrid.ItemsSource = null;
                datagrid.ItemsSource = newcatalog.Catalog;
            }
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            GameCatalog newcatalog = new GameCatalog();
            foreach(var i in datagrid.Items)
            {
                if(i is CardGame)
                {
                    newcatalog.Add(i as BoardGame);
                }
            }
            datagrid.ItemsSource = null;
            datagrid.ItemsSource = newcatalog.Catalog;
            numbercards.Binding = new Binding("NumberCards");
            numbercardseachplayer.Binding = new Binding("NumberCardsEachPlayer");
            numbercards.Visibility = Visibility.Visible;
            numbercardseachplayer.Visibility = Visibility.Visible;
            mainboard.IsEnabled = true;
            eurogameboard.IsEnabled = false;
            partygameboard.IsEnabled = false;
            deletebtn.IsEnabled = false;
            addbtn.IsEnabled = false;
            txtbl.Text = "Card Game";
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            GameCatalog newcatalog = new GameCatalog();
            foreach(var i in datagrid.ItemsSource)
            {
                if(i is EuroGame)
                {
                    newcatalog.Add(i as BoardGame);
                }
            }
            datagrid.ItemsSource = null;
            datagrid.ItemsSource = newcatalog.Catalog;
            resourcetypes.Binding = new Binding("ResourceTypes");
            storagecapacity.Binding = new Binding("StorageCapacity");
            resourcetypes.Visibility= Visibility.Visible;
            storagecapacity.Visibility = Visibility.Visible;
            mainboard.IsEnabled = true;
            cardgamebard.IsEnabled = false;
            partygameboard.IsEnabled = false;
            deletebtn.IsEnabled = false;
            addbtn.IsEnabled = false;
            txtbl.Text = "Euro Game";
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            GameCatalog newcatalog = new GameCatalog();
            foreach(var i in datagrid.ItemsSource)
            {
                if(i is PartyGame)
                {
                    newcatalog.Add(i as BoardGame);
                }
            }
            datagrid.ItemsSource = null;
            datagrid.ItemsSource = newcatalog.Catalog;
            duration.Binding = new Binding("Duration");
            isteambased.Binding = new Binding("IsTeamBased");
            duration.Visibility = Visibility.Visible;
            isteambased.Visibility = Visibility.Visible;
            mainboard.IsEnabled = true;
            cardgamebard.IsEnabled = false;
            eurogameboard.IsEnabled = false;
            deletebtn.IsEnabled = false;
            addbtn.IsEnabled = false;
            txtbl.Text = "Party Game";
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            GameCatalog newcatalog = new GameCatalog();
            newcatalog.Deserialize();
            datagrid.ItemsSource = null;
            datagrid.ItemsSource = newcatalog.Catalog;
            numbercards.Visibility = Visibility.Collapsed;
            numbercardseachplayer.Visibility = Visibility.Collapsed;
            resourcetypes.Visibility = Visibility.Collapsed;
            storagecapacity.Visibility = Visibility.Collapsed;
            duration.Visibility = Visibility.Collapsed;
            isteambased.Visibility = Visibility.Collapsed;
            mainboard.IsEnabled = false;
            cardgamebard.IsEnabled = true;
            eurogameboard.IsEnabled = true;
            partygameboard.IsEnabled = true;
            deletebtn.IsEnabled = true;
            addbtn.IsEnabled = true;
            txtbl.Text = "Board Game";
        }

        private void addbtn_Click(object sender, RoutedEventArgs e)
        {
            AddWindow window = new AddWindow();
            window.Owner = this;
            window.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            window.ShowDialog();
            IGameCatalog newcatalog = new GameCatalog();
            newcatalog.Deserialize();
            (newcatalog as GameCatalog).Sort();
            datagrid.ItemsSource = null;
            datagrid.ItemsSource = newcatalog.Catalog;
        }

        private void analyze_Click(object sender, RoutedEventArgs e)
        {
            Analyze newwin = new Analyze(_catalog as IAnalizer);
            newwin.Owner = this;
            newwin.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            newwin.ShowDialog();
        }
    }

}
