using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DestroyAfterAnimation());
    }
    IEnumerator DestroyAfterAnimation()
    {
        yield return new WaitForSeconds(1f);
        Destroy(this.gameObject);
    }
}
