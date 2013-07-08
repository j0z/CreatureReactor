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
using System.Windows.Shapes;

namespace CreatureReactor
{
    /// <summary>
    /// Interaction logic for AddBodyPartWindow.xaml
    /// </summary>
    public partial class AddBodyPartWindow : Window
    {
        public BodyPart bodyPart = new BodyPart();
        public BodyPart parent;

        public bool createdPart = false;

        public AddBodyPartWindow(BodyPart parent = null)
        {
            InitializeComponent();
            this.parent = parent;
        }

        public void edit(BodyPart bodyPart)
        {
            //MessageBox.Show("Edit bodypart");
                this.bodyPart = bodyPart;

                TxtBox_Name.Text = this.bodyPart.name;
                ChkBox_Skin.IsChecked = bodyPart.skin;
                ChkBox_Bone.IsChecked = bodyPart.bone;
                ChkBox_Crucial.IsChecked = bodyPart.crucial;
                TxtBox_DmgMod.Text = Convert.ToString(bodyPart.damageMod);
                TxtBox_BleedMod.Text = Convert.ToString(bodyPart.bleedMod);
                ChkBox_AfSight.IsChecked = bodyPart.affects[0];
                ChkBox_AfSmell.IsChecked = bodyPart.affects[1];
                ChkBox_AfHearing.IsChecked = bodyPart.affects[2];
                ChkBox_IsLeg.IsChecked = bodyPart.isLeg;
                ChkBox_IsArm.IsChecked = bodyPart.isArm;
                ChkBox_IsHand.IsChecked = bodyPart.isHand;


        }

        private void Btn_AddPart_Click(object sender, RoutedEventArgs e)
        {
            createBodyPart();
            createdPart = true;
            this.Close();
        }

        private void createBodyPart()
        {
            List<bool> affects = new List<bool>(){
                (bool)ChkBox_AfSight.IsChecked, 
                (bool)ChkBox_AfSmell.IsChecked, 
                (bool)ChkBox_AfHearing.IsChecked};

            bodyPart.newBodyPart(TxtBox_Name.Text, (bool)ChkBox_Skin.IsChecked, (bool)ChkBox_Bone.IsChecked, (bool)ChkBox_Crucial.IsChecked, affects, Convert.ToSingle(TxtBox_DmgMod.Text), Convert.ToSingle(TxtBox_BleedMod.Text), (bool)ChkBox_IsLeg.IsChecked, (bool)ChkBox_IsArm.IsChecked, (bool)ChkBox_IsHand.IsChecked, parent);
        }

        private void Btn_cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
