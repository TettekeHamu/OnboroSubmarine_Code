using System.Collections;
using DG.Tweening;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Hamu.OnboroSubmarine
{
    /// <summary>
    /// お宝オブジェクトにアタッチするクラス
    /// </summary>
    public class TreasureManager : MonoBehaviour
    {
        /// <summary>
        /// お宝のデータ
        /// </summary>
        [SerializeField] private TreasureData treasureData;
        /// <summary>
        /// SpriteRendererコンポーネント
        /// </summary>
        [SerializeField] private SpriteRenderer spriteRenderer;
        /// <summary>
        /// 破壊されたときに再生するパーティクル
        /// </summary>
        [SerializeField] private ParticleSystem destroyParticlePrefab;
        /// <summary>
        /// スコアを管理するクラス
        /// </summary>
        private MonoScoreManager monoScoreManager;

        public int Score => treasureData.Score;

        private void Awake()
        {
            //Dotweenの警告を消す
            DOTween.SetTweensCapacity( 500, 50 );
            
            monoScoreManager = FindObjectOfType<MonoScoreManager>();
            var random = Random.Range(0, treasureData.ItemSpritesLength);
            spriteRenderer.sprite = treasureData.GetSprite(random);

            StartCoroutine(AnimeCoroutine());
        }

        /// <summary>
        /// 弾とぶつかったときの処理
        /// </summary>
        public void OnCollisionBullet()
        {
            //スコアを加算する
            monoScoreManager.AddScore(this);
            //パーティクルを出す
            var destroyParticle = Instantiate(destroyParticlePrefab, transform.position, Quaternion.identity);
            destroyParticle.Play();
            Destroy(this.gameObject);
        }

        /// <summary>
        /// お宝のアニメーションをおこなうコルーチン
        /// </summary>
        private IEnumerator AnimeCoroutine()
        {
            var localScale = transform.localScale;
            yield return transform.DOScaleX(localScale.x * 3 / 2, 1).SetLink(this.gameObject).WaitForCompletion();

            while (true)
            {
                transform.DOScaleX(localScale.x * 2 / 3, 1).SetLink(this.gameObject);
                yield return transform.DOScaleY(localScale.y * 3 /2, 1).SetLink(this.gameObject).WaitForCompletion();

                transform.DOScaleY(localScale.y * 2 / 3, 1).SetLink(this.gameObject);
                yield return transform.DOScaleX(localScale.x * 3 / 2, 1).SetLink(this.gameObject).WaitForCompletion();
            }
        }
    }
}
