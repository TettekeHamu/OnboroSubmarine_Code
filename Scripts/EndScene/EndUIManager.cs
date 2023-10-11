using naichilab.EasySoundPlayer.Scripts;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace Hamu.OnboroSubmarine
{
    /// <summary>
    /// EndシーンのUIを管理するクラス
    /// </summary>
    public class EndUIManager : MonoBehaviour
    {
        /// <summary>
        /// 総得点を表示するText
        /// </summary>
        [SerializeField] private Text totalScoreText;
        /// <summary>
        /// ランクを表示するText
        /// </summary>
        [SerializeField] private Text rankText;
        /// <summary>
        /// リトライ用のボタン
        /// </summary>
        [SerializeField] private Button retryButton;

        private void Awake()
        {
            //いったんすべて非表示に
            totalScoreText.gameObject.SetActive(false);
            rankText.gameObject.SetActive(false);
            retryButton.gameObject.SetActive(false);
            //ボタンに登録
            retryButton.onClick.AsObservable()
                .First()
                .Subscribe(_ => RetryGame())
                .AddTo(this);
        }

        /// <summary>
        /// 総スコアを表示する処理
        /// </summary>
        /// <param name="totalScore">総スコア</param>
        public void ShowTotalScore(int totalScore)
        {
            totalScoreText.gameObject.SetActive(true);
            totalScoreText.text = "総スコア：" + totalScore;
        }

        /// <summary>
        /// ランクを表示する処理
        /// </summary>
        /// <param name="totalScore">総スコア</param>
        public void ShowRank(int totalScore)
        {
            rankText.gameObject.SetActive(true);
            var rank = ReturnRankName(totalScore);
            rankText.text = "あなたの評価\n" + rank;
        }

        /// <summary>
        /// リトライボタンを表示する処理
        /// </summary>
        public void ShowRetryButton()
        {
            retryButton.gameObject.SetActive(true);
        }

        private void RetryGame()
        {
            SePlayer.Instance.Play("SE_ButtonDown");
            SceneChangeManager.Instance.ChangeScene("MainGameScene");
        }

        /// <summary>
        /// 得点にあったランク名を返す処理
        /// </summary>
        /// <param name="score">総スコア</param>
        /// <returns>ランク名</returns>
        private string ReturnRankName(int score)
        {
            // 最高点数は9999点です
            // 99 + 10*50 + 30*30 + 50*20 + 100*15 + 500*10 + 1000 = 9999
            switch (score)
            {
                case <= 10:
                    return "同情するくらい\n出来てないのじゃ";
                case <= 100:
                    return "おい！\n借金肩代わりしたんだから\nもっと頑張るのじゃ！";
                case <= 500:
                    return "あともうちょい頑張るのじゃ！";
                case <= 1000:
                    return "まぁ金額分の活躍はしたので\n許してやるのじゃ";
                case <= 3000:
                    return "すごいのじゃ！\n次もまた頼むのじゃ！";
                case <= 4000:
                    return "君もしかして経験者なのじゃ？";
                default:
                    return "靴舐めます！！\nペロペロ…ペロペロ…";
            }
        }
    }
}
