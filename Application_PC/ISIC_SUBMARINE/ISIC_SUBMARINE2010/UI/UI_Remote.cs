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
    public partial class UI_Remote : Form
    {
        private BO_Commands _serialCommand;

        public UI_Remote(BO_Commands serialCommand)
        {
            this._serialCommand = serialCommand;
            InitializeComponent();

            this.rbtnVider.Checked = true;
            this.rbtnAvant.Checked = true;
            this.SetEnabledControl(false);
            //this.cbPortComNames.Items.AddRange(this._serialCommand.GetPortNames());
            //this.cbBaudRate.Items.Add("300");
            //this.cbBaudRate.Items.Add("9600");
        }

        public void SetEnabledControl(bool activate)
        {
            this.rbtnArriere.Enabled = activate;
            this.rbtnAvant.Enabled = activate;
            this.rbtnVider.Enabled = activate;
            this.rbtnRemplir.Enabled = activate;
            this.tBarBallast.Enabled = activate;
            this.tBarPosBallast.Enabled = activate;
            this.numUpDwnBallast.Enabled = activate;
            this.numUpDwnPosBallast.Enabled = activate;
            this.btnExeBallast.Enabled = activate;
            this.btnExePosBallast.Enabled = activate;
            this.numUpDwnImpulsBallast.Enabled = activate;
            this.numUpDwnImpulsPosBallast.Enabled = activate;
            this.btnImpulsBallast.Enabled = activate;
            this.btnImpulsPosBallast.Enabled = activate;
        }

        //private void btnConnect_Click(object sender, EventArgs e)
        //{
        //    if (this.btnConnect.Text == "Connecter")
        //    {
        //        if (this.cbPortComNames.Text != "")
        //        {
        //            try
        //            {
        //                this._serialCommand.SetPortName(this.cbPortComNames.Text);
        //                this._serialCommand.OpenPort(true);
        //                this.btnConnect.Text = "Déconnecter";
        //                this.cbPortComNames.Enabled = false;
        //                this.cbBaudRate.Enabled = false;
        //                this.SetEnabledControl(true);
        //                this._serialCommand.SetBaudRate(Int32.Parse(this.cbBaudRate.Text));
        //            }
        //            catch (Exception ex)
        //            {
        //                MessageBox.Show(ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //            }
        //        }
        //    }
        //    else
        //    {
        //        try
        //        {
        //            this._serialCommand.OpenPort(false);
        //            this.cbPortComNames.Enabled = true;
        //            this.cbBaudRate.Enabled = true;
        //            this.btnConnect.Text = "Connecter";
        //            this.SetEnabledControl(false);
        //        }
        //        catch (Exception ex)
        //        {
        //            MessageBox.Show(ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        }
        //    }
        //}

        private void btnExeBallast_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.rbtnRemplir.Checked == true)
                    lock(this._serialCommand)
                        this._serialCommand.fill_ballast((byte)this.tBarBallast.Value);
                else
                    lock (this._serialCommand)
                        this._serialCommand.empty_ballast((byte)this.tBarBallast.Value);
            }
            catch
            {
                Console.WriteLine("Erreur 3964r");
            }
        }

        private void btnExePosBallast_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.rbtnAvant.Checked == true)
                    lock (this._serialCommand)
                        this._serialCommand.move_ballast_forward((byte)this.tBarPosBallast.Value);
                else
                    lock (this._serialCommand)
                        this._serialCommand.move_ballast_rear((byte)this.tBarPosBallast.Value);
            }
            catch
            {
                Console.WriteLine("Erreur 3964r");
            }
        }

        private void tBarBallast_ValueChanged(object sender, EventArgs e)
        {
            this.numUpDwnBallast.Value = this.tBarBallast.Value;
        }

        private void numUpDwnBallast_ValueChanged(object sender, EventArgs e)
        {
            this.tBarBallast.Value = (int)this.numUpDwnBallast.Value;
        }

        private void tBarPosBallast_ValueChanged(object sender, EventArgs e)
        {
            this.numUpDwnPosBallast.Value = this.tBarPosBallast.Value;
        }

        private void numUpDwnPosBallast_ValueChanged(object sender, EventArgs e)
        {
            this.tBarPosBallast.Value = (int)this.numUpDwnPosBallast.Value;
        }

        private void btnImpulsBallast_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.rbtnRemplir.Checked == true)
                {
                    lock (this._serialCommand)
                        this._serialCommand.fill_ballast((byte)this.tBarBallast.Value);
                    System.Threading.Thread.Sleep((int)this.numUpDwnImpulsBallast.Value);
                    lock (this._serialCommand)
                        this._serialCommand.fill_ballast(0);
                }
                else
                {
                    lock (this._serialCommand)
                        this._serialCommand.empty_ballast((byte)this.tBarBallast.Value);
                    System.Threading.Thread.Sleep((int)this.numUpDwnImpulsBallast.Value);
                    lock (this._serialCommand)
                        this._serialCommand.empty_ballast(0);
                }
            }
            catch
            {
                Console.WriteLine("Erreur 3964r");
            }
        }

        private void btnImpulsPosBallast_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.rbtnAvant.Checked == true)
                {
                    lock (this._serialCommand)
                        this._serialCommand.move_ballast_forward((byte)this.tBarPosBallast.Value);
                    System.Threading.Thread.Sleep((int)this.numUpDwnImpulsPosBallast.Value);
                    lock (this._serialCommand)
                        this._serialCommand.move_ballast_forward(0);
                }
                else
                {
                    lock (this._serialCommand)
                        this._serialCommand.move_ballast_rear((byte)this.tBarPosBallast.Value);
                    System.Threading.Thread.Sleep((int)this.numUpDwnImpulsPosBallast.Value);
                    lock (this._serialCommand)
                        this._serialCommand.move_ballast_rear(0);
                }
            }
            catch
            {
                Console.WriteLine("Erreur 3964r");
            }
        }
    }
}
