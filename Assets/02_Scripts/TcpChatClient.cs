using System;
using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class TcpChatClient : IDisposable
{
    private string _serverIp;
    private int _serverPort;
    
    // TCP Client 관련 변수
    private TcpClient _tcpClient;
    private NetworkStream _stream;
    private StreamReader _reader;
    private StreamWriter _writer;
    
    // 상태 변수
    private bool _isConnected = false;
    private bool _isDisposed = false;
    public bool IsConnected => _isConnected && !_isDisposed;
    
    // 이벤트 선언
    public event Action Connected;
    public event Action Disconnected;
    public event Action<string> MessageReceived;
    public event Action<string> ErrorReceived;
    
    // 생성자
    public TcpChatClient(string serverIp, int serverPort)
    {
        _serverIp = serverIp;
        _serverPort = serverPort;
    }

    #region 서버 연결

    public async Task<bool> ConnectServerAsync()
    {
        if (_isConnected)
        {
            Debug.Log("이미 서버에 연결되어 있습니다.");
            return false;
        }

        try
        {
            _tcpClient = new TcpClient();
            await _tcpClient.ConnectAsync(_serverIp, _serverPort);
            _stream = _tcpClient.GetStream();
            _reader = new StreamReader(_stream, new UTF8Encoding(false));
            _writer = new StreamWriter(_stream, new UTF8Encoding(false)){AutoFlush = true};
            _isConnected = true;
            
            // TODO: 서버 연결 이벤트 발행
            // TODO: 수신루프 시작
            return true;
        }
        catch (Exception e)
        {
            Debug.LogError(e.Message);
            return false;
        }
    }
    #endregion

    #region 메시지 수신

    #endregion

    #region 메시지 전송

    #endregion
    
    public void Dispose()
    {
        if (_isDisposed) return;
        _isDisposed = true;
        _isConnected = false;
        _reader?.Dispose();
        _writer?.Dispose();
        _stream?.Dispose();
        _tcpClient?.Dispose();
    }
}
