using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMaterials : MonoBehaviour
{
    public GameObject gm;
    public Material[] materialArray;
    public static int stateMaterials;

    private void Start()
    {
        if (stateMaterials != 0)
        {
            ChangeMaterial(stateMaterials);
        }
    }

    public void ChangeMaterial(int variable)
    {
        gm.GetComponent<MeshRenderer>().material = materialArray[variable];
    }

    

}
