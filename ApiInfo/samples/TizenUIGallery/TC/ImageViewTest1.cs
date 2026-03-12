using System;
using Tizen.UI;

namespace TizenUIGallery.TC
{
    public class ImageViewTest1 : ViewGroup, ITestCase
    {
        public ImageViewTest1()
        {
            WidthResizePolicy = ResizePolicy.FillToParent;
            HeightResizePolicy = ResizePolicy.FillToParent;
            BackgroundColor = Color.White;

            Add(new TextView
            {
                Text = "ImageView Test1",
                BackgroundColor = Color.Yellow,
                ParentOriginX = 0.5f,
                ParentOriginY = 0f,
                PivotPointY = 0f,
                PositionUsesPivotPoint = true,
                HorizontalAlignment = TextAlignment.Center,
                VerticalAlignment = TextAlignment.Center,
                WidthResizePolicy = ResizePolicy.FillToParent,
                Height = 100,
                FontSize = 60,
            });

            Add(new ImageView
            {
                Name = "View1",
                ParentOriginX = 0.5f,
                ParentOriginY = 0f,
                Height = 200,
                Width = 200,
                Y = 200,
                X = 0,
                PositionUsesPivotPoint = true,
                PivotPointX = 0.5f,
                PivotPointY = 0f,
                BackgroundColor = Color.Yellow,
                ResourceUrl = "img2.png",
                FittingMode = FittingMode.ScaleToFit,
                MultipliedColor = Color.Red,
            });

            Add(new ImageView
            {
                Name = "View2",
                ParentOriginX = 0.5f,
                ParentOriginY = 0f,
                Height = 200,
                Width = 200,
                Y = 400,
                X = 0,
                PositionUsesPivotPoint = true,
                PivotPointX = 0.5f,
                PivotPointY = 0f,
                BackgroundColor = Color.Yellow,
                ResourceUrl = "img2.png",
                AlphaMaskUrl = "clip.png",
                FittingMode = FittingMode.ScaleToFill
            });

            Add(new ImageView
            {
                Name = "View3",
                ParentOriginX = 0.5f,
                ParentOriginY = 0f,
                Height = 200,
                Width = 200,
                Y = 600,
                X = 0,
                PositionUsesPivotPoint = true,
                PivotPointX = 0.5f,
                PivotPointY = 0f,
                BackgroundColor = Color.Yellow,
                ResourceUrl = "img1.jpg",
                FittingMode = FittingMode.ScaleToFit
            });

            Add(new ImageView
            {
                Name = "View3-1",
                ParentOriginX = 0.5f,
                ParentOriginY = 0f,
                Height = 200,
                Width = 200,
                Y = 600,
                X = -200,
                PositionUsesPivotPoint = true,
                PivotPointX = 0.5f,
                PivotPointY = 0f,
                BackgroundColor = Color.Yellow,
                ResourceUrl = "keyboard_focus.9.png",
                IsNinePatchImage = true,
            });

            Add(new ImageView
            {
                Name = "toggleImage",
                ParentOriginX = 0.5f,
                ParentOriginY = 0f,
                Height = 200,
                Width = 200,
                Y = 600,
                X = 200,
                PositionUsesPivotPoint = true,
                PivotPointX = 0.5f,
                PivotPointY = 0f,
                BackgroundColor = Color.Yellow,
                ResourceUrl = "dotnet_bot.png",
                IsNinePatchImage = true,
            });

            Add(new ImageView
            {
                Name = "View4",
                ParentOriginX = 0.5f,
                ParentOriginY = 0f,
                Height = 200,
                Width = 200,
                Y = 800,
                X = 0,
                PositionUsesPivotPoint = true,
                PivotPointX = 0.5f,
                PivotPointY = 0f,
                BackgroundColor = Color.Yellow,
                ResourceUrl = "img1.jpg",
                FittingMode = FittingMode.ScaleToFill
            });

            Add(new ImageView
            {
                Name = "View5",
                ParentOriginX = 0.5f,
                ParentOriginY = 0f,
                Height = 200,
                Width = 200,
                Y = 800,
                X = -200,
                PositionUsesPivotPoint = true,
                PivotPointX = 0.5f,
                PivotPointY = 0f,
                BackgroundColor = Color.Yellow,
                ResourceUrl = "animated2.gif",
                FittingMode = FittingMode.ScaleToFill
            });
            Add(new ImageView
            {
                Name = "View6",
                ParentOriginX = 0.5f,
                ParentOriginY = 0f,
                Height = 200,
                Width = 200,
                Y = 800,
                X = 200,
                PositionUsesPivotPoint = true,
                PivotPointX = 0.5f,
                PivotPointY = 0f,
                BackgroundColor = Color.Yellow,
                ResourceUrl = "animated.gif",
                FittingMode = FittingMode.ScaleToFill
            });


            //(this["View2"] as ImageView).CropToMask = true;
            (this["View2"] as ImageView).CropToMask = false;
            //(this["View2"] as ImageView).CropToMask = false;

            this["View1"].TouchEvent += touch;
            this["View2"].TouchEvent += touch;
            this["View3"].TouchEvent += touch;
            this["View4"].TouchEvent += touch;

            void touch(object sender, TouchEventArgs e)
            {
                
                ImageView view = (ImageView)sender;
                if (e.Touch[0].State == TouchState.Up)
                {
                    
                    var mode = (FittingMode)(((int)view.FittingMode + 1)%6);
                    Console.WriteLine($"FittingMode : {mode}");
                    view.FittingMode = mode;
                }
            }

            Add(new ImageView
            {
                Name = "View7",
                ParentOriginX = 0.5f,
                ParentOriginY = 0f,
                Height = 200,
                Width = 200,
                Y = 400,
                X = -200,
                PositionUsesPivotPoint = true,
                PivotPointX = 0.5f,
                PivotPointY = 0f,
                BackgroundColor = Color.Yellow,
                ResourceUrl = "img1.jpg",
                SynchronousLoading = false,
                FittingMode = FittingMode.ScaleToFill
            });

            var images2 = new string[]
            {
                    "http://i.imgur.com/H8mbyUM.jpg",
                    "http://i.imgur.com/6ZUYWDE.jpg",
                    "http://i.imgur.com/t9gomWN.jpg",
                    "http://i.imgur.com/9f974SC.jpg",
                    "http://i.imgur.com/KQ3NtX5.jpg",
                    "http://i.imgur.com/ygrDkwo.jpg",
                    "http://i.imgur.com/SZOzETV.jpg",
                    "http://i.imgur.com/YQlie8b.jpg",
                    "http://i.imgur.com/kJS4q3U.jpg",
                    "http://i.imgur.com/MkH9aPa.jpg",
                    "http://i.imgur.com/C3b9otw.jpg",
                    "http://i.imgur.com/wpcsCMh.jpg",
                    "http://i.imgur.com/fH6dqpP.jpg",
                    "http://i.imgur.com/T38xuv3.jpg",
                    "http://i.imgur.com/jZ4qSxo.jpg",
                    "http://i.imgur.com/hb7ICRv.jpg",
            };
            int idx = 0;
            (this["View7"] as ImageView).ResourceUrl = images2[idx];
            (this["View7"] as ImageView).ResourcesLoaded += (s, e) =>
            {
                idx = (idx + 1) % images2.Length;
                (this["View7"] as ImageView).ResourceUrl = images2[idx];
            };
            (this["View7"] as ImageView).TouchEvent += touch;

            var tap = new TapGestureDetector();
            tap.Attach(this["toggleImage"]);
            tap.Detected += (s, e) =>
            {
                if ((this["toggleImage"] as ImageView).ResourceUrl == null)
                {
                    (this["toggleImage"] as ImageView).ResourceUrl = "dotnet_bot.png";
                }
                else
                {
                    (this["toggleImage"] as ImageView).ResourceUrl = null;
                }
            };
        }

        public void Activate()
        {
            Window.Default.DefaultLayer.Add(this);
        }

        public void Deactivate()
        {
            Dispose();
        }
    }
}
