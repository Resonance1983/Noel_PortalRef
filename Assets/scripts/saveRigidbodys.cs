using System.Collections.Generic;
using UnityEngine;

public class saveRigidbodys : MonoBehaviour {
    [SerializeField] protected List<Rigidbody> rigidbodies = new List<Rigidbody>();
    public List<Rigidbody> GetRigidbodies() {
        return rigidbodies;
    }
}
