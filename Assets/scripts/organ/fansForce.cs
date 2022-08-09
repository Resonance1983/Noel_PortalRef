using UnityEngine;

public class fansForce : MonoBehaviour {
    private float forceStrength = 90.0f;
    private float timeJudge = 2f;
    private float timer = 0.0f;
    private bool isOut = false;

    //如果在外面呆的时间超过两秒就判定为过关
    private void Update() {
        if(isOut)
            timer += Time.deltaTime;

        //Debug.Log(timer);
    }

    private void OnTriggerEnter(Collider other) {
        if(other.tag.Equals("item")){ 
            Rigidbody otherRigid = other.gameObject.GetComponent<Rigidbody>();
            otherRigid.AddForce(new Vector3(0, 2 * forceStrength, 0));
            otherRigid.freezeRotation = true;
            isOut = false;
            timer = 0.0f;
        }
    }

    private void OnTriggerStay(Collider other) {
        if (other.tag.Equals("item")) { 
            Rigidbody otherRigid = other.gameObject.GetComponent<Rigidbody>();
            otherRigid.AddForce(new Vector3(0, forceStrength, 0));
        }   
    }
    private void OnTriggerExit(Collider other) {
        if (other.tag.Equals("item")){ 
            Rigidbody otherRigid = other.gameObject.GetComponent<Rigidbody>();
            otherRigid.freezeRotation = false;
            isOut = true;
        }
            
    }

    public bool getIsPass() {
        if (isOut & timer >= timeJudge)
            return true;
        else
            return false;
    }
}
