using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserShot : MonoBehaviour
{
    // Start is called before the first frame update
    public LaserShotContainer laserShot;
    private void FixedUpdate()
    {
        transform.position += new Vector3(0, laserShot.speed, 0) * Time.fixedDeltaTime;
        if (transform.position.y >= ScreenSizeInfo.ScreenHeight-1.5f)
            Destroy(this.gameObject);
    }
}
