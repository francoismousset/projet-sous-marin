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

namespace SensorCardSimulator
{
    public partial class MainForm : Form
    {
        private static SerialPort3964r _serial;
        private static byte[] _data;
        Thread myThread;

        public MainForm()
        {
            InitializeComponent();
            try
            {
                _serial = new SerialPort3964r(false);
                _serial.PortName = "COM9";
                _serial.BaudRate = 9600;
                _serial.ReadTimeout = 1000;
                _serial.Open();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            _data = new byte[3];
		    
		    myThread = new Thread(new ThreadStart(ThreadLoop));
		    myThread.Start();
	    }

	    public void ThreadLoop()
	    {
            while (Thread.CurrentThread.IsAlive)
            {
                if (_serial.ReadBytes3964r(ref _data) == 0)
                {
                    switch (_data[0])
                    {
                        case 0x40:
                            this.getTemperature1(ref _data);
                            break;
                        case 0x41:
                            this.getTemperature2(ref _data);
                            break;
                        case 0x42:
                            this.getTemperature3(ref _data);
                            break;
                        case 0x43:
                            this.getTemperature4(ref _data);
                            break;
                        case 0x44:
                            this.getTemperature5(ref _data);
                            break;
                        case 0x45:
                            this.getTemperature6(ref _data);
                            break;
                        case 0x46:
                            this.getTemperature7(ref _data);
                            break;
                        case 0x47:
                            this.getTemperature8(ref _data);
                            break;
                        case 0x50:
                            this.getADC1(ref _data);
                            break;
                        case 0x51:
                            this.getADC2(ref _data);
                            break;
                        case 0x52:
                            this.getADC3(ref _data);
                            break;
                        case 0x53:
                            this.getADC4(ref _data);
                            break;
                        case 0x60:
                            this.getAccelerometer(ref _data);
                            break;
                        case 0x70:
                            this.getHumidity1(ref _data);
                            break;
                        case 0x71:
                            this.getHumidity2(ref _data);
                            break;
                        case 0x80:
                            this.getImpulsion1(ref _data);
                            break;
                        case 0x81:
                            this.getImpulsion2(ref _data);
                            break;
                        default:
                            break;
                    }
                    _serial.WriteBytes3964r(ref _data);
                }
            }
		}

        public void getTemperature1(ref byte[] data)
        {
            _data[1] = (byte)this.numUpDwnTemp1.Value;
        }
        public void getTemperature2(ref byte[] data)
        {
            _data[1] = (byte)this.numUpDwnTemp2.Value;
        }
        public void getTemperature3(ref byte[] data)
        {
            _data[1] = (byte)this.numUpDwnTemp3.Value;
        }
        public void getTemperature4(ref byte[] data)
        {
            _data[1] = (byte)this.numUpDwnTemp4.Value;
        }
        public void getTemperature5(ref byte[] data)
        {
            _data[1] = (byte)this.numUpDwnTemp5.Value;
        }
        public void getTemperature6(ref byte[] data)
        {
            _data[1] = (byte)this.numUpDwnTemp6.Value;
        }
        public void getTemperature7(ref byte[] data)
        {
            _data[1] = (byte)this.numUpDwnTemp7.Value;
        }
        public void getTemperature8(ref byte[] data)
        {
            _data[1] = (byte)this.numUpDwnTemp8.Value;
        }
        public void getAccelerometer(ref byte[] data)
        {
            _data[1] = (byte)this.numUpDwnAccelero.Value;
        }
        public void getADC1(ref byte[] data)
        {
            _data[1] = (byte)this.numUpDwnADC1.Value;
        }
        public void getADC2(ref byte[] data)
        {
            _data[1] = (byte)this.numUpDwnADC2.Value;
        }
        public void getADC3(ref byte[] data)
        {
            _data[1] = (byte)this.numUpDwnADC3.Value;
        }
        public void getADC4(ref byte[] data)
        {
            _data[1] = (byte)this.numUpDwnADC4.Value;
        }
        public void getHumidity1(ref byte[] data)
        {
            _data[1] = (byte)this.numUpDwnHumidity1.Value;
        }
        public void getHumidity2(ref byte[] data)
        {
            _data[1] = (byte)this.numUpDwnHumidity2.Value;
        }
        public void getImpulsion1(ref byte[] data)
        {
            _data[1] = (byte)this.numUpDwnImpuls1.Value;
        }
        public void getImpulsion2(ref byte[] data)
        {
            _data[1] = (byte)this.numUpDwnImpuls2.Value;
        }
	}
}
