using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;
using System.IO;

namespace AD9833Control
{
    public class AD9833Control : IAD9833ControlModel
    {
        private bool _enabled = false;
        public const long MAX_FREQ = 12500000;
        public const short MAX_VOLTAGE = 255;
        private long _frequency = 0;
        private WaveFormsEnum _waveForm = WaveFormsEnum.Sine;
        private short _outVoltage = 100;
        private SerialPortStatus _serialPortStatus = SerialPortStatus.Closed;

        public bool Enabled
        {
            get
            {
                return _enabled;
            }

            set
            {
                _enabled = value;
                sendToXMC2GO();
            }
        }

        public long Frequency
        {
            get
            {
                return _frequency;
            }

            set
            {
                if (value <= MAX_FREQ)
                    _frequency = value;
                else
                    _frequency = MAX_FREQ;
                sendToXMC2GO();
            }
        }

        public WaveFormsEnum WaveForm
        {
            get
            {
                return _waveForm;
            }

            set
            {
                _waveForm = value;
                sendToXMC2GO();
            }
        }

        public short OutVoltage
        {
            get
            {
                return _outVoltage;
            }

            set
            {
                if (value <= MAX_VOLTAGE)
                    _outVoltage = value;
                else
                    _outVoltage = MAX_VOLTAGE;
                sendToXMC2GO();
            }
        }

        public SerialPortStatus SerialPortStatus
        {
            get
            {
                openSerialPort();
                return _serialPortStatus;
            }
        }

        private AD9833ControlSettings settings;
        private SerialPort serialPort;

        public AD9833Control()
        {
            settings = new AD9833ControlSettings();
            openSerialPort();
        }

        public event EventHandler<SerialPortStatusChangedEventArgs> SerialPortStatusChanged;

        protected virtual void OnSerialPortStatusChanged(Exception ex)
        {
            SerialPortStatusChanged?.Invoke(this, new SerialPortStatusChangedEventArgs(_serialPortStatus, ex));
        }

        private void openSerialPort()
        {
            try
            {
                if (serialPort == null)
                    serialPort = new SerialPort(settings.COMPort, settings.BaudRate, Parity.None, 8, StopBits.One);
                if (!serialPort.IsOpen)
                    serialPort.Open();
                _serialPortStatus = SerialPortStatus.Open;
                OnSerialPortStatusChanged(null);
            }
            catch (IOException ex)
            {
                _serialPortStatus = SerialPortStatus.Closed;
                OnSerialPortStatusChanged(ex);
            }
            catch (UnauthorizedAccessException ex)
            {
                _serialPortStatus = SerialPortStatus.Closed;
                OnSerialPortStatusChanged(ex);
            }
        }

        private void sendToXMC2GO()
        {
            if (!_enabled)
            {
                if (!serialPort.IsOpen)
                    openSerialPort();
                if (_serialPortStatus == SerialPortStatus.Open)
                    serialPort.Write("r\r\n");
                return;
            }
            if (Frequency > 0)
            {
                String sWaveForm;
                switch (WaveForm)
                {
                    default:
                    case WaveFormsEnum.Sine:
                        {
                            sWaveForm = "s,";
                            break;
                        }
                    case WaveFormsEnum.Square:
                        {
                            sWaveForm = "q,";
                            break;
                        }
                    case WaveFormsEnum.Triangular:
                        {
                            sWaveForm = "t,";
                            break;
                        }
                }
                if (!serialPort.IsOpen)
                    openSerialPort();
                if (_serialPortStatus == SerialPortStatus.Open)
                    serialPort.Write(sWaveForm + _frequency + ",0," + _outVoltage + "\r\n");
            }

        }
    }
}
