using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Collections;





namespace Music_Autocontroller_Win10
{
    /*TODOS
     * 
     * 
     */

    class MusicManager
    {
        List<String> appStrings = new List<String>();
        List<int> appIds = new List<int>();
        public List<int> musicVolumes = new List<int>();
        public int defaultMusicVolume = 100;
        double minAudibleOutput = 6e-5; //min value for what's considered background static
        Guid guid = new Guid();

        public MusicManager()
        {
            updateApps();
        }
        
        public bool containsAppString(String appString)
        {
            foreach (String app in appStrings)
            {
                if (appString.ToCharArray().Length - app.ToCharArray().Length >= -1 && appString.ToCharArray().Length - app.ToCharArray().Length <= 0)
                {
                    if (appString.ToCharArray().Length <= app.ToCharArray().Length && appString.Equals(app.Substring(0, appString.ToCharArray().Length)))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public int getAppStringIndex(String appString)
        {
            int i = 0;
            foreach (String app in appStrings)
            {
                if (appString.ToCharArray().Length - app.ToCharArray().Length >= -1 && appString.ToCharArray().Length - app.ToCharArray().Length <= 0)
                {
                    if (appString.ToCharArray().Length <= app.ToCharArray().Length && appString.Equals(app.Substring(0, appString.ToCharArray().Length)))
                    {
                        return i;
                    }
                }
                i++;
            }
            return -1;
        }

        public void updateApps()
        {
            Process[] processes = MusicManager.GetProcesses();
            IEnumerable<IAudioSessionControl2> soundApps = MusicManager.EnumerateApplications();


            int len = soundApps.Count() + processes.Length;
            int index = 0;

            foreach (IAudioSessionControl2 app in soundApps)
            {
                String dn;
                app.GetDisplayName(out dn);
                int di;
                app.GetProcessId(out di);
                if (!appIds.Contains(di))
                {
                    appIds.Add(di);
                    appStrings.Add(String.Format("App {0}: {1} \n", appIds[index], dn));
                    musicVolumes.Add(100);
                    index++;
                }
            }
            
            for (int i = 0; i < processes.Length; i++)
            {
                if (!appIds.Contains(processes[i].Id))
                {
                    appIds.Add(processes[i].Id);
                    appStrings.Add(String.Format("App {0}: {1} \n", processes[i].Id, processes[i].ProcessName));
                    musicVolumes.Add(100);
                    index++;
                }
            }
        }

        public String[] getAppsStringList() { return appStrings.ToArray(); }

        public Boolean changeAppString(String oldString, String newString)
        {
            if (newString.ToCharArray().Length <= 0) { return false; }
            
                if (containsAppString(newString)) 
                {
                    return false;
                }


            if (containsAppString(oldString))
            {
                    return changeAppString(appIds[getAppStringIndex(oldString)], newString);
            }
            return false;
        }

        public Boolean changeAppString(int id, String newString)
        {
            if (!appIds.Contains(id)) { return false; }
            appStrings[appIds.IndexOf(id)] = newString;
            return true;
        }

        public static Process[] GetProcesses()
        {
            Process[] processlist = Process.GetProcesses();
            int i = 0;
            foreach (Process process in processlist)
            {
                if (!String.IsNullOrEmpty(process.MainWindowTitle))
                {
                    i++;
                }
            }
            Process[] processes = new Process[i];

            i = 0;
            foreach (Process process in processlist)
            {
                if (!String.IsNullOrEmpty(process.MainWindowTitle))
                {
                    processes[i] = process;
                    i++;
                }
            }
            return processes;
        }

        public Boolean getAudioSessionIsMakingNoise(int id)
        {
            return getAudioSessionOutputVolume(id) > minAudibleOutput;
        }

        public Boolean getAudioSessionIsMakingNoise(String appString)
        {
            return getAudioSessionOutputVolume(appString) > minAudibleOutput;
        }

        public Boolean setItemMusicVolume(String appString, int volume, Boolean isPrimaryMusic)
        {
            if (appString == null) { return false; }
            
            if (containsAppString(appString))
            {
                int index = getAppStringIndex(appString);
                return setItemMusicVolume(appIds[index], volume, isPrimaryMusic);
            }
            return false;
        }

        public Boolean setItemMusicVolume(int id, int volume, Boolean isPrimaryMusic)
        {
            if (!appIds.Contains(id)) { return false; }
            if (!isPrimaryMusic) { musicVolumes[appIds.IndexOf(id)] = volume; }

            this.ChangeProgramVolume(id, volume);
            return true;
        }

        public int getItemMusicVolume(String appString)
        {
            if (containsAppString(appString))
            {
                return getItemMusicVolume(appIds[getAppStringIndex(appString)]);
            }
            return -1;
        }

        public int getItemMusicVolume(int id)
        {
            if (!appIds.Contains(id)) { return -1; }
            return musicVolumes[appIds.IndexOf(id)];
        }

        public static IEnumerable<IAudioSessionControl2> EnumerateApplications()
        {
            // get the speakers (1st render + multimedia) device
            IMMDeviceEnumerator deviceEnumerator = (IMMDeviceEnumerator)(new MMDeviceEnumerator());
            IMMDevice speakers;
            deviceEnumerator.GetDefaultAudioEndpoint(EDataFlow.eRender, ERole.eMultimedia, out speakers);

            // activate the session manager. we need the enumerator
            Guid IID_IAudioSessionManager2 = typeof(IAudioSessionManager2).GUID;
            object o;
            speakers.Activate(ref IID_IAudioSessionManager2, 0, IntPtr.Zero, out o);
            IAudioSessionManager2 mgr = (IAudioSessionManager2)o;

            // enumerate sessions for on this device
            IAudioSessionEnumerator sessionEnumerator;
            mgr.GetSessionEnumerator(out sessionEnumerator);
            int count;
            sessionEnumerator.GetCount(out count);

            for (int i = 0; i < count; i++)
            {
                IAudioSessionControl2 ctl;
                sessionEnumerator.GetSession(i, out ctl);
                yield return ctl;
                Marshal.ReleaseComObject(ctl);
            }
            Marshal.ReleaseComObject(sessionEnumerator);
            Marshal.ReleaseComObject(mgr);
            Marshal.ReleaseComObject(speakers);
            Marshal.ReleaseComObject(deviceEnumerator);
        }

        public float getAudioSessionOutputVolume(String appString)
        {
            if (containsAppString(appString))
            {
                return getAudioSessionOutputVolume(appIds[getAppStringIndex(appString)]);
            }
            return 0;
        }

        public float getAudioSessionOutputVolume(int id)
        {
            if (!appIds.Contains(id)) { return 0; }
            float status = VolumeManager.getAudioSessionOutputVolume(id);
            return status;
        }

        public bool ChangeProgramVolume(String appString, float vol)
        {
            if (containsAppString(appString))
            {
                return ChangeProgramVolume(appIds[getAppStringIndex(appString)], vol);
            }
            return false;
        } 

        public bool ChangeProgramVolume(int id, float vol)
        {
            if (!appIds.Contains(id)) { return false; }
            int index = appIds.IndexOf(id);

            ISimpleAudioVolume program = VolumeManager.getAudioObject(id);
            if (program == null) { return false; }
            program.SetMasterVolume(vol/100, ref guid); //TODO: MAKE SURE PROGRAM IS AN ACTUAL PROGRAM, list includes non vol objects
            return true;
        } 

        public float GetProgramVolume(String appString)
        {
            if (containsAppString(appString))
            {
                return GetProgramVolume(appIds[getAppStringIndex(appString)]);
            }
            return -1;
        }

        public float GetProgramVolume(int id)
        {
            if (!appIds.Contains(id)) { return -1; }
            int index = appIds.IndexOf(id);

            ISimpleAudioVolume program = VolumeManager.getAudioObject(id);
            if (program.Equals(null)) { return -1; }
            program.GetMasterVolume(out float hey);
            program.GetMute(out var yasSister);
            return hey;
        }
    }
}
