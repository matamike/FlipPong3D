using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System.Text;

public struct DataChunk{
    public int playerWinHolder;
    public int playerScoreHolder;
    public int aiScoreHolder;
    public string sessionIDHolder;
};

public class Tracking : MonoBehaviour{
    private const string gFormURL = "https://docs.google.com/forms/d/13w6zDXxBUHf1RKIpc5bTd0TDjHpg8zNODEpa7t38TEw/";

    private const string gForm_SessionID = "entry.3490481"; //entry.3490481 - SessionID
    private const string gForm_TriggerTimeStamp = "entry.1548080748"; //entry.1548080748 - Trigger Timestamp
    private const string gForm_PlayerWin = "entry.1367030815"; // entry.1367030815 - Player Win
    private const string gForm_PlayerScore = "entry.160813498"; // entry.160813498 - Player Score
    private const string gForm_AIScore = "entry.607146334"; //entry.607146334 - AI Score

    private System.Guid sessionID;
    private int playerWin = 0;
    private int playerScore = 0;
    private int AIScore = 0;
    
    void Awake(){
        DontDestroyOnLoad(this.gameObject); // on changing scenes this doesn't get destroyed.
    }

    void Start(){
        SetSessionID();   
    }

    void OnApplicationQuit(){

        DataChunk data = new DataChunk();
        data.playerWinHolder = playerWin;
        data.playerScoreHolder = playerScore;
        data.aiScoreHolder = AIScore;
        data.sessionIDHolder = sessionID.ToString();

        StartCoroutine(SubmitGForm(data));    
    }

    protected void SetSessionID(){
        short randomizer = (short)SystemInfo.processorFrequency;
        short randomizerExtra = (short)SystemInfo.systemMemorySize;
        string hashTableIndex = "abcdefghijklmnopqrestuvxyz01234567890";
        string hashStr = string.Empty; //init empty
        byte[] d = new byte[8];

        for (int i = 0; i < 8; i++) hashStr += hashTableIndex[Random.Range(0, hashTableIndex.Length)];
        d = Encoding.ASCII.GetBytes(hashStr);
        sessionID = new System.Guid(Random.Range(0, 10000), randomizer, randomizerExtra, d);

        Debug.Log("SessionID: " + sessionID.ToString());
    }

    public void SetPlayerWinStatus(int numOfWins) {
        playerWin = numOfWins;
    }

    public void SetPlayerScoreStatus(int plScore){
        playerScore = plScore;
    }

    public void SetAiScoreStatus(int aiScore){
        AIScore = aiScore;   
    }

    public IEnumerator SubmitGForm(DataChunk d){
        bool isPlayerWinNull = d.playerWinHolder.ToString() is null;
        bool isPlayerScoreNull = d.playerScoreHolder.ToString() is null;
        bool isAiScoreNull = d.aiScoreHolder.ToString() is null;
        bool isSessionIDNull = d.sessionIDHolder.ToString() is null;

        string jsonPlayerWinData = isPlayerWinNull ? "not found" : d.playerWinHolder.ToString();
        string jsonPlayerScoreData = isPlayerWinNull ? "not found" : d.playerScoreHolder.ToString();
        string jsonAiScoreData = isPlayerWinNull ? "not found" : d.aiScoreHolder.ToString();
        string jsonSessionIDData = isSessionIDNull ? "not found" : d.sessionIDHolder.ToString();

        WWWForm form = new WWWForm();

        form.AddField(gForm_TriggerTimeStamp, System.DateTime.Now.ToString());
        form.AddField(gForm_PlayerWin, jsonPlayerWinData);
        form.AddField(gForm_PlayerScore, jsonPlayerScoreData);
        form.AddField(gForm_AIScore, jsonAiScoreData);
        form.AddField(gForm_SessionID, jsonSessionIDData);

        string urlGFormResponse = gFormURL + "formResponse";
        UnityWebRequest www = UnityWebRequest.Post(urlGFormResponse, form);
        yield return www.SendWebRequest();     
    }
}
