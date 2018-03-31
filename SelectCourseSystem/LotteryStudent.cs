using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SelectCourseSystem
{
    public class LotteryStudent
    {
        public LotteryStudent() { isSelected = 0; }
        public LotteryStudent(string s, int f, int t)
        {
            this.studentID = s;
            this.flag = f;
            this.isSelected = t;
        }
       public string StudentID
        {
            get { return studentID; }
            set { studentID = value; }
        }
        public int Flag
        {
            get { return flag; }
            set { flag = value; }
        }
        public int IsSelected
        {
            get { return isSelected; }
            set { isSelected = value; }
        }
        private string studentID;
        private int flag, isSelected;
    }
}