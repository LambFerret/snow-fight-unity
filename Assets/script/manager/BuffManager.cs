using System;
using System.Collections.Generic;
using script.buff;
using script.command;
using UnityEngine;
using UnityEngine.UI;

namespace script.manager
{
    public class BuffManager : MonoBehaviour
    {
        public static List<Buff> buffs;

        private void Start()
        {
            buffs = new List<Buff>();
        }

        public static void AddBuff(Buff buff)
        {
            buff.ApplyEffect();
            buffs.Add(buff);
        }

        public void StartTurn()
        {
            for(int i = buffs.Count - 1; i >= 0; i--)
            {
                var buff = buffs[i];
                if (buff.duration < 0 || !buff.isActivated)
                {
                    buffs.RemoveAt(i);
                }
                else
                {
                    buff.duration--;
                    if (buff is SoldierStatBuff soldierStatBuff) soldierStatBuff.soldier.ResetStat();
                }
            }
            foreach (var buff in buffs)
            {
                buff.ApplyEffect();
            }
        }
    }
}