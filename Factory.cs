using System;
using System.Collections.Generic;
using System.Text;
using HanoiFinal.HanoiClasses;

namespace HanoiFinal
{
    static class Factory
    {
        public static Tower GetTower (HanoiTowerType type, int DiscNumber)
        {
            Tower stolp = null;

            switch(type)
            {
                case HanoiTowerType.C4_01:
                    stolp = new C4(0, 1, DiscNumber);
                    break;
                case HanoiTowerType.K4:
                    stolp = new K4(0, 1, DiscNumber);
                    break;
                case HanoiTowerType.P4_01:
                    stolp = new P4(0, 1, DiscNumber);
                    break;
                case HanoiTowerType.P4_12:
                    stolp = new P4(1, 2, DiscNumber);
                    break;
                case HanoiTowerType.P4_23:
                    stolp = new P4(2, 3, DiscNumber);
                    break;
                case HanoiTowerType.P4_31:
                    stolp = new P4(3, 1, DiscNumber);
                    break;
                default:
                    Console.WriteLine("ni definiran");
                    break;
                        
            }

            return stolp;
        }
    }
}
