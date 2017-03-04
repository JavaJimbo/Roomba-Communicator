/* RoombaCommunicator
 * Written in C# on Visual Studio 2015
 * Adapted from Jan Axelson's com_port_terminal_cs
 * 
 * 2-21-17 Sends encoded command strings to a Raspberry Pi via serial port at 57600 baud.
 * Displays incoming strings in text box. Also can send commands to quit or shut down RPI.
 * Can wake up, start, stop Roomba via RPI.
 * 2-24-17: Drive command is now Drive Direct command: 145
 * 2-28-17: RTBMonitor max length was 2147483647
 * 
 * 3-2-2017: Command sequence is now: COMMAND, SUBCOMMAND, NUM DATA BYTES, DATA....
 * Added buttons and commands for changing and sending KP, KI, KD to robot
 * 
 * 3-4-17: New text box works with leading character '>'
 */

using Microsoft.Win32;
using System;
using System.Drawing;
using System.IO.Ports;
using System.Windows.Forms;
using COMPortTerminal.Properties;
using System.Data;
using System.Text;

namespace COMPortTerminal
{
    /// <summary>
    /// com_port_terminal 
    /// Visual C# .NET application. Created with Visual Studio 2008.
    /// Converted from Visual Basic with C Sharpener for VB (www.elegancetech.com)
    ///
    /// Demonstrates communications using .NET 2.0's SerialPort class
    /// Displays a text box where users can enter text to send to a COM port 
    /// and view text received from a COM port.
    /// 
    /// The user can select a COM port, bit rate, and handshaking.
    /// A ToolStripStatusLabel displays the current port settings.
    /// A second text box displays error messages and other information.     
     
    using System.Runtime.InteropServices;
    [StructLayout(LayoutKind.Explicit)]
    struct ByteArray
    {
        [FieldOffset(0)]
        public byte LSBbyte;
        [FieldOffset(1)]
        public byte MSBbyte;
        [FieldOffset(0)]
        public uint Int1;
    }
    
    [StructLayout(LayoutKind.Explicit)]
    struct TwosComplement
    {
        [FieldOffset(0)]
        public byte LSBbyte;
        [FieldOffset(1)]
        public byte MSBbyte;
        [FieldOffset(0)]
        public Int16 integer;
    }

    public partial class MainForm  
    {
        const Byte STX = 36;
        const Byte ETX = 13;
        const Byte DLE = 16;
        const int MAXPACKET = 80;
        const Int16 MAXVELOCITY = 500;
        const Byte DRIVEDIRECT = 145;
        const Byte ROOMBA = 0;
        const Byte RASPI = 240;
        const Byte ROBOTNIK = 19;
        const Byte SETPID = 69;
        const Byte START = 128;
        const Byte STOP = 173;
        const Byte POWERDOWN = 133;
        const Byte RESET = 7;
        const Byte SAFE = 131;
        const Byte FULL = 132;
        const Byte QUIT = 128;
        const Byte SHUTDOWN = 160;


        TwosComplement result = new TwosComplement();        
        uint timerCounter = 0;


        /*
        ByteArray result = new ByteArray();

        ByteArray ConvertToTwosComplement(int decimalValue)
        {
            ByteArray result = new ByteArray();
            if (decimalValue >= 0)
            {
                result.Int1 = (uint)decimalValue;
                return (result);
            }
            else
            {
                uint valueInt = (uint)-decimalValue;
                valueInt = valueInt - 1;
                result.Int1 = ~valueInt;
                // byte lowByte = result.LSBbyte;
                // 
                byte highByte = result.MSBbyte;




                return (result);
            }
        }
        */

        public MainForm() 
        {
            
            InitializeComponent();if (transDefaultFormMainForm == null)	transDefaultFormMainForm = this;
           
            btnOpenOrClosePort.Click += new System.EventHandler (btnOpenOrClosePort_Click);
            btnPort.Click += new System.EventHandler (btnPort_Click);  
            Load += new System.EventHandler (Form1_Load);                                     
            tmrLookForPortChanges.Tick += new System.EventHandler (tmrLookForPortChanges_Tick);
            tmrComPortTimeout.Tick += new System.EventHandler(tmrComPortTimeout_Tick);
            tmrComPortTimeout.Stop();

            scrKP.Value = 300;
            scrKP_Scroll(null, null);
            scrKI.Value = 30;
            scrKI_Scroll(null, null);
            scrKD.Value = 0;
            scrKD_Scroll(null, null);
        }

