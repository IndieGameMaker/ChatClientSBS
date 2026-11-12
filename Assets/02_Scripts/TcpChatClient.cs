using System;
using System.IO;
using System.Net.Sockets;

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

    #endregion

    #region 메시지 수신

    #endregion

    #region 메시지 전송

    #endregion
    
    public void Dispose()
    {
        
    }
}
