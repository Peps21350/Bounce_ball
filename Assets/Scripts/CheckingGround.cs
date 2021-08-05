using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckingGround : MonoBehaviour
{
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag != "PLayer")
        {
            gameObject.GetComponentInParent<PlayerMecanics>().isGrounded = false;
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag != "PLayer")
        {
            gameObject.GetComponentInParent<PlayerMecanics>().isGrounded = true;
        }
    }
}
