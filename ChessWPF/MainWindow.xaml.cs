using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ChessWPF
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        //enum dla typu zawartości każdego pola
        private SquareType[] square;

        private bool whiteTurn;


        public MainWindow()
        {
            InitializeComponent();

            NewGame();
        }

        private void NewGame()
        {
            square = new SquareType[64];

            for (int i = 0; i < square.Length; i++)
                square[i] = SquareType.Black_Pawn;

            whiteTurn = true;
            
            //próbowałem złapać obraz z przycisków ale te nie są dziećmi 
            /*
            Container.Children.Cast<Image>().ToList().ForEach(image =>
            {
                image.Source = new BitmapImage(new Uri(@"images\FreeSpace.png"));
            }); */
        }
    }
}
