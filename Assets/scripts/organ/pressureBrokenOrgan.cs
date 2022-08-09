using System.Collections.Generic;
using UnityEngine;

public class pressureBrokenOrgan : MonoBehaviour {
    //true代表对于这个是有要求的，false就是没有要求跳过检查
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
        //获取机关的改变物体
        cube1 = transform.Find("cube1").gameObject;
        cube2 = transform.Find("cube2").gameObject;
        //获取三种材质
        Material massMat = Resources.Load<Material>("Material/hugeMassCube");
        Material magneticMat = Resources.Load<Material>("Material/magneticCube");
        Material hotMat = Resources.Load<Material>("Material/hotCube");
        //获取它们的材质序列
        List<Material> cubeAMaterials = new List<Material>(cube1.transform.Find("outCube").GetComponent<MeshRenderer>().sharedMaterials);
        List<Material> cubeBMaterials = new List<Material>(cube2.transform.Find("outCube").GetComponent<MeshRenderer>().sharedMaterials);
        //判断两个机关方块是否都有这些材质,记得重置为true再重新判断
        result = true;
        if (isMass) {
            //只能是cube2（下面的那个）有
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
        //如果符合结果就折断（消失）木头
        if (result) {
            isPass = true;
            gameObject.transform.Find("wood").gameObject.SetActive(false);
            //cube2.SetActive(false);
            cube1.GetComponent<Rigidbody>().freezeRotation = false;
        }

    }
}
