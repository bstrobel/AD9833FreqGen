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
        private long _frequency = 0;
        private WaveFormsEnum _waveForm = WaveFormsEnum.Sine;
        private short _outVoltage = 100;
        private SerialPortStatus _serialPortStatus = SerialPortStatus.Closed;
        public long Frequency
        {
            get
            {
                return _frequency;
            }

            set
            {
                _frequency = value;
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
                _outVoltage = value;
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
        }

        private void sendToXMC2GO()
        {
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
