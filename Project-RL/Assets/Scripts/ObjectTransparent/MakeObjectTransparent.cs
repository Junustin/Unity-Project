using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeObjectTransparent : MonoBehaviour
{
    [SerializeField] List<TransparentOnBlock> curentlyBlocked;
    [SerializeField] List<TransparentOnBlock> curentlyTransparent;
    [SerializeField] Transform player;
    Transform cam;

    private void Start()
    {
        curentlyBlocked = new List<TransparentOnBlock>();
        curentlyTransparent = new List<TransparentOnBlock>();
        cam = this.gameObject.transform;
    }

    private void Update()
    {
        GetObjectThatBlockCamera();

        MakeObjectSolid();
        MakeObjectsTransparent();
    }

    private void GetObjectThatBlockCamera()
    {
        curentlyBlocked.Clear();
        

        float cameraDistance = Vector3.Magnitude(cam.position - player.position);

        Ray forwardRay = new Ray(cam.position, player.position - cam.position);
        Ray backwardRay = new Ray(cam.position, cam.position - player.position);
        var hitForward = Physics.RaycastAll(forwardRay, cameraDistance);
        var hitBackward = Physics.RaycastAll(backwardRay, cameraDistance);

        foreach(var hit in hitForward)
        {
            if(hit.collider.gameObject.TryGetComponent(out TransparentOnBlock blocked))
            {                
                if (!curentlyBlocked.Contains(blocked))
                {
                    curentlyBlocked.Add(blocked);
                }
            }
        }
        foreach (var hit in hitBackward)
        {
            if (hit.collider.gameObject.TryGetComponent(out TransparentOnBlock blocked))
            {
                if (!curentlyBlocked.Contains(blocked))
                {
                    curentlyBlocked.Add(blocked);
                }
            }
        }
    }

    private void MakeObjectsTransparent()
    {
        for(int i = 0; i< curentlyBlocked.Count; i++)
        {
            TransparentOnBlock blocked = curentlyBlocked[i];

            if (!curentlyTransparent.Contains(blocked))
            {                
                blocked.TransparentActive();
                curentlyTransparent.Add(blocked);
            }
        }
    }

    private void MakeObjectSolid()
    {
        for(int i = curentlyTransparent.Count - 1; i >= 0; i--)
        {
            TransparentOnBlock wasBlocked = curentlyTransparent[i];
            if (!curentlyBlocked.Contains(wasBlocked))
            {
                wasBlocked.SolidActive();
                curentlyTransparent.Remove(wasBlocked);
            }
        }
    }
}   