        private const string ButtonTextOpenPort = "Open COM Port"; 
        private const string ButtonTextClosePort = "Close COM Port"; 
        private const string ModuleName = "COM Port Terminal"; 
        
        public MainForm MyMainForm; 
        internal PortSettingsDialog MyPortSettingsDialog; 
        internal ComPorts UserPort1;

        Byte testData = 65;
       
        private delegate void AccessFormMarshalDelegate (string action, string textToAdd, Color textColor);
            
        private Color colorReceive = Color.Green;
        private Color colorTransmit = Color.Red;
        private int maximumTextBoxLength;
        private string receiveBuffer;
        private bool savedOpenPortOnStartup;
        private int userInputIndex;

        /// <summary> 
        /// Perform functions on the application's form.
        /// Used to access the form from a different thread.
        /// See AccessFormMarshal().
        /// </summary>
        /// 
        /// <param name="action"> a string that names the action to perform on the form </param>  
        /// <param name="formText"> text that the form displays </param> 
        /// <param name="textColor"> a system color for displaying text </param>

        private void AccessForm( string action, string formText, Color textColor ) 
        {                                
            switch ( action ) 
            {
                case "AppendToMonitorTextBox":

                    //  Append text to the rtbMonitor textbox using the color for received data.                    
                    // rtbMonitor.SelectionColor = colorReceive;
                    // rtbMonitor.Text = formText; 
                    String strInputText = formText;
                    int startIndex = strInputText.IndexOf('>');
                    if (startIndex >= 0) txtIncoming.Clear();
                    txtIncoming.Text = txtIncoming.Text + formText;
                    // tmrComPortTimeout.Start();  // $$$$


                    //strInputText = string.Concat(strInputText, formText);
                    //int endPos = strInputText.IndexOf("<");  // $$$$
                    //if (endPos == 0)
                    //{
                    //    rtbMonitor.Text = strInputText;
                    //    strInputText = "";
                    //}

                    // rtbMonitor.AppendText( formText ); 


                    // Return to the default color.

                    // rtbMonitor.SelectionColor = colorTransmit; 

                    //  Trim the textbox's contents if needed.

                    //if ( rtbMonitor.TextLength > maximumTextBoxLength ) // $$$$
                    //{                         
                    //    TrimTextBoxContents();                         
                    //}                    
                    break;

                case "DisplayStatus":
                    
                    //  Add text to the rtbStatus textbox using the specified color.
                    
                    DisplayStatus( formText, textColor ); 
                    
                    break;

                case "DisplayCurrentSettings":
                    
                    //  Display the current port settings in the ToolStripStatusLabel.
                    
                    DisplayCurrentSettings(); 
                    
                    break;

                default:
                    
                    break;
            }                      
        } 
     
        /// <summary>
        /// Enables accessing the form from another thread.
        /// The parameters match those of AccessForm() 
        /// </summary>
        /// 
        /// <param name="action"> a string that names the action to perform on the form </param>  
        /// <param name="formText"> text that the form displays </param> 
        /// <param name="textColor"> a system color for displaying text </param>

        private void AccessFormMarshal( string action, string textToDisplay, Color textColor ) 
        {          
            AccessFormMarshalDelegate AccessFormMarshalDelegate1; 

            AccessFormMarshalDelegate1 = new AccessFormMarshalDelegate( AccessForm ); 

            object[] args = { action, textToDisplay, textColor }; 
            
            //  Call AccessForm, passing the parameters in args.
            
            base.Invoke( AccessFormMarshalDelegate1, args );             
        }       
               
        /// <summary>
        /// Display the current port parameters on the form.
        /// </summary>

        private void DisplayCurrentSettings() 
        {               
            string selectedPortState = ""; 
            
            if ( ComPorts.comPortExists ) 
            {                 
                if ( ( !( ( UserPort1.SelectedPort == null ) ) ) ) 
                {                     
                    if ( UserPort1.SelectedPort.IsOpen ) 
                    { 
                        selectedPortState = "OPEN"; 
                        btnOpenOrClosePort.Text = ButtonTextClosePort; 
                    } 
                    else 
                    { 
                        selectedPortState = "CLOSED"; 
                        btnOpenOrClosePort.Text = ButtonTextOpenPort; 
                    } 
                } 
                
                UpdateStatusLabel( System.Convert.ToString( MyPortSettingsDialog.cmbPort.SelectedItem ) + "   " + System.Convert.ToString( MyPortSettingsDialog.cmbBitRate.SelectedItem ) + "   N 8 1   Handshake: " + MyPortSettingsDialog.cmbHandshaking.SelectedItem.ToString() + "   " + selectedPortState );                 
            } 
            else 
            { 
                DisplayStatus( ComPorts.noComPortsMessage, Color.Red ); 
                UpdateStatusLabel( "" );                 
            } 
        }        
                
