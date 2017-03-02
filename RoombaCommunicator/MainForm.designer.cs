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
            this.StatusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.btnPort = new System.Windows.Forms.Button();
            this.btnOpenOrClosePort = new System.Windows.Forms.Button();
            this.tmrLookForPortChanges = new System.Windows.Forms.Timer(this.components);
            this.btnSendVel = new System.Windows.Forms.Button();
            this.btnDrive = new System.Windows.Forms.Button();
            this.btnHalt = new System.Windows.Forms.Button();
            this.lblDriveCommand = new System.Windows.Forms.Label();
            this.txtVelocityLeft = new System.Windows.Forms.TextBox();
            this.txtVelocityRight = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnFull = new System.Windows.Forms.Button();
            this.btnSafeMode = new System.Windows.Forms.Button();
            this.btnPower = new System.Windows.Forms.Button();
            this.btnQuit = new System.Windows.Forms.Button();
            this.btnShutdown = new System.Windows.Forms.Button();
            this.btnOpenJoystick = new System.Windows.Forms.Button();
            this.scrKP = new System.Windows.Forms.HScrollBar();
            this.lblKP = new System.Windows.Forms.Label();
            this.scrVelocity = new System.Windows.Forms.VScrollBar();
            this.lblVelocity = new System.Windows.Forms.Label();
            this.lblKI = new System.Windows.Forms.Label();
            this.lblKD = new System.Windows.Forms.Label();
            this.scrKI = new System.Windows.Forms.HScrollBar();
            this.scrKD = new System.Windows.Forms.HScrollBar();
            this.btnSendPID = new System.Windows.Forms.Button();
            this.btnStartStop = new System.Windows.Forms.Button();
            this.StatusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // rtbMonitor
            // 
            this.rtbMonitor.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbMonitor.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbMonitor.Location = new System.Drawing.Point(20, 315);
            this.rtbMonitor.MaxLength = 128;
            this.rtbMonitor.Name = "rtbMonitor";
            this.rtbMonitor.Size = new System.Drawing.Size(444, 26);
            this.rtbMonitor.TabIndex = 7;
            this.rtbMonitor.Text = "";
            this.rtbMonitor.TextChanged += new System.EventHandler(this.rtbMonitor_TextChanged_1);
            // 
            // StatusStrip1
            // 
            this.StatusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblStatus});
            this.StatusStrip1.Location = new System.Drawing.Point(0, 486);
            this.StatusStrip1.MinimumSize = new System.Drawing.Size(26, 0);
            this.StatusStrip1.Name = "StatusStrip1";
            this.StatusStrip1.Size = new System.Drawing.Size(487, 37);
            this.StatusStrip1.TabIndex = 9;
            this.StatusStrip1.Text = "StatusStrip1";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = false;
            this.lblStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblStatus.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblStatus.Margin = new System.Windows.Forms.Padding(5);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Padding = new System.Windows.Forms.Padding(5);
            this.lblStatus.Size = new System.Drawing.Size(462, 27);
            this.lblStatus.Spring = true;
            this.lblStatus.Text = "Port Closed";
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnPort
            // 
            this.btnPort.AutoSize = true;
            this.btnPort.Location = new System.Drawing.Point(34, 25);
            this.btnPort.Name = "btnPort";
            this.btnPort.Size = new System.Drawing.Size(105, 47);
            this.btnPort.TabIndex = 10;
            this.btnPort.Text = "Port Settings";
            this.btnPort.UseVisualStyleBackColor = true;
            // 
            // btnOpenOrClosePort
            // 
            this.btnOpenOrClosePort.AutoSize = true;
            this.btnOpenOrClosePort.Location = new System.Drawing.Point(189, 25);
            this.btnOpenOrClosePort.Name = "btnOpenOrClosePort";
            this.btnOpenOrClosePort.Size = new System.Drawing.Size(109, 47);
            this.btnOpenOrClosePort.TabIndex = 11;
            this.btnOpenOrClosePort.Text = "Open COM Port";
            this.btnOpenOrClosePort.UseVisualStyleBackColor = true;
            this.btnOpenOrClosePort.Click += new System.EventHandler(this.btnOpenOrClosePort_Click_1);
            // 
            // tmrLookForPortChanges
            // 
            this.tmrLookForPortChanges.Interval = 1000;
            this.tmrLookForPortChanges.Tick += new System.EventHandler(this.tmrLookForPortChanges_Tick_1);
            // 
            // btnSendVel
            // 
            this.btnSendVel.Location = new System.Drawing.Point(57, 399);
            this.btnSendVel.Name = "btnSendVel";
            this.btnSendVel.Size = new System.Drawing.Size(62, 23);
            this.btnSendVel.TabIndex = 12;
            this.btnSendVel.Text = "SEND";
            this.btnSendVel.UseVisualStyleBackColor = true;
            this.btnSendVel.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // btnDrive
            // 
            this.btnDrive.Location = new System.Drawing.Point(44, 134);
            this.btnDrive.Name = "btnDrive";
            this.btnDrive.Size = new System.Drawing.Size(75, 23);
            this.btnDrive.TabIndex = 20;
            this.btnDrive.Text = "Drive Direct";
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
            this.lblDriveCommand.Text = "145";
            // 
            // txtVelocityLeft
            // 
            this.txtVelocityLeft.Location = new System.Drawing.Point(218, 137);
            this.txtVelocityLeft.Name = "txtVelocityLeft";
            this.txtVelocityLeft.Size = new System.Drawing.Size(64, 20);
            this.txtVelocityLeft.TabIndex = 34;
            this.txtVelocityLeft.Text = "100";
            // 
            // txtVelocityRight
            // 
            this.txtVelocityRight.Location = new System.Drawing.Point(321, 137);
            this.txtVelocityRight.Name = "txtVelocityRight";
            this.txtVelocityRight.Size = new System.Drawing.Size(64, 20);
            this.txtVelocityRight.TabIndex = 35;
            this.txtVelocityRight.Text = "100";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(255, 107);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 13);
            this.label1.TabIndex = 40;
            this.label1.Text = "Velocity: +/-500";
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
            this.btnQuit.Location = new System.Drawing.Point(275, 266);
            this.btnQuit.Name = "btnQuit";
            this.btnQuit.Size = new System.Drawing.Size(75, 23);
            this.btnQuit.TabIndex = 50;
            this.btnQuit.Text = "Quit";
            this.btnQuit.UseVisualStyleBackColor = true;
            this.btnQuit.Click += new System.EventHandler(this.btnQuit_Click);
            // 
            // btnShutdown
            // 
            this.btnShutdown.Location = new System.Drawing.Point(376, 266);
            this.btnShutdown.Name = "btnShutdown";
            this.btnShutdown.Size = new System.Drawing.Size(75, 23);
            this.btnShutdown.TabIndex = 51;
            this.btnShutdown.Text = "Shutdown";
            this.btnShutdown.UseVisualStyleBackColor = true;
            this.btnShutdown.Click += new System.EventHandler(this.btnShutdown_Click);
            // 
            // btnOpenJoystick
            // 
            this.btnOpenJoystick.Location = new System.Drawing.Point(347, 25);
            this.btnOpenJoystick.Name = "btnOpenJoystick";
            this.btnOpenJoystick.Size = new System.Drawing.Size(104, 47);
            this.btnOpenJoystick.TabIndex = 52;
            this.btnOpenJoystick.Text = "Open Joystick";
            this.btnOpenJoystick.UseVisualStyleBackColor = true;
            // 
            // scrKP
            // 
            this.scrKP.LargeChange = 100;
            this.scrKP.Location = new System.Drawing.Point(142, 399);
            this.scrKP.Maximum = 1000;
            this.scrKP.Name = "scrKP";
            this.scrKP.Size = new System.Drawing.Size(80, 17);
            this.scrKP.SmallChange = 10;
            this.scrKP.TabIndex = 53;
            this.scrKP.Scroll += new System.Windows.Forms.ScrollEventHandler(this.scrKP_Scroll);
            // 
            // lblKP
            // 
            this.lblKP.AutoSize = true;
            this.lblKP.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblKP.Location = new System.Drawing.Point(155, 364);
            this.lblKP.Name = "lblKP";
            this.lblKP.Size = new System.Drawing.Size(67, 16);
            this.lblKP.TabIndex = 54;
            this.lblKP.Text = "KP = 300";
            // 
            // scrVelocity
            // 
            this.scrVelocity.LargeChange = 100;
            this.scrVelocity.Location = new System.Drawing.Point(20, 364);
            this.scrVelocity.Maximum = 500;
            this.scrVelocity.Minimum = -500;
            this.scrVelocity.Name = "scrVelocity";
            this.scrVelocity.Size = new System.Drawing.Size(17, 80);
            this.scrVelocity.SmallChange = 10;
            this.scrVelocity.TabIndex = 55;
            this.scrVelocity.Scroll += new System.Windows.Forms.ScrollEventHandler(this.scrVelocity_Scroll);
            // 
            // lblVelocity
            // 
            this.lblVelocity.AutoSize = true;
            this.lblVelocity.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVelocity.Location = new System.Drawing.Point(63, 364);
            this.lblVelocity.Name = "lblVelocity";
            this.lblVelocity.Size = new System.Drawing.Size(47, 16);
            this.lblVelocity.TabIndex = 56;
            this.lblVelocity.Text = "Vel: 0";
            this.lblVelocity.Click += new System.EventHandler(this.lblVelocity_Click);
            // 
            // lblKI
            // 
            this.lblKI.AutoSize = true;
            this.lblKI.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblKI.Location = new System.Drawing.Point(272, 364);
            this.lblKI.Name = "lblKI";
            this.lblKI.Size = new System.Drawing.Size(53, 16);
            this.lblKI.TabIndex = 57;
            this.lblKI.Text = "KI = 30";
            // 
            // lblKD
            // 
            this.lblKD.AutoSize = true;
            this.lblKD.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblKD.Location = new System.Drawing.Point(385, 364);
            this.lblKD.Name = "lblKD";
            this.lblKD.Size = new System.Drawing.Size(52, 16);
            this.lblKD.TabIndex = 58;
            this.lblKD.Text = "KD = 0";
            // 
            // scrKI
            // 
            this.scrKI.LargeChange = 100;
            this.scrKI.Location = new System.Drawing.Point(253, 399);
            this.scrKI.Maximum = 1000;
            this.scrKI.Name = "scrKI";
            this.scrKI.Size = new System.Drawing.Size(80, 17);
            this.scrKI.SmallChange = 10;
            this.scrKI.TabIndex = 59;
            this.scrKI.Scroll += new System.Windows.Forms.ScrollEventHandler(this.scrKI_Scroll);
            // 
            // scrKD
            // 
            this.scrKD.LargeChange = 100;
            this.scrKD.Location = new System.Drawing.Point(371, 399);
            this.scrKD.Maximum = 1000;
            this.scrKD.Name = "scrKD";
            this.scrKD.Size = new System.Drawing.Size(80, 17);
            this.scrKD.SmallChange = 10;
            this.scrKD.TabIndex = 60;
            this.scrKD.Scroll += new System.Windows.Forms.ScrollEventHandler(this.scrKD_Scroll);
            // 
            // btnSendPID
            // 
            this.btnSendPID.Location = new System.Drawing.Point(359, 433);
            this.btnSendPID.Name = "btnSendPID";
            this.btnSendPID.Size = new System.Drawing.Size(92, 23);
            this.btnSendPID.TabIndex = 61;
            this.btnSendPID.Text = "UPDATE PID";
            this.btnSendPID.UseVisualStyleBackColor = true;
            this.btnSendPID.Click += new System.EventHandler(this.btnSendPID_Click);
            // 
            // btnStartStop
            // 
            this.btnStartStop.Location = new System.Drawing.Point(158, 433);
            this.btnStartStop.Name = "btnStartStop";
            this.btnStartStop.Size = new System.Drawing.Size(61, 23);
            this.btnStartStop.TabIndex = 62;
            this.btnStartStop.Text = "START";
            this.btnStartStop.UseVisualStyleBackColor = true;
            this.btnStartStop.Click += new System.EventHandler(this.btnStartRobotnik_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(487, 523);
            this.Controls.Add(this.btnStartStop);
            this.Controls.Add(this.btnSendPID);
            this.Controls.Add(this.scrKD);
            this.Controls.Add(this.scrKI);
            this.Controls.Add(this.lblKD);
            this.Controls.Add(this.lblKI);
            this.Controls.Add(this.lblVelocity);
            this.Controls.Add(this.scrVelocity);
            this.Controls.Add(this.lblKP);
            this.Controls.Add(this.scrKP);
            this.Controls.Add(this.btnOpenJoystick);
            this.Controls.Add(this.btnShutdown);
            this.Controls.Add(this.btnQuit);
            this.Controls.Add(this.btnPower);
            this.Controls.Add(this.btnSafeMode);
            this.Controls.Add(this.btnFull);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtVelocityRight);
            this.Controls.Add(this.txtVelocityLeft);
            this.Controls.Add(this.lblDriveCommand);
            this.Controls.Add(this.btnHalt);
            this.Controls.Add(this.btnDrive);
            this.Controls.Add(this.btnSendVel);
            this.Controls.Add(this.btnOpenOrClosePort);
            this.Controls.Add(this.btnPort);
            this.Controls.Add(this.StatusStrip1);
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
        internal /* TRANSINFO: WithEvents */ System.Windows.Forms.StatusStrip StatusStrip1; 
        internal /* TRANSINFO: WithEvents */ System.Windows.Forms.ToolStripStatusLabel lblStatus; 
        internal /* TRANSINFO: WithEvents */ System.Windows.Forms.Button btnPort; 
        internal /* TRANSINFO: WithEvents */ System.Windows.Forms.Button btnOpenOrClosePort; 
        internal /* TRANSINFO: WithEvents */ System.Windows.Forms.Timer tmrLookForPortChanges;
        private Button btnSendVel;
        private Button btnDrive;
        private Button btnHalt;
        private Label lblDriveCommand;
        private TextBox txtVelocityLeft;
        private TextBox txtVelocityRight;
        private Label label1;
        private Button btnStart;
        private Button btnReset;
        private Button btnStop;
        private Button btnFull;
        private Button btnSafeMode;
        private Button btnPower;
        private Button btnQuit;
        private Button btnShutdown;
        private Button btnOpenJoystick;
        private HScrollBar scrKP;
        private Label lblKP;
        private VScrollBar scrVelocity;
        private Label lblVelocity;
        private Label lblKI;
        private Label lblKD;
        private HScrollBar scrKI;
        private HScrollBar scrKD;
        private Button btnSendPID;
        private Button btnStartStop;
    } 
    
    
} 
