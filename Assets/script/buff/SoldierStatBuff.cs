using script.soldier;
using UnityEngine;

namespace script.buff
{
    public class SoldierStatBuff : Buff
    {
        public Stat stat;
        public Operation ops;
        public int value;
        public Soldier soldier;

        public SoldierStatBuff(Soldier soldier, Stat stat, Operation ops, int value, int duration) : base(
            id: "SoldierStatBuff",
            description: "SoldierStatBuff",
            target: Target.Soldier,
            duration: duration
        )
        {
            this.soldier = soldier;
            this.stat = stat;
            this.ops = ops;
            this.value = value;
        }

        public override void ApplyEffect()
        {
            switch (ops)
            {
                case Operation.Add:
                    switch (stat)
                    {
                        case Stat.RangeX:
                            soldier.rangeX += value;

                            break;
                        case Stat.RangeY:
                            soldier.rangeY += value;
                            break;
                        case Stat.Speed:
                            soldier.speed += value;
                            break;
                        case Stat.RunAwayProbability:
                            soldier.runAwayProbability += value;
                            break;
                    }

                    break;
                case Operation.Multiply:
                    switch (stat)
                    {
                        case Stat.RangeX:
                            soldier.rangeX *= value;
                            break;
                        case Stat.RangeY:
                            soldier.rangeY *= value;
                            break;
                        case Stat.Speed:
                            soldier.speed *= value;
                            break;
                        case Stat.RunAwayProbability:
                            soldier.runAwayProbability *= value;
                            break;
                    }

                    break;
            }

            Debug.Log("SoldierStatBuff: " + stat + " " + ops + " " + value + "\n" + "turn left : " + duration);
        }

        public enum Stat
        {
            RangeX,
            RangeY,
            Speed,
            RunAwayProbability
        }

        public enum Operation
        {
            Add,
            Multiply
        }
    }
}