using Model.Core;
using Model.Data;
using Newtonsoft.Json.Linq;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace UIBoardGame
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private IGameCatalog _game;
        private int _value;
        public MainWindow()
        {
            InitializeComponent();
            _game = new GameCatalog();
            _game.Deserialize();
            (_game as GameCatalog).Sort();
            cbb.ItemsSource = _game.Catalog;
            btnshowinfo.IsEnabled = false;
            btnshowinfo.Visibility = Visibility.Hidden;
            cbbsave.ItemsSource = new List<string>() {"json","xml" };
            cbbtype.ItemsSource = new List<string>() {"CardGame", "EuroGame", "PartyGame" };
            slider.IsEnabled = false;
            tbage.IsEnabled = false;
            _value = 0;
            btnsave.IsEnabled = false;
            cbbsave.IsEnabled = false;
            btnsave.Visibility = Visibility.Collapsed;
            loadmainwiniamge();
        }

        private void cbb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            BoardGame game = cbb.SelectedItem as BoardGame;
            if (game != null)
            {
                txtbl.Text = game.Name;
                btnshowinfo.Visibility = Visibility.Visible;
                btnshowinfo.IsEnabled = true;
                if(game is CardGame)
                {
                    if(game.Name== "Уно")
                    {
                        mainwinimage.ImageSource = new BitmapImage(new Uri(getpath("uno.jpg")));
                    }
                    else if(game.Name== "Взрывные котята")
                    {
                        mainwinimage.ImageSource = new BitmapImage(new Uri(getpath("explodingkitten.jpg")));
                    }
                    else if(game.Name== "Ю-Ги-О!")
                    {
                        mainwinimage.ImageSource = new BitmapImage(new Uri(getpath("yugioh.jpg")));
                    }
                    else
                    {
                        mainwinimage.ImageSource = new BitmapImage(new Uri(getpath("mainwinimage1.jpg")));
                    }
                }
                else if(game is EuroGame)
                {
                    if(game.Name== "Колонизаторы")
                    {
                        mainwinimage.ImageSource = new BitmapImage(new Uri(getpath("catan.jpg")));
                    }
                    else if(game.Name== "Агрикола")
                    {
                        mainwinimage.ImageSource = new BitmapImage(new Uri(getpath("agricola.jpg")));
                    }
                    else if(game.Name== "Покорение Марса")
                    {
                        mainwinimage.ImageSource = new BitmapImage(new Uri(getpath("mars.jpg")));
                    }
                    else
                    {
                        mainwinimage.ImageSource = new BitmapImage(new Uri(getpath("mainwinimage1.jpg")));
                    }
                }
                else if(game is PartyGame)
                {
                    if(game.Name== "Скажи иначе")
                    {
                        mainwinimage.ImageSource = new BitmapImage(new Uri(getpath("alias.jpg")));
                    }
                    else if(game.Name== "Кодовые имена")
                    {
                        mainwinimage.ImageSource = new BitmapImage(new Uri(getpath("codenames.jpg")));
                    }
                    else if(game.Name== "Оборотни")
                    {
                        mainwinimage.ImageSource = new BitmapImage(new Uri(getpath("werewolf.jpg")));
                    }
                    else if(game.Name== "Диксит")
                    {
                        mainwinimage.ImageSource = new BitmapImage(new Uri(getpath("dixit.jpg")));
                    }
                    else if(game.Name== "Доббль")
                    {
                        mainwinimage.ImageSource = new BitmapImage(new Uri(getpath("dobble.jpg")));
                    }
                    else
                    {
                        mainwinimage.ImageSource = new BitmapImage(new Uri(getpath("mainwinimage1.jpg")));
                    }
                }
                else
                {
                    mainwinimage.ImageSource = new BitmapImage(new Uri(getpath("mainwinimage1.jpg")));
                }
            }
        }
        private void loadmainwiniamge()
        {
            string path = Directory.GetCurrentDirectory();
            string newpath = "";
            string path1, path2;
            string[] strings=path.Split('\\');
            for(int i = 0; i < strings.Length; i++)
            {
                if (strings[i] == "UIBoardGame") break;
                newpath += strings[i];              
                newpath += "\\";
            }
            path1 = System.IO.Path.Combine(newpath, "Images", "mainwinimage1.jpg");
            mainwinimage.ImageSource = new BitmapImage(new Uri(path1));
            path2 = System.IO.Path.Combine(newpath, "Images", "mainwinimage.jpg");
            mainwinimage2.ImageSource = new BitmapImage(new Uri(path2));
        }
        internal static string getpath(string s)
        {
            string path = Directory.GetCurrentDirectory();
            string[] strings = path.Split(new char[] { '\\' }, StringSplitOptions.RemoveEmptyEntries);
            string newpath = "";
            for(int i = 0; i < strings.Length; i++)
            {
                if (strings[i] == "UIBoardGame") break;
                newpath += strings[i];                
                newpath += '\\';
            }
            return System.IO.Path.Combine(newpath, "Images", s);
        }

        private void btnshowinfo_Click(object sender, RoutedEventArgs e)
        {
            NewWindow newwindow = new NewWindow(cbb.SelectedItem as BoardGame);
            newwindow.Owner = this;
            newwindow.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            newwindow.ShowDialog();
        }

        private void btnctl_Click(object sender, RoutedEventArgs e)
        {
            AnalizeWindow window = new AnalizeWindow(_game);
            window.Owner = this;
            window.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            window.ShowDialog();
            _game = new GameCatalog();
            _game.Deserialize();
            cbb.ItemsSource = null;
            cbb.ItemsSource = _game.Catalog;
          
        }

        private void cbbsave_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbbsave.SelectedItem == null) return;
            btnsave.IsEnabled = true;
        }

        private void cbbtype_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbbtype.SelectedItem == null) return;
            string type = cbbtype.SelectedItem + "";
            if (_game == null) return;
            BoardGame[] array = new BoardGame[0];
            btnctl.IsEnabled = false;
            foreach (var i in _game.Catalog)
            {
                if (i.Type == type)
                {
                    Array.Resize(ref array, array.Length + 1);
                    array[array.Length - 1] = i;
                }
            }
            IGameCatalog tmp = new GameCatalog();
            tmp.Add(array);
            (tmp as GameCatalog).Sort();
            cbb.ItemsSource = null;
            cbb.ItemsSource = tmp.Catalog;
            slider.IsEnabled = true;
            btnsave.Visibility = Visibility.Visible;
        }

        private void slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (_game == null) return;
            _value = (int)e.NewValue;
            if (_value == 0) return;
            BoardGame[] array = new BoardGame[0];
            string type = cbbtype.SelectedItem + "";
            foreach(var i in _game.Catalog)
            {
                if(_value >= i.NumberPlayers.Item1 && _value <= i.NumberPlayers.Item2 && i.Type == type)
                {
                    Array.Resize(ref array, array.Length + 1);
                    array[array.Length - 1] = i;
                }
            }
            IGameCatalog tmp = new GameCatalog();
            tmp.Add(array);
            (tmp as GameCatalog).Sort();
            cbb.ItemsSource = null;
            cbb.ItemsSource = tmp.Catalog;
            tbage.IsEnabled = true;
        }

        private void btnreset_Click(object sender, RoutedEventArgs e)
        {
            _game = new GameCatalog();
            (_game as GameCatalog).Initialize();
            (_game as GameCatalog).Sort();
            _game.Serialize();
            cbb.ItemsSource = null;
            cbb.ItemsSource = _game.Catalog;
            slider.Value = 0;
            slider.IsEnabled = false;
            tbage.Text = "Возрастное ограничение";
            tbage.IsEnabled = false;
            cbbtype.SelectedItem = null;
            cbbsave.SelectedItem = null;
            cbbsave.IsEnabled = false;
            btnctl.IsEnabled = true;
            btnsave.IsEnabled = false;
            btnsave.Visibility=Visibility.Collapsed; 
        }

        private void tbage_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (_game == null) return;
            if (tbage.Text == "Возрастное ограничение" || tbage.Text == "") return;
            int.TryParse(tbage.Text, out int age);
            BoardGame[] array = new BoardGame[0];
            string type = cbbtype.SelectedItem + "";
            foreach (var i in _game.Catalog)
            {
                if (_value >= i.NumberPlayers.Item1 && _value <= i.NumberPlayers.Item2 && i.Type == type && i.AgeLimit >= age)
                {
                    Array.Resize(ref array, array.Length + 1);
                    array[array.Length - 1] = i;
                }
            }
            IGameCatalog tmp = new GameCatalog();
            tmp.Add(array);
            (tmp as GameCatalog).Sort();
            cbb.ItemsSource = null;
            cbb.ItemsSource = tmp.Catalog;
            cbbsave.IsEnabled = true;
        }

        private void btnsave_Click(object sender, RoutedEventArgs e)
        {
            BoardGame[] array = new BoardGame[0];
            foreach(var i in cbb.ItemsSource)
            {
                BoardGame tmp = i as BoardGame;
                if (tmp == null) continue;
                Array.Resize(ref array, array.Length + 1);
                array[array.Length - 1] = tmp;
            }
            _game = new GameCatalog();
            _game.Add(array);
            _game.Serialize();
            string format = cbbsave.SelectedItem + "";
            if (format == "xml")
            {
                XmlManager xmlManager = new XmlManager();
                xmlManager.Serialize(_game);
            }
            cbbtype.SelectedItem = null;
            slider.Value = 0;
            tbage.Text = "Возрастное ограничение";
            cbbsave.SelectedItem = null;
            btnctl.IsEnabled = true;
            btnsave.IsEnabled = false;
            slider.IsEnabled = false;
            tbage.IsEnabled = false;
            cbbsave.IsEnabled = false;
            cbb.ItemsSource = null;
            cbb.ItemsSource = _game.Catalog;
            btnsave.Visibility = Visibility.Collapsed;
        }
    }
}