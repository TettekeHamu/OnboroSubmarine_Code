using UniRx;
using UniRx.Triggers;
using UnityEngine;

namespace Hamu.OnboroSubmarine
{
    /// <summary>
    /// スコアの管理クラスと表示するクラスをつなげるクラス
    /// </summary>
    public class MonoScoreManager : MonoBehaviour
    {
        /// <summary>
        /// スコアを表示するUIの管理クラス
        /// </summary>
        [SerializeField] private ScoreUIManager scoreUIManager;
        /// <summary>
        /// スコアを管理するクラス
        /// </summary>
        private ScoreManager scoreManager;

        public ScoreManager ScoreManager => scoreManager;

        private void Awake()
        {
            scoreManager = new ScoreManager(scoreUIManager);
        }

        /// <summary>
        /// ゲームスコアを加算する処理（Treasure側が呼びだす）
        /// </summary>
        /// <param name="treasure">呼び出し側のお宝</param>
        public void AddScore(TreasureManager treasure)
        {
            scoreManager.AddTotalScore(treasure);
        }
    }
}
