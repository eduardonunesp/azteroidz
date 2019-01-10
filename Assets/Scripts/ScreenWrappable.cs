using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenWrappable : MonoBehaviour
{
  protected enum WrapDirection
  {
    WRAP_LEFT,
    WRAP_RIGHT,
    WRAP_TOP,
    WRAP_BOTTOM
  };

  protected bool isWrapping = false;
  protected float padding = 0.5f;
  protected float xMin;
  protected float xMax;
  protected float yMin;
  protected float yMax;

  protected void ActiveIsWrapping()
  {
    isWrapping = true;
  }

  protected void CheckWraping()
  {
    if (transform.position.x < xMin)
    {
      WrapScreenDirection(WrapDirection.WRAP_LEFT, -transform.position.x);
    }
    else if (transform.position.x > xMax)
    {
      WrapScreenDirection(WrapDirection.WRAP_RIGHT, -transform.position.x);
    }
    else if (transform.position.y > yMax)
    {
      WrapScreenDirection(WrapDirection.WRAP_TOP, -transform.position.y);
    }
    else if (transform.position.y < yMin)
    {
      WrapScreenDirection(WrapDirection.WRAP_BOTTOM, -transform.position.y);
    }
    else
    {
      isWrapping = false;
    }
  }

  protected virtual void WrapScreenDirection(WrapDirection wrapDirection, float counterDir) { }

  protected void SetUpMoveBoundaries()
  {
    Camera gameCamera = Camera.main;
    xMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x;
    xMax = gameCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x;
    yMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).y;
    yMax = gameCamera.ViewportToWorldPoint(new Vector3(0, 1, 0)).y;
  }
}
