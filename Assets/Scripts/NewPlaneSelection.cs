using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.UI;
using UnityEngine.AI;


/// <summary> The <c>NewPlaneSelection</c> gives the user the ability to select planes
/// detected through trackables created from AR Foundation.</summary>
public class NewPlaneSelection : MonoBehaviour
{
    /// variables for plane selection
    private ARPlaneManager _arPlaneManager;
    private ARRaycastManager _arRaycastManager;
    private Vector2 touchPosition;
    static List<ARRaycastHit> hits = new List<ARRaycastHit>();
    [HideInInspector] public GameObject savedPlane;

    // Instantiating targets
    public NavMeshAgent TargetPrefab;
    [HideInInspector] public Pose planePose;
    [HideInInspector] public List<NavMeshAgent> SpawnedTargets = new List<NavMeshAgent>();
    public int NumberOfEnemies = 5;

    // Instantiating ammo
    public GameObject AmmoPrefab;
    [SerializeField] private GameObject SpawnedAmmo;
    [SerializeField] private GameObject ARCamera;
    [HideInInspector] public Vector3 cameraOffset = new Vector3(0f, -0.4f, 1f);
    public Camera cameraRef;
    public float distance = 5.0f;

    // Score & ammo system
    [HideInInspector] public int scoreInt = 0;
    public Text scoreCount;
    [HideInInspector] public int ammoInt;
    public Text ammoCount;

    /// variables for UI 
    public GameObject StartButtonRef;
    public GameObject PlayAgainButtonRef;
    public GameObject playAgain;

    void Update()
    {
        if (_arPlaneManager.enabled)
        {
            if (!GetTouchPosition(out Vector2 touchPosition))
                return;

            /// if the user touches the screen we collect the id of that track instance
            /// then we disable all other trackables except for the one we want
            /// we also disable the ability to automatically find new planes
            if (_arRaycastManager.Raycast(touchPosition, hits, TrackableType.PlaneWithinPolygon))
            {
                var planeId = hits[0].trackableId;
                planePose = hits[0].pose;
                foreach (var plane in _arPlaneManager.trackables)
                {
                    if (plane.trackableId != planeId)
                    {
                        // plane.gameObject.SetActive(false);
                        Destroy(plane.gameObject);
                    }
                    else
                    {
                        savedPlane = plane.gameObject;
                        savedPlane.GetComponent<NavMeshBaker>().ThenWeBake();
                        StartButtonRef.SetActive(enabled);
                        // this spawns when you touch which is wrong.
                    }
                }           
                _arPlaneManager.enabled = false;
                _arRaycastManager.enabled = false;
            }
        }
    }
    /// <summary> Awake is called when the script instance is being loaded
    /// here we gather a reference for the Plane Manager and Raycast Manager</summary>
    private void Awake()
    {
        _arPlaneManager = GetComponent<ARPlaneManager>();
        _arRaycastManager = GetComponent<ARRaycastManager>();
        // invisibleSphere = GameObject.Find("Sphere").GetComponent<GameObject>();
    }

    /// <summary> This method listens for when the user touches the screen</summary>
    /// <param name ="touchPosition"> the vector position of the touch</param>
    /// <returns> a bool confirming the input</returns>
    bool GetTouchPosition(out Vector2 touchPosition)
    {
        if (Input.touchCount > 0)
        {
            touchPosition = Input.GetTouch(0).position;
            return true;
        }
        touchPosition = default;
        return false;
    }

    /// <summary> This is an Onclick event attached to the Start Button
    /// it instantiate targets and ammo </summary>
    public void StartButton()
    {
        SpawnTargets();
        SpawnAmmo();
        StartButtonRef.SetActive(false);
    }

    /// <summary> Spawn Targets instantiates the targets on a navmesh</summary>
    public void SpawnTargets()
    {
        // spawn targets-default of 5
        for (int i = 0; i < NumberOfEnemies; i++)
        {
            SpawnedTargets.Add(Instantiate(TargetPrefab, planePose.position, planePose.rotation));
        }
    }
    /// <summary> Spawn Ammo instantiates the ammo in relation to the ARcamera</summary>
    public void SpawnAmmo()
    {
        Vector3 ballPos = ARCamera.transform.position + ARCamera.transform.forward * cameraOffset.z + ARCamera.transform.up * cameraOffset.y;
        SpawnedAmmo = Instantiate(AmmoPrefab, ballPos, Quaternion.identity);
    }

    /// <summary> EndGame is called when ammo or targets reach 0 </summary>
    public void EndGame()
    {
        PlayAgainButtonRef.SetActive(true);
    }
    /// <summary> Play Again is called to reset ammo, targets, and score on the saved ARPlane</summary>
    public void PlayAgain()
    {
        playAgain.SetActive(false);

        // destroy remaining targets
        // for (int i = 0; i < SpawnedTargets.Count; i++)
        // {
        
        //     SpawnedTargets[i].enabled = false;
        // }
        // spawn new targets
        SpawnTargets();
        // reset ammo
        ammoInt = 8;
        ammoCount.text = ammoInt.ToString();
        // reset score
        scoreInt = 0;
        scoreCount.text = scoreInt.ToString();
    }
}
