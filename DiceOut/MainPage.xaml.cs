using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace DiceOut
{
  /// <summary>
  /// An empty page that can be used on its own or navigated to within a Frame.
  /// </summary>
  public sealed partial class MainPage : Page
  {
    public int Score;
    public int[] Die = new int[3];
    public Random RandomGenerator = new Random();

    public MainPage()
    {
      this.InitializeComponent();
      SetupGame();
    }

    private void SetupGame()
    {

    }

    private async void RoleButton_OnClick(object sender, RoutedEventArgs e)
    {


      for (int i = 0; i < Die.Length; i++)
      {
        int DieValue = RandomGenerator.Next(1, 7);
        Die[i] = DieValue;
      }
      Die1.DisplayFace(Die[0]);
      await Task.Delay(200);
      Die2.DisplayFace(Die[1]);
      await Task.Delay(200);
      Die3.DisplayFace(Die[2]);
      await Task.Delay(1000);
      ApplyGameRules();
    }

    private void ApplyGameRules()
    {
      int score = 0;
      string text = "You rolled Nothing";
      if (Die[0] == Die[1] && Die[0] == Die[2]) // Triple
      {
        text = "You rolled a Triple!!";
        Score += 50;
      }
      else if (Die[0] == Die[1] || Die[0] == Die[2] || Die[1] == Die[2]) // Double
      {
        text = "You rolled a Double!";
        Score += 20;
      }
      DieValueText.Text = text;
      ScoreText.Text = $"{Score} Points";
    }
  }
}
