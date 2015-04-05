//---------------Service.cs-------------------//
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Net.Sockets;
using System.IO;
namespace GobangServer
{
    class Service
    {
        private ListBox listbox;
        //�����̼߳以����
        private delegate void SetListBoxCallback(string str);
        private SetListBoxCallback setListBoxCallback;
        public Service(ListBox listbox)
        {
            this.listbox = listbox;
            setListBoxCallback = new SetListBoxCallback(SetListBox);
        }
        public void SetListBox(string str)      //ͨ��ί�в��������̴߳����Ŀؼ�����ֹ������
        {
            //�Ƚϵ���SetListBox�������̺߳ʹ���listBox1���߳��Ƿ�ͬһ���߳�
            //������ǣ���listBox1��InvokeRequiredΪtrue
            if (listbox.InvokeRequired)
            {
                //���Ϊtrue����ͨ������ִ��else�еĴ���,��������Ҫ�Ĳ���
                listbox.Invoke(setListBoxCallback, str);
            }
            else
            {
                //���Ϊfalse��ֱ��ִ��
                listbox.Items.Add(str);
                listbox.SelectedIndex = listbox.Items.Count - 1;
                listbox.ClearSelected();
            }
        }
        public void SendToOne(User user, string str)
        {
            try
            {
                user.sw.WriteLine(str);
                user.sw.Flush();
                SetListBox(string.Format("��{0}����{1}", user.userName, str));
            }
            catch
            {
                SetListBox(string.Format("��{0}������Ϣʧ��", user.userName));
            }
        }
        public void SendToBoth(GameTable gameTable, string str)
        {
            for (int i = 0; i < 2; i++)
            {
                if (gameTable.gamePlayer[i].someone == true)
                {
                    SendToOne(gameTable.gamePlayer[i].user, str);
                }
            }
        }
        public void SendToAll(System.Collections.Generic.List<User> userList, string str)
        {
            for (int i = 0; i < userList.Count; i++)
            {
                SendToOne(userList[i], str);
            }
        }
    }
}