        /// <summary>
        /// Provide a central mechanism for displaying exception information.
        /// Display a message that describes the exception.
        /// </summary>
        /// 
        /// <param name="moduleName"> the module where the exception occurred.</param>
        /// <param name="ex"> the exception </param>

        private void DisplayException( string moduleName, Exception ex ) 
        {    
            string errorMessage = null; 
            
            errorMessage = "Exception: " + ex.Message + " Module: " + moduleName + ". Method: " + ex.TargetSite.Name; 
            
            DisplayStatus( errorMessage, Color.Red ); 
            
            //  To display errors in a message box, uncomment this line:
            // MessageBox.Show(errorMessage)            
        }        
 
        /// <summary>
        /// Displays text in Status bar at bottom of MainForm
        /// </summary>
        /// 
        /// <param name="status"> the text to display.</param>
        /// <param name="textColor"> the text color. </param>
       
        private void DisplayStatus( string status, Color textColor ) 
        {
            lblStatus.ForeColor = textColor;
            lblStatus.Text = status;            
        } 

        /// <summary>
        /// Get user preferences for the COM port and parameters.
        /// See SetPreferences for more information.
        /// </summary>
       
        private void GetPreferences() 
        {      
            UserPort1.SavedPortName = Settings.Default.ComPort;
            UserPort1.SavedBitRate = Settings.Default.BitRate;
            UserPort1.SavedHandshake = Settings.Default.Handshaking;
            savedOpenPortOnStartup = Settings.Default.OpenComPortOnStartup;         
        } 
         
        /// <summary>
        /// Initialize elements on the main form.
        /// </summary>

        private void InitializeDisplayElements() 
        {        
            //  The TrimTextboxContents routine trims a richtextbox with more data than this:
            
            // maximumTextBoxLength = 10000;  $$$$
            maximumTextBoxLength = 128;
            // rtbMonitor.SelectionColor = colorTransmit;             
        }

        /// <summary>
        ///  Determine if the textbox's TextChanged event occurred due to new user input.
        /// If yes, get the input and write it to the COM port.
        /// </summary>

        private void ProcessTextboxInput()
        {        
            /*
            IAsyncResult ar = null;
            string msg = null;
            int textLength = 0;
            string userInput = null;


            //  Find out if the textbox contains new user input.
            //  If the new data is data received on the COM port or if no COM port exists, do nothing.

            if (((rtbMonitor.Text.Length > userInputIndex + UserPort1.ReceivedDataLength) & ComPorts.comPortExists))
            {
                //  Retrieve the contents of the textbox.

                userInput = rtbMonitor.Text;

                //  Get the length of the new text.

                textLength = userInput.Length - userInputIndex;

                //  Extract the unread input.

                userInput = rtbMonitor.Text.Substring(userInputIndex, textLength);


                //  Create a message to pass to the Write operation (optional). 
                //  The callback routine can retrieve the message when the write completes.

                msg = DateTime.Now.ToString();

                //  Send the input to the COM port.
                //  Use a different thread so the main application doesn't have to wait
                //  for the write operation to complete.                

                UserPort1.WriteToComPortDelegate1 = new ComPorts.WriteToComPortDelegate(UserPort1.WriteToComPort);

                ar = UserPort1.WriteToComPortDelegate1.BeginInvoke(userInput, new AsyncCallback(UserPort1.WriteCompleted), msg);

                //  To use the same thread for writes to the port,
                //  comment out the statement above and uncomment the statement below.
                // UserPort1.WriteToComPort(userInput)

                AccessForm("UpdateStatusLabel", "", Color.Black);
            }
            else
            {
                //  Received bytes displayed in the text box are ignored,
                //  but we need to reset the value that indicates
                //  the number of received but not processed bytes.

                UserPort1.ReceivedDataLength = 0;
            }

            if (rtbMonitor.TextLength > maximumTextBoxLength)
            {
                TrimTextBoxContents();
            }

            //  Update the value that indicates the last character processed.

            userInputIndex = rtbMonitor.Text.Length;  
            */
        }
                
        /// <summary> 
        /// Save user preferences for the COM port and parameters.
        /// </summary>

