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

        public void Initialize(Soldier s, Stat status, Operation operation, int buffValue, int buffDuration)
        {
            InitBuff(
                id: "SoldierStatBuff",
                description: "SoldierStatBuff",
                target: Target.Soldier,
                duration: duration
            );
            soldier = s;
            stat = status;
            ops = operation;
            value = buffValue;
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