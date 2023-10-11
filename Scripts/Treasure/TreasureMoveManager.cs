using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Hamu.OnboroSubmarine
{
    /// <summary>
    /// お宝を動かすスクリプト
    /// </summary>
    public class TreasureMoveManager : MonoBehaviour
    {
        /// <summary>
        /// 物理演算用のコンポーネント
        /// </summary>
        [SerializeField] private Rigidbody2D rb2D;
        
        private void Awake()
        {
            StartCoroutine(MoveCoroutine());
        }

        /// <summary>
        /// 移動をおこなうコルーチン
        /// </summary>
        /// <returns></returns>
        private IEnumerator MoveCoroutine()
        {
            while (true)
            {
                //動かす→止まる→動かすを繰り返す
                //範囲外に出た際は中心に戻す
                if (-75 < transform.position.x && transform.position.x < 75 
                    && -75 < transform.position.y && transform.position.y < 75)
                {
                    var angle = Random.Range(0f, 360f);
                    var rad = angle * Mathf.Deg2Rad;
                    var y = Mathf.Sin(rad);
                    var x = Mathf.Cos(rad);
                    var vec2 = new Vector2(x, y).normalized;
                    rb2D.velocity = vec2 * 15f;   
                }
                else
                {
                    var vec3 = Vector3.zero - transform.position;
                    var nVec3 = vec3.normalized;
                    rb2D.velocity = nVec3 * 15f;
                }

                yield return new WaitForSeconds(5f);
                
                rb2D.velocity = Vector2.zero;
                
                yield return new WaitForSeconds(5f);
            }
        }
    }
}
