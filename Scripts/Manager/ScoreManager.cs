using naichilab.EasySoundPlayer.Scripts;
using UnityEngine;
using unityroom.Api;

namespace Hamu.OnboroSubmarine
{
    /// <summary>
    /// スコアを管理するクラス
    /// </summary>
    public class ScoreManager
    {
        /// <summary>
        /// スコア
        /// </summary>
        private int totalScore;
        /// <summary>
        /// 追加分のスコア
        /// </summary>
        private int addScore;
        /// <summary>
        /// スコアを表示するUIを管理するクラス
        /// </summary>
        private readonly ScoreUIManager scoreUI;

        public int TotalScore => totalScore;

        public int AddScore => addScore;

        public ScoreManager(ScoreUIManager sum)
        {
            totalScore = 0;
            //UI側にデータを送る
            scoreUI = sum;
            scoreUI.UpdateScoreUI(this);
        }

        /// <summary>
        /// スコアに加算する処理
        /// </summary>
        /// <param name="treasure">お宝オブジェクト</param>
        public void AddTotalScore(TreasureManager treasure)
        {
            SePlayer.Instance.Play("SE_AddScore");
            addScore = treasure.Score;
            totalScore += treasure.Score;
            //UI側にデータを送る
            scoreUI.UpdateScoreUI(this);
            //ランキングを更新
            UnityroomApiClient.Instance.SendScore(1, totalScore, ScoreboardWriteMode.HighScoreDesc);
        }
    }
}
