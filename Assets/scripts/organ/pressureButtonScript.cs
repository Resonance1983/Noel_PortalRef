using UnityEngine;

public class pressureButtonScript : MonoBehaviour {

    private bool isPass = false;
    public float trigeMass = 50.0f;
    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }

    private void OnCollisionEnter(Collision collision) {
        Animator buttonAnimator = gameObject.GetComponent<Animator>();
        string tag = collision.gameObject.tag;
        if (tag.Equals("item") || tag.Equals("Player")) {
            if (collision.gameObject.GetComponent<Rigidbody>().mass > trigeMass) {
                buttonAnimator.SetBool("isTrige", true);
                isPass = true;
            }
        }
    }

    private void OnCollisionStay(Collision collision) {
        Animator buttonAnimator = gameObject.GetComponent<Animator>();
        string tag = collision.gameObject.tag;
        if (tag.Equals("item") || tag.Equals("Player")) {
            if (collision.gameObject.GetComponent<Rigidbody>().mass > trigeMass) {
                buttonAnimator.SetBool("isTrige", true);
                isPass = true;
            } else {
                buttonAnimator.SetBool("isTrige", false);
                isPass = false;
            }
        }
    }

    private void OnCollisionExit(Collision collision) {
        Animator buttonAnimator = gameObject.GetComponent<Animator>();
        string tag = collision.gameObject.tag;
        if (tag.Equals("item") || tag.Equals("Player")) {
            if (collision.gameObject.GetComponent<Rigidbody>().mass > trigeMass) {
                buttonAnimator.SetBool("isTrige", false);
                isPass = false;
            }
        }
    }

    public bool getIsPass() {
        return isPass;
    }
}
