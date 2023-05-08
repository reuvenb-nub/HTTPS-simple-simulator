namespace project_https_emulator
{
    partial class Dashboard
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
            btn_ser = new Button();
            btn_cli = new Button();
            SuspendLayout();
            // 
            // btn_ser
            // 
            btn_ser.Location = new Point(101, 91);
            btn_ser.Name = "btn_ser";
            btn_ser.Size = new Size(154, 85);
            btn_ser.TabIndex = 0;
            btn_ser.Text = "Server";
            btn_ser.UseVisualStyleBackColor = true;
            btn_ser.Click += btn_ser_Click;
            // 
            // btn_cli
            // 
            btn_cli.Location = new Point(405, 91);
            btn_cli.Name = "btn_cli";
            btn_cli.Size = new Size(154, 85);
            btn_cli.TabIndex = 1;
            btn_cli.Text = "Client";
            btn_cli.UseVisualStyleBackColor = true;
            btn_cli.Click += btn_cli_Click;
            // 
            // Dashboard
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(684, 271);
            Controls.Add(btn_cli);
            Controls.Add(btn_ser);
            Name = "Dashboard";
            Text = "Form1";
            ResumeLayout(false);
        }

        #endregion

        private Button btn_ser;
        private Button btn_cli;
    }
}