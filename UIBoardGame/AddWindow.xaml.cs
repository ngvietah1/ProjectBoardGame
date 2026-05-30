using Model.Core;
using Model.Core;
using System;
using System.CodeDom;
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
    /// Interaction logic for AddWindow.xaml
    /// </summary>
    public partial class AddWindow : Window
    {
        public AddWindow()
        {
            InitializeComponent();
            List<string> list = new List<string>();
            list.Add("CardGame");
            list.Add("EuroGame");
            list.Add("PartyGame");
            cbbtype.ItemsSource = list;
            inputparameter2.Visibility = Visibility.Collapsed;
            List<string> list2 = new List<string>();
            list2.Add("true");
            list2.Add("false");
            inputparameter3.ItemsSource = list2;
            parameter1.Visibility = Visibility.Collapsed;
            inputparameter1.Visibility = Visibility.Collapsed;
            parameter2.Visibility= Visibility.Collapsed;
            inputparameter2.Visibility= Visibility.Collapsed;
            inputparameter3.Visibility = Visibility.Collapsed;
            savebtn.IsEnabled = false;
            mainimage.ImageSource = new BitmapImage(new Uri(MainWindow.getpath("addwindow1.jpg")));
            addimage2.ImageSource = new BitmapImage(new Uri(MainWindow.getpath("addwindow2.jpg")));
        }

        private void cbbtype_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string type = cbbtype.SelectedItem + "";
            if (type == "CardGame")
            {
                parameter1.Text = "Количество карт:";
                parameter1.Visibility = Visibility.Visible;
                inputparameter1.Visibility = Visibility.Visible;
                inputparameter1.Text = "Количество карт";
                parameter2.Text = "Количество карт у каждого игрока:";
                parameter2.Visibility = Visibility.Visible;
                inputparameter2.Text = "Количество карт у каждого игрока";
                inputparameter2.Visibility = Visibility.Visible;
                inputparameter3.Visibility = Visibility.Collapsed;
            }
            else if (type == "EuroGame")
            {
                parameter1.Text = "Типы ресурсов:";
                parameter1.Visibility = Visibility.Visible;
                inputparameter1.Text = "Типы ресурсов";
                inputparameter1.Visibility= Visibility.Visible;
                parameter2.Text = "Вместимость хранилища:";
                parameter2.Visibility = Visibility.Visible;
                inputparameter2.Text = "Вместимость хранилища";
                inputparameter2.Visibility = Visibility.Visible;
                inputparameter3.Visibility = Visibility.Collapsed;
            }
            else if (type == "PartyGame")
            {
                parameter1.Text = "Продолжительность:";
                parameter1.Visibility = Visibility.Visible;
                inputparameter1.Text = "Продолжительность";
                inputparameter1.Visibility = Visibility.Visible;
                parameter2.Text = "Командная игра:";
                parameter2.Visibility= Visibility.Visible;
                inputparameter3.Visibility = Visibility.Visible;
                inputparameter2.Visibility = Visibility.Collapsed;
            }
        }

        private void savebtn_Click(object sender, RoutedEventArgs e)
        {
            BoardGame game = null;
            string type = cbbtype.SelectedItem + "";
            string name = tbname.Text;
            int.TryParse(tbminplayers.Text, out int min);
            int.TryParse(tbmaxplayers.Text, out int max);
            int.TryParse(tbagelimit.Text, out int agelimit);
            string description = tbdescrition.Text;
            if (type == "CardGame")
            {
                int.TryParse(inputparameter1.Text, out int numbercards);
                int.TryParse(inputparameter2.Text, out int numbercardseachplayer);
                game = new CardGame(name, (min, max), agelimit, description, numbercards, numbercardseachplayer);
            }
            else if (type == "EuroGame")
            {
                string resourcetypes = inputparameter1.Text;
                int.TryParse(inputparameter2.Text, out int storagecapacity);
                game = new EuroGame(name, (min, max), agelimit, description, resourcetypes, storagecapacity);
            }
            else if (type == "PartyGame")
            {
                int.TryParse(inputparameter1.Text, out int duration);
                bool.TryParse(inputparameter3.SelectedItem + "", out bool isteambased);
                game = new PartyGame(name, (min, max), agelimit, description, duration, isteambased);
            }
            if (game == null) return;
            IGameCatalog newcatalog = new GameCatalog();
            newcatalog.Deserialize();
            newcatalog.Add(game);
            (newcatalog as GameCatalog).Sort();
            newcatalog.Serialize();
            this.Close();
        }
        private void checktn_Click(object sender, RoutedEventArgs e)
        {
            if (cbbtype.SelectedItem == null) return;
            if (string.IsNullOrEmpty(tbname.Text) || string.IsNullOrWhiteSpace(tbname.Text)) return;
            if (string.IsNullOrEmpty(tbminplayers.Text) || string.IsNullOrWhiteSpace(tbminplayers.Text)) return;
            if (string.IsNullOrEmpty(tbmaxplayers.Text) || string.IsNullOrWhiteSpace(tbmaxplayers.Text)) return;
            if (string.IsNullOrEmpty(tbagelimit.Text) || string.IsNullOrWhiteSpace(tbagelimit.Text)) return;
            if (string.IsNullOrEmpty(tbdescrition.Text) || string.IsNullOrWhiteSpace(tbdescrition.Text)) return;
            savebtn.IsEnabled = true;
            cbbtype.IsEnabled = false;
            tbname.IsEnabled = false;
            tbminplayers.IsEnabled = false;
            tbmaxplayers.IsEnabled = false;
            tbagelimit.IsEnabled = false;
            tbdescrition.IsEnabled = false;
            inputparameter1.IsEnabled = false;
            inputparameter2.IsEnabled = false;
            inputparameter3.IsEnabled = false;
        }
    }
}
