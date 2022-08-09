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
            //获取特效方块
            GameObject outCube = collision.gameObject.transform.Find("outCube").gameObject;
            //巨大质量弹
            if (type == 1) {
                setOutCube(outCube, "Material/hugeMassCube");
                if (!collision.gameObject.GetComponent<Gravity>()) {
                    collision.gameObject.AddComponent<Gravity>();
                    collision.gameObject.GetComponent<Rigidbody>().mass = 100;
                } else {
                    Destroy(collision.gameObject.GetComponent<Gravity>());
                    collision.gameObject.GetComponent<Rigidbody>().mass = 3;
                }
            } else if (type == 2) {    //电磁
                setOutCube(outCube, "Material/magneticCube");
                if (!collision.gameObject.GetComponent<Magnetic>()) {
                    collision.gameObject.AddComponent<Magnetic>();
                } else {
                    Destroy(collision.gameObject.GetComponent<Magnetic>());
                }
            } else if (type == 3) {    //冷     
                setOutCube(outCube, "Material/coldCube");
            } else if (type == 4) {    //热
                setOutCube(outCube, "Material/hotCube");
            }
        }
        //碰撞逻辑结束后子弹销毁
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
        //获取特效方块的材质序列,目标材质
        List<Material> materials = new List<Material>(outCube.GetComponent<MeshRenderer>().sharedMaterials);
        Material targetMat = Resources.Load<Material>(matPath);
        //如果没有目标材质就加上，如果有就去掉,去没有了就透明了
        if (!materials.Contains(targetMat)) {
            //将材质添加到序列上
            materials.Add(targetMat);
            //添加的逻辑中冷热如果同时出现就全部消失
            if (materials.Contains(Resources.Load<Material>("Material/coldCube")) & matPath.Equals("Material/hotCube") ||
               materials.Contains(Resources.Load<Material>("Material/hotCube")) & matPath.Equals("Material/coldCube")) {
                materials.Remove(Resources.Load<Material>("Material/coldCube"));
                materials.Remove(Resources.Load<Material>("Material/hotCube"));
            }
        } else
            materials.Remove(targetMat);
        //设置材质序列
        outCube.GetComponent<MeshRenderer>().sharedMaterials = materials.ToArray();
    }
}
