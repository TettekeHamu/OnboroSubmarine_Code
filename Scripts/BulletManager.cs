using System;
using System.Collections;
using UnityEngine;

namespace Hamu.OnboroSubmarine
{
    /// <summary>
    /// 弾を管理するクラス
    /// </summary>
    public class BulletManager : MonoBehaviour
    {
        /// <summary>
        /// 物理を管理するコンポーネント
        /// </summary>
        [SerializeField] private Rigidbody2D rb2D;
        /// <summary>
        /// 移動スピード
        /// </summary>
        [SerializeField] private float speed;

        private void Awake()
        {
            StartCoroutine(DestroyCoroutine());
        }

        private void FixedUpdate()
        {
            rb2D.velocity = transform.up.normalized * speed;
        }

        //弾を破棄する処理
        private IEnumerator DestroyCoroutine()
        {
            yield return new WaitForSeconds(1.5f);
            Destroy(this.gameObject);
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            //ぶつかった相手がお宝か判別する
            var treasure = col.gameObject.GetComponent<TreasureManager>();
            if (treasure != null)
            {
                treasure.OnCollisionBullet();
                Destroy(this.gameObject);
            }
        }
    }
}
