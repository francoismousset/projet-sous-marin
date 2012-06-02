using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ISIC_SUBMARINE
{
    public partial class UI_SerialPort : Form
    {
        private BO_Commands _cmd;
        private FormMain _parent;

        public UI_SerialPort(BO_Commands cmd, FormMain parent)
        {
            InitializeComponent();

            this._cmd = cmd;
            this._parent = parent;

            this.rbtnBluetooth.Select();
            this.cbPortComNames.Items.AddRange(this._cmd.GetPortNames());
            this.cbPortComNames.SelectedIndex = 0;
            this.cbBaudrate.SelectedIndex = 5;
            this.cbDataBits.SelectedIndex = 3;
            this.cbParity.SelectedIndex = 2;
            this.cbStopBits.SelectedIndex = 1;

            this.numUpDwnInputBuffer.Value = 4096;
            this.numUpDwnOutputBuffer.Value = 2048;

            this.numUpDwnTimeoutIn.Value = 500;
            this.numUpDwnTimeoutOut.Value = -1;
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            try{
                if (this.btnConnect.Text == "Connecter")
                {
                    this._cmd.SetPort(this.cbPortComNames.Text);
                    this._cmd.SetBaudRate(Int32.Parse(this.cbBaudrate.Text));
                    this._cmd.SetNbDataBits(Int32.Parse(this.cbDataBits.Text));
                    this._cmd.SetParity(this.cbParity.Text);
                    this._cmd.SetStopBits(this.cbStopBits.Text);
                    this._cmd.SetWriteBufferSize((int)this.numUpDwnOutputBuffer.Value);
                    this._cmd.SetReadBufferSize((int)this.numUpDwnInputBuffer.Value);
                    this._cmd.SetWriteTimeOut((int)this.numUpDwnTimeoutOut.Value);
                    this._cmd.SetReadTimeOut((int)this.numUpDwnTimeoutIn.Value);

                    this._cmd.SetOpenPort(true);
                    this.setActivate(false);

                    this._parent.SetConnected(true);

                    this.btnConnect.Text = "Déconnecter";
                }
                else
                {
                    this.setActivate(true);
                    this.cbPortComNames.Items.Clear();
                    this.cbPortComNames.Items.AddRange(this._cmd.GetPortNames());
                    this._parent.SetConnected(false);

                    this._cmd.SetOpenPort(false);
                    this.btnConnect.Text = "Connecter";
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDefault_Click(object sender, EventArgs e)
        {
            this.rbtnPhys.Select();
            this.cbPortComNames.SelectedIndex = 0;
            this.cbBaudrate.SelectedIndex = 5;
            this.cbDataBits.SelectedIndex = 3;
            this.cbParity.SelectedIndex = 2;
            this.cbStopBits.SelectedIndex = 1;

            this.numUpDwnInputBuffer.Value = 4096;
            this.numUpDwnOutputBuffer.Value = 2048;

            this.numUpDwnTimeoutIn.Value = 500;
            this.numUpDwnTimeoutOut.Value = -1;
        }

        private void rbtnBluetooth_CheckedChanged(object sender, EventArgs e)
        {
            if(this.rbtnBluetooth.Checked == true)
                this.cbBaudrate.SelectedIndex = 5;
        }

        private void rbtnPhys_CheckedChanged(object sender, EventArgs e)
        {
            if (this.rbtnPhys.Checked == true)
                this.cbBaudrate.SelectedIndex = 1;
        }

        private void setActivate(bool enable)
        {
            this.rbtnBluetooth.Enabled = enable;
            this.rbtnPhys.Enabled = enable;
            this.cbBaudrate.Enabled = enable;
            this.cbDataBits.Enabled = enable;
            this.cbParity.Enabled = enable;
            this.cbPortComNames.Enabled = enable;
            this.cbStopBits.Enabled = enable;
            this.numUpDwnInputBuffer.Enabled = enable;
            this.numUpDwnOutputBuffer.Enabled = enable;
            this.numUpDwnTimeoutIn.Enabled = enable;
            this.numUpDwnTimeoutOut.Enabled = enable;
            this.btnDefault.Enabled = enable;
        }
    }
}
