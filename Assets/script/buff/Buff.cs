using UnityEngine;
using UnityEngine.UI;

namespace script.buff
{
    public abstract class Buff
    {
        public Target target;
        public string id;
        public string description;
        public int duration;
        public Image icon;
        public bool isActivated = true;

        protected Buff(
            string id,
            string description,
            Target target,
            int duration
        )
        {
            this.target = target;
            this.id = id;
            this.description = description;
            this.duration = duration;
        }

        public abstract void ApplyEffect();

        public enum Target {Soldier, Command, Others}
    }
}