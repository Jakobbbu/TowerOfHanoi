using System;
using System.Collections.Generic;
using System.Text;
using Hanoi.HanoiClasses;

namespace Hanoi
{
    static class Factory
    {
        public static Tower GetTower (HanoiTowerType type, int discNumber)
        {
            Tower stolp = null;

            switch(type)
            {
                case HanoiTowerType.K13_01:
                    stolp = new K13_01FAST(0, 1, discNumber);
                    break;
                case HanoiTowerType.K13_12:
                    stolp = new K13_12(1, 2, discNumber);
                    break;
                case HanoiTowerType.K13e_01:
                    stolp = new K13e(0, 1, discNumber);
                    break;
                case HanoiTowerType.K13e_12:
                    stolp = new K13e(1, 2, discNumber);
                    break;
                case HanoiTowerType.K13e_23:
                    stolp = new K13e(2, 3, discNumber);
                    break;
                case HanoiTowerType.K13e_30:
                    stolp = new K13e(3, 0, discNumber);
                    break;
                case HanoiTowerType.C4_01:
                    stolp = new C4(0, 1, discNumber);
                    break;
                case HanoiTowerType.C4_12:
                    stolp = new C4(1, 2, discNumber);
                    break;
                case HanoiTowerType.K4:
                    stolp = new K4(0, 1, discNumber);
                    break;
                case HanoiTowerType.P4_01:
                    stolp = new P4(0, 1, discNumber);
                    break;
                case HanoiTowerType.P4_12:
                    stolp = new P4(1, 2, discNumber);
                    break;
                case HanoiTowerType.P4_23:
                    stolp = new P4(2, 3, discNumber);
                    break;
                case HanoiTowerType.P4_31:
                    stolp = new P4(3, 1, discNumber);
                    break;
                case HanoiTowerType.K4e_01:
                    stolp = new K4e(0, 1, discNumber);
                    break;
                case HanoiTowerType.K4e_12:
                    stolp = new K4e(1, 2, discNumber);
                    break;
                case HanoiTowerType.K4e_23:
                    stolp = new K4e(2, 3, discNumber);
                    break;
                default:
                    Console.WriteLine("ni definiran");
                    break;
                        
            }

            return stolp;
        }
    }
}
