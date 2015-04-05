//------Service.cs----------//
using System;
using System.Windows.Forms;
using System.IO;
namespace Gobang
{
    class Service
    {
        ListBox listbox;
        StreamWriter sw;
        public Service(ListBox listbox, StreamWriter sw)
        {
            this.listbox = listbox;
            this.sw = sw;
        }
        public void SendToServer(string str)
        {
            try
            {
                sw.WriteLine(str);
                sw.Flush();
            }
            catch
            {
                SetListBox("·¢ËÍÊý¾ÝÊ§°Ü");
            }
        }
        delegate void ListBoxCallback(string str);
        public void SetListBox(string str)
        {
            if (listbox.InvokeRequired == true)
            {
                ListBoxCallback d = new ListBoxCallback(SetListBox);
                try
                {
                    listbox.Invoke(d, str);
                }
                catch (Exception) {
                    return;
                }
            }
            else
            {
                listbox.Items.Add(str);
                listbox.SelectedIndex = listbox.Items.Count - 1;
                listbox.ClearSelected();
            }
        }
    }
}