using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IVO_Suite
{
    class IVO
    {
        public class AddValue
        {
            private string m_Display;
            private string m_Value;
            public AddValue(string Display, string Value)
            {
                m_Display = Display;
                m_Value = Value;
            }
            public string Display
            {
                get { return m_Display; }
            }
            public string Value
            {
                get { return m_Value; }
            }
        }

        public class SomeText
        {
            private string s_Text;
            private int s_Len;
            public SomeText(string Text, int T_Len)
            {
                s_Text = Text;
                s_Len = Text.Length;

                s_Text = s_Text.Remove(T_Len, (s_Len - T_Len));

            }
        }
    }
}
