using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMaterials : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject gm;
    public Material[] materialArray;
    public static int stateMaterials;

    private void Start()
    {
        if (stateMaterials != 0)
        {
            ChangeMaterial(stateMaterials);
        }
       // ChangeMaterial(stateMaterials);
    }

    public void ChangeMaterial(int variable)
    {
        gm.GetComponent<MeshRenderer>().material = materialArray[variable];
    }

    

}
