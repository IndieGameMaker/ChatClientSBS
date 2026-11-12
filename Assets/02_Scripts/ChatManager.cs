using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ChatManager : MonoBehaviour
{
    [Header("Server Settings")]
    [SerializeField] private string _serverIp = "127.0.0.1";
    [SerializeField] private int _serverPort = 7700;

    [Header("UI Settings")]
    [SerializeField] private TMP_InputField _nickNameIF;
    [SerializeField] private TMP_InputField _messageIF;
    
    [SerializeField] private Button _connectButton;
    [SerializeField] private Button _sendButton;
    
    [SerializeField] private TextMeshProUGUI _messageText;

    private TcpChatClient _client;
    
    private async Task Awake()
    {
        _client = new TcpChatClient(_serverIp, _serverPort);
        await _client.ConnectServerAsync();
    }
}
