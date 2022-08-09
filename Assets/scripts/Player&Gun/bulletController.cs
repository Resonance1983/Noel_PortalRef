using System.Collections.Generic;
using UnityEngine;

public class bulletController : MonoBehaviour {
    // Start is called before the first frame update
    private float timer = 0;
    public int type = 1;
    void Start() {
        gameObject.GetComponent<Rigidbody>().AddForce(transform.forward * 400);
    }

    // Update is called once per frame
    void Update() {
        timer += Time.deltaTime;
        if (timer >= 5)
            Destroy(gameObject);

    }

    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.tag == "item" || collision.gameObject.tag == "unPickItem") {
            //��ȡ��Ч����
            GameObject outCube = collision.gameObject.transform.Find("outCube").gameObject;
            //�޴�������
            if (type == 1) {
                setOutCube(outCube, "Material/hugeMassCube");
                if (!collision.gameObject.GetComponent<Gravity>()) {
                    collision.gameObject.AddComponent<Gravity>();
                    collision.gameObject.GetComponent<Rigidbody>().mass = 100;
                } else {
                    Destroy(collision.gameObject.GetComponent<Gravity>());
                    collision.gameObject.GetComponent<Rigidbody>().mass = 3;
                }
            } else if (type == 2) {    //���
                setOutCube(outCube, "Material/magneticCube");
                if (!collision.gameObject.GetComponent<Magnetic>()) {
                    collision.gameObject.AddComponent<Magnetic>();
                } else {
                    Destroy(collision.gameObject.GetComponent<Magnetic>());
                }
            } else if (type == 3) {    //��     
                setOutCube(outCube, "Material/coldCube");
            } else if (type == 4) {    //��
                setOutCube(outCube, "Material/hotCube");
            }
        }
        //��ײ�߼��������ӵ�����
        Destroy(gameObject);
    }


    private GameObject GetSubWithName(GameObject target, string name) {
        Transform[] myTransforms = target.GetComponentsInChildren<Transform>();
        foreach (var child in myTransforms) {
            if (child.name.Equals(name))
                return child.gameObject;
        }
        return null;
    }

    private void setOutCube(GameObject outCube, string matPath) {
        //��ȡ��Ч����Ĳ�������,Ŀ�����
        List<Material> materials = new List<Material>(outCube.GetComponent<MeshRenderer>().sharedMaterials);
        Material targetMat = Resources.Load<Material>(matPath);
        //���û��Ŀ����ʾͼ��ϣ�����о�ȥ��,ȥû���˾�͸����
        if (!materials.Contains(targetMat)) {
            //��������ӵ�������
            materials.Add(targetMat);
            //��ӵ��߼����������ͬʱ���־�ȫ����ʧ
            if (materials.Contains(Resources.Load<Material>("Material/coldCube")) & matPath.Equals("Material/hotCube") ||
               materials.Contains(Resources.Load<Material>("Material/hotCube")) & matPath.Equals("Material/coldCube")) {
                materials.Remove(Resources.Load<Material>("Material/coldCube"));
                materials.Remove(Resources.Load<Material>("Material/hotCube"));
            }
        } else
            materials.Remove(targetMat);
        //���ò�������
        outCube.GetComponent<MeshRenderer>().sharedMaterials = materials.ToArray();
    }
}
