using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnDApp {
    enum EnumAttributes {
        Strength,
        Dexterity,
        Constitution,
        Intelligence,
        Wisdom,
        Charisma
    }

    enum EnumCoins {
        Copper,
        Silver,
        Gold,
        Electrum,
        Platinum
    }

    enum EnumSkills {
        Acrobatics,
        AnimalHandling,
        Arcana,
        Athletics,
        Deception,
        History,
        Insight,
        Intimidation,
        Investigation,
        Medicine,
        Nature,
        Perception,
        Performance,
        Persuation,
        Religion,
        SleightOfHand,
        Stealth,
        Survival
    }

    struct HitPoints {
        short maximum;
        short current;
        short temporary;

        HitPoints(short m, short c, short t) {
            maximum = m;
            current = c;
            temporary = t;
        }

        HitPoints(short m) : this(m, m, 0) { }

        void Damage(short points) {
            current -= points;
        }

        void Heal(short points, bool overheal = false) {
            if (overheal) {
                short leftover = (short)(points - (maximum - current));

                if (leftover > 0)
                    temporary += leftover;
            }

            current += points;
            LimitCurrent();
        }

        void LimitCurrent() {
            current = (current > maximum) ? maximum : current;
        }

        void Reset(bool fullReset = false) {
            current = maximum;

            if (fullReset)
                temporary = 0;
        }
    }

    struct HitDice {
        short count;
        short sides;
        short remaining;

        HitDice(short c, short s, short r) {
            count = c;
            sides = s;
            remaining = r;
        }

        HitDice(short c, short s) : this(c, s, c) { }

        void Reset() { remaining = count; }
    }

    struct DeathSaves {
        int successes;
        int failures;

        public DeathSaves(int s, int f) {
            successes = s;
            failures = f;
        }

        public int Successes {
            get { return successes; }
        }

        public int Failures {
            get { return failures; }
        }

        public void IncrementSuccesses() {
            successes += (successes == 3) ? 0 : 1;
        }

        public void DecrementSuccesses() {
            successes -= (successes == 0) ? 0 : 1;
        }

        public void IncrementFailures() {
            failures += (failures == 3) ? 0 : 1;
        }

        public void DecrementFailures() {
            failures -= (failures == 0) ? 0 : 1;
        }

        public void ResetSuccesses() { successes = 0; }
        public void ResetFailures() { failures = 0; }
        public void Reset() { ResetSuccesses(); ResetFailures(); }
    }

    partial class Purse {
        int[] coins;

        Purse() {
            coins = new int[5];
        }

        Purse(int[] oldCoins) {
            coins = oldCoins;
            Recalculate();
        }

        Purse(int cp, int sp ,int gp, int ep, int pp) {
            coins = new int[] { cp, sp, gp, ep, pp };
            Recalculate();
        }

        int Copper {
            get { return coins[(int)EnumCoins.Copper]; }
            set {
                coins[(int)EnumCoins.Copper] = value;
                Recalculate();
            }
        }

        int Silver {
            get { return coins[(int)EnumCoins.Silver]; }
            set {
                coins[(int)EnumCoins.Silver] = value;
                Recalculate();
            }
        }

        int Gold {
            get { return coins[(int)EnumCoins.Gold]; }
            set {
                coins[(int)EnumCoins.Gold] = value;
                Recalculate();
            }
        }

        int Electrum {
            get { return coins[(int)EnumCoins.Electrum]; }
            set {
                coins[(int)EnumCoins.Electrum] = value;
                Recalculate();
            }
        }

        int Platinum {
            get { return coins[(int)EnumCoins.Platinum]; }
            set {
                coins[(int)EnumCoins.Platinum] = value;
                Recalculate();
            }
        }

        void Recalculate() {
            int remainder;
            int carrier;

            for (int i = 0; i < coins.Length - 1; i++) {
                remainder = coins[i] % 100;
                carrier = (coins[i] - remainder) / 100;
                coins[i] = remainder;
                coins[i + 1] += carrier;
            }
        }
    }

    struct Item {
        string name;
        string description;
    }

    class Character {
        short[] attributes = new short[6];
        short[] savingThrows = new short[6];
        short[] skills = new short[18];
        bool inspiration;
        bool proficiency;

        short armourClass;
        short initiative;
        short speed;
        HitPoints hitPoints;
        DeathSaves deathSaves;

        short[] activeAttacks = new short[] { -1, -1, -1 };
        

        Character(HitPoints hp) {
            for (int i = 0; i < attributes.Length; i++) {
                attributes[i] = 0;
            }

            for (int i = 0; i < skills.Length; i++) {
                skills[i] = 0;
            }

            hitPoints = hp;
        }
    }
}
