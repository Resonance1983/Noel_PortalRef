using System.Collections.Generic;
using UnityEngine;

public class Magnetic : MonoBehaviour {
    //实现逻辑和引力类似，但要求双方都有磁力才可以吸引
    private List<Rigidbody> rigids;
    private float m; //物体质量
    private float maxForce = 1000f;      //最大力，不然会飞出去
    public float G = 80.0f; //引力常量
    private Vector3 pos1, pos2;
    private float Dis; //距离

    void Start() {
        //影响的对象
        rigids = gameObject.GetComponent<saveRigidbodys>().GetRigidbodies();
        m = gameObject.GetComponent<Rigidbody>().mass;
    }

    // Update is called once per frame
    void FixedUpdate() {
        //为每个物体都添加磁力
        foreach (Rigidbody target in rigids) {
            addMagnetic(target);
        }
    }

    //添加磁力,需要双方都有磁力状态
    private void addMagnetic(Rigidbody target) {
        if (target.GetComponent<Magnetic>()) {
            pos1 = gameObject.transform.position;
            pos2 = target.gameObject.transform.position;
            Dis = (pos1 - pos2).magnitude;
            float F = G * m * target.mass / (Dis * Dis);
            Vector3 vec = pos1 - pos2;
            if (F >= maxForce) F = maxForce;
            target.AddForce(vec.normalized * F);
            Debug.Log(F);
        }
    }
}
