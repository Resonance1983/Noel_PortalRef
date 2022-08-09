using Fungus;
using UnityEngine;

public class fungusDialogTrig : MonoBehaviour {
    public float radius = 8f;
    public bool isGlados = false;
    public string chatNmae;
    // Start is called before the first frame update
    //private void OnTriggerStay(Collider other) {
    //    if (other.gameObject.tag.Equals("Player") & Input.GetKeyDown(KeyCode.F) & !isGlados) {
    //        Flowchart flowchart = GameObject.Find("Flowchart").GetComponent<Flowchart>();
    //        if (flowchart.HasBlock(chatNmae)) {
    //            flowchart.ExecuteBlock(chatNmae);
    //        }
    //    }
    //}
    private void Update() {
        GameObject player = GameObject.Find("Player");
        float dis = (transform.position - player.GetComponent<Transform>().position).sqrMagnitude;
        if(dis<=radius & Input.GetKeyDown(KeyCode.F) & !isGlados){
            Flowchart flowchart = GameObject.Find("Flowchart").GetComponent<Flowchart>();
            if (flowchart.HasBlock(chatNmae)) {
                flowchart.ExecuteBlock(chatNmae);
            }
        }
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag.Equals("Player") && isGlados) {
            Flowchart flowchart = GameObject.Find("Flowchart").GetComponent<Flowchart>();
            if (flowchart.HasBlock(chatNmae)) {
                flowchart.ExecuteBlock(chatNmae);
            }
        }
    }
}
