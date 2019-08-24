using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// [DllImport]를 사용하기 위해 추가한다
using System.Runtime.InteropServices;

namespace Auto_M
{
    public partial class Auto_M : Form
    {
        // winapi 함수를 쓰기 위해 선언함
        [DllImport("user32.dll")]
        public static extern bool GetCursorPos(ref Point point);

        [DllImport("user32.dll")]
        public static extern void SetCursorPos(Int32 x, Int32 y);

        [DllImport("user32.dll")]
        public static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint dwData, int dwExtraInfo);

        // 핫키를 사용하기 위한 winapi 함수
        // 핫키를 등록한다
        [DllImport("user32.dll")]
        public static extern bool RegisterHotKey(IntPtr hWnd, int id, int fsModifiers, int vk);

        // 핫키를 해제한다
        // 해당 핸들의 아이디에 있는 핫키를 해제한다
        [DllImport("user32.dll")]
        public static extern bool UnregisterHotKey(IntPtr hWnd, int id);



        // c# 에서는 C/C++에서 사용하는 #define 을 못쓴다
        // 대신 아래와 같이 상수를 정의한다
        const int WM_HOTKEY = 0x0312;

        public const int F2 = 113;
        public const int F3 = 114;
        public const int F4 = 115;

        public const uint LBUTTONDOWN = 0x0002;
        public const uint LBUTTONUP = 0x0004;

        // 마우스 좌표
        // 좌표에 대한 이름을 저장하기 위해 따로 구조체를 정의하였다
        public struct Pos
        {
            public string name { get; set; }
            public Point point;
        }

        Pos main_point;
        Pos origin_point;
        Pos num1_point;
        Pos num2_point;

        // 오토마우스가 실행되고 있는가
        bool isStart = false;

