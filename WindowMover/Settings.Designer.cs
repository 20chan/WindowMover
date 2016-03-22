namespace WindowMover
{
    partial class Settings
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.keySet1 = new WindowMover.KeySet();
            this.keySet2 = new WindowMover.KeySet();
            this.keySet3 = new WindowMover.KeySet();
            this.keySet4 = new WindowMover.KeySet();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // keySet1
            // 
            this.keySet1.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.keySet1.Key = System.Windows.Forms.Keys.None;
            this.keySet1.LabelText = "왼쪽";
            this.keySet1.Location = new System.Drawing.Point(12, 51);
            this.keySet1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.keySet1.Name = "keySet1";
            this.keySet1.Size = new System.Drawing.Size(467, 25);
            this.keySet1.TabIndex = 0;
            // 
            // keySet2
            // 
            this.keySet2.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.keySet2.Key = System.Windows.Forms.Keys.None;
            this.keySet2.LabelText = "오른쪽";
            this.keySet2.Location = new System.Drawing.Point(12, 84);
            this.keySet2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.keySet2.Name = "keySet2";
            this.keySet2.Size = new System.Drawing.Size(467, 25);
            this.keySet2.TabIndex = 1;
            // 
            // keySet3
            // 
            this.keySet3.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.keySet3.Key = System.Windows.Forms.Keys.None;
            this.keySet3.LabelText = "위";
            this.keySet3.Location = new System.Drawing.Point(12, 117);
            this.keySet3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.keySet3.Name = "keySet3";
            this.keySet3.Size = new System.Drawing.Size(467, 25);
            this.keySet3.TabIndex = 2;
            // 
            // keySet4
            // 
            this.keySet4.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.keySet4.Key = System.Windows.Forms.Keys.None;
            this.keySet4.LabelText = "아래";
            this.keySet4.Location = new System.Drawing.Point(12, 150);
            this.keySet4.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.keySet4.Name = "keySet4";
            this.keySet4.Size = new System.Drawing.Size(467, 25);
            this.keySet4.TabIndex = 3;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(373, 182);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(104, 25);
            this.button1.TabIndex = 4;
            this.button1.Text = "완료";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.textBox1.Location = new System.Drawing.Point(164, 8);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(315, 23);
            this.textBox1.TabIndex = 5;
            this.textBox1.Text = "10";
            this.textBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.label1.Location = new System.Drawing.Point(12, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 15);
            this.label1.TabIndex = 6;
            this.label1.Text = "움직이는 간격 : ";
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(489, 217);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.keySet4);
            this.Controls.Add(this.keySet3);
            this.Controls.Add(this.keySet2);
            this.Controls.Add(this.keySet1);
            this.Name = "Settings";
            this.Text = "이래 뵈도 나름 설정창임 ㅋ";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private KeySet keySet1;
        private KeySet keySet2;
        private KeySet keySet3;
        private KeySet keySet4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
    }
}