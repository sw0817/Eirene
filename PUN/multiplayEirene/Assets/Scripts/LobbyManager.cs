﻿using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;

public class LobbyManager : MonoBehaviourPunCallbacks
{
    private readonly string gameVersion = "1";

    public Text connectionInfoText;
    public Button joinButton;
    
    private void Start() // photon cloud 서버이자 matchmaking 위함
    {
        PhotonNetwork.GameVersion = gameVersion;
        PhotonNetwork.ConnectUsingSettings(); // master 서버에 접속 시도

        joinButton.interactable = false; // 일단 접속버튼 잠시 비활성화
        connectionInfoText.text = "Master Server에 접속하는 중입니다...";
    }
    
    public override void OnConnectedToMaster()
    {
        joinButton.interactable = true;
        connectionInfoText.text = "Online : Master Server에 연결 완료";
    }
    
    public override void OnDisconnected(DisconnectCause cause)
    {
        joinButton.interactable = false;
        connectionInfoText.text = $"Offline: Connection Disabled {cause.ToString()} - Try reconnecting...";

        PhotonNetwork.ConnectUsingSettings();
    }
    
    public void Connect() // photon event 메소드 X (룸 접속 시도)
    {
        joinButton.interactable = false; // 중복 접속 막기 위해 잠시 버튼 비활성화

        if(PhotonNetwork.IsConnected)
        {
            connectionInfoText.text = "Room에 연결하는 중입니다...";
            PhotonNetwork.JoinRandomRoom(); // 참가할 수 있는 빈자리 있다면 이동
        }
        else 
        {
            connectionInfoText.text = "Offline: Connection Disabled - Try reconnecting...";

            PhotonNetwork.ConnectUsingSettings();
        }
    }
    
    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        connectionInfoText.text = "빈 서버가 없습니다. 서버를 새로 만드는 중입니다.";
        PhotonNetwork.CreateRoom(null, new RoomOptions {MaxPlayers = 20}); // 새로운 룸 만들기 (최대 20명)
    }
    
    public override void OnJoinedRoom() // 빈 방으로 참가완료했을 때
    {
        connectionInfoText.text = "맵에 참가 완료.";
        // SceneManager.LoadScene(); // 동기화가 되지 않고 독자적으로 main으로 이동하게 됨 (나만 main으로 이동)
        PhotonNetwork.LoadLevel("chill"); // 방을 만든 방장이 실행하게 되면 모든 유저가 같은 씬이 로드됨 (동기화가 자동으로 됨)
    
        
    }
}