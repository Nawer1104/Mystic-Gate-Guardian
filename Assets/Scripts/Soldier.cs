using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soldier : MonoBehaviour
{
    public float speed;

    public int damage;

    public GameObject vfxAttack;

    private void Start()
    {
        damage = GameManager.Instance.soldierDamage;
    }

    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, Boss.Instance.transform.position, speed * Time.deltaTime);

        damage = GameManager.Instance.soldierDamage;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null && collision.gameObject.CompareTag("Boss"))
        {
            GameObject vfx = Instantiate(vfxAttack, transform.position, Quaternion.identity) as GameObject;

            Destroy(vfx, 1f);

            GameManager.Instance.coin += damage;

            collision.gameObject.GetComponent<Boss>().TakeDamage(damage);

            Destroy(gameObject);
        }
    }
}
