//---------------Player.cs-------------//
using System;
namespace GobangServer
{
    class Player
    {
        public User user;     //User���ʵ��
        public bool started;  //�Ƿ��Ѿ���ʼ
        public int grade;     //�ɼ�
        public bool someone;  //�Ƿ���������
        public Player()
        {
            someone = false;
            started = false;
            grade = 0;
            user = null;
        }
    }
}


