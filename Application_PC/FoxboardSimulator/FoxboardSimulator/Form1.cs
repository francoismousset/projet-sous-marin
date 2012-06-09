/**********************************************************************
*
* File name	        : Form1.cs
* Title 		    : FoxboardSimulator
* Author 		    : Michaël Brogniaux - Copyright (C) 2012
* Created		    : 09/06/2012
* Last revised	    : 09/06/2012
* Version		    : 0.1
* Compliler		    : Microsoft Visual Studio 2010 Ultimate
* Type              : Application Windows Forms
* Language          : C#
*
'*********************************************************************/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using SerialProtocol3964r;
using System.Threading;
using System.IO.Ports;


namespace FoxboardSimulator
{
    public partial class MainForm : Form
    {
        private static SerialPort3964r _serial;
        public byte[] _data;
        public byte[] _dataR;
        private static string[] myPort;


        public MainForm()
        {
            InitializeComponent();
            _serial = new SerialPort3964r(false);
            myPort = SerialPort3964r.GetPortNames(); //Obtenir tous les ports COM valides
            for (int i = 0; i < myPort.Length;i++)
            {
                CbPort.Items.Add(myPort[i]);
            }

            this.CbBaud.Items.Add(600) ;      //Peuplement de la combobox avec les différents baud rates
            this.CbBaud.Items.Add(1200);
            this.CbBaud.Items.Add(4800);
            this.CbBaud.Items.Add(9600);
            this.CbBaud.Items.Add(14400);
            this.CbBaud.Items.Add(19200);
            this.CbBaud.Items.Add(38400);
            this.CbBaud.Items.Add(57600);
            this.CbBaud.Items.Add(115200);

            this.CbPort.SelectedIndex = 0;      //1er port COM par défaut
            this.CbBaud.SelectedIndex = 3;     //4ème baud rate par défaut

            _data = new byte[3];
            _dataR = new byte[10];
     
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void CbPort_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void BtConnect_Click(object sender, EventArgs e)
        {
            try
            {
                //Propriétés du port COM
                _serial.PortName = CbPort.Text;       //Port COM choisi;
                _serial.BaudRate = Int32.Parse(this.CbBaud.Text); // Baud rate choisi
                //_serial.ReadTimeout = 1000;
                _serial.Parity = System.IO.Ports.Parity.None;
                _serial.StopBits = System.IO.Ports.StopBits.One;
                _serial.DataBits = 8;
                _serial.WriteBufferSize = 2048;
                _serial.ReadBufferSize = 4096;
                //_serial.WriteTimeout = -1;
                //_serial.ReadTimeout = 50;
                _serial.Open();
                BtConnect.Enabled = false ;      //Désactiver le bouton "Connect"
                BtDisconnect.Enabled = true;      //Activer le bouton "Disconnect"
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void BtDisconnect_Click(object sender, EventArgs e)
        {
            try
            {
                _serial.Close();             //Fermeture du port COM précédement ouvert
                BtConnect.Enabled = true;   //Activer le bouton "Connect"
                BtDisconnect.Enabled = false;   //Désactiver le bouton "Disconnect"
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }  
        }

        private void BtSend_Click(object sender, EventArgs e)
        {
            if (RbT1.Checked == true)
            {
                _data[0] = (byte)0x40;
            }
            else if (RbT2.Checked == true)
            {
                _data[0] = (byte)0x41;
            }
            else if (RbT3.Checked == true)
            {
                _data[0] = (byte)0x42;
            }
            else if (RbT4.Checked == true)
            {
                _data[0] = (byte)0x43;
            }
            else if (RbT5.Checked == true)
            {
                _data[0] = (byte)0x44;
            }
            else if (RbT6.Checked == true)
            {
                _data[0] = (byte)0x45;
            }
            else if (RbT7.Checked == true)
            {
                _data[0] = (byte)0x46;
            }
            else if (RbT8.Checked == true)
            {
                _data[0] = (byte)0x47;
            }
            else if (RbH.Checked == true)
            {
                _data[0] = (byte)0x70;
            }
            else if (RbADC1.Checked == true)
            {
                _data[0] = (byte)0x50;
            }
            else if (RbADC2.Checked == true)
            {
                _data[0] = (byte)0x51;
            }
            else if (RbADC3.Checked == true)
            {
                _data[0] = (byte)0x52;
            }
            else if (RbADC4.Checked == true)
            {
                _data[0] = (byte)0x53;
            }

            try
            {
                _serial.WriteBytes3964r(ref _data);
                //Thread.Sleep(500);
                _dataR[0] = 0;
                _dataR[1] = 0;
                _dataR[2] = 0;
                _serial.ReadBytes3964r(ref _dataR);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }



            this.RchTxtReceive.AppendText("\r\n" +"Answer : " + Encoding.ASCII.GetString(_dataR, 0, _dataR.Length));
            this.TxtBValeur.Text = _dataR[1].ToString() + "." + _dataR[2].ToString();
        }
    }
}
