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

namespace CreatureReactor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static RawScriptData scriptData = new RawScriptData();

        public static Core core = new Core();

        //public static string creatureName = "Creature";
        //public static string creatureRace = "creature";
        public List<string> limbs = new List<string>();

        public static List<BodyPart> bodyParts = new List<BodyPart>();
        public static List<BodyPartItem> bodyPartItems = new List<BodyPartItem>();


        private CreatureWriter writer = new CreatureWriter();
        public MainWindow()
        {
            InitializeComponent();
            core.SetWindow(this);
        }

        private void editName(object sender, RoutedEventArgs e)
        {
            NameEditWindow nameEditWindow = new NameEditWindow();
            nameEditWindow.Owner = this;
            nameEditWindow.ShowDialog();
            Lbl_CreatureName.Content = scriptData.creatureName;
           // Lbl_CreatureName.
        }

        private void desiresToSpeakSameRace(object sender, RoutedEventArgs e)
        {
            scriptData.addSpeakingDesire(scriptData.creatureRace);
        }

        private void addRaces(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                scriptData.addSpeakingDesire(TxtBox_RaceNames.Text);
            }
        }

        private void addDistrustsAllButSameRace(object sender, RoutedEventArgs e)
        {
            scriptData.addDistrustWho("!IS_SAME_RACE");
        }

        private void removeDistrustsAllButSameRace(object sender, RoutedEventArgs e)
        {
            scriptData.removeDistrustWho("!IS_SAME_RACE");
        }

        private void addAbletoBite(object sender, RoutedEventArgs e)
        {
            scriptData.addCombatEntranceNeeds("CAN_BITE");
        }

        private void removeAbletoBite(object sender, RoutedEventArgs e)
        {
            scriptData.removeCombatEntranceNeeds("CAN_BITE");
        }

        private void addIsHealthy(object sender, RoutedEventArgs e)
        {
            scriptData.addCombatEntranceNeeds("IS_HEALTHY");
        }

        private void removeIsHealthy(object sender, RoutedEventArgs e)
        {
            scriptData.removeCombatEntranceNeeds("IS_HEALTHY");
        }


        //These need to be finished-----------------------
        private void addAttackVectorLimb(object sender, RoutedEventArgs e)
        {
            CBox_LimbAttack.IsEnabled = true;
        }

        private void removeAttackVectorLimb(object sender, RoutedEventArgs e)
        {
            CBox_LimbAttack.IsEnabled = false;
        }

        private void setTarget(object sender, SelectionChangedEventArgs e)
        {
            scriptData.setTarget(CBox_TargetSelect.SelectedValue.ToString());
        }

        private void setGoal(object sender, SelectionChangedEventArgs e)
        {
            scriptData.setGoal(CBox_AttackGoal.SelectedItem.ToString());
        }

        private void showDebugData(object sender, RoutedEventArgs e)
        {
            writer.SerializeToXML(scriptData);
            MessageBox.Show(writer.final);
        }

        //-------------------------------

        //Physical Characteristics Tab

        private void Btn_NewPart_Click(object sender, RoutedEventArgs e)
        {
            AddBodyPartWindow addBodyPart = new AddBodyPartWindow();
            addBodyPart.Owner = this;
            addBodyPart.ShowDialog();

            if (addBodyPart.createdPart == true)
            {
                bodyParts.Add(addBodyPart.bodyPart);
                BodyPartItem bodyPartItem = new BodyPartItem(bodyParts.Last().name, addBodyPart.bodyPart);
                bodyPartItems.Add(bodyPartItem);
                addToStackPanel(bodyPartItem);
            }
        }

        public void addToStackPanel(BodyPartItem item)
        {
            StckPanel_Characteristics.Children.Add(item.panel);
        }
    }
}
