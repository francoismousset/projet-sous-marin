using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;


namespace ISIC_SUBMARINE2010
{
    public partial class FormParam_OngletRS232 : Form
    {
        public FormParam_OngletRS232()
        {
            InitializeComponent();
        }

        
        // SET
        

        public void setText_timeOutSortie(string value)
        {
            timeOutSortie.Text = value;
        }

        public void setText_timeOutEntree(string value)
        {
            timeOutEntree.Text = value;
        }

        public void setText_bufferSortie(string value)
        {
            bufferSortie.Text = value;
        }

        public void setText_bufferEntree(string value)
        {
            bufferEntree.Text = value;
        }

        public void setText_parity(string value)
        {
            parity.SelectedItem = value;
        }

        public void setText_nbBits(string value)
        {
            nb_bits.SelectedItem = value;
        }

        public void setText_baudrate(string value)
        {
            baudrate.SelectedItem = value;
        }

        public void setText_nbBitsStop(string value)
        {
            nb_bits_stop.SelectedItem = value;
        }

         // GET

        public string getTimeOutSortie()
        {
            return timeOutSortie.Text;
        }

        public string getTimeOutEntree()
        {
            return timeOutEntree.Text;
        }

        public string getBufferSortie()
        {
            return bufferSortie.Text;
        }

        public string getBufferEntree()
        {
            return bufferEntree.Text;
        }

        public string getParity()
        {
            return parity.SelectedItem.ToString();
        }

        public string getNbBits()
        {
            return nb_bits.SelectedItem.ToString();
        }

        public string getBaudrate()
        {
            return baudrate.SelectedItem.ToString();
        }

        public string getNbBitsStop()
        {
            return nb_bits_stop.SelectedItem.ToString();
        }
    }

}
