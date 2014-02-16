using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using System.ComponentModel;
using System.Threading;
using System.Windows.Forms;
using System.IO;
using System.Drawing;

namespace _4Hud
{
    public partial class Form1
    {
        void launchTF2(int w, int h, bool fullscreen, bool hooked)
        {
            string borderless = "-sw";
            string map = "";

            if (hooked && !fullscreen)
            {
                tf2width = w;
                tf2height = h;
                movetf = true;
                Size s = new System.Drawing.Size(w + 10, h + 10);

                transpanel.Location = new Point(transpanel.Location.X + transpanel.Size.Width - w - 10, transpanel.Location.Y + transpanel.Size.Height - h - 10);
                transpanel.Size = s;

                borderless = " -sw -noborder";
            }

            if (!hooked && !fullscreen)
                borderless = " -sw";

            if (tsMaps.Text != "_nomap")
                map = "+map " + tsMaps.Text;

            if (fullscreen)
                borderless = "-full";

            if (File.Exists(settings.GetString("Steam Path")))
            {
                foreach (Process p in Process.GetProcessesByName("hl2"))
                {
                    p.Kill();
                    p.WaitForExit();
                    Thread.Sleep(100);
                }
                try
                {
                    if (hooked && !fullscreen)
                        timerTF2LaunchResize.Start();
                    Process.Start(settings.GetString("Steam Path"), "-applaunch 440 -w " + w + " -h " + h + borderless + " " + settings.GetString("Custom Launch Line") + " " + map);
                }
                catch (Exception exc)
                {
                    MessageBox.Show("Some error happened :€\r\n\r\nMessage:" + exc.Message + "\r\n\r\nSource:" + exc.Source);
                }
            }
            else
            {
                ShowSteamPathDialog();
            }
        }

        public void showSettings()
        {
            showSettings(0);
        }

        public void showSettings(int tabPage)
        {
            if (settingsDialog == null || settingsDialog.IsDisposed)
            {
                settingsDialog = new SettingsDialog(TFKeys, settings);
                settingsDialog.SettingChanged += new SettingsDialog.SettingChangedHandler(SettingChanged);
                settingsDialog.Show(tabPage);
            }
        }


        //unused
        public List<String> HudSort(List<String> lines)
        {
            if (lines.Count > 2)
            {
                lines.RemoveAt(lines.Count - 1);
                lines.RemoveAt(0);
            }

            //string b1 = null;
            //string b2 = null;
            List<String2> L = new List<String2>();
            List<String> L2 = new List<String>();
            List<String> Keys = new List<string> { "controlname", "controlname_minmode", "fieldname", "fieldname_minmode", "{", "visible", "visible_minmode", "enabled", "enabled_minmode", "{", "xpos", "xpos_minmode", "ypos", "ypos_minmode", "zpos", "zpos_minmode", "{", "wide", "wide_minmode", "tall", "tall_minmode", "{", "font", "font_minmode", "fgcolor", "fgcolor_minmode", "fillcolor", "fillcolor_minmode" };

            foreach (string s in Keys)
            {
                if (s == "{")
                    L.Add(new String2("{", ""));
                else
                    L.Add(new String2(s, null));
            }

            foreach (string s in lines)
            {
                if (s.Trim() == "{" || s.Trim() == "}")
                {
                    String A;
                    try
                    {
                        A = s.Split(new char[] { ' ', '\"' }, StringSplitOptions.RemoveEmptyEntries)[0];
                    }
                    catch
                    {
                        A = s.Trim();
                    }
                    bool r = true;
                    for (int i = 0; i < L.Count; ++i)
                    {
                        if (L[i].s1 == A)
                        {
                            L[i].s2 = s;
                            r = false;
                            break;
                        }
                    }
                    if (r)
                    {
                        L2.Add(s);
                    }
                }
                else
                {

                }
            }

            List<String> list = new List<string>();

            //if (b1 != null)
            list.Add("    {");

            foreach (String2 S in L)
            {
                if (S.s2 != null)
                    list.Add(S.s2);
            }
            foreach (String S in L2)
            {
                list.Add(S);
            }

            //if (b2 != null)
            list.Add("    }");

            return list;
        }

        void mover_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (domove == true)
            {
                mover.RunWorkerAsync();
            }
        }

        void mover_DoWork(object sender, DoWorkEventArgs e)
        {
            domove = false;
            var Prc = Process.GetProcessesByName("hl2");
            if (Prc.Length != 0)
            {
                MoveWindow(Prc[0].MainWindowHandle, Location.X - tf2width + Size.Width - 10, Location.Y - tf2height + Size.Height - 10, tf2width, tf2height, true);
            }
        }

        void checker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //throw new NotImplementedException();
        }

        void checker_DoWork(object sender, DoWorkEventArgs e)
        {
            var Prc = Process.GetProcessesByName("hl2");
            RECT winpos = new RECT();
            GetWindowRect(Prc[0].MainWindowHandle, ref winpos);

            while (winpos.Left != Location.X - tf2width + Size.Width - 10)
            {
                Prc = Process.GetProcessesByName("hl2");
                if (!mover.IsBusy)
                    mover.RunWorkerAsync();
                GetWindowRect(Prc[0].MainWindowHandle, ref winpos);
                Thread.Sleep(200);
            }
        }

        void timerTF2CheckClosed_Tick(object sender, EventArgs e)
        {
            if (Process.GetProcessesByName("hl2").Length == 0)
            {
                splitContainer1.Panel2Collapsed = true;
                timerTF2CheckClosed.Stop();
                movetf = false;
            }
        }

        void timerTF2LaunchResize_Tick(object sender, EventArgs e)
        {
            var Prc = Process.GetProcessesByName("hl2");
            if (Prc.Length != 0)
            {
                if (!timerTF2CheckClosed.Enabled)
                    timerTF2CheckClosed.Start();
                movetf = true;

                if (!checker.IsBusy)
                    checker.RunWorkerAsync();

                timerTF2LaunchResize.Stop();
                splitContainer1.Panel2Collapsed = false;
            }
        }
    }
}
