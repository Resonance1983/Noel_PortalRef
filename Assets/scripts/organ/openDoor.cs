using UnityEngine;

//脚本只要挂载在会产生isPass的物体上，public放上要开的门就可以了
public class openDoor : MonoBehaviour {
    public GameObject door;
    public string scriptName;
    private bool isPass = false;
    private bool isOpen = false;

    private void Update() {
        MonoBehaviour[] monos = gameObject.GetComponents<MonoBehaviour>();
        for (int i = 0; i < monos.Length; i++) {
            //筛选出其中符合名字的脚本
            if (monos[i].GetType().ToString().Equals(scriptName)) {
                //获取isPass字段的值
                isPass = (bool)monos[i].GetType().GetMethod("getIsPass").Invoke(monos[i], null);
                break;
            }
        }

        //isPass = gameObject.GetComponent<circuitOrgan>().getIsPass();

        if (isPass & !isOpen) {
            Debug.Log(isPass);
            isOpen = true;
            door.GetComponent<Animator>().SetBool("organPass", true);
        }
    }


}
