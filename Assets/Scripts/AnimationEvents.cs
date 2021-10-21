using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationEvents : MonoBehaviour
{
    public GameObject explo;
    public AudioSource exploSound;
    public void Explode()
    {
        exploSound.pitch = Random.Range(0.7f, 1.3f);
        exploSound.Play();
        for(int i = 1; i <= 20; i++)
        {
            Vector3 rand = new Vector3(Random.Range(-2, 2), Random.Range(0, 2), Random.Range(-2, 2));
            GameObject yeet = Instantiate(explo, transform.position + rand, Quaternion.identity);
            yeet.GetComponent<Rigidbody>().velocity += rand.normalized * 2;
        }
    }
    public void Deactivate() => gameObject.SetActive(false);
}
