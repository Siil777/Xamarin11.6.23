using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Targv22.Ivanov
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Frame_page : ContentPage
    {
        //Storing these variables at the class level to make them accessible throughout the entire class
        Frame fr;
        Label lbl;
        Grid gr;

        public Frame_page()
        {
            lbl = new Label
            {
                // typeof ensures that the font size retrieved is appropriate for a Label
                Text = "Raami kujundus",
                FontSize = Device.GetNamedSize(NamedSize.Subtitle, typeof(Label))
            };
            //Grid elements contains multiple BoxView with different properties
            gr = new Grid
            {
                RowDefinitions =
            {
                //GridUnitType.Star is used to share the available space proportionally based on weights assigned to each row or column
                //number перед GridUnitType.Star представляет долю пространства, которое строка или столбец должны занимать
                //относительно других строк с разными размерами в данном соучае относительно высоты других строк
                new RowDefinition{Height = new GridLength(2, GridUnitType.Star)},
                new RowDefinition{Height = new GridLength(1, GridUnitType.Star)},
                new RowDefinition{Height = new GridLength(1, GridUnitType.Star)},
            },
                ColumnDefinitions =
            {
                //1 перед GridUnitType.Star представляет долю пространства, которое строка или столбец должны занимать
                //относительно других строк с разными размерами в данном соучае относительно ширины других строк
                new ColumnDefinition{Width = new GridLength(1, GridUnitType.Star)},
                new ColumnDefinition{Width = new GridLength(1, GridUnitType.Star)},
            },
            };

            gr.Children.Add(new BoxView { Color = Color.Blue }, 0, 0);
            gr.Children.Add(new BoxView { Color = Color.Green }, 1, 0);
            gr.Children.Add(new BoxView { Color = Color.Red }, 0, 1);
            gr.Children.Add(new BoxView { Color = Color.YellowGreen }, 1, 1);
            gr.Children.Add(new BoxView { Color = Color.Purple }, 0, 2);
            gr.Children.Add(new BoxView { Color = Color.Blue }, 1, 2);

            //Frame named fr is created with its Content set to the previously defined Grid (gr).
            fr = new Frame
            {
                Content = gr,
                BorderColor = Color.FromRgb(20, 120, 255),
                CornerRadius = 20,
                VerticalOptions = LayoutOptions.FillAndExpand
            };
             //children we zip through Stacklayout to display them in order they have been written
            StackLayout st = new StackLayout
            {
                Children = { lbl, fr }
            };
            //display content
            Content = st;
        }
    }



}
