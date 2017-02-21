using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Diagnostics;
using System.Windows.Forms;
namespace COMPortTerminal
{
   
    [ global::Microsoft.VisualBasic.CompilerServices.DesignerGenerated() ]
    public partial class MainForm : System.Windows.Forms.Form 
    { 
        
        // Form overrides dispose to clean up the component list.
        [ System.Diagnostics.DebuggerNonUserCode() ]
        protected override void Dispose( bool disposing ) 
        { 
            if ( disposing && components != null ) 
            { 
                components.Dispose(); 
            } 
            base.Dispose( disposing ); 
        } 
        
        
        // Required by the Windows Form Designer
        private System.ComponentModel.IContainer components; 
        
        // NOTE: The following procedure is required by the Windows Form Designer
        // It can be modified using the Windows Form Designer.  
        // Do not modify it using the code editor.
        [ System.Diagnostics.DebuggerStepThrough() ]
        private void InitializeComponent() 
        {
            this.components = new System.ComponentModel.Container();
            this.rtbMonitor = new System.Windows.Forms.RichTextBox();
            this.rtbStatus = new System.Windows.Forms.RichTextBox();
            this.StatusStrip1 = new System.Windows.Forms.StatusStrip();
            this.ToolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.btnPort = new System.Windows.Forms.Button();
            this.btnOpenOrClosePort = new System.Windows.Forms.Button();
            this.tmrLookForPortChanges = new System.Windows.Forms.Timer(this.components);
            this.btnSend = new System.Windows.Forms.Button();
            this.btnDrive = new System.Windows.Forms.Button();
            this.btnHalt = new System.Windows.Forms.Button();
            this.lblDriveCommand = new System.Windows.Forms.Label();
            this.txtVelocity = new System.Windows.Forms.TextBox();
            this.txtRadius = new System.Windows.Forms.TextBox();
            this.txtCommand1 = new System.Windows.Forms.TextBox();
            this.txtCommand2 = new System.Windows.Forms.TextBox();
            this.txtCommand3 = new System.Windows.Forms.TextBox();
            this.txtCommand4 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnFull = new System.Windows.Forms.Button();
            this.btnSafeMode = new System.Windows.Forms.Button();
            this.btnPower = new System.Windows.Forms.Button();
            this.btnQuit = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.btnShutdown = new System.Windows.Forms.Button();
            this.StatusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // rtbMonitor
            // 
            this.rtbMonitor.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbMonitor.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbMonitor.Location = new System.Drawing.Point(12, 328);
            this.rtbMonitor.Name = "rtbMonitor";
            this.rtbMonitor.Size = new System.Drawing.Size(455, 73);
            this.rtbMonitor.TabIndex = 7;
            this.rtbMonitor.Text = "";
            this.rtbMonitor.TextChanged += new System.EventHandler(this.rtbMonitor_TextChanged_1);
            // 
            // rtbStatus
            // 
            this.rtbStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbStatus.BackColor = System.Drawing.SystemColors.Control;
            this.rtbStatus.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbStatus.Location = new System.Drawing.Point(14, 422);
            this.rtbStatus.Margin = new System.Windows.Forms.Padding(5);
            this.rtbStatus.Name = "rtbStatus";
            this.rtbStatus.ReadOnly = true;
            this.rtbStatus.Size = new System.Drawing.Size(453, 50);
            this.rtbStatus.TabIndex = 8;
            this.rtbStatus.Text = "";
            // 
            // StatusStrip1
            // 
            this.StatusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripStatusLabel1});
            this.StatusStrip1.Location = new System.Drawing.Point(0, 486);
            this.StatusStrip1.MinimumSize = new System.Drawing.Size(26, 0);
            this.StatusStrip1.Name = "StatusStrip1";
            this.StatusStrip1.Size = new System.Drawing.Size(487, 37);
            this.StatusStrip1.TabIndex = 9;
            this.StatusStrip1.Text = "StatusStrip1";
            // 
            // ToolStripStatusLabel1
            // 
            this.ToolStripStatusLabel1.AutoSize = false;
            this.ToolStripStatusLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.ToolStripStatusLabel1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ToolStripStatusLabel1.Margin = new System.Windows.Forms.Padding(5);
            this.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1";
            this.ToolStripStatusLabel1.Padding = new System.Windows.Forms.Padding(5);
            this.ToolStripStatusLabel1.Size = new System.Drawing.Size(462, 27);
            this.ToolStripStatusLabel1.Spring = true;
            this.ToolStripStatusLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnPort
            // 
            this.btnPort.AutoSize = true;
            this.btnPort.Location = new System.Drawing.Point(14, 12);
            this.btnPort.Name = "btnPort";
            this.btnPort.Size = new System.Drawing.Size(167, 47);
            this.btnPort.TabIndex = 10;
            this.btnPort.Text = "Port Settings";
            this.btnPort.UseVisualStyleBackColor = true;
            // 
            // btnOpenOrClosePort
            // 
            this.btnOpenOrClosePort.AutoSize = true;
            this.btnOpenOrClosePort.Location = new System.Drawing.Point(207, 12);
            this.btnOpenOrClosePort.Name = "btnOpenOrClosePort";
            this.btnOpenOrClosePort.Size = new System.Drawing.Size(163, 47);
            this.btnOpenOrClosePort.TabIndex = 11;
            this.btnOpenOrClosePort.Text = "Open COM Port";
            this.btnOpenOrClosePort.UseVisualStyleBackColor = true;
            this.btnOpenOrClosePort.Click += new System.EventHandler(this.btnOpenOrClosePort_Click_1);
            // 
            // tmrLookForPortChanges
            // 
            this.tmrLookForPortChanges.Interval = 1000;
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(207, 422);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(75, 23);
            this.btnSend.TabIndex = 12;
            this.btnSend.Text = "Clear Box";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // btnDrive
            // 
            this.btnDrive.Location = new System.Drawing.Point(44, 134);
            this.btnDrive.Name = "btnDrive";
            this.btnDrive.Size = new System.Drawing.Size(75, 23);
            this.btnDrive.TabIndex = 20;
            this.btnDrive.Text = "Drive";
            this.btnDrive.UseVisualStyleBackColor = true;
            this.btnDrive.Click += new System.EventHandler(this.btnDrive_Click);
            // 
            // btnHalt
            // 
            this.btnHalt.Location = new System.Drawing.Point(44, 176);
            this.btnHalt.Name = "btnHalt";
            this.btnHalt.Size = new System.Drawing.Size(75, 23);
            this.btnHalt.TabIndex = 28;
            this.btnHalt.Text = "Halt";
            this.btnHalt.UseVisualStyleBackColor = true;
            this.btnHalt.Click += new System.EventHandler(this.btnHalt_Click);
            // 
            // lblDriveCommand
            // 
            this.lblDriveCommand.AutoSize = true;
            this.lblDriveCommand.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDriveCommand.Location = new System.Drawing.Point(145, 165);
            this.lblDriveCommand.Name = "lblDriveCommand";
            this.lblDriveCommand.Size = new System.Drawing.Size(36, 20);
            this.lblDriveCommand.TabIndex = 33;
            this.lblDriveCommand.Text = "137";
            // 
            // txtVelocity
            // 
            this.txtVelocity.Location = new System.Drawing.Point(218, 137);
            this.txtVelocity.Name = "txtVelocity";
            this.txtVelocity.Size = new System.Drawing.Size(64, 20);
            this.txtVelocity.TabIndex = 34;
            this.txtVelocity.Text = "200";
            // 
            // txtRadius
            // 
            this.txtRadius.Location = new System.Drawing.Point(321, 137);
            this.txtRadius.Name = "txtRadius";
            this.txtRadius.Size = new System.Drawing.Size(64, 20);
            this.txtRadius.TabIndex = 35;
            this.txtRadius.Text = "1000";
            // 
            // txtCommand1
            // 
            this.txtCommand1.Location = new System.Drawing.Point(218, 176);
            this.txtCommand1.Name = "txtCommand1";
            this.txtCommand1.Size = new System.Drawing.Size(29, 20);
            this.txtCommand1.TabIndex = 36;
            this.txtCommand1.Text = "0";
            // 
            // txtCommand2
            // 
            this.txtCommand2.Location = new System.Drawing.Point(253, 176);
            this.txtCommand2.Name = "txtCommand2";
            this.txtCommand2.Size = new System.Drawing.Size(29, 20);
            this.txtCommand2.TabIndex = 37;
            this.txtCommand2.Text = "0";
            // 
            // txtCommand3
            // 
            this.txtCommand3.Location = new System.Drawing.Point(321, 176);
            this.txtCommand3.Name = "txtCommand3";
            this.txtCommand3.Size = new System.Drawing.Size(29, 20);
            this.txtCommand3.TabIndex = 38;
            this.txtCommand3.Text = "0";
            // 
            // txtCommand4
            // 
            this.txtCommand4.Location = new System.Drawing.Point(356, 176);
            this.txtCommand4.Name = "txtCommand4";
            this.txtCommand4.Size = new System.Drawing.Size(29, 20);
            this.txtCommand4.TabIndex = 39;
            this.txtCommand4.Text = "0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(215, 107);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 13);
            this.label1.TabIndex = 40;
            this.label1.Text = "Velocity: +/-500";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(318, 107);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 13);
            this.label2.TabIndex = 41;
            this.label2.Text = "Radius: +/-2000";
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(46, 228);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(43, 23);
            this.btnStart.TabIndex = 42;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(107, 228);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(43, 23);
            this.btnReset.TabIndex = 43;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(167, 228);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(43, 23);
            this.btnStop.TabIndex = 44;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnFull
            // 
            this.btnFull.Location = new System.Drawing.Point(107, 266);
            this.btnFull.Name = "btnFull";
            this.btnFull.Size = new System.Drawing.Size(43, 23);
            this.btnFull.TabIndex = 46;
            this.btnFull.Text = "Full";
            this.btnFull.UseVisualStyleBackColor = true;
            this.btnFull.Click += new System.EventHandler(this.btnFull_Click);
            // 
            // btnSafeMode
            // 
            this.btnSafeMode.Location = new System.Drawing.Point(44, 266);
            this.btnSafeMode.Name = "btnSafeMode";
            this.btnSafeMode.Size = new System.Drawing.Size(44, 23);
            this.btnSafeMode.TabIndex = 48;
            this.btnSafeMode.Text = "Safe";
            this.btnSafeMode.UseVisualStyleBackColor = true;
            this.btnSafeMode.Click += new System.EventHandler(this.btnSafeMode_Click);
            // 
            // btnPower
            // 
            this.btnPower.Location = new System.Drawing.Point(172, 266);
            this.btnPower.Name = "btnPower";
            this.btnPower.Size = new System.Drawing.Size(75, 23);
            this.btnPower.TabIndex = 49;
            this.btnPower.Text = "Power Down";
            this.btnPower.UseVisualStyleBackColor = true;
            this.btnPower.Click += new System.EventHandler(this.btnPower_Click);
            // 
            // btnQuit
            // 
            this.btnQuit.Location = new System.Drawing.Point(14, 422);
            this.btnQuit.Name = "btnQuit";
            this.btnQuit.Size = new System.Drawing.Size(75, 23);
            this.btnQuit.TabIndex = 50;
            this.btnQuit.Text = "Quit";
            this.btnQuit.UseVisualStyleBackColor = true;
            this.btnQuit.Click += new System.EventHandler(this.btnQuit_Click);
            // 
            // btnShutdown
            // 
            this.btnShutdown.Location = new System.Drawing.Point(107, 422);
            this.btnShutdown.Name = "btnShutdown";
            this.btnShutdown.Size = new System.Drawing.Size(75, 23);
            this.btnShutdown.TabIndex = 51;
            this.btnShutdown.Text = "Shutdown";
            this.btnShutdown.UseVisualStyleBackColor = true;
            this.btnShutdown.Click += new System.EventHandler(this.btnShutdown_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(487, 523);
            this.Controls.Add(this.btnShutdown);
            this.Controls.Add(this.btnQuit);
            this.Controls.Add(this.btnPower);
            this.Controls.Add(this.btnSafeMode);
            this.Controls.Add(this.btnFull);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtCommand4);
            this.Controls.Add(this.txtCommand3);
            this.Controls.Add(this.txtCommand2);
            this.Controls.Add(this.txtCommand1);
            this.Controls.Add(this.txtRadius);
            this.Controls.Add(this.txtVelocity);
            this.Controls.Add(this.lblDriveCommand);
            this.Controls.Add(this.btnHalt);
            this.Controls.Add(this.btnDrive);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.btnOpenOrClosePort);
            this.Controls.Add(this.btnPort);
            this.Controls.Add(this.StatusStrip1);
            this.Controls.Add(this.rtbStatus);
            this.Controls.Add(this.rtbMonitor);
            this.MaximumSize = new System.Drawing.Size(2000, 2000);
            this.Name = "MainForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.Text = "COM Port Terminal";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.StatusStrip1.ResumeLayout(false);
            this.StatusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        } 
        
        internal /* TRANSINFO: WithEvents */ System.Windows.Forms.RichTextBox rtbMonitor; 
        internal /* TRANSINFO: WithEvents */ System.Windows.Forms.RichTextBox rtbStatus; 
        internal /* TRANSINFO: WithEvents */ System.Windows.Forms.StatusStrip StatusStrip1; 
        internal /* TRANSINFO: WithEvents */ System.Windows.Forms.ToolStripStatusLabel ToolStripStatusLabel1; 
        internal /* TRANSINFO: WithEvents */ System.Windows.Forms.Button btnPort; 
        internal /* TRANSINFO: WithEvents */ System.Windows.Forms.Button btnOpenOrClosePort; 
        internal /* TRANSINFO: WithEvents */ System.Windows.Forms.Timer tmrLookForPortChanges;
        private Button btnSend;
        private Button btnDrive;
        private Button btnHalt;
        private Label lblDriveCommand;
        private TextBox txtVelocity;
        private TextBox txtRadius;
        private TextBox txtCommand1;
        private TextBox txtCommand2;
        private TextBox txtCommand3;
        private TextBox txtCommand4;
        private Label label1;
        private Label label2;
        private Button btnStart;
        private Button btnReset;
        private Button btnStop;
        private Button btnFull;
        private Button btnSafeMode;
        private Button btnPower;
        private Button btnQuit;
        private Timer timer1;
        private Button btnShutdown;
    } 
    
    
} 
