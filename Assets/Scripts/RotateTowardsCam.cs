using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateTowardsCam : MonoBehaviour
{
    private void Update() => transform.LookAt(Camera.main.transform);
    public void Destroy() => Destroy(gameObject);
}
