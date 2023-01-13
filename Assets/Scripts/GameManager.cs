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
    public Transform origin2;

    public AudioSource audio;
    public AudioClip clip0;
    public AudioClip clip1;
    public AudioClip clip2;

    public GameObject level0;
    public GameObject level1;
    public GameObject level2;

    private bool currentPortalActive = false;
    private int currentScore;

    private Dictionary<int, Transform> spawns;
    private Dictionary<int, AudioClip> sounds;
    private Dictionary<int, GameObject> levels;


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
        level0.SetActive(true);
        level1.SetActive(false);
        level2.SetActive(false);
        levels = new Dictionary<int, GameObject>();
        levels.Add(0,level0);
        levels.Add(1,level1);
        levels.Add(2,level2);
        level = 0;
        currentScore = 0;
        spawns = new Dictionary<int, Transform>();
        spawns.Add(0, origin0);
        spawns.Add(1, origin1);
        spawns.Add(2, origin2);
        sounds = new Dictionary<int, AudioClip>();
        sounds.Add(0, clip0);
        sounds.Add(1, clip1);
        sounds.Add(2, clip2);
        audio.clip = clip0;
        audio.loop = true;
        audio.Play();
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
        if (level < 2)
        {
            level++;
            levels[level].SetActive(true);
            setPlayerScore(currentScore);
            currentScore = 0;
            currentPortalActive = false;
            XRRigPosition.transform.position = spawns[level].position;
            audio.Stop();
            audio.clip = sounds[level];
            audio.loop = true;
            audio.Play();
            levels[level-1].SetActive(false);
        }
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

