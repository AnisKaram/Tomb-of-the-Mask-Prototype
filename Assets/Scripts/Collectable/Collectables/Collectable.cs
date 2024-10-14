using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Collectable : MonoBehaviour
{
    public delegate void ShakeCameraOnCollision();
    public static event ShakeCameraOnCollision CollectableCollided;

    public virtual void Collect(int amount) { }
    public virtual void DestroyObject() { Destroy(this.gameObject); }
    public virtual void ShakeCamera() { CollectableCollided?.Invoke(); }
}
