using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using TouchUI.Properties;

namespace TouchUI.Lib
{
    public class TCPConn
    {
        private TcpClient _tcpClient = new TcpClient();
        private static TCPConn? _conn = null;
        private IPAddress? _address;
        private int _port = 23000;
        private bool log = true;
        private byte[] gBuffer = new byte[512];
        NetworkStream? stream = null;
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
                _tcpClient.Close();
//                MessageBox.Show("Connection already started. Please disconnect first");
//                return;
            }

            _tcpClient = new TcpClient();
            _tcpClient.NoDelay = true;
            CancellationTokenSource cts = new CancellationTokenSource();
            int tryCount = 0;
            bool isCompleted= false;
            do
            {
                try
                {
                    _ = Task.Run(async () =>
                    {
                        await Task.Delay(1000);
                        if (isCompleted)
                            return;
                        cts.Cancel();
                        isCompleted = false;
                    });
                    await _tcpClient.ConnectAsync(_address, _port, cts.Token);
                    if (!cts.IsCancellationRequested)
                        isCompleted = true;
                    //            _tcpClient.GetStream().BeginRead(gBuffer, 0, gBuffer.Length, this.checkConnection, _tcpClient);
                }
                catch (Exception ex)
                {

                    _tcpClient = new TcpClient();
                    _tcpClient.NoDelay = true;
                    Debug.WriteLine(ex.Message);
                    Task.Delay(100);
                    tryCount++;
                    isCompleted = false;
                }
                finally
                {
                     cts = new CancellationTokenSource();
                }
            }
            while (!isCompleted);
            
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
        public async Task<string> SendCommand(string cmd,CancellationToken? token=null)
        {
            if (!IsRunning() )
                await StartConnection();
            int count = 0;
                try
                {
                    string msg = string.Empty;
                    stream = _tcpClient.GetStream();
                    stream.ReadTimeout = 500;
                    stream.WriteTimeout = 1000;
                do
                {
                    if (count > 100)
                    {
                        StopConnection();
                        await Task.Delay(100);
                        await StartConnection();
                        count = 0;
                    }
                    count = count + 1;
                        byte[] buffer = Encoding.ASCII.GetBytes($"{cmd}\r\n");
                        Debug.WriteLineIf(log, $"Writing {cmd} Command");
                        await stream.WriteAsync(buffer, 0, buffer.Length,token ?? CancellationToken.None);
                    if (token is not null && token.Value.IsCancellationRequested)
                    {
                        await stream.FlushAsync();
                    }
                    //Thread.Sleep(100);
                    msg = await ReadIncomingMsg(cmd,token);

                    }
                    while ((msg.Contains("E1") || msg == string.Empty) && (token is null || !token.Value.IsCancellationRequested) );
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
        private async Task<string> ReadIncomingMsg(string? logCommand=null,CancellationToken? token=null)
        {
            try
            {
                if (!_tcpClient.Connected || stream is null)
                {
                    StopConnection();
                    await StartConnection();
                }
                byte[] buffer = new byte[1024];
                Debug.WriteLineIf(log,$"Reading Stream TCP {(logCommand is not null ? "From "+logCommand : "") }...");
                await stream.ReadAsync(buffer, 0, buffer.Length,token ?? CancellationToken.None);
                string msg = Encoding.ASCII.GetString(buffer, 0, buffer.Length);
//                await stream.FlushAsync();
                Debug.WriteLineIf(log, $"Result: {msg}");
                if (token is not null && token.Value.IsCancellationRequested)
                {
                    await stream.FlushAsync();
                }

                return msg;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message + " " + ex.InnerException?.Message);
//                MessageBox.Show(ex.Message);
                return string.Empty;
            }
        }
    }
}
