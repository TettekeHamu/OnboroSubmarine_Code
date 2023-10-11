using System.Collections;
using UniRx;
using UnityEngine;

namespace Hamu.OnboroSubmarine
{
    /// <summary>
    /// ゲームの進み具合を管理するクラス
    /// </summary>
    public class GameProgressManager : MonoBehaviour
    {
        /// <summary>
        /// ゲーム開始時に説明文を表示する用のクラス
        /// </summary>
        [SerializeField] private ExplainTextManager explainTextManager;
        /// <summary>
        /// OneButtonを生成する用のクラス
        /// </summary>
        [SerializeField] private GameStartingManager gameStartingManager;
        /// <summary>
        /// カウントダウンをおこなう用のクラス
        /// </summary>
        [SerializeField] private CountDownTextManager countDownTextManager;
        /// <summary>
        /// 時間を管理するクラス
        /// </summary>
        [SerializeField] private MonoTimeManager monoTimeManager;
        /// <summary>
        /// スコアの管理クラス
        /// </summary>
        [SerializeField] private MonoScoreManager monoScoreManager;
        /// <summary>
        /// 潜水艦
        /// </summary>
        [SerializeField] private SubmarineManager submarine;

        private void Awake()
        {
            StartCoroutine(GameStartCoroutine());
        }

        private IEnumerator GameStartCoroutine()
        {
            //説明のテキストを出す
            yield return explainTextManager.ShowExplainText();
            
            //プレイヤーを照らす
            yield return gameStartingManager.Submarine.StartLightingUp();
            
            //ボタンなどのオブジェクトを生成（可視化）
            yield return gameStartingManager.CreateOneButton();
            
            //カウントダウンをおこなう
            yield return countDownTextManager.CountDownCoroutine();
            
            //操作が出来るようにする
            gameStartingManager.Submarine.Initialize();
            
            //タイマーを開始させる
            monoTimeManager.GameOverObservable
                .First()
                .Subscribe(_ => EndGame())
                .AddTo(this);
            monoTimeManager.StartCountDown();
        }

        private void EndGame()
        {
            submarine.StopMoving();
            StartCoroutine(EndGameCoroutine());
        }
        
        private IEnumerator EndGameCoroutine()
        {
            explainTextManager.SendHighScoreText();
            PlayerPrefs.SetInt("TotalScore", monoScoreManager.ScoreManager.TotalScore);
            yield return new WaitForSeconds(6f);
            SceneChangeManager.Instance.ChangeScene("EndScene");
        }
    }
}
