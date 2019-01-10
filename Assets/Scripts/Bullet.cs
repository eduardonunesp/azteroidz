using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
  public float speed;
  public float lifeTime;

  private Collider2D bulletCollider2D;

  private void Awake()
  {
    bulletCollider2D = GetComponent<Collider2D>();
    Invoke("DestroyProjectile", lifeTime);
  }

  private void Update()
  {
    transform.Translate(Vector2.up * speed * Time.deltaTime);
  }

  void DestroyProjectile()
  {
    Destroy(gameObject);
  }
}
