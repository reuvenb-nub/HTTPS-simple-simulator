namespace project_https_emulator
{
    partial class Client
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
            this.MethodComboBox = new System.Windows.Forms.ComboBox();
            this.ResourceTextBox = new System.Windows.Forms.TextBox();
            this.SendButton = new System.Windows.Forms.Button();
            this.ServIPTextBox = new System.Windows.Forms.TextBox();
            this.ServPortTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.RespHeadTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.statusLabel = new System.Windows.Forms.Label();
            this.KeyLabel = new System.Windows.Forms.Label();
            this.ValueLabel = new System.Windows.Forms.Label();
            this.KeyTextBox = new System.Windows.Forms.TextBox();
            this.ValueTextBox = new System.Windows.Forms.TextBox();
            this.SuggestLabel = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.BodyTextBox = new System.Windows.Forms.TextBox();
            this.btn_connect = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // MethodComboBox
            // 
            this.MethodComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MethodComboBox.FormattingEnabled = true;
            this.MethodComboBox.Items.AddRange(new object[] {
            "GET",
            "POST",
            "DELETE"});
            this.MethodComboBox.Location = new System.Drawing.Point(33, 173);
            this.MethodComboBox.Name = "MethodComboBox";
            this.MethodComboBox.Size = new System.Drawing.Size(120, 37);
            this.MethodComboBox.TabIndex = 1;
            this.MethodComboBox.Text = "GET";
            this.MethodComboBox.TextChanged += new System.EventHandler(this.MethodComboBox_TextChanged);
            // 
            // ResourceTextBox
            // 
            this.ResourceTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ResourceTextBox.Location = new System.Drawing.Point(168, 174);
            this.ResourceTextBox.Name = "ResourceTextBox";
            this.ResourceTextBox.Size = new System.Drawing.Size(200, 36);
            this.ResourceTextBox.TabIndex = 2;
            this.ResourceTextBox.Enter += new System.EventHandler(this.ResourceTextBox_Enter);
            this.ResourceTextBox.Leave += new System.EventHandler(this.ResourceTextBox_Leave);
            // 
            // SendButton
            // 
            this.SendButton.BackColor = System.Drawing.Color.Transparent;
            this.SendButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SendButton.Location = new System.Drawing.Point(168, 225);
            this.SendButton.Name = "SendButton";
            this.SendButton.Size = new System.Drawing.Size(109, 43);
            this.SendButton.TabIndex = 3;
            this.SendButton.Text = "SEND";
            this.SendButton.UseVisualStyleBackColor = false;
            this.SendButton.Click += new System.EventHandler(this.SendButton_Click);
            // 
            // ServIPTextBox
            // 
            this.ServIPTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ServIPTextBox.Location = new System.Drawing.Point(168, 79);
            this.ServIPTextBox.Name = "ServIPTextBox";
            this.ServIPTextBox.Size = new System.Drawing.Size(200, 36);
            this.ServIPTextBox.TabIndex = 4;
            // 
            // ServPortTextBox
            // 
            this.ServPortTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ServPortTextBox.Location = new System.Drawing.Point(168, 125);
            this.ServPortTextBox.Name = "ServPortTextBox";
            this.ServPortTextBox.Size = new System.Drawing.Size(90, 36);
            this.ServPortTextBox.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(28, 83);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 29);
            this.label1.TabIndex = 6;
            this.label1.Text = "Server IP";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(28, 129);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(134, 29);
            this.label2.TabIndex = 7;
            this.label2.Text = "Server Port";
            // 
            // RespHeadTextBox
            // 
            this.RespHeadTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RespHeadTextBox.Location = new System.Drawing.Point(407, 98);
            this.RespHeadTextBox.Multiline = true;
            this.RespHeadTextBox.Name = "RespHeadTextBox";
            this.RespHeadTextBox.ReadOnly = true;
            this.RespHeadTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.RespHeadTextBox.Size = new System.Drawing.Size(774, 170);
            this.RespHeadTextBox.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(401, 54);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(123, 29);
            this.label3.TabIndex = 10;
            this.label3.Text = "Response";
            // 
            // statusLabel
            // 
            this.statusLabel.AutoSize = true;
            this.statusLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusLabel.Location = new System.Drawing.Point(741, 57);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(91, 29);
            this.statusLabel.TabIndex = 11;
            this.statusLabel.Text = "Status: ";
            // 
            // KeyLabel
            // 
            this.KeyLabel.AutoSize = true;
            this.KeyLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.KeyLabel.Location = new System.Drawing.Point(99, 232);
            this.KeyLabel.Name = "KeyLabel";
            this.KeyLabel.Size = new System.Drawing.Size(54, 29);
            this.KeyLabel.TabIndex = 12;
            this.KeyLabel.Text = "Key";
            this.KeyLabel.Visible = false;
            // 
            // ValueLabel
            // 
            this.ValueLabel.AutoSize = true;
            this.ValueLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ValueLabel.Location = new System.Drawing.Point(79, 281);
            this.ValueLabel.Name = "ValueLabel";
            this.ValueLabel.Size = new System.Drawing.Size(74, 29);
            this.ValueLabel.TabIndex = 13;
            this.ValueLabel.Text = "Value";
            this.ValueLabel.Visible = false;
            // 
            // KeyTextBox
            // 
            this.KeyTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.KeyTextBox.Location = new System.Drawing.Point(168, 228);
            this.KeyTextBox.Name = "KeyTextBox";
            this.KeyTextBox.Size = new System.Drawing.Size(200, 36);
            this.KeyTextBox.TabIndex = 14;
            this.KeyTextBox.Visible = false;
            // 
            // ValueTextBox
            // 
            this.ValueTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ValueTextBox.Location = new System.Drawing.Point(168, 277);
            this.ValueTextBox.Name = "ValueTextBox";
            this.ValueTextBox.Size = new System.Drawing.Size(200, 36);
            this.ValueTextBox.TabIndex = 15;
            this.ValueTextBox.Visible = false;
            // 
            // SuggestLabel
            // 
            this.SuggestLabel.AutoSize = true;
            this.SuggestLabel.BackColor = System.Drawing.Color.Transparent;
            this.SuggestLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SuggestLabel.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.SuggestLabel.Location = new System.Drawing.Point(230, 180);
            this.SuggestLabel.Name = "SuggestLabel";
            this.SuggestLabel.Size = new System.Drawing.Size(135, 24);
            this.SuggestLabel.TabIndex = 16;
            this.SuggestLabel.Text = "Enter resource";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(401, 308);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 29);
            this.label4.TabIndex = 18;
            this.label4.Text = "Body";
            // 
            // BodyTextBox
            // 
            this.BodyTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BodyTextBox.Location = new System.Drawing.Point(406, 354);
            this.BodyTextBox.Multiline = true;
            this.BodyTextBox.Name = "BodyTextBox";
            this.BodyTextBox.ReadOnly = true;
            this.BodyTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.BodyTextBox.Size = new System.Drawing.Size(774, 380);
            this.BodyTextBox.TabIndex = 17;
            // 
            // btn_connect
            // 
            this.btn_connect.BackColor = System.Drawing.Color.Transparent;
            this.btn_connect.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_connect.Location = new System.Drawing.Point(168, 30);
            this.btn_connect.Name = "btn_connect";
            this.btn_connect.Size = new System.Drawing.Size(153, 43);
            this.btn_connect.TabIndex = 19;
            this.btn_connect.Text = "CONNECT";
            this.btn_connect.UseVisualStyleBackColor = false;
            this.btn_connect.Click += new System.EventHandler(this.btn_connect_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1192, 746);
            this.Controls.Add(this.btn_connect);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.BodyTextBox);
            this.Controls.Add(this.SuggestLabel);
            this.Controls.Add(this.ValueTextBox);
            this.Controls.Add(this.KeyTextBox);
            this.Controls.Add(this.ValueLabel);
            this.Controls.Add(this.KeyLabel);
            this.Controls.Add(this.statusLabel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.RespHeadTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ServPortTextBox);
            this.Controls.Add(this.ServIPTextBox);
            this.Controls.Add(this.SendButton);
            this.Controls.Add(this.ResourceTextBox);
            this.Controls.Add(this.MethodComboBox);
            this.Name = "Form1";
            this.Text = "Client";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox MethodComboBox;
        private System.Windows.Forms.TextBox ResourceTextBox;
        private System.Windows.Forms.Button SendButton;
        private System.Windows.Forms.TextBox ServIPTextBox;
        private System.Windows.Forms.TextBox ServPortTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox RespHeadTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label statusLabel;
        private System.Windows.Forms.Label KeyLabel;
        private System.Windows.Forms.Label ValueLabel;
        private System.Windows.Forms.TextBox KeyTextBox;
        private System.Windows.Forms.TextBox ValueTextBox;
        private System.Windows.Forms.Label SuggestLabel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox BodyTextBox;
        private System.Windows.Forms.Button btn_connect;
    }
}