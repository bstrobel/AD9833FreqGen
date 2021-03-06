﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AD9833Control
{

    public enum WaveFormsEnum
    {
        Sine,
        Triangular,
        Square
    }

    public enum SerialPortStatus
    {
        Open,
        Closed
    }

    public class SerialPortStatusChangedEventArgs
    {
        public SerialPortStatus status { get; }
        public String ackMsg;
        public Exception exception { get; }
        public SerialPortStatusChangedEventArgs(SerialPortStatus s, String a, Exception ex)
        {
            status = s;
            ackMsg = a;
            exception = ex;
        }
    }

    public interface IAD9833ControlModel
    {
        bool Enabled { get; set; }
        long Frequency { get; set; }
        WaveFormsEnum WaveForm { get; set; }
        short OutVoltage { get; set; }
        event EventHandler<SerialPortStatusChangedEventArgs> SerialPortStatusChanged;
        SerialPortStatus SerialPortStatus { get; }
    }
}