        private void SavePreferences() 
        {  
            // To define additional settings, in the Visual Studio IDE go to
            // Solution Explorer > right click on project name > Properties > Settings.

            if (MyPortSettingsDialog.cmbPort.SelectedIndex > -1) 
            {
                // The system has at least one COM port.

                Settings.Default.ComPort = MyPortSettingsDialog.cmbPort.SelectedItem.ToString();
                Settings.Default.BitRate = (int)MyPortSettingsDialog.cmbBitRate.SelectedItem;
                Settings.Default.Handshaking = (Handshake) MyPortSettingsDialog.cmbHandshaking.SelectedItem;
                Settings.Default.OpenComPortOnStartup = MyPortSettingsDialog.chkOpenComPortOnStartup.Checked;

                Settings.Default.Save();    
            }
        }
        
        /// <summary>
        /// Use stored preferences or defaults to set the initial port parameters.
        /// </summary>

        private void SetInitialPortParameters() 
        {         
            GetPreferences(); 
            
            if ( ComPorts.comPortExists ) 
            {                 
                //  Select a COM port and bit rate using stored preferences if available.
                
                UsePreferencesToSelectParameters(); 
                
                //  Save the selected indexes of the combo boxes.
                
                MyPortSettingsDialog.SavePortParameters();                 
            } 
            else 
            {                 
                //  No COM ports have been detected. Watch for one to be attached.
                
                tmrLookForPortChanges.Start(); 
                DisplayStatus( ComPorts.noComPortsMessage, Color.Red );                 
            }             
            UserPort1.ParameterChanged = false;             
        }         
       
        /// <summary>
        /// Saves the passed port parameters.
        /// Called when the user clicks OK on PortSettingsDialog.
        /// </summary>

        private void SetPortParameters( string userPort, int userBitRate, Handshake userHandshake ) 
        {          
            try 
            {                 
                //  Don't do anything if the system has no COM ports.
                
                if ( ComPorts.comPortExists ) 
                {                     
                    if ( MyPortSettingsDialog.ParameterChanged() ) 
                    {                         
                        //  One or more port parameters has changed.
                        
                        if ( ( string.Compare( MyPortSettingsDialog.oldPortName, userPort, true ) != 0 ) ) 
                        {                             
                            //  The port has changed.
                            //  Close the previously selected port.
                            
                            UserPort1.PreviousPort = UserPort1.SelectedPort; 
                            UserPort1.CloseComPort( UserPort1.SelectedPort ); 
                            
                            //  Set SelectedPort to the current port.
                            
                            UserPort1.SelectedPort.PortName = userPort; 
                            UserPort1.PortChanged = true;                            
                        } 
                        
                        //  Set other port parameters.
                        
                        UserPort1.SelectedPort.BaudRate = userBitRate; 
                        UserPort1.SelectedPort.Handshake = userHandshake; 
                        
                        MyPortSettingsDialog.SavePortParameters(); 
                        
                        UserPort1.ParameterChanged = true;                         
                    } 
                    else 
                    { 
                        UserPort1.ParameterChanged = false;                         
                    } 
                }
            } 
            catch ( InvalidOperationException ex ) 
            {                 
                UserPort1.ParameterChanged = true; 
                DisplayException( ModuleName, ex );                 
            } 
            catch ( UnauthorizedAccessException ex ) 
            {                 
                UserPort1.ParameterChanged = true; 
                DisplayException( ModuleName, ex ); 
                
                //  This exception can occur if the port was removed. 
                //  If the port was open, close it.
                
                UserPort1.CloseComPort( UserPort1.SelectedPort );                 
            } 
            catch ( System.IO.IOException ex ) 
            {                 
                UserPort1.ParameterChanged = true; 
                DisplayException( ModuleName, ex );                 
            } 
        }        
    
        /// <summary>
        /// Trim a richtextbox by removing the oldest contents.
        /// </summary>
        /// 
        /// <remarks >
        /// To trim the box while retaining any formatting applied to the retained contents,
        /// create a temporary richtextbox, copy the contents to be preserved to the 
        /// temporary richtextbox,and copy the temporary richtextbox back to the original richtextbox.
        /// </remarks>

        private void TrimTextBoxContents() 
        {        
            /*
            RichTextBox rtbTemp = new RichTextBox(); 
            int textboxTrimSize = 0;           
                        
            //  When the contents are too large, remove half.
            
            textboxTrimSize = maximumTextBoxLength / 2; 
            
            rtbMonitor.Select( rtbMonitor.TextLength - textboxTrimSize + 1, textboxTrimSize ); 
            rtbTemp.Rtf = rtbMonitor.SelectedRtf; 
            rtbMonitor.Clear(); 
            rtbMonitor.Rtf = rtbTemp.Rtf; 
            rtbTemp = null; 
            rtbMonitor.SelectionStart = rtbMonitor.TextLength;             
            */
        } 

