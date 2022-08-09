using System.Collections.Generic;
using UnityEngine;

public class cubeController : MonoBehaviour {
    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        //如果身上有冷热的材质就变一下尺寸(热胀冷缩)
        List<Material> materials = new List<Material>(gameObject.transform.Find("outCube").GetComponent<MeshRenderer>().sharedMaterials);
        if (materials.Contains(Resources.Load<Material>("Material/coldCube"))) {
            gameObject.transform.localScale = new Vector3(0.13f, 0.13f, 0.13f);
        } else if (materials.Contains(Resources.Load<Material>("Material/hotCube"))) {
            gameObject.transform.localScale = new Vector3(0.17f, 0.17f, 0.17f);
        } else
            gameObject.transform.localScale = new Vector3(0.15f, 0.15f, 0.15f);

    }
}
