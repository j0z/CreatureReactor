using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreatureReactor
{
    public class BodyPart
    {
        public string name;
        //Flags
        public bool skin;
        public bool bone;
        public bool crucial;
        public List<bool> affects;

        public float damageMod;
        public float bleedMod;

        public bool isLeg;
        public bool isArm;
        public bool isHand;

        BodyPart parent;


        public void newBodyPart(string name, bool skin, bool bone, bool crucial, List<bool> affects, float damageMod, float bleedMod, bool isLeg, bool isArm, bool isHand, BodyPart parent)
        {
            this.name = name;
            this.skin = skin;
            this.bone = bone;
            this.crucial = crucial;
            this.affects = affects;
            this.damageMod = damageMod;
            this.bleedMod = bleedMod;
            this.isLeg = isLeg;
            this.isArm = isArm;
            this.isHand = isHand;
            this.parent = parent;
        }
    }
}
