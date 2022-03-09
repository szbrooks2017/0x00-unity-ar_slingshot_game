using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.AI.Navigation;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;
public class NavMeshBaker : MonoBehaviour
{
    [SerializeField]
    NavMeshSurface SurfaceToBake;
    // ARPlane PlaneRef;

    /// debug variable
    private void Awake() 
    {
        // PlaneRef = GetComponent<ARPlane>();
        SurfaceToBake = GetComponent<NavMeshSurface>();
                // for (int i = 0; i < navMeshSurfaces.Length; i++)
        // {
        //     navMeshSurfaces[i].BuildNavMesh();
        //     debugText.text = "you made me ink!!";
        // }
    }

    public void ThenWeBake()
    {
        SurfaceToBake.BuildNavMesh();
    }
}
