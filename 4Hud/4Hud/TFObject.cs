using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace _4Hud
{
    public class TFObject
    {
        public Boolean CustomControl;
        public String ID;
        public List<String2> GameMenuParams = new List<String2>();
        public String MainMenuCode;

        public TFObject(String ID)
        {
            this.ID = ID;
            CustomControl = true;
            MainMenuCode = "";
        }

        public TFObject()
        {
            CustomControl = false;
            MainMenuCode = "";
        }

        public int XPos
        {
            get
            {
                foreach (String s in MainMenuCode.Split(new String[]{ Environment.NewLine }, StringSplitOptions.None))
                {
                    if (s.Contains("\"xpos\""))
                    {
                        try
                        {
                            short x;
                            string t = s.TrimEnd(' ', '\"');
                            Int16.TryParse(t.Substring(t.LastIndexOf('\"')+1), out x);
                            return x;
                        }
                        catch { }
                        break;
                    }
                }
                return 0;
            }
        }

        public int YPos
        {
            get
            {
                foreach (String s in MainMenuCode.Split(new String[] { Environment.NewLine }, StringSplitOptions.None))
                {
                    if (s.Contains("\"ypos\""))
                    {
                        try
                        {
                            short x;
                            string t = s.TrimEnd(' ', '\"');
                            Int16.TryParse(t.Substring(t.LastIndexOf('\"') + 1), out x);
                            return x;
                        }
                        catch { }
                        break;
                    }
                }
                return 0;
            }
        }

        public int Wide
        {
            get
            {
                foreach (String s in MainMenuCode.Split(new String[] { Environment.NewLine }, StringSplitOptions.None))
                {
                    if (s.Contains("\"wide\""))
                    {
                        try
                        {
                            short x;
                            string t = s.TrimEnd(' ', '\"');
                            Int16.TryParse(t.Substring(t.LastIndexOf('\"') + 1), out x);
                            return x;
                        }
                        catch { }
                        break;
                    }
                }
                return 0;
            }
        }

        public int Tall
        {
            get
            {
                foreach (String s in MainMenuCode.Split(new String[] { Environment.NewLine }, StringSplitOptions.None))
                {
                    if (s.Contains("\"tall\""))
                    {
                        try
                        {
                            short x;
                            string t = s.TrimEnd(' ', '\"');
                            Int16.TryParse(t.Substring(t.LastIndexOf('\"') + 1), out x);
                            return x;
                        }
                        catch { }
                        break;
                    }
                }
                return 0;
            }
        }

        public ShowInValue ShowIn()
        {
            foreach (String2 s in GameMenuParams)
            {
                if (s.s1 == "OnlyInGame")
                    if (s.s2 == "1")
                        return ShowInValue.InGameOnly;
                    else
                        return ShowInValue.Both;
                else if (s.s2 == "OnlyAtMenu")
                    if (s.s2 == "1")
                        return ShowInValue.MenuOnly;
                    else
                        return ShowInValue.Both;
            }
            return ShowInValue.Both;
        }

        public enum ShowInValue
        {
            Both, MenuOnly, InGameOnly
        }
    }


    public class TFObjectCollection : CollectionBase
    {

        public TFObject this[int index]
        {
            get
            {
                return ((TFObject)List[index]);
            }
            set
            {
                List[index] = value;
            }
        }

        public TFObject this[string ID]
        {
            get
            {
                for (int i = 0; i < List.Count; ++i)
                    if ((List[i] as TFObject).ID == ID)
                        return ((TFObject)List[i]);
                return null;
            }
            set
            {
                for (int i = 0; i < List.Count; ++i)
                    if ((List[i] as TFObject).ID == ID)
                        List[i] = value;
            }
        }

        public int Add(TFObject value)
        {
            return (List.Add(value));
        }

        public int Add(string ID)
        {
            return (List.Add(new TFObject(ID)));
        }

        public int Add()
        {
            return (List.Add(new TFObject()));
        }

        public int IndexOf(TFObject value)
        {
            return (List.IndexOf(value));
        }

        public void Insert(int index, TFObject value)
        {
            List.Insert(index, value);
        }

        public void Remove(TFObject value)
        {
            List.Remove(value);
        }

        public bool Contains(TFObject value)
        {
            return (List.Contains(value));
        }

        protected override void OnInsert(int index, Object value)
        {

        }

        protected override void OnRemove(int index, Object value)
        {

        }

        protected override void OnSet(int index, Object oldValue, Object newValue)
        {

        }

        protected override void OnValidate(Object value)
        {
            if (value.GetType() != typeof(TFObject))
                throw new ArgumentException("value must be of type TFObject.", "value");
        }

        public bool IDExists(string ID)
        {
            foreach (object o in List)
                if ((o as TFObject).ID == ID)
                    return true;
            return false;
        }
    }
}
