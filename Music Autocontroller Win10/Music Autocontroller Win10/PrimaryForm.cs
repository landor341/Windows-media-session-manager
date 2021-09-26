using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace Music_Autocontroller_Win10
{
    public partial class PrimaryForm : Form
    {
        MusicManager myMusicManager = new MusicManager();
        String startedText = "Stop";
        String stoppedText = "Start";
        Boolean isOn = false;
        Timer myTimer;
        int timeCounter;
        int currentExemptIndex = -1;
        double twoSeconds;

        public PrimaryForm()
        {
            InitializeComponent();
            myTimer = new Timer();
            myTimer.Interval = 100;
            twoSeconds = 2000 / myTimer.Interval;
            myTimer.Tick += new EventHandler(this.periodic);
            myTimer.Enabled = true;
            scan();
        }

        private void periodic(object sender, EventArgs e)
        {
            //Changes appStrings if user changes appstring text
            if (currentExemptIndex != -1 && (String) ExemptApps.Items[currentExemptIndex] != DetailedAppTitle.Text)
            {
                updateSelectedAppBox();
            }


            //rescans every 2 seconds as long as user isn't changing an app title
            timeCounter++;
            if (!DetailedAppTitle.Focused && timeCounter % twoSeconds == 0) { scan(); } 

            if (isOn) { soundScan(); }
        }

        private void updateSelectedAppBox()
        {
            ExemptApps.SelectedIndex = currentExemptIndex;
            String newText = DetailedAppTitle.Text;

            bool changed = myMusicManager.changeAppString((String)ExemptApps.Items[currentExemptIndex], newText);
            if (!changed) { return; }

            MusicSelectionBox.Items[currentExemptIndex] = newText;
            ExemptApps.Items[currentExemptIndex] = newText;

        }

        private void soundScan()
        {
            bool foundNoise = false;
            if (ExemptApps.Items.Count != 0)
            {
                for (int x = 0; x < ExemptApps.Items.Count; x++)
                {
                    var obj = ExemptApps.Items[x];
                    String s = obj.ToString();
                    if (s.Length <= 0) { continue; }
                    String appString = (s).Substring(0, (s).Length - 1);

                    //sets all programs to their proper volumes
                    int appVolume = myMusicManager.getItemMusicVolume(appString);
                    bool yeh = true;
                    if ((MusicSelectionBox.SelectedIndex != -1 ? !MusicSelectionBox.SelectedItem.Equals(s) : true)) { yeh = myMusicManager.setItemMusicVolume(appString, appVolume, false); }

                    if (!foundNoise)
                    {
                        //Checks to see that music is selected, it's not an exempt app, and that it is a valid app to check 
                        if ((MusicSelectionBox.SelectedIndex != -1 ? !MusicSelectionBox.SelectedItem.Equals(s) : true) && !ExemptApps.CheckedItems.Contains(s) && myMusicManager.containsAppString(appString))
                        {
                            if (myMusicManager.getAudioSessionIsMakingNoise(appString))
                            {
                                myMusicManager.setItemMusicVolume((String)MusicSelectionBox.SelectedItem, 0, true);
                                foundNoise = true;
                            }
                        }
                    }
                }
                if (!foundNoise) { myMusicManager.setItemMusicVolume((String)MusicSelectionBox.SelectedItem, myMusicManager.defaultMusicVolume, true); }
            }

        }

        private void OnOffButton_Click(object sender, EventArgs e)
        {
            /*
             * Start/stop music scanning
             * Change music text
            */
            
            isOn = !isOn;
            OnOffButton.Text = !isOn ? stoppedText : startedText;
            myMusicManager.setItemMusicVolume((String)MusicSelectionBox.SelectedItem, myMusicManager.defaultMusicVolume, true);
        }

        private void Scan_Click(object sender, EventArgs e)
        {
            /*
             * Used to rescan for programs
             */
            scan();
        }

        private void scan()
        {
            myMusicManager.updateApps();
            fillAppLists(myMusicManager.getAppsStringList());
        }

        private void fillAppLists(String[] apps)
        {
            foreach (String app in apps)
            {
                if (!ExemptApps.Items.Contains(app)) { ExemptApps.Items.Add(app, false); }
                if (!MusicSelectionBox.Items.Contains(app)) { MusicSelectionBox.Items.Add(app); }
            }
        }

        private void AboutButton_Click(object sender, EventArgs e)
        {
            AboutForm settings = new AboutForm();
            settings.ShowDialog();
        }

        private void SettingsButton_Click(object sender, EventArgs e)
        {
            SettingsForm settings = new SettingsForm();
            settings.ShowDialog();
        }

        private void DefaultMusicVolume_ValueChanged(object sender, EventArgs e)
        {
            myMusicManager.defaultMusicVolume = (int) DefaultMusicVolume.Value;
        }

        private void ActiveMusicVolume_ValueChanged(object sender, EventArgs e)
        {
            
            myMusicManager.setItemMusicVolume((String) ExemptApps.SelectedItem, (int) ActiveMusicVolume.Value, false);
        }

        private void IsSelectedExempt_CheckedChanged(object sender, EventArgs e)
        {
            //change the checkbox in the selection box list
            ExemptApps.SetItemChecked(ExemptApps.SelectedIndex, IsSelectedExempt.Checked);
        }

        private void ExemptApps_SelectedIndexChanged(object sender, EventArgs e)
        {
            currentExemptIndex = ExemptApps.SelectedIndex;
            if (currentExemptIndex == -1) { return;  }

            DetailedAppTitle.Text = (String) ExemptApps.SelectedItem;
            IsSelectedExempt.Checked = ExemptApps.GetItemChecked(currentExemptIndex);

            int musicVol = myMusicManager.getItemMusicVolume((String)ExemptApps.SelectedItem);
            ActiveMusicVolume.Value = musicVol == -1 ? 32 : musicVol;
        }
    }
}