        /// <summary>
        /// Set the text in the ToolStripStatusLabel.
        /// </summary>
        /// 
        /// <param name="status"> the text to display </param>

        private void UpdateStatusLabel( string status ) 
        {        
            lblStatus.Text = status; 
            StatusStrip1.Update();             
        } 

        /// <summary>
        /// Set the user preferences or default values in the combo boxes and ports array
        /// using stored preferences or default values.
        /// </summary>
      
        private void UsePreferencesToSelectParameters() 
        {         
            int myPortIndex = 0;

            myPortIndex = MyPortSettingsDialog.SelectComPort(UserPort1.SavedPortName);
                
            MyPortSettingsDialog.SelectBitRate(UserPort1.SavedBitRate);

            UserPort1.SelectedPort.BaudRate = (int)MyPortSettingsDialog.cmbBitRate.SelectedItem;
                
            MyPortSettingsDialog.SelectHandshaking(UserPort1.SavedHandshake);

            UserPort1.SelectedPort.Handshake = (Handshake)MyPortSettingsDialog.cmbHandshaking.SelectedItem;

            MyPortSettingsDialog.chkOpenComPortOnStartup.Checked = savedOpenPortOnStartup;           
        }
        
        /// <summary>
        /// Depending on the text displayed on the button, open or close the selected port
        /// and change the button text to the opposite action.
        /// </summary>

        private void btnOpenOrClosePort_Click( object sender, System.EventArgs e ) 
        {         
            if ( ( btnOpenOrClosePort.Text == ButtonTextOpenPort ) ) 
            { 
                UserPort1.OpenComPort(); 
                if ( UserPort1.SelectedPort.IsOpen ) 
                { 
                    btnOpenOrClosePort.Text = ButtonTextClosePort;
                    DisplayStatus("Port open", Color.Red);
                }                 
            } 
            else 
            { 
                UserPort1.CloseComPort( UserPort1.SelectedPort ); 
                
                if ( !( UserPort1.SelectedPort.IsOpen ) ) 
                { 
                    btnOpenOrClosePort.Text = ButtonTextOpenPort;
                    DisplayStatus("Port closed", Color.Red);
                }                 
            }             
        } 

        /// <summary>
        /// Look for COM ports and display them in the combo box.
        /// </summary>

        private void btnPort_Click( object sender, System.EventArgs e ) 
        {          
            ComPorts.FindComPorts(); 
            
            MyPortSettingsDialog.DisplayComPorts(); 
            MyPortSettingsDialog.SelectComPort( UserPort1.SelectedPort.PortName ); 
            MyPortSettingsDialog.SelectBitRate( UserPort1.SelectedPort.BaudRate ); 
            MyPortSettingsDialog.SelectHandshaking( UserPort1.SelectedPort.Handshake ); 
            
            UserPort1.ParameterChanged = false; 
            
            //  Display the combo boxes for setting port parameters.
            
            MyPortSettingsDialog.ShowDialog(); 
        } 

        /// <summary>
        /// Create an instance of the ComPorts class.
        /// Initialize port settings and other parameters. 
        /// specify behavior on events.
        /// </summary>
       
        private void Form1_Load( object sender, System.EventArgs e ) 
        {
                Show();                        

                UserPort1 = new ComPorts();

                MyPortSettingsDialog = new PortSettingsDialog();

                tmrLookForPortChanges.Interval = 1000;
                tmrLookForPortChanges.Stop();

                InitializeDisplayElements();

                SetInitialPortParameters();

                if (ComPorts.comPortExists)
                {
                    UserPort1.SelectedPort.PortName = ComPorts.myPortNames[MyPortSettingsDialog.cmbPort.SelectedIndex];

                    //  A check box enables requesting to open the selected COM port on start up.
                    //  Otherwise the application opens the port when the user clicks the Open Port
                    //  button or types text to send. 

                    if (MyPortSettingsDialog.chkOpenComPortOnStartup.Checked)
                    {
                        UserPort1.PortOpen = UserPort1.OpenComPort();
                        AccessForm("DisplayCurrentSettings", "", Color.Black);
                        AccessForm("DisplayStatus", "", Color.Black);
                    }
                    else
                    {
                        DisplayCurrentSettings();
                    }
                }

                //  Specify the routines that execute on events in other modules.
                //  The routines can receive data from other modules. 

                ComPorts.UserInterfaceData += new ComPorts.UserInterfaceDataEventHandler(AccessFormMarshal);
                PortSettingsDialog.UserInterfaceData += new PortSettingsDialog.UserInterfaceDataEventHandler(AccessFormMarshal);
                PortSettingsDialog.UserInterfacePortSettings += new PortSettingsDialog.UserInterfacePortSettingsEventHandler(SetPortParameters);
                       }         
        