        // 윈도우 프로시저 콜백 함수
        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);

            // 핫키가 눌러지면 312 정수 메시지를 받게됨 // WM_HOTKEY로 312를 상수정의
            if(m.Msg == WM_HOTKEY)
            {
                // 눌러진 키의 ID가 0이면
                if (m.WParam == (IntPtr)0x0)
                {
                    if(!isStart)
                    {
                        isStart = true;

                        log_Label.Text = "오토마우스가 실행되었습니다!";

                        // 원래 있던 마우스 좌표로 이동하기 위해 저장
                        origin_point = main_point;

                        timer2.Start();
                    }
                    else
                    {
                        isStart = false;

                        log_Label.Text = "오토마우스가 종료되었습니다!";

                        timer2.Stop();

                        // 원래 있던 좌표로 이동
                        SetCursorPos(origin_point.point.X, origin_point.point.Y);
                    }
                }
                // 눌러진 키의 ID가 1이면
                else if (m.WParam == (IntPtr)0x1)
                {
                    if (num1_point.point.X == 0 && num1_point.point.Y == 0)
                    {
                        num1_point = main_point;
                        num1_X_pos.Text = num1_point.point.X.ToString();
                        num1_Y_pos.Text = num1_point.point.Y.ToString();

                        log_Label.Text = "첫 번째 좌표가 저장되었습니다!";
                    }
                    else if (num2_point.point.X == 0 && num2_point.point.Y == 0)
                    {
                        num2_point = main_point;
                        num2_X_pos.Text = num2_point.point.X.ToString();
                        num2_Y_pos.Text = num2_point.point.Y.ToString();

                        log_Label.Text = "두 번째 좌표가 저장되었습니다!";
                    }
                }
                // 눌러진 키의 ID가 2이면
                else if (m.WParam == (IntPtr)0x2)
                {
                    num1_point.point.X = 0;
                    num1_point.point.Y = 0;

                    num1_X_pos.Text = num1_point.point.X.ToString();
                    num1_Y_pos.Text = num1_point.point.Y.ToString();

                    num2_point.point.X = 0;
                    num2_point.point.Y = 0;

                    num2_X_pos.Text = num2_point.point.X.ToString();
                    num2_Y_pos.Text = num2_point.point.Y.ToString();

                    log_Label.Text = "모든 좌표가 초기화되었습니다!";
                }
            }
        }

        public Auto_M()
        {
            InitializeComponent();
        }

        private void Auto_M_Load(object sender, EventArgs e)
        {
            main_point.point.X = 0;
            main_point.point.Y = 0;

            num1_point.point.X = 0;
            num1_point.point.Y = 0;

            num2_point.point.X = 0;
            num2_point.point.Y = 0;

            // 핫키를 등록
            // RegisterHotkey(핫키를 입력받을 핸들, id 값, modifer 라고 불리우는 키값(ctrl, alt, shift, winkey 등 조합키, 어떤 키를 누를지)
            // 조합키 - 0x0: 조합키안씀  |  0x1: alt  | 0x2: ctrl  |  0x3: shift
            RegisterHotKey(this.Handle, 0, 0x0, (int)Keys.F4);
            RegisterHotKey(this.Handle, 1, 0x0, (int)Keys.F3);
            RegisterHotKey(this.Handle, 2, 0x0, (int)Keys.F2);

            timer1_Tick(sender, e);
            timer1.Start();
        }

        // 핫키코드로 바꾸기 전 코드 // 키보드 이벤트 함수를 만들어서 메인폼 keyDown에 추가시킨다
        //private void SaveKeyDown_KeyDown(object sender, KeyEventArgs e)
        //{
        //    log_Label.Text = "키보드 이벤트 발생!";

        //    if (e.KeyValue == F3)
        //    {
        //        if (num1_point.X == 0 && num1_point.Y == 0)
        //        {
        //            num1_point = main_point;
        //            num1_X_pos.Text = num1_point.X.ToString();
        //            num1_Y_pos.Text = num1_point.Y.ToString();

        //            log_Label.Text = "첫 번째 좌표가 저장되었습니다!";
        //        }
        //        else if (num2_point.X == 0 && num2_point.Y == 0)
        //        {
        //            num2_point = main_point;
        //            num2_X_pos.Text = num2_point.X.ToString();
        //            num2_Y_pos.Text = num2_point.Y.ToString();

        //            log_Label.Text = "두 번째 좌표가 저장되었습니다!";
        //        }
        //    }
        //    else if (e.KeyValue == F2)
        //    {
        //        num1_point.X = 0;
        //        num1_point.Y = 0;

        //        num1_X_pos.Text = num1_point.X.ToString();
        //        num1_Y_pos.Text = num1_point.Y.ToString();

        //        num2_point.X = 0;
        //        num2_point.Y = 0;

        //        num2_X_pos.Text = num2_point.X.ToString();
        //        num2_Y_pos.Text = num2_point.Y.ToString();

        //        log_Label.Text = "모든 좌표가 초기화되었습니다!";
        //    }
        //    else if (e.KeyValue == F4)
        //    {
        //        if (!isStart)
        //        {
        //            log_Label.Text = "오토마우스가 실행되었습니다!";

        //            isStart = true;
        //            // 타이머 간격
        //            timer2.Interval = 3000;
        //            //timer2_Tick += new EventHandler(timer2_Tick);
        //            timer2.Start();
        //        }
        //        else
        //        {
        //            log_Label.Text = "오토마우스가 종료되었습니다!";
        //            isStart = false;
        //            timer2.Stop();
        //        }
        //    }
        //}

        private void timer1_Tick(object sender, EventArgs e) // 타이머
        {
            GetCursorPos(ref main_point.point);
            X_pos.Text = main_point.point.X.ToString();
            Y_pos.Text = main_point.point.Y.ToString();
        }

        private void timer2_Tick(object sender, EventArgs e) // 타이머2
        {
            // 타이머 일시정지 // 1000밀리초 = 1초
            System.Threading.Thread.Sleep(100);

            SetCursorPos(num1_point.point.X, num1_point.point.Y);
            mouse_event(LBUTTONDOWN, 0, 0, 0, 0);
            mouse_event(LBUTTONUP, 0, 0, 0, 0);

            // 타이머 일시정지
            System.Threading.Thread.Sleep(100);

            SetCursorPos(num2_point.point.X, num2_point.point.Y);
            mouse_event(LBUTTONDOWN, 0, 0, 0, 0);
            mouse_event(LBUTTONUP, 0, 0, 0, 0);
        }

        private void Poslist_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
    }
}

// 핫키가 등록되는 즉시 핫키에 지정된 핸들외에 다른 프로그램들은 해당 키의 입력을 전달받지 못한다
// 익스플로러에서 F5는 새로고침이지만 F5를 핫키로 등록했다면
// F5를 눌러도 새로고침 이라는 기능은 실행되지 않습니다
// 상황에 따라서 의도적으로 이용하거나 신경쓰지 않아도 되겠지만
// 그렇지 않다면 다른 프로그램의 단축키를 피해서 설정하거나 키입력을 다시 돌려주는 등의 해결방안을 신경써야합니다

// 도움이 된 사이트
// https://11cc.tistory.com/10
// https://www.hobbiez.ml/archives/174
