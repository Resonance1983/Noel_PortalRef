using UnityEngine;
using UnityEngine.SceneManagement;

public class pickUp : MonoBehaviour {
    private float detectDist = 4f;
    //private float forceNum = 200f;
    private bool isPicked = false;
    private GameObject pickedObject = null;


    // Update is called once per frame                                                                             
    void Update() {
        if (Input.GetKeyDown(KeyCode.E)) {
            if (isPicked && pickedObject != null) {
                Debug.Log("throw out");
                pickedObject.GetComponent<Rigidbody>().freezeRotation = false;
                pickedObject = null;
                isPicked = false;
            } else {
                //�����E������û�ж����ͼ��,����
                Ray ray = new Ray(transform.position, transform.forward);
                RaycastHit hit;
                //���������ڼ��item��ǩ����,����оͿ��Լ�����
                if (Physics.Raycast(ray, out hit, detectDist)) {
                    if (hit.collider.gameObject.CompareTag("item")) {
                        GameObject item = hit.collider.gameObject;
                        Debug.Log("pick up");
                        item.GetComponent<Rigidbody>().freezeRotation = true;
                        pickedObject = item;
                        isPicked = true;
                    }
                }
            }

        } else {
            if (isPicked && pickedObject != null) {
                //item�������,ʼ������ǰ��λ��
                pickedObject.transform.position = gameObject.transform.position + gameObject.transform.forward * 2.5f;
                pickedObject.GetComponent<Rigidbody>().freezeRotation = true;
                //�����ʱ���ܿ���
                gameObject.transform.Find("NoelGun").GetComponent<GunController>().canFire = false;
            } else {
                gameObject.transform.Find("NoelGun").GetComponent<GunController>().canFire = true;
            }
        }

        //����һ��R�����¿�ʼ�Ĺ���
        if (Input.GetKeyDown(KeyCode.R)) {
            SceneManager.LoadScene("SampleScene");
            //GameObject.Find("Flowchart").gameObject.SetActive(false);
        }

    }
}
