using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject Player;
    public GameObject Bullet;
    public Transform BulletSpawnPoint;

    public float MoveSpeed = 1f;
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
        //if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        //{
        //    temprorayPosition = Player.transform.position;
        //    temprorayPosition.x += Time.deltaTime * MoveSpeed;
        //    MovePlayer();
        //}

        //if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        //{
        //    temprorayPosition = Player.transform.position;
        //    temprorayPosition.x -= Time.deltaTime * MoveSpeed;
        //    MovePlayer();
        //}

        //if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        //{
        //    temprorayPosition = Player.transform.position;
        //    temprorayPosition.z += Time.deltaTime * MoveSpeed;
        //    MovePlayer();
        //}

        //if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        //{
        //    temprorayPosition = Player.transform.position;
        //    temprorayPosition.z -= Time.deltaTime * MoveSpeed;
        //    MovePlayer();
        //}

        if (Input.GetMouseButtonDown(0))
        {
            ShootBullet();
        }
        this.transform.Translate(new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")) * Time.deltaTime * MoveSpeed);
        temprorayPosition = Player.transform.position;
        MovePlayer();

    }

    void MovePlayer()
    {
        temprorayPosition.x = Mathf.Clamp(temprorayPosition.x, MinX, MaxX);
        temprorayPosition.z = Mathf.Clamp(temprorayPosition.z, MinZ, MaxZ);
        Player.transform.position = temprorayPosition;
    }

    void ShootBullet()
    {
        GameObject bullet = Instantiate(Bullet, BulletSpawnPoint.position, Quaternion.identity);
        //bullet.transform.localPosition = Vector3.zero;
    }
}
