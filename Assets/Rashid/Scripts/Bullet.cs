using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float Speed;
    // Update is called once per frame

    private void Start()
    {
        
    }
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * Speed);
    }

    private void OnTriggerEnter(Collider other)
    {
       if(other.gameObject.tag == "Enemy")
        {
            //GameManager to spawn next enemy
            //GameObject.Find("GameManager").GetComponent<GameManager>().SpawnEnemy();
            GameManager.instance.SpawnEnemy();
            GameManager.instance.Score++;
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }
    }
}
