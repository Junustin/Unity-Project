using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransparentOnBlock : MonoBehaviour
{
    [SerializeField] GameObject solidObject;
    [SerializeField] GameObject transparentObject;

    private void Start()
    {
        SolidActive();
    }


    public void TransparentActive()
    {
        solidObject.SetActive(false);
        transparentObject.SetActive(true);
    }
    public void SolidActive()
    {
        transparentObject.SetActive(false);
        solidObject.SetActive(true);
    }
}
