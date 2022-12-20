using System.Collections;
using System.Collections.Generic;
using UnityEngine;


using Photon.Pun;
using Photon.Realtime;


public class GameManager: MonoBehaviour
{
    public static GameManager Instance;

    private int level;

    [SerializeField]
    GameObject networkPlayer;

    [SerializeField]
    Transform cameraRig;

    NetworkPlayer np;

    public Transform XRRigPosition;

    public Transform origin0;
    public Transform origin1;

    private bool currentPortalActive = false;
    private int currentScore;

    private Dictionary<int, Transform> spawns;


    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        level = 0;
        currentScore = 0;
        spawns = new Dictionary<int, Transform>();
        spawns.Add(0, origin0);
        spawns.Add(1, origin1);
    }

    void Update()
    {

    }

    public void InstantiatePlayer()
    {
        networkPlayer = PhotonNetwork.Instantiate(this.networkPlayer.name, new Vector3(0, 3f, 0), Quaternion.identity, 0);
        np = networkPlayer.GetComponent<NetworkPlayer>();
        networkPlayer.transform.parent = transform;
        cameraRig.transform.parent = networkPlayer.transform;
    }

    public void nextLevel() {
        level++;
        setPlayerScore(currentScore);
        currentScore = 0;
        currentPortalActive = false;
        XRRigPosition.transform.position = spawns[level].position;
        //XRRigPosition.transform.position = origin1.position;
        //XRRigPosition.transform.position = new Vector3(Random.Range(-2, 2), 0.25f, Random.Range(3, 4));
    }

    public int getCurrentLevel()
    {
        return level;
    }

    public bool isCurrentPortalActive()
    {
        return currentPortalActive;
    }

    public void setCurrentPortal(bool status)
    {
        currentPortalActive = status;
    }

    public void setPlayerScoreGM (int score)
    {
        currentScore = score;
    }

    public void setPlayerScore(int score)
    {
        np.setScore(score);
    }
    public int getTotalScore() {
        return np.getTotalScore();
    }
}

