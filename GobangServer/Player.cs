//---------------Player.cs-------------//
using System;
namespace GobangServer
{
    class Player
    {
        public User user;     //User类的实例
        public bool started;  //是否已经开始
        public int grade;     //成绩
        public bool someone;  //是否有人坐下
        public Player()
        {
            someone = false;
            started = false;
            grade = 0;
            user = null;
        }
    }
}


