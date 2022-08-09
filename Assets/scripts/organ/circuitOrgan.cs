using System.Collections.Generic;
using UnityEngine;

public class circuitOrgan : MonoBehaviour {
    //true��������������Ҫ��ģ�false����û��Ҫ���������
    public bool noMass = true;
    public bool noMagnetic = true;
    public bool noCold = true;
    public bool isHot = true;
    private GameObject resCube, wire1, wire2, noticeLight;
    private List<Material> cubeMaterials;
    private bool result = true;
    private bool isPass = false;

    private void Update() {
        //��ȡ���ֲ��ʺ�resCube�Ĳ�������
        Material massMat = Resources.Load<Material>("Material/hugeMassCube");
        Material magneticMat = Resources.Load<Material>("Material/magneticCube");
        Material hotMat = Resources.Load<Material>("Material/hotCube");
        Material coldMat = Resources.Load<Material>("Material/coldCube");
        resCube = gameObject.transform.Find("resCube").gameObject;
        wire1 = gameObject.transform.Find("wire1").gameObject;
        wire2 = gameObject.transform.Find("wire2").gameObject;
        noticeLight = gameObject.transform.Find("noticeLight").gameObject;
        List<Material> cubeMaterials = new List<Material>(resCube.transform.Find("outCube").GetComponent<MeshRenderer>().sharedMaterials);

        //�ж��Ƿ��������,�ǵ�����result
        result = true;
        if (noMass) {
            if (cubeMaterials.Contains(massMat)) {
                result = false;
            }
        }
        if (noMagnetic) {
            if (cubeMaterials.Contains(magneticMat)) {
                result = false;
            }
        }
        if (isHot) {
            if (!cubeMaterials.Contains(hotMat)) {
                result = false;
            }
        }
        if (noCold) {
            if (cubeMaterials.Contains(coldMat)) {
                result = false;
            }
        }

        //���ܷ������϶�Ҫ���ָ���Ĳ���
        if (result) {
            //���� -> �ƻƺ�.pass
            changeGameObjectFirstMat(wire1, magneticMat);
            changeGameObjectFirstMat(wire2, magneticMat);
            changeGameObjectFirstMat(noticeLight, hotMat);
            isPass = true;
        } else {
            //������ȫ���������
            changeGameObjectFirstMat(wire1, coldMat);
            changeGameObjectFirstMat(wire2, coldMat);
            changeGameObjectFirstMat(noticeLight, coldMat);
        }

    }

    private void changeGameObjectFirstMat(GameObject target, Material mat) {
        List<Material> materials = new List<Material>(target.GetComponent<MeshRenderer>().sharedMaterials);
        materials.RemoveAt(0);
        materials.Add(mat);
        target.GetComponent<MeshRenderer>().sharedMaterials = materials.ToArray();
    }

    public bool getIsPass() {
        return isPass;
    }

}
