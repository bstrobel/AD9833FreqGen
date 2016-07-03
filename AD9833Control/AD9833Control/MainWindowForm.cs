using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AD9833Control
{
    public partial class MainWindowForm : Form
    {

        [DllImport("user32.dll", CharSet = CharSet.Unicode)]
        static extern uint SendMessage(IntPtr hWnd,
          uint Msg,
          uint wParam,
          uint lParam);

        private const short UPP_DEFAULT_MAX_VALUE = 255;
        private const short UPP_1V_VALUE = 144;
        private const short UPP_SQR_1V_VALUE = 25;
        private const short UPP_DEFAULT_WARN_VALUE = 218;
        private const short UPP_SQR_MAX_VALUE = 42;
        private Color displayTextColor = SystemColors.Info;
        private Color displayTextWarnColor = Color.Orange;
        private IAD9833ControlModel ctrl;
        private bool outputEnabled = false;
        private SerialPortStatus connectedState = SerialPortStatus.Closed;
        private AD9833ControlSettings settings = new AD9833ControlSettings();
        private List<Control> interactiveControls = new List<Control>();

        public MainWindowForm(AD9833Control ctrl)
        {
            this.ctrl = ctrl;
            InitializeComponent();

            interactiveControls.Add(ncFreqHz1);
            interactiveControls.Add(ncFreqHz10);
            interactiveControls.Add(ncFreqHz100);
            interactiveControls.Add(ncFreqkHz1);
            interactiveControls.Add(ncFreqkHz10);
            interactiveControls.Add(ncFreqkHz100);
            interactiveControls.Add(ncFreqMHz);
            interactiveControls.Add(tbOutVoltage);
            interactiveControls.Add(tbFreqAdjust);
            interactiveControls.Add(btn1Vpp);
            interactiveControls.Add(btnFreqAdjustReset);
            interactiveControls.Add(rbWfSine);
            interactiveControls.Add(rbWfSquare);
            interactiveControls.Add(rbWfTriangular);

            ncFreqHz1.ValueChanged += NcFreqInput_ValueChanged; ;
            ncFreqHz10.ValueChanged += NcFreqInput_ValueChanged;
            ncFreqHz100.ValueChanged += NcFreqInput_ValueChanged;
            ncFreqkHz1.ValueChanged += NcFreqInput_ValueChanged;
            ncFreqkHz10.ValueChanged += NcFreqInput_ValueChanged;
            ncFreqkHz100.ValueChanged += NcFreqInput_ValueChanged;
            ncFreqMHz.ValueChanged += NcFreqInput_ValueChanged;
            tbFreqAdjust.Scroll += freqSliderMoved;
            tbOutVoltage.Scroll += voltageSliderMoved;
            ctrl.SerialPortStatusChanged += Ctrl_SerialPortStatusChanged;
            Ctrl_SerialPortStatusChanged(null, new SerialPortStatusChangedEventArgs(ctrl.SerialPortStatus, null, null));
            timerSerialConnect.Tick += TimerSerialConnect_Tick;
            foreach (RadioButton rb in gbWaveForm.Controls.OfType<RadioButton>())
            {
                rb.CheckedChanged += waveFormRb_CheckedChanged;
            }
            tbOutVoltage.Maximum = AD9833Control.MAX_VOLTAGE;
            tbOutVoltage.Value = settings.LastOutVoltage;
            adjustOutVoltage();
            setFreqSliders(settings.LastFreq, settings.LastAdjustFreq);
            adjustFreq();
            WaveFormsEnum wf = (WaveFormsEnum)settings.LastWaveForm;
            switch(wf)
            {
                default:
                case WaveFormsEnum.Sine:
                    rbWfSine.Checked = true;
                    tbOutVoltage.Maximum = UPP_DEFAULT_MAX_VALUE;
                    progBarOutVoltage.Maximum = UPP_DEFAULT_MAX_VALUE;
                    progBarOutVoltage.WarningLevel = UPP_DEFAULT_WARN_VALUE;
                    break;
                case WaveFormsEnum.Triangular:
                    rbWfTriangular.Checked = true;
                    tbOutVoltage.Maximum = UPP_DEFAULT_MAX_VALUE;
                    progBarOutVoltage.Maximum = UPP_DEFAULT_MAX_VALUE;
                    progBarOutVoltage.WarningLevel = UPP_DEFAULT_WARN_VALUE;
                    break;
                case WaveFormsEnum.Square:
                    rbWfSquare.Checked = true;
                    tbOutVoltage.Maximum = UPP_SQR_MAX_VALUE;
                    progBarOutVoltage.Maximum = UPP_SQR_MAX_VALUE;
                    progBarOutVoltage.WarningLevel = UPP_SQR_MAX_VALUE;
                    break;
            }
            ctrl.WaveForm = wf;
            FormClosing += MainWindowForm_FormClosing;

            // disables the flickering of the ProgressBar. I know, this is kind of an ugly solution...
            // http://stackoverflow.com/questions/2834761/disable-winforms-progressbar-animation
            SendMessage(progBarOutVoltage.Handle,
               0x400 + 16, //WM_USER + PBM_SETSTATE
               0x0003, //PBST_PAUSED
               0);

        }

        private void TimerSerialConnect_Tick(object sender, EventArgs e)
        {

            SerialPortStatus newState = ctrl.SerialPortStatus;
            switch (newState)
            {
                case SerialPortStatus.Open:
                    if (connectedState == SerialPortStatus.Closed)
                    {

                        foreach (var item in interactiveControls)
                        {
                            item.Enabled = true;
                        }
                        toolStripStatusSerialPort.Text = settings.COMPort + ": Connected";
                        toolStripStatusSerialPort.ToolTipText = null;
                        setFreqSliders(settings.LastFreq, settings.LastAdjustFreq);
                        adjustFreq();
                    }
                    break;
                case SerialPortStatus.Closed:
                    if (connectedState == SerialPortStatus.Open)
                    {
                        foreach (var item in interactiveControls)
                        {
                            item.Enabled = false;
                        }
                        gbMainFreqSetting.Enabled = true;
                        toolStripStatusSerialPort.Text = settings.COMPort + ": Disconnected";
                    }
                    break;
                default:
                    toolStripStatusSerialPort.Text = settings.COMPort + ": Undefined";
                    break;
            }
            connectedState = newState;
        }

        private void Ctrl_SerialPortStatusChanged(object sender, SerialPortStatusChangedEventArgs e)
        {
            switch(e.status)
            {
                case SerialPortStatus.Open:
                    if (e.ackMsg != null)
                    {
                        textBoxLogger.AppendText(e.ackMsg + "\n");
                        toolStripStatusSerialPort.ToolTipText = e.ackMsg;
                    }
                    break;
                case SerialPortStatus.Closed:
                    if (e.exception != null)
                    {
                        textBoxLogger.AppendText(e.exception.ToString());
                        toolStripStatusSerialPort.ToolTipText = e.exception.Message;
                    }
                    break;
            }
        }

        private void MainWindowForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            settings.Save();
        }

        private void waveFormRb_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rb = (RadioButton)sender;
            if (!rb.Checked)
                return;

            WaveFormsEnum wf = WaveFormsEnum.Sine;
            if (rb == rbWfTriangular)
                wf = WaveFormsEnum.Triangular;
            if (rb == rbWfSquare)
                wf = WaveFormsEnum.Square;
            ctrl.WaveForm = wf;
            settings.LastWaveForm = (int)wf;
            switch (wf)
            {
                case WaveFormsEnum.Square:
                    tbOutVoltage.Maximum = UPP_SQR_MAX_VALUE;
                    progBarOutVoltage.Maximum = UPP_SQR_MAX_VALUE;
                    progBarOutVoltage.WarningLevel = UPP_SQR_MAX_VALUE;
                    break;
                default:
                case WaveFormsEnum.Sine:
                case WaveFormsEnum.Triangular:
                    tbOutVoltage.Maximum = UPP_DEFAULT_MAX_VALUE;
                    progBarOutVoltage.Maximum = UPP_DEFAULT_MAX_VALUE;
                    progBarOutVoltage.WarningLevel = UPP_DEFAULT_WARN_VALUE;
                    break;
            }
            adjustOutVoltage();
        }

        private void voltageSliderMoved(object sender, EventArgs e)
        {
            adjustOutVoltage();
        }

        private void adjustOutVoltage()
        {
            progBarOutVoltage.Value = tbOutVoltage.Value;
            short val = (short)tbOutVoltage.Value;
            settings.LastOutVoltage = val;
            double dispVal = 0;
            if (rbWfSquare.Checked)
            {
                if (val > UPP_SQR_MAX_VALUE)
                    val = UPP_SQR_MAX_VALUE;
                dispVal = (double)val / (double)UPP_SQR_1V_VALUE;
            }
            else
                dispVal = (double)val / (double)UPP_1V_VALUE;

            // https://msdn.microsoft.com/en-us/library/dwhawy9k(v=vs.110).aspx#FFormatString
            lblOutVoltage.Text = String.Format("Û= {0:F2} Vpp", dispVal);
            double dispValEff = 0;
            if (rbWfSine.Checked)
                dispValEff = dispVal / Math.Sqrt(2);
            else if (rbWfTriangular.Checked)
                dispValEff = dispVal / Math.Sqrt(3);
            else
                dispValEff = dispVal;
            lblUeff.Text = String.Format("Ueff= {0:F2} V", dispValEff);
            if (val > 218)
                lblOutVoltage.ForeColor = displayTextWarnColor;
            else
                lblOutVoltage.ForeColor = displayTextColor;
            tbOutVoltage.Value = val;
            ctrl.OutVoltage = val;
        }

        int getCenterFreqFromInput()
        {
            return (int)ncFreqHz1.Value
               + (int)ncFreqHz10.Value * 10
               + (int)ncFreqHz100.Value * 100
               + (int)ncFreqkHz1.Value * 1000
               + (int)ncFreqkHz10.Value * 10000
               + (int)ncFreqkHz100.Value * 100000
               + (int)ncFreqMHz.Value * 1000000;
        }
        private void NcFreqInput_ValueChanged(object sender, EventArgs e)
        {
            setFreqAdjustLowHighText();
            adjustFreq();
        }

        private void freqSliderMoved(object sender, EventArgs e)
        {
            adjustFreq();
        }

        private void setFreqSliders(int centerFreq, int adjustFactor)
        {
            ncFreqMHz.Value = centerFreq / 1000000;
            ncFreqkHz100.Value = (centerFreq / 100000) % 10;
            ncFreqkHz10.Value = (centerFreq / 10000) % 10;
            ncFreqkHz1.Value = (centerFreq / 1000) % 10;
            ncFreqHz100.Value = (centerFreq / 100) % 10;
            ncFreqHz10.Value = (centerFreq / 10) % 10;
            ncFreqHz1.Value = centerFreq % 10;
            tbFreqAdjust.Value = adjustFactor;
        }

        private void setFreqAdjustLowHighText()
        {
            int centerFreq = getCenterFreqFromInput();
            lblAdjFreqLow.Text = String.Format("{0:N0}", centerFreq / 10);
            int highFreqVal = centerFreq * 10;
            if (highFreqVal > AD9833Control.MAX_FREQ)
                highFreqVal = (int)AD9833Control.MAX_FREQ;
            lblAdjFreqHigh.Text = String.Format("{0:N0}", highFreqVal);
        }


        private void adjustFreq()
        {
            int centerFreq = getCenterFreqFromInput();
            int adjustFactor = tbFreqAdjust.Value;
            settings.LastFreq = centerFreq;
            settings.LastAdjustFreq = adjustFactor;
            double actFreq = (double)centerFreq * Math.Pow(10,(double)adjustFactor/500);
            if (actFreq > (double)AD9833Control.MAX_FREQ)
            {
                actFreq = (double)AD9833Control.MAX_FREQ;
            }
            lblActFreq.Text = String.Format("{0:N0} Hz", (long)actFreq);
            ctrl.Frequency = (long)actFreq;
        }

        private void btn1Vpp_Clicked(object sender, EventArgs e)
        {
            if (rbWfSquare.Checked)
                tbOutVoltage.Value = UPP_SQR_1V_VALUE;
            else
                tbOutVoltage.Value = UPP_1V_VALUE;
            adjustOutVoltage();
        }

        private void btnFreqAdjustRest_Clicked(object sender, EventArgs e)
        {
            tbFreqAdjust.Value = 0;
            adjustFreq();
        }

        private void OutputEnable_Clicked(object sender, EventArgs e)
        {
            if (sender.Equals(btnEnableOutput))
            {
                outputEnabled = true;
                btnEnableOutput.Enabled = false;
                btnEnableOutput.ForeColor = Color.Gray;
                btnDisableOutput.Enabled = true;
                btnDisableOutput.ForeColor = Color.Red;
            }
            else if (sender.Equals(btnDisableOutput))
            {
                outputEnabled = false;
                btnEnableOutput.Enabled = true;
                btnEnableOutput.ForeColor = Color.Green;
                btnDisableOutput.Enabled = false;
                btnDisableOutput.ForeColor = Color.Gray;
            }
            ctrl.Enabled = outputEnabled;
        }
    }
}
