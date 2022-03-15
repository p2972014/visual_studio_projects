namespace AspNetCoreKafka
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.vsl_btn_send = new System.Windows.Forms.Button();
            this.vsl_txt_send_text = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.vsl_txt_receiveds = new System.Windows.Forms.TextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // vsl_btn_send
            // 
            this.vsl_btn_send.Location = new System.Drawing.Point(12, 12);
            this.vsl_btn_send.Name = "vsl_btn_send";
            this.vsl_btn_send.Size = new System.Drawing.Size(75, 23);
            this.vsl_btn_send.TabIndex = 0;
            this.vsl_btn_send.Text = "send";
            this.vsl_btn_send.UseVisualStyleBackColor = true;
            this.vsl_btn_send.Click += new System.EventHandler(this.vsl_btn_send_Click);
            // 
            // vsl_txt_send_text
            // 
            this.vsl_txt_send_text.Location = new System.Drawing.Point(93, 12);
            this.vsl_txt_send_text.Name = "vsl_txt_send_text";
            this.vsl_txt_send_text.Size = new System.Drawing.Size(620, 23);
            this.vsl_txt_send_text.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "receiveds:";
            // 
            // vsl_txt_receiveds
            // 
            this.vsl_txt_receiveds.Location = new System.Drawing.Point(93, 52);
            this.vsl_txt_receiveds.Multiline = true;
            this.vsl_txt_receiveds.Name = "vsl_txt_receiveds";
            this.vsl_txt_receiveds.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.vsl_txt_receiveds.Size = new System.Drawing.Size(620, 256);
            this.vsl_txt_receiveds.TabIndex = 3;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(725, 320);
            this.Controls.Add(this.vsl_txt_receiveds);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.vsl_txt_send_text);
            this.Controls.Add(this.vsl_btn_send);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button vsl_btn_send;
        private TextBox vsl_txt_send_text;
        private Label label1;
        private TextBox vsl_txt_receiveds;
        private System.Windows.Forms.Timer timer1;
    }
}