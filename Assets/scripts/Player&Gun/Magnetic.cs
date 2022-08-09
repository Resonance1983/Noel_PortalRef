using System.Collections.Generic;
using UnityEngine;

public class Magnetic : MonoBehaviour {
    //ʵ���߼����������ƣ���Ҫ��˫�����д����ſ�������
    private List<Rigidbody> rigids;
    private float m; //��������
    private float maxForce = 1000f;      //���������Ȼ��ɳ�ȥ
    public float G = 80.0f; //��������
    private Vector3 pos1, pos2;
    private float Dis; //����

    void Start() {
        //Ӱ��Ķ���
        rigids = gameObject.GetComponent<saveRigidbodys>().GetRigidbodies();
        m = gameObject.GetComponent<Rigidbody>().mass;
    }

    // Update is called once per frame
    void FixedUpdate() {
        //Ϊÿ�����嶼��Ӵ���
        foreach (Rigidbody target in rigids) {
            addMagnetic(target);
        }
    }

    //��Ӵ���,��Ҫ˫�����д���״̬
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
