namespace Auto_M
{
    partial class Auto_M
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Auto_M));
            this.X_pos_label = new System.Windows.Forms.Label();
            this.Y_pos_label = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.log_Label = new System.Windows.Forms.Label();
            this.X_pos = new System.Windows.Forms.Label();
            this.Y_pos = new System.Windows.Forms.Label();
            this.num1_X_pos = new System.Windows.Forms.Label();
            this.num1_Y_pos = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.num2_Y_pos = new System.Windows.Forms.Label();
            this.num2_X_pos = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.Poslist = new System.Windows.Forms.ListBox();
            this.delaybox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.deletebutton = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.changebutton = new System.Windows.Forms.Button();
            this.name_change = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // X_pos_label
            // 
            this.X_pos_label.AutoSize = true;
            this.X_pos_label.Location = new System.Drawing.Point(14, 47);
            this.X_pos_label.Name = "X_pos_label";
            this.X_pos_label.Size = new System.Drawing.Size(44, 12);
            this.X_pos_label.TabIndex = 0;
            this.X_pos_label.Text = "x좌표 :";
            // 
            // Y_pos_label
            // 
            this.Y_pos_label.AutoSize = true;
            this.Y_pos_label.Location = new System.Drawing.Point(14, 74);
            this.Y_pos_label.Name = "Y_pos_label";
            this.Y_pos_label.Size = new System.Drawing.Size(44, 12);
            this.Y_pos_label.TabIndex = 1;
            this.Y_pos_label.Text = "y좌표 :";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "-현재 마우스 좌표-";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(129, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 12);
            this.label2.TabIndex = 5;
            this.label2.Text = "-1번 마우스좌표-";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(131, 47);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 12);
            this.label3.TabIndex = 6;
            this.label3.Text = "x좌표 :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(131, 73);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 12);
            this.label4.TabIndex = 7;
            this.label4.Text = "y좌표 :";
            // 
            // log_Label
            // 
            this.log_Label.AutoSize = true;
            this.log_Label.Location = new System.Drawing.Point(14, 261);
            this.log_Label.Name = "log_Label";
            this.log_Label.Size = new System.Drawing.Size(25, 12);
            this.log_Label.TabIndex = 10;
            this.log_Label.Text = "null";
            // 
            // X_pos
            // 
            this.X_pos.Location = new System.Drawing.Point(64, 47);
            this.X_pos.Name = "X_pos";
            this.X_pos.Size = new System.Drawing.Size(38, 15);
            this.X_pos.TabIndex = 11;
            this.X_pos.Text = "0";
            // 
            // Y_pos
            // 
            this.Y_pos.AutoSize = true;
            this.Y_pos.Location = new System.Drawing.Point(64, 74);
            this.Y_pos.Name = "Y_pos";
            this.Y_pos.Size = new System.Drawing.Size(11, 12);
            this.Y_pos.TabIndex = 12;
            this.Y_pos.Text = "0";
            // 
            // num1_X_pos
            // 
            this.num1_X_pos.Location = new System.Drawing.Point(181, 47);
            this.num1_X_pos.Name = "num1_X_pos";
            this.num1_X_pos.Size = new System.Drawing.Size(47, 17);
            this.num1_X_pos.TabIndex = 13;
            this.num1_X_pos.Text = "0";
            // 
            // num1_Y_pos
            // 
            this.num1_Y_pos.AutoSize = true;
            this.num1_Y_pos.Location = new System.Drawing.Point(181, 73);
            this.num1_Y_pos.Name = "num1_Y_pos";
            this.num1_Y_pos.Size = new System.Drawing.Size(11, 12);
            this.num1_Y_pos.TabIndex = 14;
            this.num1_Y_pos.Text = "0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(11, 282);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(286, 12);
            this.label5.TabIndex = 15;
            this.label5.Text = "좌표 저장 - F1    좌표 선택 - F3    좌표 초기화 - F2";
            // 
            // timer2
            // 
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // num2_Y_pos
            // 
            this.num2_Y_pos.AutoSize = true;
            this.num2_Y_pos.Location = new System.Drawing.Point(286, 73);
            this.num2_Y_pos.Name = "num2_Y_pos";
            this.num2_Y_pos.Size = new System.Drawing.Size(11, 12);
            this.num2_Y_pos.TabIndex = 20;
            this.num2_Y_pos.Text = "0";
            // 
            // num2_X_pos
            // 
            this.num2_X_pos.Location = new System.Drawing.Point(286, 47);
            this.num2_X_pos.Name = "num2_X_pos";
            this.num2_X_pos.Size = new System.Drawing.Size(32, 17);
            this.num2_X_pos.TabIndex = 19;
            this.num2_X_pos.Text = "0";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(236, 73);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(44, 12);
            this.label8.TabIndex = 18;
            this.label8.Text = "y좌표 :";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(236, 47);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(44, 12);
            this.label9.TabIndex = 17;
            this.label9.Text = "x좌표 :";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(234, 21);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(99, 12);
            this.label10.TabIndex = 16;
            this.label10.Text = "-2번 마우스좌표-";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(11, 303);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(164, 12);
            this.label6.TabIndex = 21;
            this.label6.Text = "오토마우스 실행 및 종료 - F4";
            // 
            // Poslist
            // 
            this.Poslist.FormattingEnabled = true;
            this.Poslist.ItemHeight = 12;
            this.Poslist.Location = new System.Drawing.Point(16, 119);
            this.Poslist.Name = "Poslist";
            this.Poslist.Size = new System.Drawing.Size(79, 88);
            this.Poslist.TabIndex = 22;
            this.Poslist.SelectedIndexChanged += new System.EventHandler(this.Poslist_SelectedIndexChanged);
            // 
            // delaybox
            // 
            this.delaybox.Location = new System.Drawing.Point(128, 119);
            this.delaybox.Name = "delaybox";
            this.delaybox.Size = new System.Drawing.Size(100, 21);
            this.delaybox.TabIndex = 23;
            this.delaybox.TextChanged += new System.EventHandler(this.delaybox_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(128, 104);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(103, 12);
            this.label7.TabIndex = 24;
            this.label7.Text = "딜레이 (1/1000초)";
            // 
            // deletebutton
            // 
            this.deletebutton.Location = new System.Drawing.Point(128, 184);
            this.deletebutton.Name = "deletebutton";
            this.deletebutton.Size = new System.Drawing.Size(100, 23);
            this.deletebutton.TabIndex = 25;
            this.deletebutton.Text = "선택좌표삭제";
            this.deletebutton.UseVisualStyleBackColor = true;
            this.deletebutton.Click += new System.EventHandler(this.deletebutton_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(14, 104);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(81, 12);
            this.label11.TabIndex = 26;
            this.label11.Text = "-좌표 리스트-";
            // 
            // changebutton
            // 
            this.changebutton.Location = new System.Drawing.Point(128, 213);
            this.changebutton.Name = "changebutton";
            this.changebutton.Size = new System.Drawing.Size(100, 23);
            this.changebutton.TabIndex = 27;
            this.changebutton.Text = "이름바꾸기";
            this.changebutton.UseVisualStyleBackColor = true;
            this.changebutton.Click += new System.EventHandler(this.changebutton_Click);
            // 
            // name_change
            // 
            this.name_change.Location = new System.Drawing.Point(16, 213);
            this.name_change.Name = "name_change";
            this.name_change.Size = new System.Drawing.Size(79, 21);
            this.name_change.TabIndex = 28;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(286, 305);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(61, 12);
            this.label12.TabIndex = 29;
            this.label12.Text = "-버전 5.0-";
            // 
            // Auto_M
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(355, 326);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.name_change);
            this.Controls.Add(this.changebutton);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.deletebutton);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.delaybox);
            this.Controls.Add(this.Poslist);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.num2_Y_pos);
            this.Controls.Add(this.num2_X_pos);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.num1_Y_pos);
            this.Controls.Add(this.num1_X_pos);
            this.Controls.Add(this.Y_pos);
            this.Controls.Add(this.X_pos);
            this.Controls.Add(this.log_Label);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Y_pos_label);
            this.Controls.Add(this.X_pos_label);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Auto_M";
            this.Text = "이것이 오토인지 뭔지 그런거냐?";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_Closing);
            this.Load += new System.EventHandler(this.Auto_M_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label X_pos_label;
        private System.Windows.Forms.Label Y_pos_label;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label log_Label;
        private System.Windows.Forms.Label X_pos;
        private System.Windows.Forms.Label Y_pos;
        private System.Windows.Forms.Label num1_X_pos;
        private System.Windows.Forms.Label num1_Y_pos;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Label num2_Y_pos;
        private System.Windows.Forms.Label num2_X_pos;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label6;
        public System.Windows.Forms.ListBox Poslist;
        private System.Windows.Forms.TextBox delaybox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button deletebutton;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button changebutton;
        private System.Windows.Forms.TextBox name_change;
        private System.Windows.Forms.Label label12;
    }
}

