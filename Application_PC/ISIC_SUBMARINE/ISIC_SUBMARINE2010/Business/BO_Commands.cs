using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.IO.Ports;
using SerialProtocol3964r;

namespace ISIC_SUBMARINE
{
    public class BO_Commands
    {
        private static SerialPort3964r _serial;
        private byte[] _data;

        public BO_Commands()
        {
            this._data = new byte[3];

            try
            {
                _serial = new SerialPort3964r(false);
                _serial.ReadTimeout = 1000;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void empty_ballast(byte speed)
        {
            this._data[0] = (byte)'M';
            this._data[1] = 0;
            this._data[2] = speed;

            try
            {
                _serial.WriteBytes3964r(ref this._data);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void fill_ballast(byte speed)
        {
            this._data[0] = (byte)'M';
            this._data[1] = 1;
            this._data[2] = speed;

            try
            {
                _serial.WriteBytes3964r(ref this._data);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void move_ballast_forward(byte speed)
        {
            this._data[0] = (byte)'K';
            this._data[1] = 0;
            this._data[2] = speed;

            try
            {
                _serial.WriteBytes3964r(ref this._data);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void move_ballast_rear(byte speed)
        {
            this._data[0] = (byte)'K';
            this._data[1] = 1;
            this._data[2] = speed;

            try
            {
                _serial.WriteBytes3964r(ref this._data);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error transmission");
                //throw ex;
            }
        }

        public string get_temperature1()
        {
            this._data[0] = (byte)0x40;

            try
            {
                _serial.WriteBytes3964r(ref this._data);
                int i = 0;
                while ((_serial.ReadBytes3964r(ref this._data) != 0) && (i < 10))
                    i++;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error transmission");
                //throw ex;
            }
            return this._data[1].ToString() + "." + this._data[2].ToString();
        }

        public string get_temperature2()
        {
            this._data[0] = (byte)0x41;

            try
            {
                _serial.WriteBytes3964r(ref this._data);
                int i = 0;
                while ((_serial.ReadBytes3964r(ref this._data) != 0) && (i < 10))
                    i++;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error transmission");
                //throw ex;
            }
            return this._data[1].ToString() + "." + this._data[2].ToString();
        }

        public string get_temperature3()
        {
            this._data[0] = (byte)0x42;

            try
            {
                _serial.WriteBytes3964r(ref this._data);
                int i = 0;
                while ((_serial.ReadBytes3964r(ref this._data) != 0) && (i < 10))
                    i++;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error transmission");
                //throw ex;
            }
            return this._data[1].ToString() + "." + this._data[2].ToString();
        }

        public string get_temperature4()
        {
            this._data[0] = (byte)0x43;

            try
            {
                _serial.WriteBytes3964r(ref this._data);
                int i = 0;
                while ((_serial.ReadBytes3964r(ref this._data) != 0) && (i < 10))
                    i++;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error transmission");
                //throw ex;
            }
            return this._data[1].ToString() + "." + this._data[2].ToString();
        }

        public string get_temperature5()
        {
            this._data[0] = (byte)0x44;

            try
            {
                _serial.WriteBytes3964r(ref this._data);
                int i = 0;
                while ((_serial.ReadBytes3964r(ref this._data) != 0) && (i < 10))
                    i++;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error transmission");
                //throw ex;
            }
            return this._data[1].ToString() + "." + this._data[2].ToString();
        }

        public string get_temperature6()
        {
            this._data[0] = (byte)0x45;

            try
            {
                _serial.WriteBytes3964r(ref this._data);
                int i = 0;
                while ((_serial.ReadBytes3964r(ref this._data) != 0) && (i < 10))
                    i++;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error transmission");
                //throw ex;
            }
            return this._data[1].ToString() + "." + this._data[2].ToString();
        }

        public string get_temperature7()
        {
            this._data[0] = (byte)0x46;

            try
            {
                _serial.WriteBytes3964r(ref this._data);
                int i = 0;
                while ((_serial.ReadBytes3964r(ref this._data) != 0) && (i < 10))
                    i++;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error transmission");
                //throw ex;
            }
            return this._data[1].ToString() + "." + this._data[2].ToString();
        }

        public string get_temperature8()
        {
            this._data[0] = (byte)0x47;

            try
            {
                _serial.WriteBytes3964r(ref this._data);
                int i = 0;
                while ((_serial.ReadBytes3964r(ref this._data) != 0) && (i < 10))
                    i++;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error transmission");
                //throw ex;
            }
            return this._data[1].ToString() + "." + this._data[2].ToString();
        }

        public string get_adc1()
        {
            this._data[0] = (byte)0x50;

            try
            {
                _serial.WriteBytes3964r(ref this._data);
                int i = 0;
                while ((_serial.ReadBytes3964r(ref this._data) != 0) && (i < 10))
                    i++;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error transmission");
                //throw ex;
            }
            return this._data[1].ToString() + "." + this._data[2].ToString();
        }

        public string get_adc2()
        {
            this._data[0] = (byte)0x51;

            try
            {
                _serial.WriteBytes3964r(ref this._data);
                int i = 0;
                while ((_serial.ReadBytes3964r(ref this._data) != 0) && (i < 10))
                    i++;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error transmission");
                //throw ex;
            }
            return this._data[1].ToString() + "." + this._data[2].ToString();
        }

        public string get_adc3()
        {
            this._data[0] = (byte)0x52;

            try
            {
                _serial.WriteBytes3964r(ref this._data);
                int i = 0;
                while ((_serial.ReadBytes3964r(ref this._data) != 0) && (i < 10))
                    i++;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error transmission");
                //throw ex;
            }
            return this._data[1].ToString() + "." + this._data[2].ToString();
        }

        public string get_adc4()
        {
            this._data[0] = (byte)0x53;

            try
            {
                _serial.WriteBytes3964r(ref this._data);
                int i = 0;
                while ((_serial.ReadBytes3964r(ref this._data) != 0) && (i < 10))
                    i++;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error transmission");
                //throw ex;
            }
            return this._data[1].ToString() + "." + this._data[2].ToString();
        }

        public string get_accelerometer1()
        {
            this._data[0] = (byte)0x60;

            try
            {
                _serial.WriteBytes3964r(ref this._data);
                int i = 0;
                while ((_serial.ReadBytes3964r(ref this._data) != 0) && (i < 10))
                    i++;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error transmission");
                //throw ex;
            }
            return this._data[1].ToString() + "." + this._data[2].ToString();
        }

        public string get_hygrometer1()
        {
            this._data[0] = (byte)0x70;

            try
            {
                _serial.WriteBytes3964r(ref this._data);
                int i = 0;
                while ((_serial.ReadBytes3964r(ref this._data) != 0) && (i < 10))
                    i++;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error transmission");
                //throw ex;
            }
            return this._data[1].ToString() + "." + this._data[2].ToString();
        }

        public string get_hygrometer2()
        {
            this._data[0] = (byte)0x71;

            try
            {
                _serial.WriteBytes3964r(ref this._data);
                int i = 0;
                while ((_serial.ReadBytes3964r(ref this._data) != 0) && (i < 10))
                    i++;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error transmission");
                //throw ex;
            }
            return this._data[1].ToString() + "." + this._data[2].ToString();
        }

        public string get_impulsion1()
        {
            this._data[0] = (byte)0x80;

            try
            {
                _serial.WriteBytes3964r(ref this._data);
                int i = 0;
                while ((_serial.ReadBytes3964r(ref this._data) != 0) && (i < 10))
                    i++;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error transmission");
                //throw ex;
            }
            return this._data[1].ToString() + "." + this._data[2].ToString();
        }

        public string get_impulsion2()
        {
            this._data[0] = (byte)0x81;

            try
            {
                _serial.WriteBytes3964r(ref this._data);
                int i = 0;
                while ((_serial.ReadBytes3964r(ref this._data) != 0) && (i < 10))
                    i++;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error transmission");
                //throw ex;
            }
            return this._data[1].ToString() + "." + this._data[2].ToString();
        }

        public string[] GetPortNames()
        {
            return SerialPort3964r.GetPortNames();
        }

        public void SetPort(string portName)
        {
            _serial.PortName = portName;
        }

        public void SetBaudRate(int baudRate)
        {
            _serial.BaudRate = baudRate;
        }

        public void SetOpenPort(bool open)
        {
            try
            {
                if (open == true)
                    _serial.Open();
                else
                    _serial.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void SetNbDataBits(int nbbits)
        {
            _serial.DataBits = nbbits;
        }

        public void SetReadBufferSize(int size)
        {
            _serial.ReadBufferSize = size;
        }

        public void SetWriteBufferSize(int size)
        {
            _serial.WriteBufferSize = size;
        }

        public void SetReadTimeOut(int timeout)
        {
            _serial.ReadTimeout = timeout;
        }

        public void SetWriteTimeOut(int timeout)
        {
            _serial.WriteTimeout = timeout;
        }

        public void SetParity(string parity)
        {
            switch (parity)
            {
                case "Aucun":
                    _serial.Parity = Parity.None;
                    break;
                case "Impair":
                    _serial.Parity = Parity.Odd;
                    break;
                case "Pair":
                    _serial.Parity = Parity.Even;
                    break;
                case "Marque":
                    _serial.Parity = Parity.Mark;
                    break;
                case "Espace":
                    _serial.Parity = Parity.Space;
                    break;
                default:
                    _serial.Parity = Parity.None;
                    break;
            }
        }

        public void SetStopBits(string stopBits)
        {
            switch (stopBits)
            {
                case "Aucun":
                    _serial.StopBits = StopBits.None;
                    break;
                case "1":
                    _serial.StopBits = StopBits.One;
                    break;
                case "2":
                    _serial.StopBits = StopBits.Two;
                    break;
                case "1,5":
                    _serial.StopBits = StopBits.OnePointFive;
                    break;
                default:
                    _serial.StopBits = StopBits.One;
                    break;
            }
        }

        public bool IsOpen()
        {
            bool isOpen;

            try
            {
                isOpen = _serial.IsOpen;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return _serial.IsOpen;
        }
    }
}
