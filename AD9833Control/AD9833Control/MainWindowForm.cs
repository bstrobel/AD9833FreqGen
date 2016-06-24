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
        private const short UPP_1V_VALUE = 144;
        private const short UPP_MAX_VALUE = 218;
        private Color displayTextColor = SystemColors.Info;
        private Color displayTextWarnColor = Color.Orange;
        private IAD9833ControlModel ctrl;
        private AD9833ControlSettings settings = new AD9833ControlSettings();
        private List<Control> interactiveControls = new List<Control>();
        public MainWindowForm(AD9833Control ctrl)
        {
            this.ctrl = ctrl;
            InitializeComponent();

            interactiveControls.Add(tbFreqHz1);
            interactiveControls.Add(tbFreqHz10);
            interactiveControls.Add(tbFreqHz100);
            interactiveControls.Add(tbFreqkHz1);
            interactiveControls.Add(tbFreqkHz10);
            interactiveControls.Add(tbFreqkHz100);
            interactiveControls.Add(tbFreqMHz);
            interactiveControls.Add(tbOutVoltage);
            interactiveControls.Add(tbFreqAdjust);
            interactiveControls.Add(btn1Vpp);
            interactiveControls.Add(btnFreqAdjustReset);
            interactiveControls.Add(rbWfSine);
            interactiveControls.Add(rbWfSquare);
            interactiveControls.Add(rbWfTriangular);

            tbFreqHz1.Scroll += freqSliderMoved;
            tbFreqHz10.Scroll += freqSliderMoved;
            tbFreqHz100.Scroll += freqSliderMoved;
            tbFreqkHz1.Scroll += freqSliderMoved;
            tbFreqkHz10.Scroll += freqSliderMoved;
            tbFreqkHz100.Scroll += freqSliderMoved;
            tbFreqMHz.Scroll += freqSliderMoved;
            tbFreqAdjust.Scroll += freqSliderMoved;
            tbOutVoltage.Scroll += voltageSliderMoved;
            ctrl.SerialPortStatusChanged += Ctrl_SerialPortStatusChanged;
            Ctrl_SerialPortStatusChanged(null, new SerialPortStatusChangedEventArgs(ctrl.SerialPortStatus, null));
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
                    break;
                case WaveFormsEnum.Triangular:
                    rbWfTriangular.Checked = true;
                    break;
                case WaveFormsEnum.Square:
                    rbWfTriangular.Checked = true;
                    break;
            }
            ctrl.WaveForm = wf;
            FormClosing += MainWindowForm_FormClosing;
            progBarOutVoltage.WarningLevel = UPP_MAX_VALUE;

            // disables the flickering of the ProgressBar. I know, this is kind of an ugly solution...
            // http://stackoverflow.com/questions/2834761/disable-winforms-progressbar-animation
            SendMessage(progBarOutVoltage.Handle,
               0x400 + 16, //WM_USER + PBM_SETSTATE
               0x0003, //PBST_PAUSED
               0);

        }

        private void TimerSerialConnect_Tick(object sender, EventArgs e)
        {
            var state = ctrl.SerialPortStatus;
        }

        private void Ctrl_SerialPortStatusChanged(object sender, SerialPortStatusChangedEventArgs e)
        {
            switch (e.status)
            {
                case SerialPortStatus.Open:
                    foreach (var item in interactiveControls)
                    {
                        item.Enabled = true;
                    }
                    toolStripStatusSerialPort.Text = settings.COMPort + ": Connected";
                    toolStripStatusSerialPort.ToolTipText = null;
                    setFreqSliders(settings.LastFreq, settings.LastAdjustFreq);
                    adjustFreq();
                    break;
                case SerialPortStatus.Closed:
                    foreach (var item in interactiveControls)
                    {
                        item.Enabled = false;
                    }
                    gbMainFreqSetting.Enabled = true;
                    toolStripStatusSerialPort.Text = settings.COMPort + ": Disconnected";
                    toolStripStatusSerialPort.ToolTipText = e.exception?.Message;
                    break;
                default:
                    toolStripStatusSerialPort.Text = settings.COMPort + ": Undefined";
                    toolStripStatusSerialPort.ToolTipText = null;
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
            double dispVal = (double)val / (double)UPP_1V_VALUE;
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

        private void freqSliderMoved(object sender, EventArgs e)
        {
            adjustFreq();
        }

        private void setFreqSliders(int centerFreq, int adjustFactor)
        {
            tbFreqMHz.Value = centerFreq / 1000000;
            lblFreqSbMHz.Text = String.Format("{0:N0} MHz", centerFreq / 1000000);
            tbFreqkHz100.Value = (centerFreq / 100000) % 10;
            lblFreqSbkHz100.Text = String.Format("{0:N0}00 kHz", (centerFreq / 100000) % 10);
            tbFreqkHz10.Value = (centerFreq / 10000) % 10;
            lblFreqSbkHz10.Text = String.Format("{0:N0}0 kHz", (centerFreq / 10000) % 10);
            tbFreqkHz1.Value = (centerFreq / 1000) % 10;
            lblFreqSbkHz1.Text = String.Format("{0:N0} kHz", (centerFreq / 1000) % 10);
            tbFreqHz100.Value = (centerFreq / 100) % 10;
            lblFreqSbHz100.Text = String.Format("{0:N0}00 Hz", (centerFreq / 100) % 10);
            tbFreqHz10.Value = (centerFreq / 10) % 10;
            lblFreqSbHz10.Text = String.Format("{0:N0}0 Hz", (centerFreq / 10) % 10);
            tbFreqHz1.Value = centerFreq % 10;
            lblFreqSbHz1.Text = String.Format("{0:N0} Hz", centerFreq % 10);
            tbFreqAdjust.Value = adjustFactor;
            lblAdjFreqLow.Text = String.Format("{0:N0}", centerFreq / 10);
            int highFreqVal = centerFreq * 10;
            if (highFreqVal > AD9833Control.MAX_FREQ)
                highFreqVal = (int)AD9833Control.MAX_FREQ;
            lblAdjFreqHigh.Text = String.Format("{0:N0}", highFreqVal);
        }

        private void adjustFreq()
        {
            int centerFreq = tbFreqHz1.Value
               + tbFreqHz10.Value * 10
               + tbFreqHz100.Value * 100
               + tbFreqkHz1.Value * 1000
               + tbFreqkHz10.Value * 10000
               + tbFreqkHz100.Value * 100000
               + tbFreqMHz.Value * 1000000;
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
            tbOutVoltage.Value = UPP_1V_VALUE;
            adjustOutVoltage();
        }

        [DllImport("user32.dll", CharSet = CharSet.Unicode)]
        static extern uint SendMessage(IntPtr hWnd,
          uint Msg,
          uint wParam,
          uint lParam);

        private void btnFreqAdjustRest_Clicked(object sender, EventArgs e)
        {
            tbFreqAdjust.Value = 0;
            adjustFreq();
        }
    }
}
