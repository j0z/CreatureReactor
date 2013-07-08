using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreatureReactor
{
    class CreatureWriter
    {
        string race;
        string flags;
        string vars;
        string icon;
        List<string> bodyParts = new List<string>();
        List<string> flagsList = new List<string>();

        public string final;

        public void SerializeToXML(RawScriptData scriptData)
        {
            race = scriptData.creatureName;
            flags = serializeFlags();

            final = flags;
        }

        private string serializeFlags()
        {
            string legs = "";
            string arms = "";
            string hands = "";
            List<BodyPart> legList = MainWindow.bodyParts.FindAll(
                delegate(BodyPart item)
                {
                    if (item.isLeg == true)
                    {
                        return true;
                    }
                    {
                        return false;
                    }
                });
            if (legList.Count > 0)
            {
                legs = "LEGS[";
                foreach (BodyPart leg in legList)
                {
                    legs += leg.name + ",";
                }
                legs = legs.Remove(legs.Length-1);
                legs += "]";
            }

            List<BodyPart> armList = MainWindow.bodyParts.FindAll(
                                delegate(BodyPart item)
                                {
                                    if (item.isArm == true)
                                    {
                                        return true;
                                    }
                                    {
                                        return false;
                                    }
                                });
            if (armList.Count > 0)
            {
                arms = "ARMS[";
                foreach (BodyPart arm in armList)
                {
                    arms += arm.name + ",";
                }
                arms = arms.Remove(arms.Length-1);
                arms += "]";
            }

            List<BodyPart> handList = MainWindow.bodyParts.FindAll(
                                            delegate(BodyPart item)
                                            {
                                                if (item.isHand == true)
                                                {
                                                    return true;
                                                }
                                                {
                                                    return false;
                                                }
                                            });
            if (handList.Count > 0)
            {
                hands = "HANDS[";
                foreach (BodyPart hand in handList)
                {
                    hands += hand.name + ",";
                }
                hands = hands.Remove(hands.Length-1);
                hands += "]";
            }

            flagsList.Add(legs);
            flagsList.Add(arms);
            flagsList.Add(hands);


            return legs + "|" + arms + "|" + hands;
        }
    }
}
