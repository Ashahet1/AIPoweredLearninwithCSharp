using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;

namespace LiteTest
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.TextBox txtElement;
		private System.Windows.Forms.TextBox txtArray;
		private System.Windows.Forms.TextBox txtAWriteVal;
		private System.Windows.Forms.Button btnGetElement;
		private System.Windows.Forms.TextBox txtElem;
		private System.Windows.Forms.TextBox txtReadVal;
		private System.Windows.Forms.TextBox txtAReadVal;
		private System.Windows.Forms.TextBox txtWrite;
		private System.Windows.Forms.Button btnReadArray;
		private System.Windows.Forms.Button btnAsyncWrite;
		private System.Windows.Forms.Button btnWriteArray;
		private System.Windows.Forms.Button btnWrite;
		private System.Windows.Forms.Button btnAsyncRead;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtPoint;
		private System.Windows.Forms.TextBox txtPLC;
		private System.Windows.Forms.TextBox txtType;
		private System.Windows.Forms.TextBox txtClockWrite;
		private System.Windows.Forms.TextBox txtClockRead;
		private System.Windows.Forms.OpenFileDialog openFileDialog1;
		private System.Windows.Forms.Button btnClockWrite;
		private System.Windows.Forms.Button btnClockRead;
		private System.Windows.Forms.Button btnCloseDevice;
		private System.Windows.Forms.Button btnOpenDevice;
		private System.Windows.Forms.TextBox txtMode;
		private System.Windows.Forms.TextBox txtVal;
		private System.Windows.Forms.Button btnGetMode;
		private System.Windows.Forms.Button btnGetType;
		private System.Windows.Forms.Button btnRead;
		private System.Windows.Forms.Button btnStopData;
		private System.Windows.Forms.ListBox lstPoints;
		private System.Windows.Forms.ListBox lstPLC;
        private System.Windows.Forms.Button btnGetData;

        private BindingSource bindingSource1;
        private CXSLite.CXSLiteCtrl cxsLiteCtrl1;
        private Button button1;
        private Timer timer1;
        private TextBox textBox1;
        private Button btnP1ReadSP;
        private TextBox textBox2;
        private Button btnP1ReadVal;
        private TextBox textBox3;
        private Label label3;
        private TextBox textBox4;
        private Label label4;
        private TextBox textBox5;
        private Label label5;
        private Button button2;
        private TextBox textBox6;
        private Label label6;
        private TextBox textBox7;
        private Label label7;
        private TextBox textBox8;
        private Label label8;
        private TextBox textBox9;
        private Label label9;
        private ListBox listBox2;
        private TextBox textBox10;
        private Label label10;
        private Label label11;
        private TextBox textBox11;
        private TextBox textBox12;
        private Label label12;
        private TextBox textBox13;
        private Label label13;
        private Label label14;
        private TextBox textBox14;
        private Label label15;
        private TextBox textBox15;
        private Label label16;
        private ListBox listBox3;
        private ListBox listBox4;
        private Label label17;
        private TextBox textBox16;
        private Label label18;
        private TextBox textBox17;
        private Label label19;
        private TextBox textBox18;
        private Label label20;
        private TextBox textBox19;
        private TextBox textBox20;
        private ListBox listBox5;
        private Label label21;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private ListBox listBox6;
        private Label label22;
        private ListBox listBox7;
        private Label label23;
        private TextBox textBox21;
        private Timer timer2;
        private TextBox textBox22;
		private System.ComponentModel.IContainer components;

		public Form1()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            this.txtElement = new System.Windows.Forms.TextBox();
            this.txtArray = new System.Windows.Forms.TextBox();
            this.txtAWriteVal = new System.Windows.Forms.TextBox();
            this.btnGetElement = new System.Windows.Forms.Button();
            this.txtElem = new System.Windows.Forms.TextBox();
            this.txtReadVal = new System.Windows.Forms.TextBox();
            this.txtAReadVal = new System.Windows.Forms.TextBox();
            this.txtWrite = new System.Windows.Forms.TextBox();
            this.btnReadArray = new System.Windows.Forms.Button();
            this.btnAsyncWrite = new System.Windows.Forms.Button();
            this.btnWriteArray = new System.Windows.Forms.Button();
            this.btnWrite = new System.Windows.Forms.Button();
            this.btnAsyncRead = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPoint = new System.Windows.Forms.TextBox();
            this.txtPLC = new System.Windows.Forms.TextBox();
            this.txtType = new System.Windows.Forms.TextBox();
            this.txtClockWrite = new System.Windows.Forms.TextBox();
            this.txtClockRead = new System.Windows.Forms.TextBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.btnClockWrite = new System.Windows.Forms.Button();
            this.btnClockRead = new System.Windows.Forms.Button();
            this.btnCloseDevice = new System.Windows.Forms.Button();
            this.btnOpenDevice = new System.Windows.Forms.Button();
            this.txtMode = new System.Windows.Forms.TextBox();
            this.txtVal = new System.Windows.Forms.TextBox();
            this.btnGetMode = new System.Windows.Forms.Button();
            this.btnGetType = new System.Windows.Forms.Button();
            this.btnRead = new System.Windows.Forms.Button();
            this.btnStopData = new System.Windows.Forms.Button();
            this.lstPoints = new System.Windows.Forms.ListBox();
            this.lstPLC = new System.Windows.Forms.ListBox();
            this.btnGetData = new System.Windows.Forms.Button();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.cxsLiteCtrl1 = new CXSLite.CXSLiteCtrl();
            this.button1 = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btnP1ReadSP = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.btnP1ReadVal = new System.Windows.Forms.Button();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox8 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.textBox9 = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.textBox10 = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.textBox11 = new System.Windows.Forms.TextBox();
            this.textBox12 = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.textBox13 = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.textBox14 = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.textBox15 = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.listBox3 = new System.Windows.Forms.ListBox();
            this.listBox4 = new System.Windows.Forms.ListBox();
            this.label17 = new System.Windows.Forms.Label();
            this.textBox16 = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.textBox17 = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.textBox18 = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.textBox19 = new System.Windows.Forms.TextBox();
            this.textBox20 = new System.Windows.Forms.TextBox();
            this.listBox5 = new System.Windows.Forms.ListBox();
            this.label21 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.listBox6 = new System.Windows.Forms.ListBox();
            this.listBox7 = new System.Windows.Forms.ListBox();
            this.label22 = new System.Windows.Forms.Label();
            this.textBox21 = new System.Windows.Forms.TextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.textBox22 = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtElement
            // 
            this.txtElement.Location = new System.Drawing.Point(160, 368);
            this.txtElement.Name = "txtElement";
            this.txtElement.Size = new System.Drawing.Size(72, 20);
            this.txtElement.TabIndex = 62;
            this.txtElement.Text = "IntArray 1[0]";
            // 
            // txtArray
            // 
            this.txtArray.Location = new System.Drawing.Point(160, 336);
            this.txtArray.Name = "txtArray";
            this.txtArray.Size = new System.Drawing.Size(144, 20);
            this.txtArray.TabIndex = 60;
            // 
            // txtAWriteVal
            // 
            this.txtAWriteVal.Location = new System.Drawing.Point(160, 304);
            this.txtAWriteVal.Name = "txtAWriteVal";
            this.txtAWriteVal.Size = new System.Drawing.Size(144, 20);
            this.txtAWriteVal.TabIndex = 58;
            this.txtAWriteVal.Text = "456";
            // 
            // btnGetElement
            // 
            this.btnGetElement.Location = new System.Drawing.Point(8, 368);
            this.btnGetElement.Name = "btnGetElement";
            this.btnGetElement.Size = new System.Drawing.Size(144, 24);
            this.btnGetElement.TabIndex = 61;
            this.btnGetElement.Text = "Get Element";
            this.btnGetElement.Click += new System.EventHandler(this.btnGetElement_Click);
            // 
            // txtElem
            // 
            this.txtElem.Location = new System.Drawing.Point(240, 368);
            this.txtElem.Name = "txtElem";
            this.txtElem.Size = new System.Drawing.Size(64, 20);
            this.txtElem.TabIndex = 64;
            // 
            // txtReadVal
            // 
            this.txtReadVal.Location = new System.Drawing.Point(160, 208);
            this.txtReadVal.Name = "txtReadVal";
            this.txtReadVal.Size = new System.Drawing.Size(144, 20);
            this.txtReadVal.TabIndex = 51;
            // 
            // txtAReadVal
            // 
            this.txtAReadVal.Location = new System.Drawing.Point(160, 240);
            this.txtAReadVal.Name = "txtAReadVal";
            this.txtAReadVal.Size = new System.Drawing.Size(144, 20);
            this.txtAReadVal.TabIndex = 53;
            // 
            // txtWrite
            // 
            this.txtWrite.Location = new System.Drawing.Point(160, 272);
            this.txtWrite.Name = "txtWrite";
            this.txtWrite.Size = new System.Drawing.Size(144, 20);
            this.txtWrite.TabIndex = 55;
            this.txtWrite.Text = "123";
            // 
            // btnReadArray
            // 
            this.btnReadArray.Location = new System.Drawing.Point(80, 336);
            this.btnReadArray.Name = "btnReadArray";
            this.btnReadArray.Size = new System.Drawing.Size(72, 24);
            this.btnReadArray.TabIndex = 59;
            this.btnReadArray.Text = "Read array";
            this.btnReadArray.Click += new System.EventHandler(this.btnReadArray_Click);
            // 
            // btnAsyncWrite
            // 
            this.btnAsyncWrite.Location = new System.Drawing.Point(8, 304);
            this.btnAsyncWrite.Name = "btnAsyncWrite";
            this.btnAsyncWrite.Size = new System.Drawing.Size(144, 24);
            this.btnAsyncWrite.TabIndex = 57;
            this.btnAsyncWrite.Text = "AsyncWrite";
            this.btnAsyncWrite.Click += new System.EventHandler(this.btnAsyncWrite_Click);
            // 
            // btnWriteArray
            // 
            this.btnWriteArray.Location = new System.Drawing.Point(8, 336);
            this.btnWriteArray.Name = "btnWriteArray";
            this.btnWriteArray.Size = new System.Drawing.Size(72, 24);
            this.btnWriteArray.TabIndex = 56;
            this.btnWriteArray.Text = "Write array";
            this.btnWriteArray.Click += new System.EventHandler(this.btnWriteArray_Click);
            // 
            // btnWrite
            // 
            this.btnWrite.Location = new System.Drawing.Point(8, 272);
            this.btnWrite.Name = "btnWrite";
            this.btnWrite.Size = new System.Drawing.Size(144, 24);
            this.btnWrite.TabIndex = 54;
            this.btnWrite.Text = "Write";
            this.btnWrite.Click += new System.EventHandler(this.btnWrite_Click);
            // 
            // btnAsyncRead
            // 
            this.btnAsyncRead.Location = new System.Drawing.Point(8, 240);
            this.btnAsyncRead.Name = "btnAsyncRead";
            this.btnAsyncRead.Size = new System.Drawing.Size(144, 24);
            this.btnAsyncRead.TabIndex = 52;
            this.btnAsyncRead.Text = "AsyncRead";
            this.btnAsyncRead.Click += new System.EventHandler(this.btnAsyncRead_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtPoint);
            this.groupBox1.Controls.Add(this.txtPLC);
            this.groupBox1.Location = new System.Drawing.Point(8, 112);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(296, 48);
            this.groupBox1.TabIndex = 63;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Selection";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(8, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 23);
            this.label2.TabIndex = 28;
            this.label2.Text = "Device:";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(144, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 23);
            this.label1.TabIndex = 27;
            this.label1.Text = "Point:";
            // 
            // txtPoint
            // 
            this.txtPoint.Location = new System.Drawing.Point(184, 16);
            this.txtPoint.Name = "txtPoint";
            this.txtPoint.Size = new System.Drawing.Size(104, 20);
            this.txtPoint.TabIndex = 26;
            // 
            // txtPLC
            // 
            this.txtPLC.Location = new System.Drawing.Point(56, 16);
            this.txtPLC.Name = "txtPLC";
            this.txtPLC.Size = new System.Drawing.Size(80, 20);
            this.txtPLC.TabIndex = 25;
            // 
            // txtType
            // 
            this.txtType.Location = new System.Drawing.Point(160, 400);
            this.txtType.Name = "txtType";
            this.txtType.Size = new System.Drawing.Size(144, 20);
            this.txtType.TabIndex = 74;
            // 
            // txtClockWrite
            // 
            this.txtClockWrite.Location = new System.Drawing.Point(160, 496);
            this.txtClockWrite.Name = "txtClockWrite";
            this.txtClockWrite.Size = new System.Drawing.Size(144, 20);
            this.txtClockWrite.TabIndex = 73;
            this.txtClockWrite.Text = "00/00/0001 00:00:00";
            // 
            // txtClockRead
            // 
            this.txtClockRead.Location = new System.Drawing.Point(160, 464);
            this.txtClockRead.Name = "txtClockRead";
            this.txtClockRead.Size = new System.Drawing.Size(144, 20);
            this.txtClockRead.TabIndex = 72;
            // 
            // btnClockWrite
            // 
            this.btnClockWrite.Location = new System.Drawing.Point(8, 496);
            this.btnClockWrite.Name = "btnClockWrite";
            this.btnClockWrite.Size = new System.Drawing.Size(144, 23);
            this.btnClockWrite.TabIndex = 71;
            this.btnClockWrite.Text = "ClockWrite";
            this.btnClockWrite.Click += new System.EventHandler(this.btnClockWrite_Click);
            // 
            // btnClockRead
            // 
            this.btnClockRead.Location = new System.Drawing.Point(8, 464);
            this.btnClockRead.Name = "btnClockRead";
            this.btnClockRead.Size = new System.Drawing.Size(144, 23);
            this.btnClockRead.TabIndex = 70;
            this.btnClockRead.Text = "ClockRead";
            this.btnClockRead.Click += new System.EventHandler(this.btnClockRead_Click);
            // 
            // btnCloseDevice
            // 
            this.btnCloseDevice.Location = new System.Drawing.Point(160, 528);
            this.btnCloseDevice.Name = "btnCloseDevice";
            this.btnCloseDevice.Size = new System.Drawing.Size(144, 23);
            this.btnCloseDevice.TabIndex = 69;
            this.btnCloseDevice.Text = "CloseDevice";
            this.btnCloseDevice.Click += new System.EventHandler(this.btnCloseDevice_Click);
            // 
            // btnOpenDevice
            // 
            this.btnOpenDevice.Location = new System.Drawing.Point(8, 528);
            this.btnOpenDevice.Name = "btnOpenDevice";
            this.btnOpenDevice.Size = new System.Drawing.Size(144, 23);
            this.btnOpenDevice.TabIndex = 68;
            this.btnOpenDevice.Text = "OpenDevice";
            this.btnOpenDevice.Click += new System.EventHandler(this.btnOpenDevice_Click);
            // 
            // txtMode
            // 
            this.txtMode.Location = new System.Drawing.Point(160, 432);
            this.txtMode.Name = "txtMode";
            this.txtMode.Size = new System.Drawing.Size(144, 20);
            this.txtMode.TabIndex = 67;
            // 
            // txtVal
            // 
            this.txtVal.Location = new System.Drawing.Point(160, 176);
            this.txtVal.Name = "txtVal";
            this.txtVal.Size = new System.Drawing.Size(144, 20);
            this.txtVal.TabIndex = 46;
            // 
            // btnGetMode
            // 
            this.btnGetMode.Location = new System.Drawing.Point(8, 432);
            this.btnGetMode.Name = "btnGetMode";
            this.btnGetMode.Size = new System.Drawing.Size(144, 24);
            this.btnGetMode.TabIndex = 66;
            this.btnGetMode.Text = "GetMode";
            this.btnGetMode.Click += new System.EventHandler(this.btnGetMode_Click);
            // 
            // btnGetType
            // 
            this.btnGetType.Location = new System.Drawing.Point(8, 400);
            this.btnGetType.Name = "btnGetType";
            this.btnGetType.Size = new System.Drawing.Size(144, 24);
            this.btnGetType.TabIndex = 65;
            this.btnGetType.Text = "GetType";
            this.btnGetType.Click += new System.EventHandler(this.btnGetType_Click);
            // 
            // btnRead
            // 
            this.btnRead.Location = new System.Drawing.Point(8, 208);
            this.btnRead.Name = "btnRead";
            this.btnRead.Size = new System.Drawing.Size(144, 24);
            this.btnRead.TabIndex = 50;
            this.btnRead.Text = "Read";
            this.btnRead.Click += new System.EventHandler(this.btnRead_Click);
            // 
            // btnStopData
            // 
            this.btnStopData.Location = new System.Drawing.Point(80, 176);
            this.btnStopData.Name = "btnStopData";
            this.btnStopData.Size = new System.Drawing.Size(72, 24);
            this.btnStopData.TabIndex = 49;
            this.btnStopData.Text = "StopData";
            this.btnStopData.Click += new System.EventHandler(this.btnStopData_Click);
            // 
            // lstPoints
            // 
            this.lstPoints.Location = new System.Drawing.Point(160, 8);
            this.lstPoints.Name = "lstPoints";
            this.lstPoints.Size = new System.Drawing.Size(144, 95);
            this.lstPoints.TabIndex = 48;
            this.lstPoints.SelectedIndexChanged += new System.EventHandler(this.lstPoints_SelectedIndexChanged);
            // 
            // lstPLC
            // 
            this.lstPLC.Location = new System.Drawing.Point(8, 8);
            this.lstPLC.Name = "lstPLC";
            this.lstPLC.Size = new System.Drawing.Size(144, 95);
            this.lstPLC.TabIndex = 47;
            this.lstPLC.SelectedIndexChanged += new System.EventHandler(this.lstPLC_SelectedIndexChanged);
            // 
            // btnGetData
            // 
            this.btnGetData.Location = new System.Drawing.Point(8, 176);
            this.btnGetData.Name = "btnGetData";
            this.btnGetData.Size = new System.Drawing.Size(72, 24);
            this.btnGetData.TabIndex = 45;
            this.btnGetData.Text = "GetData";
            this.btnGetData.Click += new System.EventHandler(this.btnGetData_Click);
            // 
            // cxsLiteCtrl1
            // 
            this.cxsLiteCtrl1.Devices = null;
            this.cxsLiteCtrl1.Location = new System.Drawing.Point(8, 90);
            this.cxsLiteCtrl1.Name = "cxsLiteCtrl1";
            this.cxsLiteCtrl1.Points = null;
            this.cxsLiteCtrl1.Size = new System.Drawing.Size(64, 64);
            this.cxsLiteCtrl1.TabIndex = 29;
            this.cxsLiteCtrl1.Text = "cxsLiteCtrl1";
            this.cxsLiteCtrl1.OnDataChange += new CXSLite.CXSLiteCtrl.OnDataChangeHandler(this.cxsLiteCtrl1_OnDataChange);
            this.cxsLiteCtrl1.OnReadComplete += new CXSLite.CXSLiteCtrl.OnReadCompleteHandler(this.cxsLiteCtrl1_OnReadComplete);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(160, 567);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(144, 23);
            this.button1.TabIndex = 75;
            this.button1.Text = "LoadProgram";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(482, 40);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(70, 20);
            this.textBox1.TabIndex = 76;
            // 
            // btnP1ReadSP
            // 
            this.btnP1ReadSP.Location = new System.Drawing.Point(332, 40);
            this.btnP1ReadSP.Name = "btnP1ReadSP";
            this.btnP1ReadSP.Size = new System.Drawing.Size(132, 23);
            this.btnP1ReadSP.TabIndex = 77;
            this.btnP1ReadSP.Text = "P1ReadSP";
            this.btnP1ReadSP.UseVisualStyleBackColor = true;
            this.btnP1ReadSP.Click += new System.EventHandler(this.btnP1ReadSP_Click);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(482, 103);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(70, 20);
            this.textBox2.TabIndex = 78;
            // 
            // btnP1ReadVal
            // 
            this.btnP1ReadVal.Location = new System.Drawing.Point(332, 103);
            this.btnP1ReadVal.Name = "btnP1ReadVal";
            this.btnP1ReadVal.Size = new System.Drawing.Size(132, 23);
            this.btnP1ReadVal.TabIndex = 79;
            this.btnP1ReadVal.Text = "P1ReadVal";
            this.btnP1ReadVal.UseVisualStyleBackColor = true;
            this.btnP1ReadVal.Click += new System.EventHandler(this.btnP1ReadVal_Click);
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(482, 134);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(70, 20);
            this.textBox3.TabIndex = 80;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(373, 138);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 13);
            this.label3.TabIndex = 81;
            this.label3.Text = "P1 Slew Time";
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(482, 186);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(70, 20);
            this.textBox4.TabIndex = 82;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(348, 189);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(116, 13);
            this.label4.TabIndex = 83;
            this.label4.Text = "P1CaliberationOperator";
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(482, 160);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(70, 20);
            this.textBox5.TabIndex = 84;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(347, 167);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(122, 13);
            this.label5.TabIndex = 85;
            this.label5.Text = "P1CaliberationAutomatic";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(487, 567);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 86;
            this.button2.Text = "Exit";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(482, 8);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(70, 20);
            this.textBox6.TabIndex = 88;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(373, 11);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(54, 13);
            this.label6.TabIndex = 89;
            this.label6.Text = "PManifold";
            // 
            // textBox7
            // 
            this.textBox7.Location = new System.Drawing.Point(482, 77);
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new System.Drawing.Size(70, 20);
            this.textBox7.TabIndex = 90;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(358, 77);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(69, 13);
            this.label7.TabIndex = 91;
            this.label7.Text = "P1Difference";
            // 
            // textBox8
            // 
            this.textBox8.Location = new System.Drawing.Point(487, 275);
            this.textBox8.Name = "textBox8";
            this.textBox8.Size = new System.Drawing.Size(65, 20);
            this.textBox8.TabIndex = 92;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(365, 279);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(99, 13);
            this.label8.TabIndex = 93;
            this.label8.Text = "P1LowerDeadband";
            // 
            // textBox9
            // 
            this.textBox9.Location = new System.Drawing.Point(487, 308);
            this.textBox9.Name = "textBox9";
            this.textBox9.Size = new System.Drawing.Size(65, 20);
            this.textBox9.TabIndex = 94;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(365, 315);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(99, 13);
            this.label9.TabIndex = 95;
            this.label9.Text = "P1UpperDeadband";
            // 
            // listBox2
            // 
            this.listBox2.FormatString = "N2";
            this.listBox2.FormattingEnabled = true;
            this.listBox2.Location = new System.Drawing.Point(399, 387);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(111, 121);
            this.listBox2.TabIndex = 97;
            // 
            // textBox10
            // 
            this.textBox10.Location = new System.Drawing.Point(487, 334);
            this.textBox10.Name = "textBox10";
            this.textBox10.Size = new System.Drawing.Size(65, 20);
            this.textBox10.TabIndex = 98;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(393, 341);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(56, 13);
            this.label10.TabIndex = 99;
            this.label10.Text = "Difference";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(389, 219);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(60, 13);
            this.label11.TabIndex = 100;
            this.label11.Text = "P1Request";
            // 
            // textBox11
            // 
            this.textBox11.Location = new System.Drawing.Point(482, 219);
            this.textBox11.Name = "textBox11";
            this.textBox11.Size = new System.Drawing.Size(70, 20);
            this.textBox11.TabIndex = 101;
            // 
            // textBox12
            // 
            this.textBox12.Location = new System.Drawing.Point(487, 514);
            this.textBox12.Name = "textBox12";
            this.textBox12.Size = new System.Drawing.Size(65, 20);
            this.textBox12.TabIndex = 102;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(404, 517);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(65, 13);
            this.label12.TabIndex = 103;
            this.label12.Text = "P1Rqtbinary";
            // 
            // textBox13
            // 
            this.textBox13.Location = new System.Drawing.Point(482, 245);
            this.textBox13.Name = "textBox13";
            this.textBox13.Size = new System.Drawing.Size(70, 20);
            this.textBox13.TabIndex = 104;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(382, 247);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(82, 13);
            this.label13.TabIndex = 105;
            this.label13.Text = "P1Requestwrite";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(444, 368);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(108, 13);
            this.label14.TabIndex = 106;
            this.label14.Text = "Recording Difference";
            // 
            // textBox14
            // 
            this.textBox14.Location = new System.Drawing.Point(103, 29);
            this.textBox14.Name = "textBox14";
            this.textBox14.Size = new System.Drawing.Size(88, 20);
            this.textBox14.TabIndex = 107;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(51, 32);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(46, 13);
            this.label15.TabIndex = 108;
            this.label15.Text = "P1Timer";
            // 
            // textBox15
            // 
            this.textBox15.Location = new System.Drawing.Point(103, 64);
            this.textBox15.Name = "textBox15";
            this.textBox15.Size = new System.Drawing.Size(88, 20);
            this.textBox15.TabIndex = 109;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(26, 69);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(71, 13);
            this.label16.TabIndex = 110;
            this.label16.Text = "P1TimerWrite";
            // 
            // listBox3
            // 
            this.listBox3.FormattingEnabled = true;
            this.listBox3.Location = new System.Drawing.Point(71, 118);
            this.listBox3.Name = "listBox3";
            this.listBox3.Size = new System.Drawing.Size(120, 95);
            this.listBox3.TabIndex = 111;
            // 
            // listBox4
            // 
            this.listBox4.FormattingEnabled = true;
            this.listBox4.Location = new System.Drawing.Point(71, 250);
            this.listBox4.Name = "listBox4";
            this.listBox4.Size = new System.Drawing.Size(120, 95);
            this.listBox4.TabIndex = 112;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(100, 228);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(56, 13);
            this.label17.TabIndex = 113;
            this.label17.Text = "Difference";
            // 
            // textBox16
            // 
            this.textBox16.Location = new System.Drawing.Point(335, 30);
            this.textBox16.Name = "textBox16";
            this.textBox16.Size = new System.Drawing.Size(53, 20);
            this.textBox16.TabIndex = 114;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(282, 32);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(47, 13);
            this.label18.TabIndex = 115;
            this.label18.Text = "E9_0.07";
            // 
            // textBox17
            // 
            this.textBox17.Location = new System.Drawing.Point(335, 62);
            this.textBox17.Name = "textBox17";
            this.textBox17.Size = new System.Drawing.Size(53, 20);
            this.textBox17.TabIndex = 116;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(282, 65);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(47, 13);
            this.label19.TabIndex = 117;
            this.label19.Text = "E9_0.03";
            // 
            // textBox18
            // 
            this.textBox18.Location = new System.Drawing.Point(335, 98);
            this.textBox18.Name = "textBox18";
            this.textBox18.Size = new System.Drawing.Size(53, 20);
            this.textBox18.TabIndex = 118;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(297, 98);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(32, 13);
            this.label20.TabIndex = 119;
            this.label20.Text = "T202";
            // 
            // textBox19
            // 
            this.textBox19.Location = new System.Drawing.Point(215, 30);
            this.textBox19.Name = "textBox19";
            this.textBox19.Size = new System.Drawing.Size(61, 20);
            this.textBox19.TabIndex = 120;
            // 
            // textBox20
            // 
            this.textBox20.Location = new System.Drawing.Point(215, 62);
            this.textBox20.Name = "textBox20";
            this.textBox20.Size = new System.Drawing.Size(61, 20);
            this.textBox20.TabIndex = 121;
            // 
            // listBox5
            // 
            this.listBox5.FormattingEnabled = true;
            this.listBox5.Location = new System.Drawing.Point(259, 155);
            this.listBox5.Name = "listBox5";
            this.listBox5.Size = new System.Drawing.Size(70, 95);
            this.listBox5.TabIndex = 122;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(257, 125);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(79, 13);
            this.label21.TabIndex = 123;
            this.label21.Text = "Values of T202";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(582, 20);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(412, 460);
            this.tabControl1.TabIndex = 124;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.textBox22);
            this.tabPage1.Controls.Add(this.label23);
            this.tabPage1.Controls.Add(this.textBox21);
            this.tabPage1.Controls.Add(this.label22);
            this.tabPage1.Controls.Add(this.listBox7);
            this.tabPage1.Controls.Add(this.listBox3);
            this.tabPage1.Controls.Add(this.label21);
            this.tabPage1.Controls.Add(this.textBox14);
            this.tabPage1.Controls.Add(this.listBox5);
            this.tabPage1.Controls.Add(this.label15);
            this.tabPage1.Controls.Add(this.textBox20);
            this.tabPage1.Controls.Add(this.textBox15);
            this.tabPage1.Controls.Add(this.textBox19);
            this.tabPage1.Controls.Add(this.label16);
            this.tabPage1.Controls.Add(this.label20);
            this.tabPage1.Controls.Add(this.listBox4);
            this.tabPage1.Controls.Add(this.textBox18);
            this.tabPage1.Controls.Add(this.label17);
            this.tabPage1.Controls.Add(this.label19);
            this.tabPage1.Controls.Add(this.label18);
            this.tabPage1.Controls.Add(this.textBox17);
            this.tabPage1.Controls.Add(this.textBox16);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(404, 434);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.listBox6);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(404, 434);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // listBox6
            // 
            this.listBox6.FormattingEnabled = true;
            this.listBox6.Location = new System.Drawing.Point(101, 55);
            this.listBox6.Name = "listBox6";
            this.listBox6.Size = new System.Drawing.Size(120, 95);
            this.listBox6.TabIndex = 0;
            // 
            // listBox7
            // 
            this.listBox7.FormattingEnabled = true;
            this.listBox7.Location = new System.Drawing.Point(259, 294);
            this.listBox7.Name = "listBox7";
            this.listBox7.Size = new System.Drawing.Size(70, 95);
            this.listBox7.TabIndex = 124;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(257, 272);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(79, 13);
            this.label22.TabIndex = 125;
            this.label22.Text = "Values of T203";
            // 
            // textBox21
            // 
            this.textBox21.Location = new System.Drawing.Point(335, 256);
            this.textBox21.Name = "textBox21";
            this.textBox21.Size = new System.Drawing.Size(53, 20);
            this.textBox21.TabIndex = 126;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(347, 233);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(32, 13);
            this.label23.TabIndex = 127;
            this.label23.Text = "T203";
            // 
            // timer2
            // 
            this.timer2.Interval = 1000;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // textBox22
            // 
            this.textBox22.Location = new System.Drawing.Point(335, 293);
            this.textBox22.Name = "textBox22";
            this.textBox22.Size = new System.Drawing.Size(63, 20);
            this.textBox22.TabIndex = 128;
            // 
            // Form1
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(1287, 620);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.textBox13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.textBox12);
            this.Controls.Add(this.textBox11);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.textBox10);
            this.Controls.Add(this.listBox2);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.textBox9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.textBox8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.textBox7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textBox6);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.btnP1ReadVal);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.btnP1ReadSP);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtAWriteVal);
            this.Controls.Add(this.btnGetElement);
            this.Controls.Add(this.txtElem);
            this.Controls.Add(this.txtReadVal);
            this.Controls.Add(this.txtAReadVal);
            this.Controls.Add(this.txtWrite);
            this.Controls.Add(this.btnReadArray);
            this.Controls.Add(this.btnAsyncWrite);
            this.Controls.Add(this.btnWriteArray);
            this.Controls.Add(this.btnWrite);
            this.Controls.Add(this.btnAsyncRead);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txtType);
            this.Controls.Add(this.txtClockWrite);
            this.Controls.Add(this.txtClockRead);
            this.Controls.Add(this.btnClockWrite);
            this.Controls.Add(this.btnClockRead);
            this.Controls.Add(this.btnCloseDevice);
            this.Controls.Add(this.btnOpenDevice);
            this.Controls.Add(this.txtMode);
            this.Controls.Add(this.txtVal);
            this.Controls.Add(this.btnGetMode);
            this.Controls.Add(this.btnGetType);
            this.Controls.Add(this.btnRead);
            this.Controls.Add(this.btnStopData);
            this.Controls.Add(this.lstPoints);
            this.Controls.Add(this.lstPLC);
            this.Controls.Add(this.btnGetData);
            this.Controls.Add(this.txtElement);
            this.Controls.Add(this.txtArray);
            this.Controls.Add(this.cxsLiteCtrl1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion


		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			try
			{
				Application.Run(new Form1());
			}
			catch(Exception e)
			{
				String s = e.ToString();
			}
		}


       
		private void btnGetData_Click(object sender, System.EventArgs e)
		{
            int update = 1;
			cxsLiteCtrl1.GetData(txtPLC.Text, txtPoint.Text, update);
		}

		private void btnStopData_Click(object sender, System.EventArgs e)
		{
			cxsLiteCtrl1.StopData(txtPLC.Text, txtPoint.Text);
		}

		private void btnRead_Click(object sender, System.EventArgs e)
		{
			object Value = null;
			bool Quality = false;
			if(cxsLiteCtrl1.Read(txtPLC.Text,txtPoint.Text, out Value, out Quality))
				txtReadVal.Text = Value.ToString();

            timer1.Enabled = true;
		}

		private void btnAsyncRead_Click(object sender, System.EventArgs e)
		{
			cxsLiteCtrl1.ReadAsync(txtPLC.Text,txtPoint.Text);
		}

		private void btnWrite_Click(object sender, System.EventArgs e)
		{
			cxsLiteCtrl1.Write(txtPLC.Text,txtPoint.Text, txtWrite.Text);
            MessageBox.Show(txtPLC.Text);
            MessageBox.Show(txtPoint.Text);
            MessageBox.Show(txtWrite.Text);



		}

		private void btnAsyncWrite_Click(object sender, System.EventArgs e)
		{
			cxsLiteCtrl1.WriteAsync(txtPLC.Text,txtPoint.Text, txtAWriteVal.Text);
		}

		private void btnWriteArray_Click(object sender, System.EventArgs e)
		{
			short[] myarray = new short[10] { 1,2,3,4,5,6,7,8,9,10 };
			cxsLiteCtrl1.Write(txtPLC.Text,"IntArray 1", myarray);
		}

		private void btnReadArray_Click(object sender, System.EventArgs e)
		{
			txtArray.Clear();		
			object Value = null;
			bool BadQuality = false;
			cxsLiteCtrl1.Read(txtPLC.Text,"IntArray 1", out Value, out BadQuality);
			if(!BadQuality)
			{
				foreach(object o in (Array)Value)
					txtArray.Text += o.ToString() + ", ";
			}
		}

		private void btnGetElement_Click(object sender, System.EventArgs e)
		{
			object Value = null;
			bool Quality = false;
			if (cxsLiteCtrl1.Read(txtPLC.Text,txtElement.Text, out Value, out Quality))
				txtElem.Text = Value.ToString();
		}

		private void btnGetType_Click(object sender, System.EventArgs e)
		{
			string Result = "";
			cxsLiteCtrl1.TypeName(txtPLC.Text,out Result);
			txtType.Text = Result;
		}

		private void btnGetMode_Click(object sender, System.EventArgs e)
		{
			int Result = 0;
			cxsLiteCtrl1.RunMode(txtPLC.Text, out Result);
			txtMode.Text = Result.ToString();
		}

		private void btnClockRead_Click(object sender, System.EventArgs e)
		{
			DateTime dt = new DateTime(); 
			bool bOK = cxsLiteCtrl1.ClockRead(txtPLC.Text, out dt);
			txtClockRead.Text = dt.ToString();
		}

		private void btnClockWrite_Click(object sender, System.EventArgs e)
		{
			DateTime dt = new DateTime();
			try
			{
				dt = DateTime.Parse(txtClockWrite.Text);
			}
			catch (Exception ex)
			{
				string exception = ex.ToString();
				// probably invalid text, just use current time
				dt = DateTime.Now;
			}
			bool bOK = cxsLiteCtrl1.ClockWrite(txtPLC.Text, dt);
		}

		private void btnOpenDevice_Click(object sender, System.EventArgs e)
		{
			bool bOK = cxsLiteCtrl1.OpenDevice(txtPLC.Text);
		}

		private void btnCloseDevice_Click(object sender, System.EventArgs e)
		{
			bool bOK = cxsLiteCtrl1.CloseDevice(txtPLC.Text);
		}

     	private void lstPoints_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			txtPoint.Text = (string)lstPoints.Items[lstPoints.SelectedIndex];
		}

		private void lstPLC_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			string[] Names = null;
			cxsLiteCtrl1.ListPoints((string)lstPLC.Items[lstPLC.SelectedIndex], out Names);
			txtPLC.Text = (string)lstPLC.Items[lstPLC.SelectedIndex];
			lstPoints.DataSource = Names;
		}

		private void SelectProjectPath()
		{
			openFileDialog1.Filter = "CXServer Project Files(*.cdm)|*.cdm|All files (*.*)|*.*";
			DialogResult result = openFileDialog1.ShowDialog();
			if (result == DialogResult.OK && openFileDialog1.FileName != "")
				cxsLiteCtrl1.ProjectName = openFileDialog1.FileName.ToString();
		}

        private void Form1_Load(object sender, System.EventArgs e)
        {
            SelectProjectPath();
            lstPLC.DataSource = cxsLiteCtrl1.Devices;
        }

        private void cxsLiteCtrl1_OnDataChange(object sender, CXSLite.CXSLiteCtrl.DataChangeArgs e)
        {
            object Value = e.Value;
            txtVal.Text = e.Value.ToString();
            MessageBox.Show(Value.ToString());
        }

        private void cxsLiteCtrl1_OnReadComplete(object sender, CXSLite.CXSLiteCtrl.DataChangeArgs e)
        {
            txtAReadVal.Text = e.Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool Success;
            bool IsConnected;

            bool _bWait = true;
            bool _bReportP = true;


            bool bOK = cxsLiteCtrl1.OpenDevice(txtPLC.Text);

            IsConnected = cxsLiteCtrl1.Connect();  // Comms1.IsActive(txtPLC.Text);

            if (IsConnected && bOK)
            {
                MessageBox.Show("connected");


                
                            openFileDialog1.Filter = "CXServer Project Files(*.prg)|*.obj|All files (*.*)|*.*";
                            DialogResult result = openFileDialog1.ShowDialog();
                            if (result == DialogResult.OK && openFileDialog1.FileName != "")
                            {
                                MessageBox.Show("PLC:  " + txtPLC.Text);
                                //Success = cxsLiteCtrl1.DownloadProgram(txtPLC.Text, "c:\test.obj", "", true, true);

                                MessageBox.Show("download:  " + openFileDialog1.FileName);
                            }
                            //  bool Success1 = cxsLiteCtrl1.Protect("BSEPLC", false, "12345678", 2468);



                            //  Success = cxsLiteCtrl1.DownloadProgram(txtPLC.Text, "C:\\PLC\\BSEPLC.OBJ", "PRG", true, true);
                            Success = cxsLiteCtrl1.DownloadProgram(txtPLC.Text, openFileDialog1.FileName, "PRG", true, false);
                            //   Success = cxsLiteCtrl1.DownloadProgram("MyBSEPLC", "C:\\PLC\\BSEPLC.OBJ", "PRG", true, true);
                            //Success = cxsLiteCtrl1.DownloadProgram(txtPLC.Text, "C:\\PLC\\BSEPLC.OBJ", "PRG", _bWait, _bReportP);           


                            // cxsLiteCtrl1.ProjectName = openFileDialog1.FileName.ToString();
                
               
                if (_bWait == true)
                {
                    MessageBox.Show("wait ok");
                }
                else
                {
                    MessageBox.Show("wait Fail");
                }


                if (_bReportP == true)
                {
                    MessageBox.Show("reportP ok");
                }
                else
                {
                    MessageBox.Show("reportP Fail");
                }

                if (Success == true)
                {
                    MessageBox.Show("download ok");
                }
                else
                {
                    MessageBox.Show("download Fail");
                }



            }
            else
            {
                MessageBox.Show("not connected");
                // return;
            }

        }
  
        int value1, value2;
        int value3, value4;
       double value5, value6, value7;
    //   int value8;
       int value13;
       int value15;
     //   int value16;
     //   int value17;
        int value18;
        int value19;
        int value23;
        int value24;
        int value25;
        int value26;
        int value27;


  //     bool testBool = true;
    //   bool valuetest;
      
    //   bool value21;
       bool value22;
      

           private void timer1_Tick(object sender, EventArgs e)
        {

            object Value = null;
            bool Quality = false;
            bool IsConnected;
            
            bool bOK = cxsLiteCtrl1.OpenDevice(txtPLC.Text);
            IsConnected = cxsLiteCtrl1.Connect();
          if (IsConnected && bOK)
          {
              
              if (cxsLiteCtrl1.Read(txtPLC.Text, "P1CalOp", out Value, out Quality))
                  textBox4.Text = Value.ToString();

              if (cxsLiteCtrl1.Read(txtPLC.Text, "P1Lower", out Value, out Quality))
                    textBox8.Text = Value.ToString();
                          value3 = value2 + int.Parse(textBox8.Text);
                          textBox8.Text = value3.ToString();
                          value5 = double.Parse(textBox8.Text) / 100;
                          textBox8.Text = value5.ToString();

              if (cxsLiteCtrl1.Read(txtPLC.Text, "P1Upper", out Value, out Quality))
                  textBox9.Text = Value.ToString();
                          value4 = value2 + int.Parse(textBox9.Text);
                          textBox9.Text = value4.ToString();
                          value6 = double.Parse(textBox9.Text) / 100;
                          textBox9.Text = value6.ToString();

             if (cxsLiteCtrl1.Read(txtPLC.Text, "P1Timer", out Value, out Quality))
                  textBox14.Text = Value.ToString();
                 int value17 = int.Parse(textBox14.Text);


            if (cxsLiteCtrl1.Read(txtPLC.Text, "PM", out Value, out Quality))
                     textBox6.Text = Value.ToString();
            if (cxsLiteCtrl1.Read(txtPLC.Text, "PACE1_SP", out Value, out Quality))
                     textBox1.Text = Value.ToString();
                              value1 = int.Parse(textBox6.Text);
                              textBox6.Text = value1.ToString();
                              value7 = double.Parse(textBox6.Text);
                              textBox6.Text = value7.ToString();
                              value2 = int.Parse(textBox1.Text);

            
             if (cxsLiteCtrl1.Read(txtPLC.Text, "P1CalAuto", out Value, out Quality))
                                  textBox5.Text = Value.ToString();
              value26 = int.Parse(textBox5.Text);

              listBox6.Items.Add(value26);

          //    cxsLiteCtrl1.Read(txtPLC.Text, "TimerCond", out Value, out Quality);
            //  textBox21.Text = Value.ToString();
              //value27 = int.Parse(textBox21.Text);


              //cxsLiteCtrl1.Write(txtPLC.Text, txtPoint.Text, txtWrite.Text);
              //textBox22.Text = value27.ToString();
              //value28 = int.Parse(textBox22.Text);
              //listBox7.Items.Add(textBox22.Text);

              cxsLiteCtrl1.Read(txtPLC.Text, "TimerCond", out Value, out Quality);
             textBox21.Text = Value.ToString();
             value27 = int.Parse(textBox21.Text);


              cxsLiteCtrl1.Write(txtPLC.Text, txtPoint.Text, txtWrite.Text);
              textBox22.Text = value27.ToString();
              value28 = int.Parse(textBox22.Text);
              if(value3 < value28 > value4)
              {

               listBox7.Items.Add(value28);
              }
         cxsLiteCtrl1.Read(txtPLC.Text, "P1Stable", out Value, out Quality);
         textBox11.Text = Value.ToString();
         bool value14 = bool.Parse(textBox11.Text);

         
         cxsLiteCtrl1.Write(txtPLC.Text, txtPoint.Text, txtWrite.Text);
         textBox13.Text = value14.ToString();    
         value13 = Convert.ToInt32(value14);
         textBox12.Text = value13.ToString();
        
        if(value13 == 1)
        {
       
           if (cxsLiteCtrl1.Read(txtPLC.Text, "Difference", out Value, out Quality))
            textBox10.Text = Value.ToString();
            value15 = int.Parse(textBox10.Text);
            listBox2.Items.Add(value15);



            cxsLiteCtrl1.Write(txtPLC.Text, txtPLC.Text, txtWrite.Text);
            textBox15.Text = value17.ToString();
            value18 = int.Parse(textBox15.Text);

            
            listBox3.Items.Add(value18);
            value19 = ((value18 - 10000) * (-1));
            if (value19 < 10000)
            {
                if (value19 > 0)
                {
                    listBox4.Items.Add(value19);
                }
            }

        
            FileInfo fi = new FileInfo(@"C:\Testing\Myprogram.txt");
            FileStream fstr = fi.Create();
            System.IO.StreamWriter SaveFile = new System.IO.StreamWriter(fstr);

           foreach(var item in listBox2.Items)
             {
                  SaveFile.WriteLine(item.ToString());
               }
           SaveFile.Close();

           cxsLiteCtrl1.Read(txtPLC.Text, "CondTimer1", out Value, out Quality);
           textBox16.Text = Value.ToString();
     
           bool value21 = bool.Parse(textBox16.Text);
           value23 = Convert.ToInt32(value21);

           cxsLiteCtrl1.Write(txtPLC.Text, txtPLC.Text, txtWrite.Text);
           textBox19.Text = value23.ToString();
           


           cxsLiteCtrl1.Read(txtPLC.Text, "CondTimer2", out Value, out Quality);
           textBox17.Text = Value.ToString();
           value22 = bool.Parse(textBox17.Text);
           value24 = Convert.ToInt32(value22);

           cxsLiteCtrl1.Write(txtPLC.Text, "CondTimer2", txtWrite.Text);
           textBox20.Text = value24.ToString();
          
          


           if (value23 == 1 && value24 == 1)
           {
               
               
                       cxsLiteCtrl1.Read(txtPLC.Text, "CondTrue", out Value, out Quality);
                       textBox18.Text = Value.ToString();
                       value25 = int.Parse(textBox18.Text);
                       listBox5.Items.Add(value25);

                                             
                       //value27 = int.Parse(textBox21.Text);
                       
                                     
                            
               }

          
         

        }
 
    
               
        }
        }



           int value28;
           private void timer2_Tick(object sender, EventArgs e)
           {
               object Value = null;
               bool Quality = false;
               bool IsConnected;

               bool bOK = cxsLiteCtrl1.OpenDevice(txtPLC.Text);
               IsConnected = cxsLiteCtrl1.Connect();
               if (IsConnected && bOK)
               {


                   cxsLiteCtrl1.Read(txtPLC.Text, "TimerCond", out Value, out Quality);
                   textBox21.Text = Value.ToString();
                   value27 = int.Parse(textBox21.Text);


                   cxsLiteCtrl1.Write(txtPLC.Text, txtPoint.Text, txtWrite.Text);
                   textBox22.Text = value27.ToString();
                   value28 = int.Parse(textBox22.Text);
                   listBox7.Items.Add(textBox22.Text);

               }



           }


        private void WHILE(bool p)
        {
            throw new NotImplementedException();
        }


        
        private void btnP1ReadSP_Click(object sender, EventArgs e)
        {
            object Value = null;
            bool Quality = false;
            bool IsConnected;
       //     int value1, value2, result = 0;

            bool bOK = cxsLiteCtrl1.OpenDevice(txtPLC.Text);

            IsConnected = cxsLiteCtrl1.Connect();  // Comms1.IsActive(txtPLC.Text);

            if (IsConnected && bOK)
            {
                if (cxsLiteCtrl1.Read(txtPLC.Text, "PACE1_SP", out Value, out Quality))
                    textBox1.Text = Value.ToString();
            }

                   }

        private void btnP1ReadVal_Click(object sender, EventArgs e)
        {
            object Value = null;
            bool Quality = false;
            bool IsConnected;

            bool bOK = cxsLiteCtrl1.OpenDevice(txtPLC.Text);

            IsConnected = cxsLiteCtrl1.Connect();  // Comms1.IsActive(txtPLC.Text);

            if (IsConnected && bOK)
            {
                if (cxsLiteCtrl1.Read(txtPLC.Text, "P1_Valve", out Value, out Quality))
                    textBox2.Text = Value.ToString();
            }
        }

       
                 private void button2_Click(object sender, EventArgs e)
           {
               System.Windows.Forms.Application.Exit();
           }

       
       




      

       
    }
}
