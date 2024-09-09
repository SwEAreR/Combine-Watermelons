using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FruitCompose : MonoBehaviour
{
    private bool IsTrigger = true;
    public int level;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(Mathf.Abs(this.gameObject.GetComponent<Rigidbody2D>().velocity.y) != 0 && collision.gameObject.name == "Floor")
        {
            AudioManager.Instance.PlayAudio(AudioManager.Instance.AudioClips[1]);
        }
        if (collision.gameObject.tag == "fruit" && PlayerManager.Instance.ReadyFruit != this.gameObject)
        {
            if(this.level == collision.gameObject.GetComponent<FruitCompose>().level)
            {
                if (this.gameObject.GetInstanceID() > collision.gameObject.GetInstanceID())
                {
                    //合成
                    GameObject prefab = PlayerManager.Instance.FruitPreFabs[level];
                    if(this.level <= 6)
                    {
                        PlayerManager.Instance.MaxRange = level;
                    }
                    GameObject fruit = Instantiate(prefab);
                    fruit.transform.position = this.gameObject.transform .position;
                    UIManager.Instance.Score += this.level * 2;
                    AudioManager.Instance.PlayAudio(AudioManager.Instance.AudioClips[0]);
                    Destroy(this.gameObject);
                    Destroy(collision.gameObject);
                }
            }
            else
            {
                if (Mathf.Abs(this.gameObject.GetComponent<Rigidbody2D>().velocity.y) > 0.8f)
                {
                    AudioManager.Instance.PlayAudio(AudioManager.Instance.AudioClips[1]);
                }
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (IsTrigger == false && PlayerManager.Instance.ReadyFruit != this.gameObject && collision.gameObject.name == "Dead Line")
        {
            SceneManager.LoadScene("Combine-Watermelons");
        }
        else if(collision.gameObject.name == "Dead Line" && IsTrigger == true)
        {
            IsTrigger = false;
        }
    }
}
