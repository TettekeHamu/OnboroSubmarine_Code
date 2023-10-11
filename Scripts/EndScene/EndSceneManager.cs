using System.Collections;
using naichilab.EasySoundPlayer.Scripts;
using UnityEngine;

namespace Hamu.OnboroSubmarine
{
    /// <summary>
    /// Endシーンの管理クラス
    /// </summary>
    public class EndSceneManager : MonoBehaviour
    {
        /// <summary>
        /// UIを管理するクラス
        /// </summary>
        [SerializeField] private EndUIManager uiManager;
        /// <summary>
        /// 総スコア
        /// </summary>
        private int totalScore;

        private void Awake()
        {
            totalScore = 0;
            totalScore = PlayerPrefs.GetInt("TotalScore");
            StartCoroutine(EndDirectionCoroutine());
        }

        /// <summary>
        /// ゲーム終了時の演出をおこなうコルーチン
        /// </summary>
        /// <returns></returns>
        private IEnumerator EndDirectionCoroutine()
        {
            yield return new WaitForSeconds(2f);
            
            SePlayer.Instance.Play("SE_GameEnd");
            uiManager.ShowTotalScore(totalScore);

            yield return new WaitForSeconds(0.5f);
            
            SePlayer.Instance.Play("SE_GameEnd");
            uiManager.ShowRank(totalScore);
            
            yield return new WaitForSeconds(0.5f);
            
            uiManager.ShowRetryButton();
        }
    }
}
