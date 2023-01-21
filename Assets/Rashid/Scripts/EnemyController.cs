using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public GameObject Enemy;
    public GameObject Bullet;
    public Transform BulletSpawnPoint;
    public GameObject DestroyEffect;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("ShootBullet", 1, 0.5f);
        //StartCoroutine(Shooting());
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime);
    }

    void ShootBullet()
    {
        GameObject bullet = Instantiate(Bullet, BulletSpawnPoint.position, BulletSpawnPoint.rotation);
        //bullet.transform.localPosition = Vector3.zero;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Boundary")
        {
            GameManager.instance.SpawnEnemy();
            Destroy(gameObject);
        }
    }

    //IEnumerator Shooting()
    //{
    //    yield return new WaitForSeconds(1);
    //    ShootBullet();
    //    StartCoroutine(Shooting());
    //}

}
