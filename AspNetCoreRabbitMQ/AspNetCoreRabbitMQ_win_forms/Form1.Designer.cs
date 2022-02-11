namespace AspNetCoreRabbitMQ_win_forms
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
            this.vsl_txt_send = new System.Windows.Forms.TextBox();
            this.vsl_send = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.vsl_received_message = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // vsl_txt_send
            // 
            this.vsl_txt_send.Location = new System.Drawing.Point(12, 12);
            this.vsl_txt_send.Name = "vsl_txt_send";
            this.vsl_txt_send.Size = new System.Drawing.Size(100, 23);
            this.vsl_txt_send.TabIndex = 0;
            // 
            // vsl_send
            // 
            this.vsl_send.Location = new System.Drawing.Point(118, 12);
            this.vsl_send.Name = "vsl_send";
            this.vsl_send.Size = new System.Drawing.Size(75, 23);
            this.vsl_send.TabIndex = 1;
            this.vsl_send.Text = "send";
            this.vsl_send.UseVisualStyleBackColor = true;
            this.vsl_send.Click += new System.EventHandler(this.vsl_send_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 500;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "received message: ";
            // 
            // vsl_received_message
            // 
            this.vsl_received_message.AutoSize = true;
            this.vsl_received_message.Location = new System.Drawing.Point(118, 48);
            this.vsl_received_message.Name = "vsl_received_message";
            this.vsl_received_message.Size = new System.Drawing.Size(0, 15);
            this.vsl_received_message.TabIndex = 3;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.vsl_received_message);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.vsl_send);
            this.Controls.Add(this.vsl_txt_send);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox vsl_txt_send;
        private Button vsl_send;
        private System.Windows.Forms.Timer timer1;
        private Label label1;
        private Label vsl_received_message;
    }
}