using System.Collections.Generic;
using UnityEngine;

public class Gravity : MonoBehaviour {
    private List<Rigidbody> rigids;
    private float m; //物体质量
    private float maxForce = 250f;      //最大力，不然会飞出去
    public float G = 0.5f; //引力常量，电磁力设置为10
    private Vector3 pos1, pos2;
    private float Dis; //距离

    void Start() {
        //影响的对象
        rigids = gameObject.GetComponent<saveRigidbodys>().GetRigidbodies();
        m = gameObject.GetComponent<Rigidbody>().mass;
    }

    // Update is called once per frame
    void FixedUpdate() {
        //为每个物体都添加引力
        foreach (Rigidbody target in rigids) {
            addGravity(target);
        }
    }

    //添加引力
    private void addGravity(Rigidbody target) {
        pos1 = gameObject.transform.position;
        pos2 = target.gameObject.transform.position;
        Dis = (pos1 - pos2).magnitude;
        float F = G * m * target.mass / (Dis * Dis);
        Vector3 vec = pos1 - pos2;
        if (F >= maxForce) F = maxForce;
        target.AddForce(vec.normalized * F);
        //Debug.Log(F);
    }
}
