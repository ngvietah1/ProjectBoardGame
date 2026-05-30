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
    /// Interaction logic for NewWindow.xaml
    /// </summary>
    public partial class NewWindow : Window
    {
        public NewWindow(BoardGame game)
        {
            InitializeComponent();
            if (game == null) return;
            mainnewwinimage.Source = new BitmapImage(new Uri(MainWindow.getpath("mainnewwin.jpg")));
            txtblock.Text = game.GetInformation();
            txtblock2.Visibility = Visibility.Collapsed;
            grid2.Visibility = Visibility.Collapsed;
            loadimage(game);
        }
        private void loadimage(BoardGame game)
        {
            if(game is CardGame)
            {
                if(game.Name== "Уно")
                {
                    image.Source = new BitmapImage(new Uri(MainWindow.getpath("uno2.jpg")));
                }
                else if(game.Name== "Взрывные котята")
                {
                    image.Source = new BitmapImage(new Uri(MainWindow.getpath("explodingkitten2.jpg")));
                }
                else if(game.Name== "Ю-Ги-О!")
                {
                    image.Source = new BitmapImage(new Uri(MainWindow.getpath("yugioh2.jpg")));
                }
                else
                {
                    txtblock2.Text = game.Name;
                    grid2.Visibility = Visibility.Visible;
                    txtblock2.Visibility = Visibility.Visible;
                }
            }
            else if(game is EuroGame)
            {
                if(game.Name== "Колонизаторы")
                {
                    image.Source = new BitmapImage(new Uri(MainWindow.getpath("catan2.jpg")));
                }
                else if(game.Name== "Агрикола")
                {
                    image.Source = new BitmapImage(new Uri(MainWindow.getpath("agricola2.jpg")));
                }
                else if(game.Name== "Покорение Марса")
                {
                    image.Source = new BitmapImage(new Uri(MainWindow.getpath("mars2.jpg")));
                }
                else
                {
                    txtblock2.Text = game.Name;
                    grid2.Visibility = Visibility.Visible;
                    txtblock2.Visibility = Visibility.Visible;
                }
            }
            else if(game is PartyGame)
            {
                if (game.Name == "Скажи иначе")
                {
                    image.Source = new BitmapImage(new Uri(MainWindow.getpath("alias2.jpg")));
                }
                else if(game.Name== "Кодовые имена")
                {
                    image.Source = new BitmapImage(new Uri(MainWindow.getpath("codenames2.jpg")));
                }
                else if(game.Name== "Оборотни")
                {
                    image.Source = new BitmapImage(new Uri(MainWindow.getpath("werewolf2.jpg")));
                }
                else if(game.Name== "Диксит")
                {
                    image.Source = new BitmapImage(new Uri(MainWindow.getpath("dixit2.jpg")));
                }
                else if(game.Name== "Доббль")
                {
                    image.Source = new BitmapImage(new Uri(MainWindow.getpath("dobble2.jpg")));

                }
                else
                {
                    txtblock2.Text = game.Name;
                    grid2.Visibility = Visibility.Visible;
                    txtblock2.Visibility = Visibility.Visible;
                }
            }
            else
            {
                txtblock2.Text = game.Name;
                grid2.Visibility = Visibility.Visible;
                txtblock2.Visibility = Visibility.Visible;
            }
        }
    }
}
