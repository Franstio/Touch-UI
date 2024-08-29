using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using TestTCP1.Properties;

namespace TestTCP1.Lib
{
    public class TCPConn
    {
        private TcpClient _tcpClient = new TcpClient();
        private static TCPConn? _conn = null;
        private IPAddress? _address;
        private int _port = 23000;
        private bool log = true;
        private byte[] gBuffer = new byte[512];
        public void setLog(bool log)
        {
            this.log = log;
        }
        public static TCPConn newInstance() => new TCPConn();
        public TCPConn()
        {
            string addr = Properties.Settings.Default["ServerIpAddress"].ToString() ?? string.Empty;
            int port = int.Parse(Properties.Settings.Default["ServerPort"].ToString() ?? "0");
            if (!IPAddress.TryParse(addr, out _address))
                MessageBox.Show("Please supply an IP Address.");
            _conn = this;
            _port = port;
        }
        public TCPConn(string addr, int port)
        {
            if (!IPAddress.TryParse(addr, out _address))
                MessageBox.Show("Please supply an IP Address.");
            _tcpClient = _tcpClient ?? new TcpClient();
            _port = port;
        }
        public void SetIpAddress(string addr)
        {
            if (!IPAddress.TryParse(addr, out _address))
                MessageBox.Show("Please supply an IP Address.");
        }
        public void SetPort(int port)
        {
            _port = port;
        }
        public async Task StartConnection()
        {
            if (_address is null)
            {
                MessageBox.Show("Set IP Address First");
                return;
            }
            if (IsRunning())
            {
                MessageBox.Show("Connection already started. Please disconnect first");
                return;
            }
            int tryCount = 0;
            bool isCompleted= false;
            do
            {
                try
                {
                    await _tcpClient.ConnectAsync(_address, _port);
                    isCompleted = true;
                    //            _tcpClient.GetStream().BeginRead(gBuffer, 0, gBuffer.Length, this.checkConnection, _tcpClient);
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                    Task.Delay(100);
                    tryCount++;
                    isCompleted = false;
                }
            }
            while (tryCount < 3 && !isCompleted);
            
        }
        public bool IsRunning()
        {
            return _tcpClient.Connected;
        }
        public void StopConnection()
        {
            _tcpClient.Close();
            _tcpClient = new TcpClient();
        }
        void showMsgBox(string message)
        {
            MessageBox.Show(message);
        }
        public async Task<string> SendCommand(string cmd)
        {
            if (!IsRunning())
                await StartConnection();

                try
                {
                    string msg = string.Empty;
                    do
                    {
                        byte[] buffer = Encoding.ASCII.GetBytes($"{cmd}\r\n");
                        Debug.WriteLineIf(log, $"Writing {cmd} Command");
                        await _tcpClient.GetStream().WriteAsync(buffer, 0, buffer.Length);
                        await _tcpClient.GetStream().FlushAsync();
                    //Thread.Sleep(100);
                    msg = await ReadIncomingMsg(cmd);

                    }
                    while ((msg.Contains("E1") || msg == string.Empty) );
                await Task.Delay(10);
                    return msg.Replace("\0", string.Empty).Replace("\\0", string.Empty).Trim().Replace("\r", "").Replace("\n", "");
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message + " " + ex.InnerException?.Message);
                    StopConnection();
                    await StartConnection();
                    return await SendCommand(cmd);
                }
        }
        private async Task<string> ReadIncomingMsg(string? logCommand=null)
        {
            try
            {
                if (!_tcpClient.Connected)
                {
                    showMsgBox("TCP is not Connected");
                    return string.Empty;
                }
                byte[] buffer = new byte[512];
                Debug.WriteLineIf(log,$"Reading Stream TCP {(logCommand is not null ? "From "+logCommand : "") }...");
                await Task.Delay(50);
                var stream = _tcpClient.GetStream();
                await stream.ReadAsync(buffer, 0, buffer.Length);
                string msg = Encoding.ASCII.GetString(buffer, 0, buffer.Length);
//                await stream.FlushAsync();
                Debug.WriteLineIf(log, $"Result: {msg}");
                return msg;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message + " " + ex.InnerException?.Message);
                StopConnection();
                await StartConnection();
//                MessageBox.Show(ex.Message);
                return await ReadIncomingMsg(logCommand);
            }
        }
    }
}
