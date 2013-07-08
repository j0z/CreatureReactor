using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
namespace CreatureReactor
{
    public class BodyPartItem
    {
        public BodyPart bodyPart;
        public BodyPart bodyPartParent;
        //public GroupBox bodyItem = new GroupBox();
        public StackPanel panel = new StackPanel();
        public Button editButton = new Button();
        Button addChildButton = new Button();

        public BodyPartItem(string name, BodyPart bodyPart)
        {
            this.bodyPart = bodyPart;

            panel.Orientation = Orientation.Horizontal;
            //bodyItem.Content = panel;

            bodyPart.name = name;
            editButton.Content = bodyPart.name;
            editButton.Click += new RoutedEventHandler(editBodyPart);

            addChildButton.Content = "+ Add Child";
            addChildButton.Click += new RoutedEventHandler(addChild);
            panel.Children.Add(editButton);
            panel.Children.Add(addChildButton);
        }

        private void editBodyPart(object sender, RoutedEventArgs e)
        {
            int index;
            AddBodyPartWindow editPartWindow = new AddBodyPartWindow();



            editPartWindow.edit(bodyPart);
            editPartWindow.ShowDialog();

            MainWindow.bodyPartItems.Find(
                delegate(BodyPartItem item)
                {
                    if (item.bodyPart == this.bodyPart)
                    {
                        return true;
                    }
                    {
                        return false;
                    }
                }).bodyPart = this.bodyPart;

            editButton.Content = bodyPart.name;
            Core.mainWindow.StckPanel_Characteristics.InvalidateVisual();
        }
        private void addChild(object sender, RoutedEventArgs e)
        {
            BodyPart childBodyPart = new BodyPart();
            AddBodyPartWindow addChildWindow = new AddBodyPartWindow();
            addChildWindow.parent = bodyPart;
            addChildWindow.ShowDialog();

            if (addChildWindow.createdPart == true)
            {
                MainWindow.bodyParts.Add(addChildWindow.bodyPart);
                BodyPartItem bodyPartItem = new BodyPartItem(MainWindow.bodyParts.Last().name, addChildWindow.bodyPart);
                MainWindow.bodyPartItems.Add(bodyPartItem);
                Core.mainWindow.addToStackPanel(bodyPartItem);
            }
        }
    }
}
