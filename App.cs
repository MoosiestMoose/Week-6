#region Namespaces
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;

using System.Reflection;
using System.Drawing;
using System.Windows.Media.Imaging;
using System.IO;
using System.Windows.Controls;
using System.Windows.Media;
using static System.Net.Mime.MediaTypeNames;

#endregion

namespace Finalweek
{
    internal class App : IExternalApplication
    {
        public Result OnStartup(UIControlledApplication a)
        {
            string AssemblyName = GetAssemblyName();

            // create ribbon tab
            a.CreateRibbonTab("Revit Add-in Bootcamp");
            
            //create ribbon panel(s)
            RibbonPanel Panel1 = a.CreateRibbonPanel("Revit Add-in Bootcamp", "Sensible Revit Tools");
           
            //Create button data
            PushButtonData pData1 = new PushButtonData("Tool 1", "This is \r tool one", AssemblyName, "Finalweek.Command1");
            PushButtonData pData2 = new PushButtonData("Tool two", "T2", AssemblyName, "Finalweek.Command1");
            PushButtonData pData3 = new PushButtonData("Tool 3", "T3", AssemblyName, "Finalweek.Command1");
            PushButtonData pData4 = new PushButtonData("Tool 4", "T4", AssemblyName, "Finalweek.Command1");
            PushButtonData pData5 = new PushButtonData("Tool 5", "T5", AssemblyName, "Finalweek.Command1");
            PushButtonData pData6 = new PushButtonData("Tool 6", "T6", AssemblyName, "Finalweek.Command2");
            PushButtonData pData7 = new PushButtonData("Tool 7", "T7", AssemblyName, "Finalweek.Command2");
            PushButtonData pData8 = new PushButtonData("Tool 8", "T8", AssemblyName, "Finalweek.Command2");
            PushButtonData pData9 = new PushButtonData("Tool 9", "T9", AssemblyName, "Finalweek.Command2");
            PushButtonData pData10 = new PushButtonData("Tool 10", "Tten", AssemblyName, "Finalweek.Command2");

            SplitButtonData splitData1 = new SplitButtonData("Tool 101", "Tool 0");
            PulldownButtonData pullData1 = new PulldownButtonData("Pull", "Pull Down");

            //Add images
            pData1.LargeImage = BitmapToImageSource(Finalweek.Properties.Resources._32x32Moose);
            pData1.Image = BitmapToImageSource(Finalweek.Properties.Resources._32x32Moose);
            pData2.LargeImage = BitmapToImageSource(Finalweek.Properties.Resources.Laura);
            pData2.Image = BitmapToImageSource(Finalweek.Properties.Resources.Laura);
            pData3.LargeImage = BitmapToImageSource(Finalweek.Properties.Resources.Plate);
            pData3.Image = BitmapToImageSource(Finalweek.Properties.Resources.Plate);
            pData4.LargeImage = BitmapToImageSource(Finalweek.Properties.Resources.Cheese);
            pData4.Image = BitmapToImageSource(Finalweek.Properties.Resources.Cheese);
            pData5.LargeImage = BitmapToImageSource(Finalweek.Properties.Resources.Cheese);
            pData5.Image = BitmapToImageSource(Finalweek.Properties.Resources.Cheese);
            pData6.LargeImage = BitmapToImageSource(Finalweek.Properties.Resources.Plate);
            pData6.Image = BitmapToImageSource(Finalweek.Properties.Resources.Plate);
            pData7.LargeImage = BitmapToImageSource(Finalweek.Properties.Resources.Cheese);
            pData7.Image = BitmapToImageSource(Finalweek.Properties.Resources.Cheese);
            pData8.LargeImage = BitmapToImageSource(Finalweek.Properties.Resources.InvG);
            pData8.Image = BitmapToImageSource(Finalweek.Properties.Resources.InvG);
            pData9.LargeImage = BitmapToImageSource(Finalweek.Properties.Resources.InvP);
            pData9.Image = BitmapToImageSource(Finalweek.Properties.Resources.InvP);
            pData10.LargeImage = BitmapToImageSource(Finalweek.Properties.Resources.InvW);
            pData10.Image = BitmapToImageSource(Finalweek.Properties.Resources.InvW);

            splitData1.LargeImage = BitmapToImageSource(Finalweek.Properties.Resources.Plate);
            splitData1.Image = BitmapToImageSource(Finalweek.Properties.Resources.Plate);
            pullData1.Image = BitmapToImageSource(Finalweek.Properties.Resources.InvOs);
            pullData1.LargeImage = BitmapToImageSource(Finalweek.Properties.Resources.InvOs);

            //Add tooltips
            pData1.ToolTip = "Moose tip";
            pData2.ToolTip = "Button 2 tool tip";
            splitData1.ToolTip = "Mmm cheese";

            //Create buttons

            //push buttons
            Panel1.AddItem(pData1);
            Panel1.AddItem(pData2);

            //stacked row
            Panel1.AddStackedItems(pData3, pData4, pData5);

            //split button
            SplitButton split1 = Panel1.AddItem(splitData1) as SplitButton;
            split1.AddPushButton(pData6);
            split1.AddPushButton(pData7);

            //pulldown button
            PulldownButton pull1 = Panel1.AddItem(pullData1) as PulldownButton;
            pull1.AddPushButton(pData8);
            pull1.AddPushButton(pData9);
            pull1.AddPushButton(pData10);

            return Result.Succeeded;
        }

        public Result OnShutdown(UIControlledApplication a)
        {
            return Result.Succeeded;
        }

        private string GetAssemblyName()
        {
            string AssemblyName = Assembly.GetExecutingAssembly().Location;
            return AssemblyName;
        }

        //convert images to something Revit likes
        private BitmapImage BitmapToImageSource(Bitmap BMapm)
        {
            using (MemoryStream mem = new MemoryStream())
            {
                BMapm.Save(mem, System.Drawing.Imaging.ImageFormat.Jpeg);
                mem.Position = 0;
                BitmapImage bmi = new BitmapImage();
                bmi.BeginInit();
                bmi.StreamSource = mem;
                bmi.CacheOption = BitmapCacheOption.OnLoad;
                bmi.EndInit();

                return bmi;
            }
        }
    }
}
