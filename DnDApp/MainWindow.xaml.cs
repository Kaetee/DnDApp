using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DnDApp {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
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
        }

        DeathSaves deathSaves;
        bool inspiration;

        public MainWindow() {
            InitializeComponent();
            deathSaves = new DeathSaves(0, 0);
            inspiration = false;
        }

        private void DiceHitCountUpClick(object sender, RoutedEventArgs e) {
            int diceCount;
            if (Int32.TryParse(dice_hit_count.Text, out diceCount)) {
                dice_hit_count.Text = (diceCount + 1).ToString();
            }
        }

        private void DiceHitCountDownClick(object sender, RoutedEventArgs e) {
            int diceCount;
            if (Int32.TryParse(dice_hit_count.Text, out diceCount)) {
                diceCount--;
                dice_hit_count.Text = (diceCount < 0 ? 0 : diceCount).ToString();
            }
        }

        private void DiceHitSizeUpClick(object sender, RoutedEventArgs e) {
            int diceSize;
            if (Int32.TryParse(dice_hit_size.Text, out diceSize)) {
                dice_hit_size.Text = (diceSize + 1).ToString();
            }
        }

        private void DiceHitSizeDownClick(object sender, RoutedEventArgs e) {
            int diceSize;
            if (Int32.TryParse(dice_hit_size.Text, out diceSize)) {
                diceSize--;
                dice_hit_size.Text = (diceSize < 1 ? 1 : diceSize).ToString();
            }
        }

        private void DiceHitCurrentDown(object sender, RoutedEventArgs e) {
            int diceCurrent;
            if (Int32.TryParse(dice_hit_current.Text, out diceCurrent)) {
                diceCurrent--;
                dice_hit_current.Text = (diceCurrent < 0 ? 0 : diceCurrent).ToString();
            }
        }

        private void DiceHitCurrentUp(object sender, RoutedEventArgs e) {
            int diceCurrent;
            if (Int32.TryParse(dice_hit_current.Text, out diceCurrent)) {
                dice_hit_current.Text = (diceCurrent + 1).ToString();
            }
        }

        private void DrawSuccesses() {
            if (deathSaves.Successes >= 1)
                death_save_success_0.Visibility = Visibility.Visible;
            else
                death_save_success_0.Visibility = Visibility.Hidden;

            if (deathSaves.Successes >= 2)
                death_save_success_1.Visibility = Visibility.Visible;
            else
                death_save_success_1.Visibility = Visibility.Hidden;

            if (deathSaves.Successes >= 3)
                death_save_success_2.Visibility = Visibility.Visible;
            else
                death_save_success_2.Visibility = Visibility.Hidden;
        }

        private void DrawFailures() {
            if (deathSaves.Failures >= 1)
                death_save_fail_0.Visibility = Visibility.Visible;
            else
                death_save_fail_0.Visibility = Visibility.Hidden;

            if (deathSaves.Failures >= 2)
                death_save_fail_1.Visibility = Visibility.Visible;
            else
                death_save_fail_1.Visibility = Visibility.Hidden;

            if (deathSaves.Failures >= 3)
                death_save_fail_2.Visibility = Visibility.Visible;
            else
                death_save_fail_2.Visibility = Visibility.Hidden;
        }

        private void DeathSavesSuccessDown(object sender, RoutedEventArgs e) {
            deathSaves.DecrementSuccesses();
            DrawSuccesses();
        }

        private void DeathSavesSuccessUp(object sender, RoutedEventArgs e) {
            deathSaves.IncrementSuccesses();
            DrawSuccesses();
        }

        private void DeathSavesFailDown(object sender, RoutedEventArgs e) {
            deathSaves.DecrementFailures();
            DrawFailures();
        }

        private void DeathSavesFailUp(object sender, RoutedEventArgs e) {
            deathSaves.IncrementFailures();
            DrawFailures();
        }

        private void ToggleInspiration(object sender, RoutedEventArgs e) {
            inspiration = !inspiration;

            if (inspiration)
                inspirationBox.Visibility = Visibility.Visible;
            else
                inspirationBox.Visibility = Visibility.Hidden;
        }
    }
}