        /// <summary>
        /// Close the port if needed and save preferences.
        /// </summary>
        
        private void Form1_FormClosing( object sender, System.Windows.Forms.FormClosingEventArgs e ) 
        {             
            UserPort1.CloseComPort( UserPort1.SelectedPort ); 
            SavePreferences(); 
        } 

        /// <summary>
        /// Do whatever is needed with new characters in the textbox.
        /// </summary>
     

        private void rtbMonitor_TextChanged( System.Object sender, System.EventArgs e ) 
        {            
            // ProcessTextboxInput();             
        } 
               
        /// <summary>
        /// Look for ports. If at least one is found, stop the timer and
        /// select the saved port if possible or the first port.
        /// This timer is enabled only when no COM ports are present.
        /// </summary>

        private void tmrLookForPortChanges_Tick( object sender, System.EventArgs e ) 
        {         
            ComPorts.FindComPorts(); 
            
            if ( ComPorts.comPortExists ) 
            {                 
                tmrLookForPortChanges.Stop(); 
                DisplayStatus( "COM port(s) found.", Color.Black ); 
                
                MyPortSettingsDialog.DisplayComPorts(); 
                MyPortSettingsDialog.SelectComPort( UserPort1.SavedPortName ); 
                MyPortSettingsDialog.SelectBitRate(UserPort1.SavedBitRate); 
                MyPortSettingsDialog.SelectHandshaking( ( ( Handshake )( UserPort1.SavedHandshake ) ) ); 
                
                //  Set selectedPort.
                
                SetPortParameters( UserPort1.SavedPortName, UserPort1.SavedBitRate, ( ( Handshake )( UserPort1.SavedHandshake ) ) ); 
                
                DisplayCurrentSettings(); 
                UserPort1.ParameterChanged = true; 
            } 
        } 
                
        // Default instance for Form

        private static MainForm transDefaultFormMainForm = null;
        public static MainForm TransDefaultFormMainForm
        { 
        	get
        	{ 
        		if (transDefaultFormMainForm == null)
        		{
        			transDefaultFormMainForm = new MainForm();
        		}
        		return transDefaultFormMainForm;
        	} 
        }

        private void btnOpenOrClosePort_Click_1(object sender, EventArgs e)
        {

        }

        private void rtbMonitor_TextChanged_1(object sender, EventArgs e)
        {


        }



        bool insertByte(byte dataByte, ref byte[] ptrBuffer, ref UInt16 index)
        {
            if (index >= MAXPACKET) return (false);
            if (dataByte == STX || dataByte == DLE || dataByte == ETX)           
                ptrBuffer[index++] = DLE;            
            if (index >= MAXPACKET) return (false);
            ptrBuffer[index++] = dataByte;
            return (true);
        }

        UInt16 BuildPacket(byte command, byte subCommand, byte dataLength, ref byte[] ptrData, ref byte[] ptrPacket)
        {
            UInt16 packetIndex = 0, dataIndex = 0;

            if (dataLength <= MAXPACKET)
            {
                ptrPacket[packetIndex++] = STX;
                insertByte(command, ref ptrPacket, ref packetIndex);                                
                insertByte(subCommand, ref ptrPacket, ref packetIndex);
                insertByte(dataLength, ref ptrPacket, ref packetIndex);
                for (dataIndex = 0; dataIndex < dataLength; dataIndex++)
                    insertByte(ptrData[dataIndex], ref ptrPacket, ref packetIndex);
                ptrPacket[packetIndex++] = ETX;
                return (packetIndex);
            }
            else return (0);
        }


