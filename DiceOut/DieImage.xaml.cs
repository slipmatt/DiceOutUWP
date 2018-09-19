using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace DiceOut
{
  public sealed partial class DieImage : UserControl
  {
    private const int NumFaces = 7;
    private Image[] Faces = new Image[NumFaces];
    public DieImage()
    {
      this.InitializeComponent();
      CreateFaceArray();
    }



    private void CreateFaceArray()
    {
      Faces[0] = Face1;
      Faces[1] = Face2;
      Faces[2] = Face3;
      Faces[3] = Face4;
      Faces[4] = Face5;
      Faces[5] = Face6;
      Faces[6] = Spin;
    }

    public async void DisplayFace(int FaceID)
    {
        HideFaces();
      Faces[6].Visibility = Visibility.Visible;
      await Task.Delay(1000);
      Faces[6].Visibility = Visibility.Collapsed;
      for (int i = 0; i < NumFaces; i++)
      {
        if (i == FaceID - 1)
        {
          Faces[i].Visibility = Visibility.Visible;
        }
      }
    }

      private void HideFaces()
      {
      for (int i = 0; i < NumFaces; i++)
      {
          Faces[i].Visibility = Visibility.Collapsed;
      }
    }
  }
}
