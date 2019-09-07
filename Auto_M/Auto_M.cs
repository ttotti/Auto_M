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

using System.IO;
using System.Collections;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;

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

        public const int F1 = 112;
        public const int F2 = 113;
        public const int F3 = 114;
        public const int F4 = 115;

        public const uint LBUTTONDOWN = 0x0002;
        public const uint LBUTTONUP = 0x0004;

        public const int MAX = 10;

        // 마우스 좌표
        // 좌표에 대한 이름을 저장하기 위해 따로 구조체를 정의하였다
        // 직렬화 할 구조체 혹은 클래스
        [Serializable]
        public struct Pos
        {
            public string name { get; set; }
            public Point point_1;
            public Point point_2;

            // 생성자
            public Pos(string name, Point point_1, Point point_2)
            {
                this.name = name;
                this.point_1 = point_1;
                this.point_2 = point_2;
            }
        }

        Point main_point = new Point(0, 0);
        Point origin_point = new Point(0, 0);
        Pos save_point = new Pos("", new Point(0, 0), new Point(0, 0));

        Pos[] list_point = new Pos[MAX];

        // 딜레이
        int delay = 1000;

        // 오토마우스가 실행되고 있는가
        bool isStart = false;

        List<Pos> list = new List<Pos>();

        // 프로그램 실행 시 저장된 데이터를 불러오기 위한 코드
        public void SetdatFile()
        {
            // 직렬화 전에 파일 스트림을 오픈해준다
            FileStream fs = new FileStream("PointList.dat", FileMode.Create);

            // BinaryFormatter 는 직렬화를 해주는 역할을 한다
            BinaryFormatter formatter = new BinaryFormatter();

            try
            {
                formatter.Serialize(fs, list);
            }
            catch (SerializationException e)
            {
                Console.WriteLine("Failed to serialize. Reason: ", e.Message);
            }
            finally
            {
                fs.Close();
            }
        }

        // dat 파일의 데이터를 불러온다
        public void GetdatFile()
        {
            if(File.Exists("PointList.dat"))
            {
                // 직렬화된 파일을 오픈해 준다
                FileStream fs = new FileStream("PointList.dat", FileMode.Open);

                try
                {
                    BinaryFormatter formatter = new BinaryFormatter();

                    // 직렬화를 해제해준다
                    list = (List<Pos>)formatter.Deserialize(fs);

                    foreach (Pos data in list)
                    {
                        list_point[Poslist.Items.Count] = data;
                        Poslist.Items.Add(list_point[Poslist.Items.Count].name);
                        Console.WriteLine("{0}, {1} {2}", list_point[Poslist.Items.Count - 1].name, list_point[Poslist.Items.Count - 1].point_1, list_point[Poslist.Items.Count - 1].point_2);
                    }
                }
                catch (SerializationException e)
                {
                    Console.WriteLine("Failed to serialize. Reason: " + e.Message);
                    throw;
                }
                finally
                {
                    fs.Close();
                }
            }
            else
            {
                Console.WriteLine("파일이 존재하지 않습니다");
            }
        }

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
                        SetCursorPos(origin_point.X, origin_point.Y);
                    }
                }
                // 눌러진 키의 ID가 1이면
                else if (m.WParam == (IntPtr)0x1)
                {
                    if (save_point.point_1.X == 0 && save_point.point_1.Y == 0)
                    {
                        save_point.point_1 = main_point;
                        num1_X_pos.Text = save_point.point_1.X.ToString();
                        num1_Y_pos.Text = save_point.point_1.Y.ToString();

                        log_Label.Text = "첫 번째 좌표가 저장되었습니다!";
                    }
                    else if (save_point.point_2.X == 0 && save_point.point_2.Y == 0)
                    {
                        save_point.point_2 = main_point;
                        num2_X_pos.Text = save_point.point_2.X.ToString();
                        num2_Y_pos.Text = save_point.point_2.Y.ToString();

                        log_Label.Text = "두 번째 좌표가 저장되었습니다!";
                    }
                }
                // 눌러진 키의 ID가 2이면
                else if (m.WParam == (IntPtr)0x2)
                {
                    save_point.point_1.X = 0;
                    save_point.point_1.Y = 0;

                    num1_X_pos.Text = save_point.point_1.X.ToString();
                    num1_Y_pos.Text = save_point.point_1.Y.ToString();

                    save_point.point_2.X = 0;
                    save_point.point_2.Y = 0;

                    num2_X_pos.Text = save_point.point_2.X.ToString();
                    num2_Y_pos.Text = save_point.point_2.Y.ToString();

                    log_Label.Text = "모든 좌표가 초기화되었습니다!";
                }
                else if(m.WParam == (IntPtr)0x3)
                {
                    if(Poslist.Items.Count < MAX)
                    {
                        int count = Poslist.Items.Count + 1;

                        save_point.name = count.ToString() + "번째 좌표";

                        list_point[Poslist.Items.Count] = save_point;

                        Poslist.Items.Add(list_point[Poslist.Items.Count].name);

                        list.Add(list_point[Poslist.Items.Count - 1]);

                        log_Label.Text = "dat파일에 좌표가 저장되었습니다! 좌표가 저장되었습니다!";
                    }
                    else
                    {
                        log_Label.Text = "더 이상 저장할 수 없습니다!";
                    }
                }
            }
        }

        public Auto_M()
        {
            InitializeComponent();
        }

        // 초기화
        private void Auto_M_Load(object sender, EventArgs e)
        {
            // 핫키를 등록
            // RegisterHotkey(핫키를 입력받을 핸들, id 값, modifer 라고 불리우는 키값(ctrl, alt, shift, winkey 등 조합키, 어떤 키를 누를지)
            // 조합키 - 0x0: 조합키안씀  |  0x1: alt  | 0x2: ctrl  |  0x3: shift
            RegisterHotKey(this.Handle, 0, 0x0, (int)Keys.F4);
            RegisterHotKey(this.Handle, 1, 0x0, (int)Keys.F3);
            RegisterHotKey(this.Handle, 2, 0x0, (int)Keys.F2);
            RegisterHotKey(this.Handle, 3, 0x0, (int)Keys.F1);

            name_change.Text = "이름입력";
            delaybox.Text = delay.ToString();

            timer1_Tick(sender, e);
            timer1.Start();

            GetdatFile();
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
            GetCursorPos(ref main_point);
            X_pos.Text = main_point.X.ToString();
            Y_pos.Text = main_point.Y.ToString();
        }

        // 오토마우스 시작
        private void timer2_Tick(object sender, EventArgs e) // 타이머2
        {
            // 타이머 일시정지 // 1000밀리초 = 1초
            System.Threading.Thread.Sleep(delay);

            SetCursorPos(save_point.point_1.X, save_point.point_1.Y);
            mouse_event(LBUTTONDOWN, 0, 0, 0, 0);
            mouse_event(LBUTTONUP, 0, 0, 0, 0);

            // 타이머 일시정지
            System.Threading.Thread.Sleep(delay);

            SetCursorPos(save_point.point_2.X, save_point.point_2.Y);
            mouse_event(LBUTTONDOWN, 0, 0, 0, 0);
            mouse_event(LBUTTONUP, 0, 0, 0, 0);
        }

        // 선택한 인덱스 출력
        private void Poslist_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Poslist.SelectedItem != null)  
            {
                save_point = list_point[Poslist.SelectedIndex];

                num1_X_pos.Text = save_point.point_1.X.ToString();
                num1_Y_pos.Text = save_point.point_1.Y.ToString();

                num2_X_pos.Text = save_point.point_2.X.ToString();
                num2_Y_pos.Text = save_point.point_2.Y.ToString();

                log_Label.Text = save_point.name + "가 선택되었습니다";            
            }
        }

        // 딜레이 설정
        private void delaybox_TextChanged(object sender, EventArgs e)
        {
            if(delaybox.Text == "")
            {
                delaybox.Text = "0";
            }

            delay = Int32.Parse(delaybox.Text);
        }

        // 선택한 리스트 삭제
        private void deletebutton_Click(object sender, EventArgs e)
        {
            if(Poslist.SelectedItem != null)
            {
                list.RemoveAt(Poslist.SelectedIndex);

                // 배열의 중간을 삭제하는 것이므로 빈곳을 채우기 위해 한 칸씩 밀어서 다시 저장한다(동적 리스트를 사용하면 이럴 필요가 없다)
                for (int index = Poslist.SelectedIndex; index < Poslist.Items.Count - 1; index++)
                {
                    if(index == MAX)
                    {

                    }
                    list_point[index] = list_point[index + 1];
                }

                Poslist.Items.RemoveAt(Poslist.SelectedIndex);
                //Poslist.Items.Remove(Poslist.SelectedIndex);
            }
        }

        // 이름바꾸기 버튼
        private void changebutton_Click(object sender, EventArgs e)
        {
            int Index = 0;

            if (Poslist.SelectedItem != null)
            {
                Index = Poslist.SelectedIndex;

                if(name_change.Text.Length != 0)
                {
                    list_point[Index].name = name_change.Text;
                }

                Poslist.Items.RemoveAt(Index);
                //Poslist.Items.Remove(Index);
                Poslist.Items.Insert(Index, list_point[Index].name);

                list.RemoveAt(Index);
                list.Insert(Index, list_point[Index]);
            }
            else
            {
                MessageBox.Show("저장되어 있는 좌표를 선택해주세요!");
            }
        }

        private void Form_Closing(object sender, FormClosingEventArgs e)
        {
            SetdatFile();
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
