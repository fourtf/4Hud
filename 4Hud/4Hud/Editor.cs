using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace _4Hud
{
    public partial class Form1
    {
        //This allows the SplitFCTB to change settings values
        void editor_ValueChanged(object sender, String name, String value)
        {
            settings.Set(name, value);
        }

        //Save all files
        public void SaveAll()
        {
            foreach (TabContent t in editor1.Tabs)
            {
                if (!t.Saved)
                {
                    t.Saved = true;
                    Console.WriteLine(t.Name);
                    if (editor1.currentTab != t.Name)
                        File.WriteAllText(currentPath + t.Name, t.Text);
                    else
                        File.WriteAllText(currentPath + t.Name, editor1.eText);
                }
            }
            if (editor1.getCurrentTabC() != null && !editor1.currentTabSaved)
            {
                File.WriteAllText(currentPath + editor1.getCurrentTabC().Name, editor1.eText);
                editor1.currentTabSaved = true;
            }
            editor1.DeleteAllAsterisks();

            foreach (TabContent t in editor2.Tabs)
            {
                if (!t.Saved)
                {
                    t.Saved = true;
                    if (editor2.currentTab != t.Name)
                        File.WriteAllText(currentPath + t.Name, t.Text);
                    else
                        File.WriteAllText(currentPath + t.Name, editor2.eText);
                }
            }
            if (editor2.getCurrentTabC() != null && !editor2.currentTabSaved)
            {
                File.WriteAllText(currentPath + editor2.getCurrentTabC().Name, editor2.eText);
                editor2.currentTabSaved = true;
            }
            editor2.DeleteAllAsterisks();
        }

    }
}
