using System.Collections.Generic;
using UnityEngine;

public class pressureBrokenOrgan : MonoBehaviour {
    //true��������������Ҫ��ģ�false����û��Ҫ���������
    public bool isMass = true;
    public bool isMagnetic = true;
    public bool isHot = false;
    private GameObject cube1, cube2;
    private Material massMat, magneticMat, hotMat;
    private List<Material> cubeAMaterials, cubeBMaterials;
    private bool result = true;
    private bool isPass = false;

    private void Start() {

    }

    private void Update() {
        //��ȡ���صĸı�����
        cube1 = transform.Find("cube1").gameObject;
        cube2 = transform.Find("cube2").gameObject;
        //��ȡ���ֲ���
        Material massMat = Resources.Load<Material>("Material/hugeMassCube");
        Material magneticMat = Resources.Load<Material>("Material/magneticCube");
        Material hotMat = Resources.Load<Material>("Material/hotCube");
        //��ȡ���ǵĲ�������
        List<Material> cubeAMaterials = new List<Material>(cube1.transform.Find("outCube").GetComponent<MeshRenderer>().sharedMaterials);
        List<Material> cubeBMaterials = new List<Material>(cube2.transform.Find("outCube").GetComponent<MeshRenderer>().sharedMaterials);
        //�ж��������ط����Ƿ�����Щ����,�ǵ�����Ϊtrue�������ж�
        result = true;
        if (isMass) {
            //ֻ����cube2��������Ǹ�����
            if (!cubeBMaterials.Contains(massMat) || cubeAMaterials.Contains(massMat)) {
                //Debug.Log("lack mass");
                result = false;
            }
        }
        if (isMagnetic) {
            if (!cubeAMaterials.Contains(magneticMat) || !cubeBMaterials.Contains(magneticMat)) {
                //Debug.Log("lack magnetic");
                result = false;
            }
        }
        if (isHot) {
            if (!cubeAMaterials.Contains(hotMat) || !cubeBMaterials.Contains(hotMat)) {
                result = false;
            }
        }
        //Debug.Log(result);
        //������Ͻ�����۶ϣ���ʧ��ľͷ
        if (result) {
            isPass = true;
            gameObject.transform.Find("wood").gameObject.SetActive(false);
            //cube2.SetActive(false);
            cube1.GetComponent<Rigidbody>().freezeRotation = false;
        }

    }
}
