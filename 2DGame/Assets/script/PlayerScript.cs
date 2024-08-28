using UnityEngine;

using System.Collections;

using System.Collections.Generic;

using UnityEngine.SceneManagement;
using Unity.VisualScripting;
public class PlayerController : MonoBehaviour

{

    //�d��

    Rigidbody2D rigidbody2D;

    //�W�����v����Ƃ��̗�

    float jumpForce = 680.0f;

    //�������̗�

    float walkForce = 30.0f;

    float maxWalkSpeed = 2.0f;

    //�A�j���[�V����

    Animator animator;

    // Start is called before the first frame update

    void Start()

    {

        this.animator = GetComponent<Animator>();
        //�t���[���J�E���g
        Application.targetFrameRate = 60;

        //Rigitbody���R���|�[�l���g

        this.rigidbody2D = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame

    void Update()

    {

        //�W�����v����

        if (Input.GetKeyDown(KeyCode.Space)&&this.rigidbody2D.velocity.y==0)

        {
            this.rigidbody2D.AddForce(transform.up * this.jumpForce);

            this.animator.SetTrigger("Jump");
        }

        //���E�Ɉړ�

        int key = 0;

        if (Input.GetKeyDown(KeyCode.RightArrow))

        {

            key = 1;

        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))

        {

            key = -1;

        }

        //�v���C���[���x

        float speedx = Mathf.Abs(this.rigidbody2D.velocity.x);

        //�X�s�[�h����

        if (speedx < this.maxWalkSpeed)

        {

            this.rigidbody2D.AddForce(transform.right * key * walkForce);

        }

        if (transform.position.y <= -20)
        {
            SceneManager.LoadScene("GameOver");
        }
        Debug.Log("GameOver");



        //���������Ŕ��]������

        //if (key != 0)

        //{

        //    transform.localScale = new Vector3(key, 1, 1);

        //}

        //if (transform.position.y < -10 || transform.position.x > -3 || transform.position.x > 3)
        //{
        //    SceneManager.LoadScene("GameScenes");
        //}
        //else if (transform.position.y > 17)
        //{
        //    this.transform.position = new Vector3(transform.position.x, 17, transform.position.z);
        //}

        //this.animator.speed = speedx / .75f;

    }


    //�S�[���ɓ��B
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag=="GOAL")
        {
            SceneManager.LoadScene("GoalScenes");
        }
        Debug.Log("Goal");
    }

}

