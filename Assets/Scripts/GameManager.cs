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

    public Transform XRRigPosition;

    public Transform origin0;
    public Transform origin1;

    /*private Dictionary<int, Transform> spawns;

    public Transform originLevel0;
    public Transform originLevel1;*/


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
        /*spawns = new Dictionary<int, Transform>();
        spawns.Add(0, originLevel0);
        spawns.Add(1, originLevel1);*/
    }

    void Update()
    {

    }

    public void InstantiatePlayer()
    {
        networkPlayer = PhotonNetwork.Instantiate(this.networkPlayer.name, new Vector3(Random.Range(-2, 2), 3f, Random.Range(3, 4)), Quaternion.identity, 0);
        networkPlayer.transform.parent = transform;
        cameraRig.transform.parent = networkPlayer.transform;
    }

   /* public void nextLevel()
    {
        level++;
        switch (level)
        {
            case 0:
                VROrigin.transform.position = spawns[level].position + new Vector3(0, 0.5f, 0);
                break;

            case 1:
                VROrigin.transform.position = spawns[level].position + new Vector3(0, 0.5f, 0);
                break;

            default:
                break;
        }
    }*/

    public void nextLevel() {
        XRRigPosition.transform.position = origin1.position;
        //XRRigPosition.transform.position = new Vector3(Random.Range(-2, 2), 0.25f, Random.Range(3, 4));
    }
    

}

