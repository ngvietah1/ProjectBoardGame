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
    /// Interaction logic for Analyze.xaml
    /// </summary>
    public partial class Analyze : Window
    {
        public Analyze(IAnalizer catalog)
        {
            InitializeComponent();
            tbmin.Text += catalog.AverageMinAmount() + "";
            tbmax.Text += catalog.AverageMaxAmount() + "";
            tbplayers.Text += catalog.MeanAmount() + "";
            tbage.Text += catalog.MeanAgeRestriction() + "";
        }
    }
}
