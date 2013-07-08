using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreatureReactor
{
    public class RawScriptData
    {

        public string creatureName;
        public string creatureRace;
        //[TALK]
        List<string> desiresConversationWith = new List<string>();

        //[JUDGE]
        string trust = "";
        List<string> dontTrust = new List<string>();

        //[GROUP]
        
        //[COMBAT]
        List<string> needs = new List<string>();
        string attackVector = "";
        string attackTarget = "";
        string attackGoal = "";

        public void addSpeakingDesire(string race)
        {
            if (!desiresConversationWith.Contains(race))
            {
                if (race == creatureRace)
                    desiresConversationWith.Add("IS_SAME_RACE");
                desiresConversationWith.Add(race);
            }
        }
        public void removeSpeakingDesire(string race)
        {
            if (desiresConversationWith.Contains(race))
                desiresConversationWith.Remove(race);
        }

        public void addDistrustWho(string race)
        {
            if(!dontTrust.Contains(race))
                dontTrust.Add(race);
        }

        public void removeDistrustWho(string race)
        {
            if(dontTrust.Contains(race))
                dontTrust.Remove(race);
        }

        public void addCombatEntranceNeeds(string need)
        {
            if (!needs.Contains(need))
                needs.Add(need);
        }

        public void removeCombatEntranceNeeds(string need)
        {
            if (needs.Contains(need))
                needs.Remove(need);
        }

        public void setTarget(string target)
        {
            attackTarget = target;
        }

        public void setGoal(string goal)
        {
            attackGoal = goal;
        }

        //debug use only! Don't even think about using this for anything else.

        public string displayInfo()
        {
            string talk = "[TALK] \n ";
            foreach (string dcw in desiresConversationWith)
            {
                talk += dcw + " \n ";
            }

            string judge = "[JUDGE] \n";
            foreach (string dt in dontTrust)
            {
                judge += dt + " \n ";
            }

            string combat = "[COMBAT]";
            foreach (string need in needs)
            {
                combat += need + " \n ";
            }
            combat += attackVector + "\n" + attackTarget + "\n" + attackGoal;

            return creatureName + "\n" + creatureRace + "\n" + talk + judge + combat;
        }

        public void createDatFile()
        {
            //Create [TALK]
            string talk = "[TALK] \n DESIRES_CONVERSATION_WITH:";
            foreach (string s in desiresConversationWith)
            {
                if (s == desiresConversationWith.Last())
                    talk += s + "\n";
                else
                    talk += s + ",";
            }
        }

    }
}
