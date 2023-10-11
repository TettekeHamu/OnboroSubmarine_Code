using System.Collections;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace Hamu.OnboroSubmarine
{
    /// <summary>
    /// スコアを表示するUIの管理クラス
    /// </summary>
    public class ScoreUIManager : MonoBehaviour
    {
        /// <summary>
        /// スコアを表示するキャンバス
        /// </summary>
        [SerializeField] private Canvas canvas;
        /// <summary>
        /// スコアを表示するText
        /// </summary>
        [SerializeField] private Text scoreText;
        /// <summary>
        /// 得点時ポップアップするTextのPrefab
        /// </summary>
        [SerializeField] private Text popupTextPrefab;

        /// <summary>
        /// スコアを表示するTextを更新する処理
        /// </summary>
        /// <param name="scoreManager">スコアを持つクラス</param>
        public void UpdateScoreUI(ScoreManager scoreManager)
        {
            StartCoroutine(PopupTextCoroutine(scoreManager.AddScore));
            scoreText.text = "スコア：" + scoreManager.TotalScore.ToString();
        }

        /// <summary>
        /// テキストをポップアップさせるコルーチン
        /// </summary>
        private IEnumerator PopupTextCoroutine(int score)
        {
            //０以下なら表示しない
            if (score <= 0) yield break;
            //生成場所を決める
            var randomX = Random.Range(730, 840);
            var createPos = new Vector2(randomX, 372);
            //生成
            var popupText = Instantiate(popupTextPrefab,createPos,Quaternion.identity);
            popupText.transform.SetParent(canvas.transform);
            popupText.text = "+" + score.ToString();
            //アニメーションさせる
            yield return popupText.transform.DOMoveY(popupText.transform.position.y + 50, 0.5f)
                                            .WaitForCompletion();
            //破棄する
            Destroy(popupText);
        }
    }
}
