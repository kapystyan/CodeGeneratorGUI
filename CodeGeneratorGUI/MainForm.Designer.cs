namespace CodeGeneratorGUI
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            GroupBox groupBox1;
            Label label8;
            Label label7;
            Label label6;
            Label label5;
            Label label4;
            Label label3;
            Label label2;
            Label label1;
            ToolTip _memo;
            _codePrefix = new TextBox();
            _clearTerminal = new Button();
            _terminal = new TextBox();
            _start = new Button();
            _codeLenght = new TextBox();
            _listLenght = new TextBox();
            _symbolWhiteList = new TextBox();
            _isAddToCodeList = new CheckBox();
            _copyViewport = new Button();
            _viewport = new TextBox();
            _clearViewport = new Button();
            groupBox1 = new GroupBox();
            label8 = new Label();
            label7 = new Label();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            _memo = new ToolTip(components);
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.BackColor = Color.FromArgb(43, 139, 223);
            groupBox1.Controls.Add(label8);
            groupBox1.Controls.Add(_codePrefix);
            groupBox1.Controls.Add(label7);
            groupBox1.Controls.Add(_clearTerminal);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(_terminal);
            groupBox1.Controls.Add(_start);
            groupBox1.Controls.Add(_codeLenght);
            groupBox1.Controls.Add(_listLenght);
            groupBox1.Controls.Add(_symbolWhiteList);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.FlatStyle = FlatStyle.Flat;
            groupBox1.ForeColor = Color.White;
            groupBox1.Location = new Point(556, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(232, 426);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "настройки";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(97, 138);
            label8.Name = "label8";
            label8.Size = new Size(12, 15);
            label8.TabIndex = 19;
            label8.Text = "?";
            _memo.SetToolTip(label8, "Префикс перед кодом");
            // 
            // _codePrefix
            // 
            _codePrefix.BackColor = Color.FromArgb(17, 68, 115);
            _codePrefix.BorderStyle = BorderStyle.None;
            _codePrefix.ForeColor = Color.White;
            _codePrefix.Location = new Point(115, 138);
            _codePrefix.Name = "_codePrefix";
            _codePrefix.Size = new Size(111, 16);
            _codePrefix.TabIndex = 18;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(6, 138);
            label7.Name = "label7";
            label7.Size = new Size(60, 15);
            label7.TabIndex = 17;
            label7.Text = "Префикс";
            // 
            // _clearTerminal
            // 
            _clearTerminal.BackColor = Color.FromArgb(17, 68, 115);
            _clearTerminal.BackgroundImage = Properties.Resources.trashbox;
            _clearTerminal.BackgroundImageLayout = ImageLayout.Stretch;
            _clearTerminal.FlatStyle = FlatStyle.Popup;
            _clearTerminal.Location = new Point(203, 220);
            _clearTerminal.Name = "_clearTerminal";
            _clearTerminal.Size = new Size(23, 23);
            _clearTerminal.TabIndex = 16;
            _clearTerminal.UseVisualStyleBackColor = false;
            _clearTerminal.Click += ClearTerminal_BT_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(97, 116);
            label6.Name = "label6";
            label6.Size = new Size(12, 15);
            label6.TabIndex = 15;
            label6.Text = "?";
            _memo.SetToolTip(label6, "Длинна кода может составять от 4 до 64 символов");
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(97, 95);
            label5.Name = "label5";
            label5.Size = new Size(12, 15);
            label5.TabIndex = 14;
            label5.Text = "?";
            _memo.SetToolTip(label5, "Количество кодов от 1 до 1024");
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(97, 25);
            label4.Name = "label4";
            label4.Size = new Size(12, 15);
            label4.TabIndex = 13;
            label4.Text = "?";
            _memo.SetToolTip(label4, "Список символов для генератора");
            // 
            // _terminal
            // 
            _terminal.BackColor = Color.FromArgb(17, 68, 115);
            _terminal.BorderStyle = BorderStyle.None;
            _terminal.Font = new Font("Segoe UI", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 204);
            _terminal.ForeColor = Color.Yellow;
            _terminal.Location = new Point(6, 220);
            _terminal.Multiline = true;
            _terminal.Name = "_terminal";
            _terminal.PlaceholderText = "терминал";
            _terminal.ReadOnly = true;
            _terminal.ScrollBars = ScrollBars.Vertical;
            _terminal.Size = new Size(220, 171);
            _terminal.TabIndex = 12;
            // 
            // _start
            // 
            _start.BackColor = Color.FromArgb(0, 24, 150);
            _start.FlatAppearance.BorderColor = Color.Red;
            _start.FlatAppearance.BorderSize = 0;
            _start.FlatStyle = FlatStyle.Flat;
            _start.Location = new Point(6, 397);
            _start.Name = "_start";
            _start.Size = new Size(220, 23);
            _start.TabIndex = 8;
            _start.Text = "Старт";
            _start.UseVisualStyleBackColor = false;
            _start.Click += Start_BT_Click;
            // 
            // _codeLenght
            // 
            _codeLenght.BackColor = Color.FromArgb(17, 68, 115);
            _codeLenght.BorderStyle = BorderStyle.None;
            _codeLenght.ForeColor = Color.White;
            _codeLenght.Location = new Point(115, 116);
            _codeLenght.MaxLength = 2;
            _codeLenght.Name = "_codeLenght";
            _codeLenght.Size = new Size(111, 16);
            _codeLenght.TabIndex = 7;
            _codeLenght.KeyPress += TextBox_TextChanged;
            // 
            // _listLenght
            // 
            _listLenght.BackColor = Color.FromArgb(17, 68, 115);
            _listLenght.BorderStyle = BorderStyle.None;
            _listLenght.ForeColor = Color.White;
            _listLenght.Location = new Point(115, 94);
            _listLenght.MaxLength = 4;
            _listLenght.Name = "_listLenght";
            _listLenght.Size = new Size(111, 16);
            _listLenght.TabIndex = 6;
            _listLenght.KeyPress += TextBox_TextChanged;
            // 
            // _symbolWhiteList
            // 
            _symbolWhiteList.BackColor = Color.FromArgb(17, 68, 115);
            _symbolWhiteList.BorderStyle = BorderStyle.None;
            _symbolWhiteList.ForeColor = Color.White;
            _symbolWhiteList.Location = new Point(115, 22);
            _symbolWhiteList.Multiline = true;
            _symbolWhiteList.Name = "_symbolWhiteList";
            _symbolWhiteList.Size = new Size(111, 66);
            _symbolWhiteList.TabIndex = 4;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(6, 94);
            label3.Name = "label3";
            label3.Size = new Size(76, 15);
            label3.TabIndex = 3;
            label3.Text = "Количество";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(6, 25);
            label2.Name = "label2";
            label2.Size = new Size(62, 15);
            label2.TabIndex = 2;
            label2.Text = "Символы";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 116);
            label1.Name = "label1";
            label1.Size = new Size(51, 15);
            label1.TabIndex = 1;
            label1.Text = "Длинна";
            // 
            // _memo
            // 
            _memo.UseAnimation = false;
            // 
            // _isAddToCodeList
            // 
            _isAddToCodeList.AutoSize = true;
            _isAddToCodeList.ForeColor = Color.White;
            _isAddToCodeList.Location = new Point(12, 15);
            _isAddToCodeList.Name = "_isAddToCodeList";
            _isAddToCodeList.Size = new Size(88, 19);
            _isAddToCodeList.TabIndex = 17;
            _isAddToCodeList.Text = "Добавлять";
            _memo.SetToolTip(_isAddToCodeList, "Стоит ли добавлять коды к уже снегерированным");
            _isAddToCodeList.UseVisualStyleBackColor = true;
            // 
            // _copyViewport
            // 
            _copyViewport.BackColor = Color.FromArgb(0, 19, 77);
            _copyViewport.BackgroundImage = Properties.Resources.copy;
            _copyViewport.BackgroundImageLayout = ImageLayout.Stretch;
            _copyViewport.FlatStyle = FlatStyle.Popup;
            _copyViewport.Location = new Point(106, 12);
            _copyViewport.Name = "_copyViewport";
            _copyViewport.Size = new Size(23, 23);
            _copyViewport.TabIndex = 18;
            _memo.SetToolTip(_copyViewport, "Скопировать в буффер");
            _copyViewport.UseVisualStyleBackColor = false;
            _copyViewport.Click += CopyViewport_Click;
            // 
            // _viewport
            // 
            _viewport.BackColor = Color.FromArgb(0, 19, 77);
            _viewport.BorderStyle = BorderStyle.None;
            _viewport.Font = new Font("Consolas", 9F, FontStyle.Bold, GraphicsUnit.Point, 204);
            _viewport.ForeColor = Color.White;
            _viewport.Location = new Point(12, 41);
            _viewport.Multiline = true;
            _viewport.Name = "_viewport";
            _viewport.PlaceholderText = "вывод";
            _viewport.ReadOnly = true;
            _viewport.ScrollBars = ScrollBars.Vertical;
            _viewport.Size = new Size(538, 397);
            _viewport.TabIndex = 1;
            // 
            // _clearViewport
            // 
            _clearViewport.BackColor = Color.FromArgb(0, 19, 77);
            _clearViewport.BackgroundImage = Properties.Resources.trashbox;
            _clearViewport.BackgroundImageLayout = ImageLayout.Stretch;
            _clearViewport.FlatStyle = FlatStyle.Popup;
            _clearViewport.Location = new Point(527, 12);
            _clearViewport.Name = "_clearViewport";
            _clearViewport.Size = new Size(23, 23);
            _clearViewport.TabIndex = 17;
            _clearViewport.UseVisualStyleBackColor = false;
            _clearViewport.Click += ClearViewport_BT_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(14, 23, 42);
            ClientSize = new Size(800, 450);
            Controls.Add(_copyViewport);
            Controls.Add(_isAddToCodeList);
            Controls.Add(_clearViewport);
            Controls.Add(_viewport);
            Controls.Add(groupBox1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "MainForm";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Code generator GUI";
            FormClosing += MainForm_FormClosing;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox _symbolWhiteList;
        private TextBox _listLenght;
        private Button _start;
        private TextBox _codeLenght;
        private TextBox _viewport;
        private ToolTip _memo;
        private TextBox _terminal;
        private Button _clearTerminal;
        private Button _clearViewport;
        private CheckBox _isAddToCodeList;
        private Button _copyViewport;
        private TextBox _codePrefix;
    }
}
