using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public CharacterController CharacterController;
    public Animator animator;
    public Transform Cam;
    public float speed;

    private void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float Vertical = Input.GetAxis("Vertical");

        float turnSVel = 0;
        Vector3 direction = new Vector3(horizontal, 0, Vertical).normalized;

        if (direction.magnitude >= .1f)
        {

            float tarAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + Cam.eulerAngles.y;

            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, tarAngle, ref turnSVel, .06f);
            transform.rotation = Quaternion.Euler(0, angle, 0);

            Vector3 moveDir = Quaternion.Euler(0, tarAngle, 0) * Vector3.forward;
            CharacterController.Move(moveDir.normalized * speed * Time.deltaTime);


            animator.SetBool("walk", true);
        }
        else
        {
            animator.SetBool("walk", false);
        }
    }
}
