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
                //如果按E且手上没有东西就检测,捡东西
                Ray ray = new Ray(transform.position, transform.forward);
                RaycastHit hit;
                //检测距离以内检测item标签物体,如果有就可以捡起来
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
                //item物体跟随,始终在身前的位置
                pickedObject.transform.position = gameObject.transform.position + gameObject.transform.forward * 2.5f;
                pickedObject.GetComponent<Rigidbody>().freezeRotation = true;
                //拿起的时候不能开火
                gameObject.transform.Find("NoelGun").GetComponent<GunController>().canFire = false;
            } else {
                gameObject.transform.Find("NoelGun").GetComponent<GunController>().canFire = true;
            }
        }

        //附带一个R键重新开始的功能
        if (Input.GetKeyDown(KeyCode.R)) {
            SceneManager.LoadScene("SampleScene");
            //GameObject.Find("Flowchart").gameObject.SetActive(false);
        }

    }
}
