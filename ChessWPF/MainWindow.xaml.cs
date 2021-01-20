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

        private string lastClickedButton = string.Empty;

        public MainWindow()
        {
            InitializeComponent();

            NewGame();
        }

        private void NewGame()
        {
            square = new SquareType[64];

            //wypełnienie początkowe wszystkich pól odpowiednimi pionkami
            for (int i = 0; i < square.Length; i++)
            {
                if (i >= 8 && i <= 15)
                    square[i] = SquareType.Black_Pawn;
                else if (i == 0 || i == 7)
                    square[i] = SquareType.Black_Rook;
                else if (i == 1 || i == 6)
                    square[i] = SquareType.Black_Knight;
                else if (i == 2 || i == 5)
                    square[i] = SquareType.Black_Bishop;
                else if (i == 3)
                    square[i] = SquareType.Black_Queen;
                else if (i == 4)
                    square[i] = SquareType.Black_King;
                else if (i >= 48 && i <= 55)
                    square[i] = SquareType.White_Pawn;
                else if (i == 56 || i == 63)
                    square[i] = SquareType.White_Rook;
                else if (i == 57 || i == 62)
                    square[i] = SquareType.White_Knight;
                else if (i == 58 || i == 61)
                    square[i] = SquareType.White_Bishop;
                else if (i == 59)
                    square[i] = SquareType.White_Queen;
                else if (i == 60)
                    square[i] = SquareType.White_King;
                else
                    square[i] = SquareType.Free;
            }
            whiteTurn = true;
            Container.Children.Cast<Button>().ToList().ForEach(button =>
            {
                //pokolorowanie szachownicy
                if ((Grid.GetColumn(button) + Grid.GetRow(button)) % 2 == 1)
                    button.Background = Brushes.SeaGreen;
                else
                    button.Background = Brushes.White;

                //string s = square[Grid.GetColumn(button) + 8 * Grid.GetRow(button)];

                //wypełnienie odpowiednimi figurami pola szachownicy - nadanie im tekstu
                button.Content = square[Grid.GetColumn(button) + 8*Grid.GetRow(button)];

                //w wypadku pustego pola pozbycie się tekstu
                if (button.Content.Equals(SquareType.Free))
                    button.Content = "";
            });


            //próbowałem złapać obraz z przycisków ale te nie są dziećmi 
            /*
            Container.Children.Cast<Image>().ToList().ForEach(image =>
            {
                image.Source = new BitmapImage(new Uri(@"images\FreeSpace.png"));
            }); */
        }

        private void ButtonClick(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;
            //if (!button.Content.Equals("") || lastClickedButton.Equals(""))
            //{ 
                if(lastClickedButton.Equals(""))
                {
                    lastClickedButton = button.Name;
                    button.Background = Brushes.Cyan;
                }
                else
                {
                    var lastButton = (Button)FindName(lastClickedButton);
                    if ((Grid.GetColumn(lastButton) + Grid.GetRow(lastButton)) % 2 == 1)
                        lastButton.Background = Brushes.SeaGreen;
                    else
                        lastButton.Background = Brushes.White;


                    var tmp = lastButton.Content;
                    lastButton.Content = button.Content;
                    button.Content = tmp;
                    lastClickedButton = "";

                }
            //}
        }
    }
}
