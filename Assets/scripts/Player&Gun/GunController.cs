using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour {
    public Transform bulletPoint;
    public GameObject bulletPre;
    [SerializeField] protected List<GameObject> bullets = new List<GameObject>();

    private float fireCd = 0.5f;
    private float timer = 0;
    public bool canFire = true;

    void Start() {

    }

    // Update is called once per frame
    void Update() {
        timer += Time.deltaTime;
        if (timer > fireCd & Input.GetMouseButton(0) & canFire) {
            timer = 0;
            Instantiate(bulletPre, bulletPoint.position, bulletPoint.rotation);
            gameObject.GetComponent<AudioSource>().Play();
        }
        if (Input.GetKeyDown(KeyCode.Alpha1)) {
            bulletPre = bullets[0];
        } else if (Input.GetKeyDown(KeyCode.Alpha2)) {
            bulletPre = bullets[1];
        } else if (Input.GetKeyDown(KeyCode.Alpha3)) {
            bulletPre = bullets[2];
        } else if (Input.GetKeyDown(KeyCode.Alpha4)) {
            bulletPre = bullets[3];
        } else if (Input.GetKeyDown(KeyCode.Alpha5)) {
            bulletPre = bullets[4];
        }
    }

    public void setCanFire(bool canFire) {
        this.canFire = canFire;
    }

}
