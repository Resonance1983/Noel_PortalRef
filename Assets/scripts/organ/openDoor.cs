using UnityEngine;

//�ű�ֻҪ�����ڻ����isPass�������ϣ�public����Ҫ�����žͿ�����
public class openDoor : MonoBehaviour {
    public GameObject door;
    public string scriptName;
    private bool isPass = false;
    private bool isOpen = false;

    private void Update() {
        MonoBehaviour[] monos = gameObject.GetComponents<MonoBehaviour>();
        for (int i = 0; i < monos.Length; i++) {
            //ɸѡ�����з������ֵĽű�
            if (monos[i].GetType().ToString().Equals(scriptName)) {
                //��ȡisPass�ֶε�ֵ
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
