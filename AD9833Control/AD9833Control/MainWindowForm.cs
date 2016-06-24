using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
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
        public MainWindowForm(IAD9833ControlModel ctrl)
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
            tbOutVoltage.Value = settings.LastOutVoltage;
            adjustOutVoltage();
            adjustFreq(settings.LastFreq, 0);
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
            progBarOutVoltage.Value = tbOutVoltage.Value;
            adjustOutVoltage();
        }

        private void adjustOutVoltage()
        {
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
            long centerFreq = tbFreqHz1.Value
                + tbFreqHz10.Value * 10
                + tbFreqHz100.Value * 100
                + tbFreqkHz1.Value * 1000
                + tbFreqkHz10.Value * 10000
                + tbFreqkHz100.Value * 100000
                + tbFreqMHz.Value * 1000000;
            long deviationPct = tbFreqAdjust.Value;
            adjustFreq(centerFreq, deviationPct);
        }

        private void adjustFreq(long centerFreq, long deviationPct)
        {
            settings.LastFreq = centerFreq;
            double actFreq = (double)centerFreq * ((1000 + (double)deviationPct) / 1000);
            lblActFreq.Text = String.Format("{0:N0} Hz", (long)actFreq);
            ctrl.Frequency = (long)actFreq;
            int val = (int)centerFreq;
            tbFreqMHz.Value = val / 1000000;
            lblFreqSbMHz.Text = String.Format("{0:N0} MHz", val / 1000000);
            tbFreqkHz100.Value = (val / 100000) % 10;
            lblFreqSbkHz100.Text = String.Format("{0:N0}00 kHz", (val / 100000) % 10);
            tbFreqkHz10.Value = (val / 10000) % 10;
            lblFreqSbkHz10.Text = String.Format("{0:N0}0 kHz", (val / 10000) % 10);
            tbFreqkHz1.Value = (val / 1000) % 10;
            lblFreqSbkHz1.Text = String.Format("{0:N0} kHz", (val / 1000) % 10);
            tbFreqHz100.Value = (val / 100) % 10;
            lblFreqSbHz100.Text = String.Format("{0:N0}00 Hz", (val / 100) % 10);
            tbFreqHz10.Value = (val / 10) % 10;
            lblFreqSbHz10.Text = String.Format("{0:N0}0 Hz", (val / 10) % 10);
            tbFreqHz1.Value = val % 10;
            lblFreqSbHz1.Text = String.Format("{0:N0} Hz", val % 10);
        }

        private void btn1Vpp_Clicked(object sender, EventArgs e)
        {
            tbOutVoltage.Value = UPP_1V_VALUE;
            adjustOutVoltage();
        }
    }
}
