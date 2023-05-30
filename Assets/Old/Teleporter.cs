using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField]
    public GameObject linkedportal;

    public GameObject player;

    bool isplayerinside = false;
    void Awake()
    {
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (isplayerinside)
        {
            Vector3 PlayerPortal = player.transform.position - this.transform.position;
            if (Vector3.Dot(PlayerPortal, Vector3.up) < 0){
                float rotationdiff = -Quaternion.Angle(transform.rotation, linkedportal.transform.rotation);
                rotationdiff += 180;
                player.transform.Rotate(Vector3.up, rotationdiff);

                Vector3 offset = Quaternion.Euler(0f,rotationdiff,0f)*PlayerPortal;
                offset.y = 0;
                player.transform.position = linkedportal.transform.position + offset;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) isplayerinside = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player")) isplayerinside = false;
    }

}
