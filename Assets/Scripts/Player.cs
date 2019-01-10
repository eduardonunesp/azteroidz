using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : ScreenWrappable
{
  public float speed = 200f;
  public float rotateSpeed = 200f;
  public GameObject bullet;

  private Rigidbody2D rb2D;
  private Vector3 axisMove;
  private Vector3 opposeAxisMove;

  private void Awake()
  {
    rb2D = GetComponent<Rigidbody2D>();
    axisMove = new Vector3(0f, 0f, 0f);
    opposeAxisMove = new Vector3(0f, 0f, 0f);
    SetUpMoveBoundaries();
  }

  protected override void WrapScreenDirection(WrapDirection wrapDirection, float counterDir)
  {
    if (!isWrapping)
    {
      switch (wrapDirection)
      {
        case WrapDirection.WRAP_LEFT:
          opposeAxisMove.x = counterDir;
          opposeAxisMove.y = transform.position.y;
          break;
        case WrapDirection.WRAP_RIGHT:
          opposeAxisMove.x = counterDir;
          opposeAxisMove.y = transform.position.y;
          break;
        case WrapDirection.WRAP_TOP:
          opposeAxisMove.y = counterDir;
          opposeAxisMove.x = transform.position.x;
          break;
        case WrapDirection.WRAP_BOTTOM:
          opposeAxisMove.y = counterDir;
          opposeAxisMove.x = transform.position.x;
          break;
      }

      Player playerWrapped = Instantiate(this, opposeAxisMove, transform.rotation);
      playerWrapped.isWrapping = true;
      isWrapping = true;
      playerWrapped.rb2D.velocity = rb2D.velocity;
      playerWrapped.name = name;
      Destroy(gameObject, 0.5f);
    }
  }

  private void Update()
  {
    axisMove.z = -Input.GetAxis("Horizontal") * Time.deltaTime * rotateSpeed;
    transform.Rotate(axisMove);

    float verticalInput = Input.GetAxis("Vertical");
    if (verticalInput > 0f)
    {
      if (rb2D.velocity.x < 5f)
      {
        rb2D.AddForce(transform.up * verticalInput * 1f);
      }
    }

    if (Input.GetButtonDown("Fire1"))
    {
      Instantiate(bullet, transform.position, transform.rotation);
    }

    CheckWraping();
  }
}
