using System.Collections.Generic;
using UnityEngine;

public class Gravity : MonoBehaviour {
    private List<Rigidbody> rigids;
    private float m; //��������
    private float maxForce = 250f;      //���������Ȼ��ɳ�ȥ
    public float G = 0.5f; //�������������������Ϊ10
    private Vector3 pos1, pos2;
    private float Dis; //����

    void Start() {
        //Ӱ��Ķ���
        rigids = gameObject.GetComponent<saveRigidbodys>().GetRigidbodies();
        m = gameObject.GetComponent<Rigidbody>().mass;
    }

    // Update is called once per frame
    void FixedUpdate() {
        //Ϊÿ�����嶼�������
        foreach (Rigidbody target in rigids) {
            addGravity(target);
        }
    }

    //�������
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
