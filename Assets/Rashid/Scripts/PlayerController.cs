using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject Player;

    public float MinX, MaxX, MinZ, MaxZ;
    private Vector3 temprorayPosition;
    // Start is called before the first frame update
    void Start()
    {
        temprorayPosition = Player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            temprorayPosition = Player.transform.position;
            temprorayPosition.x += Time.deltaTime;
            MovePlayer();
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            temprorayPosition = Player.transform.position;
            temprorayPosition.x -= Time.deltaTime;
            MovePlayer();
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            temprorayPosition = Player.transform.position;
            temprorayPosition.z += Time.deltaTime;
            MovePlayer();
        }
        //test

        if (Input.GetKey(KeyCode.DownArrow))
        {
            temprorayPosition = Player.transform.position;
            temprorayPosition.z -= Time.deltaTime;
            MovePlayer();
        }

        //this.transform.Translate(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        //temprorayPosition = Player.transform.position;
        //MovePlayer();

    }

    void MovePlayer()
    {
        temprorayPosition.x = Mathf.Clamp(temprorayPosition.x, MinX, MaxX);
        temprorayPosition.z = Mathf.Clamp(temprorayPosition.z, MinZ, MaxZ);
        Player.transform.position = temprorayPosition;
    }
}
