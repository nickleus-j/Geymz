using System;
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

namespace TicTacToe
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool _playerXTurn = true;
        private int _turnCount = 0;

        public MainWindow()
        {
            InitializeComponent();
            ResetGame();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;
            if (button.Content == null)
            {
                button.Content = _playerXTurn ? "X" : "O";
                _playerXTurn = !_playerXTurn;
                _turnCount++;

                if (CheckForWinner())
                {
                    lblStatus.Content = _playerXTurn ? "O Wins!" : "X Wins!";
                    DisableButtons();
                }
                else if (_turnCount == 9)
                {
                    lblStatus.Content = "Draw!";
                }
            }
        }
        private void Reset_Click(object sender, RoutedEventArgs e)
        {
            ResetGame();
        }
        private bool CheckForWinner()
        {
            if (CheckLine(btn1, btn2, btn3) ||
                CheckLine(btn4, btn5, btn6) ||
                CheckLine(btn7, btn8, btn9) ||
                CheckLine(btn1, btn4, btn7) ||
                CheckLine(btn2, btn5, btn8) ||
                CheckLine(btn3, btn6, btn9) ||
                CheckLine(btn1, btn5, btn9) ||
                CheckLine(btn3, btn5, btn7))
            {
                return true;
            }
            return false;
        }

        private bool CheckLine(Button b1, Button b2, Button b3)
        {
            if (b1.Content == b2.Content && b2.Content == b3.Content && b1.Content != null)
            {
                return true;
            }
            return false;
        }

        private void DisableButtons()
        {
            foreach (var child in grid1.Children)
            {
                if (child is Button button)
                {
                    button.IsEnabled = false;
                }
            }
        }

        private void ResetGame()
        {
            foreach (var child in grid1.Children)
            {
                if (child is Button button)
                {
                    button.IsEnabled = true;
                    button.Content = null;
                }
            }
            _playerXTurn = true;
            _turnCount = 0;
            lblStatus.Content = "Player X's Turn";
        }
    }
}