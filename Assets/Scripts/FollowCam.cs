using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour
{
    public GameObject character;
    Vector3 distance;

    // Start is called before the first frame update
    void Start()
    {
        distance = transform.position - character.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = character.transform.position + distance;
    }
}
