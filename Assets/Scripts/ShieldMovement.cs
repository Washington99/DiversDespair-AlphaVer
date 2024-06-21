using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class ShieldMovement : MonoBehaviour
{
    public SkinSelector player;

    void Start()
    {
        gameObject.transform.parent = player.skins[PlayerPrefs.GetInt("SelectedSkin", 1)].transform;
        ShieldOff();
    }

    public void ShieldOn()
    {
        Debug.Log("Shield On");
        GetComponent<SpriteRenderer>().enabled = true;
    }

    public void ShieldOff()
    {
        Debug.Log("Shield Off");
        GetComponent<SpriteRenderer>().enabled = false;
    }
}