        private void btnReset_Click(object sender, EventArgs e)
        {
            // rtbMonitor.Text = "";

            Byte[] arrData = new Byte[5];
            arrData[0] = STX;
            arrData[1] = ROOMBA;
            arrData[2] = RESET;
            arrData[3] = 0;
            arrData[4] = ETX;
            UserPort1.WriteBytesToComPort(arrData, 0, 5);
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            // rtbMonitor.Text = "";

            Byte[] arrData = new Byte[5];
            arrData[0] = STX;
            arrData[1] = ROOMBA;
            arrData[2] = STOP;
            arrData[3] = 0;
            arrData[4] = ETX;
            UserPort1.WriteBytesToComPort(arrData, 0, 5);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void btnSafeMode_Click(object sender, EventArgs e)
        {
            //rtbMonitor.Text = "";

            Byte[] arrData = new Byte[5];
            arrData[0] = STX;
            arrData[1] = ROOMBA;
            arrData[2] = SAFE;            
            arrData[3] = 0;
            arrData[4] = ETX;
            UserPort1.WriteBytesToComPort(arrData, 0, 5);
        }

        private void btnHalt_Click(object sender, EventArgs e)
        {
            //rtbMonitor.Text = "";

            Byte[] arrData = new Byte[9];
            arrData[0] = STX;
            arrData[1] = ROOMBA;
            arrData[2] = DRIVEDIRECT;
            arrData[3] = 4;
            arrData[4] = 0;
            arrData[5] = 0;
            arrData[6] = 0;
            arrData[7] = 0;
            arrData[8] = ETX;
            UserPort1.WriteBytesToComPort(arrData, 0, 9);
        }

        private void btnFull_Click(object sender, EventArgs e)
        {
            //rtbMonitor.Text = "";

            Byte[] arrData = new Byte[5];
            arrData[0] = STX;
            arrData[1] = ROOMBA;
            arrData[2] = FULL;
            arrData[3] = 0;
            arrData[4] = ETX;
            UserPort1.WriteBytesToComPort(arrData, 0, 5);
        }

        private void btnPowerDown_Click(object sender, EventArgs e)
        {
            Byte[] arrData = new Byte[5];
            arrData[0] = STX;
            arrData[1] = ROOMBA;
            arrData[2] = POWERDOWN;
            arrData[3] = 0;
            arrData[4] = ETX;
            UserPort1.WriteBytesToComPort(arrData, 0, 5);
        }


        private void btnStart_Click(object sender, EventArgs e)
        {
            //rtbMonitor.Text = "";

            Byte[] arrData = new Byte[5];
            arrData[0] = STX;
            arrData[1] = ROOMBA;
            arrData[2] = START;
            arrData[3] = 0;
            arrData[4] = ETX;
            UserPort1.WriteBytesToComPort(arrData, 0, 5);
        }

        private void btnPower_Click(object sender, EventArgs e)
        {
            //rtbMonitor.Text = "";

            Byte[] arrData = new Byte[5];
            arrData[0] = STX;
            arrData[1] = ROOMBA;
            arrData[2] = POWERDOWN;
            arrData[3] = 0;
            arrData[4] = ETX;
            UserPort1.WriteBytesToComPort(arrData, 0, 5);
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            //rtbMonitor.Text = "QUIT";
            Byte[] arrData = new Byte[5];
            arrData[0] = STX;
            arrData[1] = RASPI;
            arrData[2] = QUIT;
            arrData[3] = 0;
            arrData[4] = ETX;
            UserPort1.WriteBytesToComPort(arrData, 0, 5);
        }

        private void btnShutdown_Click(object sender, EventArgs e)
        {
            //rtbMonitor.Text = "SHUTDOWN";
            Byte[] arrData = new Byte[5];
            arrData[0] = STX;
            arrData[1] = RASPI;
            arrData[2] = SHUTDOWN;
            arrData[3] = 0;
            arrData[4] = ETX;
            UserPort1.WriteBytesToComPort(arrData, 0, 5);
        }


        private void tmrLookForPortChanges_Tick_1(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void rtbStatus_TextChanged(object sender, EventArgs e)
        {

        }
        
        private void lblVelocity_Click(object sender, EventArgs e)
        {

        }
        
        private void btnSend_Click(object sender, EventArgs e)
        {
            short velocity;
            velocity = (short)(0 - scrVelocity.Value);
            sendVelocity(ROBOTNIK, velocity, velocity);
        }

        private void btnDrive_Click(object sender, EventArgs e)
        {
            Int16 velocityLeft, velocityRight;

            if (txtVelocityLeft.Text == "") txtVelocityLeft.Text = "0";
            if (txtVelocityRight.Text == "") txtVelocityRight.Text = "0";

            String strVelocityLeft = txtVelocityLeft.Text;
            velocityLeft = (Int16)Convert.ToDecimal(strVelocityLeft);
            if (velocityLeft > MAXVELOCITY) velocityLeft = MAXVELOCITY;
            else if (velocityLeft < -MAXVELOCITY) velocityLeft = -MAXVELOCITY;
            strVelocityLeft = velocityLeft.ToString();
            txtVelocityLeft.Text = strVelocityLeft;

            String strVelocityRight = txtVelocityRight.Text;
            velocityRight = (Int16)Convert.ToDecimal(strVelocityRight);
            if (velocityRight > MAXVELOCITY) velocityRight = MAXVELOCITY;
            else if (velocityRight < -MAXVELOCITY) velocityRight = -MAXVELOCITY;
            strVelocityRight = velocityRight.ToString();
            txtVelocityRight.Text = strVelocityRight;

            //rtbMonitor.Text = "";
            sendVelocity (ROOMBA, velocityLeft, velocityRight);
        }

        private void sendVelocity(byte command, short velocityLeft, short velocityRight)
        {
            byte[] arrPacketData = new byte[MAXPACKET];
            byte[] arrOutPacket = new byte[MAXPACKET];
            UInt16 outPacketLength;

            result.integer = (Int16)velocityLeft;
            arrPacketData[0] = result.MSBbyte;
            arrPacketData[1] = result.LSBbyte;

            result.integer = (Int16)velocityRight;
            arrPacketData[2] = result.MSBbyte;
            arrPacketData[3] = result.LSBbyte;

            outPacketLength = BuildPacket(command, DRIVEDIRECT, 4, ref arrPacketData, ref arrOutPacket);

            if (outPacketLength > 0)
                UserPort1.WriteBytesToComPort(arrOutPacket, 0, outPacketLength);
        }

        private void scrVelocity_Scroll(object sender, ScrollEventArgs e)
        {
            Int16 velocity;
            velocity = (Int16) (0 - scrVelocity.Value);
            lblVelocity.Text = "VEL: " + velocity.ToString();
            txtVelocityLeft.Text = txtVelocityRight.Text = velocity.ToString();
        }

        public void scrKP_Scroll(object sender, ScrollEventArgs e)
        {
            UInt16 KP;
            KP = (UInt16)(scrKP.Value);
            lblKP.Text = "KP = " + scrKP.Value.ToString();
        }

        private void scrKI_Scroll(object sender, ScrollEventArgs e)
        {
            UInt16 KI;
            KI = (UInt16)(scrKI.Value);
            lblKI.Text = "KI = " + scrKI.Value.ToString();
        }

        private void scrKD_Scroll(object sender, ScrollEventArgs e)
        {
            UInt16 KD;
            KD = (UInt16)(scrKD.Value);
            lblKD.Text = "KD = " + scrKD.Value.ToString();
        }

        private void btnSendPID_Click(object sender, EventArgs e)
        {
            byte[] arrPacketData = new byte[MAXPACKET];
            byte[] arrOutPacket = new byte[MAXPACKET];
            UInt16 outPacketLength;
            UInt16 KP, KI, KD;

            KP = (UInt16)(scrKP.Value);
            KI = (UInt16)(scrKI.Value);
            KD = (UInt16)(scrKD.Value);

            result.integer = (Int16)KP;
            arrPacketData[0] = result.MSBbyte;
            arrPacketData[1] = result.LSBbyte;

            result.integer = (Int16)KI;
            arrPacketData[2] = result.MSBbyte;
            arrPacketData[3] = result.LSBbyte;

            result.integer = (Int16)KD;
            arrPacketData[4] = result.MSBbyte;
            arrPacketData[5] = result.LSBbyte;

            outPacketLength = BuildPacket(ROBOTNIK, SETPID, 6, ref arrPacketData, ref arrOutPacket);

            if (outPacketLength > 0)
                UserPort1.WriteBytesToComPort(arrOutPacket, 0, outPacketLength);

        }

        private void btnStartRobotnik_Click(object sender, EventArgs e)
        {
            Byte[] arrData = new Byte[5];            

            if (btnStartStop.Text == "START") {
                btnStartStop.Text = "STOP";                
                arrData[0] = STX;
                arrData[1] = ROBOTNIK;
                arrData[2] = START;
                arrData[3] = 0;
                arrData[4] = ETX;
                UserPort1.WriteBytesToComPort(arrData, 0, 5);
            }
            else
            {
                btnStartStop.Text = "START";
                arrData[0] = STX;
                arrData[1] = ROBOTNIK;
                arrData[2] = STOP;
                arrData[3] = 0;
                arrData[4] = ETX;
                UserPort1.WriteBytesToComPort(arrData, 0, 5);
            }
        }

        private void btnTest_Click(object sender, EventArgs e)
        {

        }

        private void tmrComPortTimeout_Tick(object sender, EventArgs e)
        {
            timerCounter++;
            lblTimer.Text = "Timer: " + timerCounter.ToString();
            UserPort1.SelectedPort.DiscardInBuffer();
            tmrComPortTimeout.Stop();
        }
    }    
}
