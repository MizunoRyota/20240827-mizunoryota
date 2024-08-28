using UnityEngine;

using System.Collections;

using System.Collections.Generic;

using UnityEngine.SceneManagement;
using Unity.VisualScripting;
public class PlayerController : MonoBehaviour

{

    //重力

    Rigidbody2D rigidbody2D;

    //ジャンプするときの力

    float jumpForce = 680.0f;

    //歩く時の力

    float walkForce = 30.0f;

    float maxWalkSpeed = 2.0f;

    //アニメーション

    Animator animator;

    // Start is called before the first frame update

    void Start()

    {

        this.animator = GetComponent<Animator>();
        //フレームカウント
        Application.targetFrameRate = 60;

        //Rigitbodyをコンポーネント

        this.rigidbody2D = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame

    void Update()

    {

        //ジャンプする

        if (Input.GetKeyDown(KeyCode.Space)&&this.rigidbody2D.velocity.y==0)

        {
            this.rigidbody2D.AddForce(transform.up * this.jumpForce);

            this.animator.SetTrigger("Jump");
        }

        //左右に移動

        int key = 0;

        if (Input.GetKeyDown(KeyCode.RightArrow))

        {

            key = 1;

        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))

        {

            key = -1;

        }

        //プレイヤー速度

        float speedx = Mathf.Abs(this.rigidbody2D.velocity.x);

        //スピード制限

        if (speedx < this.maxWalkSpeed)

        {

            this.rigidbody2D.AddForce(transform.right * key * walkForce);

        }

        if (transform.position.y <= -20)
        {
            SceneManager.LoadScene("GameOver");
        }
        Debug.Log("GameOver");



        //動く方向で反転させる

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


    //ゴールに到達
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag=="GOAL")
        {
            SceneManager.LoadScene("GoalScenes");
        }
        Debug.Log("Goal");
    }

}

