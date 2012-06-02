using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Threading;

namespace ISIC_SUBMARINE
{
    public partial class UI_Sensor : Form
    {
        private Thread _thread;
        private MyThreadHandle _MyThreadHandle;

        public UI_Sensor(BO_Commands serialCommand)
        {
            InitializeComponent();

            this._MyThreadHandle = new MyThreadHandle(serialCommand, this);
            this._thread = new Thread(new ThreadStart(this._MyThreadHandle.ThreadLoop));
            CheckForIllegalCrossThreadCalls = false;
            this._thread.Start();
        }
    }

    public class MyThreadHandle
    {
	    // Cet entier sera utilisé comme paramètre
	    private BO_Commands _serialCommands;
        private UI_Sensor _UI_Sensor_parent;

	    // Constructeur
        public MyThreadHandle(BO_Commands myParam, UI_Sensor parent)
	    {
            this._serialCommands = myParam;
            this._UI_Sensor_parent = parent;
	    }

	    // Méthode boucle du thread
	    public void ThreadLoop()
	    {
		    // On peut utiliser ici notre paramètre myParam    	
            while (Thread.CurrentThread.IsAlive)
            {
                if(this._serialCommands.IsOpen() == true)
                    lock(this._serialCommands)
                        this._UI_Sensor_parent.txtTemperature1.Text = this._serialCommands.get_temperature1();
                //Thread.Sleep(100);
                if (this._serialCommands.IsOpen() == true)
                    lock (this._serialCommands)
                        this._UI_Sensor_parent.txtTemperature2.Text = this._serialCommands.get_temperature2();
                //Thread.Sleep(100);
                if (this._serialCommands.IsOpen() == true)
                    lock (this._serialCommands)
                        this._UI_Sensor_parent.txtTemperature3.Text = this._serialCommands.get_temperature3();
                //Thread.Sleep(100);
                if (this._serialCommands.IsOpen() == true)
                    lock (this._serialCommands)
                        this._UI_Sensor_parent.txtTemperature4.Text = this._serialCommands.get_temperature4();
                //Thread.Sleep(100);
                if (this._serialCommands.IsOpen() == true)
                    lock (this._serialCommands)
                        this._UI_Sensor_parent.txtTemperature5.Text = this._serialCommands.get_temperature5();
                //Thread.Sleep(100);
                if (this._serialCommands.IsOpen() == true)
                    lock (this._serialCommands)
                        this._UI_Sensor_parent.txtTemperature6.Text = this._serialCommands.get_temperature6();
                //Thread.Sleep(100);
                if (this._serialCommands.IsOpen() == true)
                    lock (this._serialCommands)
                        this._UI_Sensor_parent.txtTemperature7.Text = this._serialCommands.get_temperature7();
                //Thread.Sleep(100);
                if (this._serialCommands.IsOpen() == true)
                    lock (this._serialCommands)
                        this._UI_Sensor_parent.txtTemperature8.Text = this._serialCommands.get_temperature8();
                //Thread.Sleep(100);
                if (this._serialCommands.IsOpen() == true)
                    lock (this._serialCommands)
                        this._UI_Sensor_parent.txtADC1.Text = this._serialCommands.get_adc1();
                //Thread.Sleep(100);
                if (this._serialCommands.IsOpen() == true)
                    lock (this._serialCommands)
                        this._UI_Sensor_parent.txtADC2.Text = this._serialCommands.get_adc2();
                //Thread.Sleep(100);
                if (this._serialCommands.IsOpen() == true)
                    lock (this._serialCommands)
                        this._UI_Sensor_parent.txtADC3.Text = this._serialCommands.get_adc3();
                //Thread.Sleep(100);
                if (this._serialCommands.IsOpen() == true)
                    lock (this._serialCommands)
                        this._UI_Sensor_parent.txtADC4.Text = this._serialCommands.get_adc4();
                //Thread.Sleep(100);
                if (this._serialCommands.IsOpen() == true)
                    lock (this._serialCommands)
                        this._UI_Sensor_parent.txtHumidity1.Text = this._serialCommands.get_hygrometer1();
                //Thread.Sleep(100);
                if (this._serialCommands.IsOpen() == true)
                    lock (this._serialCommands)
                        this._UI_Sensor_parent.txtHumidity2.Text = this._serialCommands.get_hygrometer2();
                //Thread.Sleep(100);
                if (this._serialCommands.IsOpen() == true)
                    lock (this._serialCommands)
                        this._UI_Sensor_parent.txtImpuls1.Text = this._serialCommands.get_impulsion1();
                //Thread.Sleep(100);
                if (this._serialCommands.IsOpen() == true)
                    lock (this._serialCommands)
                        this._UI_Sensor_parent.txtImpuls2.Text = this._serialCommands.get_impulsion2();
                //Thread.Sleep(100);
                if (this._serialCommands.IsOpen() == true)
                    lock (this._serialCommands)
                        this._UI_Sensor_parent.txtAccelerometer.Text = this._serialCommands.get_accelerometer1();
                //Thread.Sleep(100);
            }
	    }
    }
}
