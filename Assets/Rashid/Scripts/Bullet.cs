using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float Speed = 100;
    public GameObject DestroyEffect;
    // Update is called once per frame

    private void Start()
    {
        Destroy(gameObject, 3);

    }
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * Speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            //GameManager to spawn next enemy
            //GameObject.Find("GameManager").GetComponent<GameManager>().SpawnEnemy();
            GameManager.instance.SpawnEnemy();
            GameManager.instance.Score++;
            GameManager.instance.UpdateUIElement();
            if (GameManager.instance.Score >= 10)
            {
                GameManager.instance.GameWon();
            }
            Instantiate(other.gameObject.GetComponent<EnemyController>().DestroyEffect, other.transform.position, Quaternion.identity);
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }

        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<PlayerController>().Health -= 3;
            GameManager.instance.HealthSlider.value = other.gameObject.GetComponent<PlayerController>().Health;
            if (other.gameObject.GetComponent<PlayerController>().Health <= 0)
            {
                GameManager.instance.GameOver();
            }
            Destroy(this.gameObject);
        }
        if (other.gameObject.tag == "Boundary")
        {
            Destroy(gameObject);
        }
        if (other.gameObject.tag == "Bullet")
        {
            if (DestroyEffect != null)
                Instantiate(DestroyEffect, this.transform.position, Quaternion.identity);

            Destroy(gameObject);
            Destroy(other.gameObject);
        }
    }
}
