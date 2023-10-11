using System;
using UniRx;
using UniRx.Triggers;
using UnityEngine;

namespace Hamu.OnboroSubmarine
{
    /// <summary>
    /// 時間の管理クラスと表示するクラスをつなげるクラス
    /// </summary>
    public class MonoTimeManager : MonoBehaviour
    {
        /// <summary>
        /// 残り時間を表示するUIを管理するクラス
        /// </summary>
        [SerializeField] private TimerUIManager timerUIManager;
        /// <summary>
        /// ゲームの時間を管理するクラス
        /// </summary>
        private GameTimeManager gameTimeManager;
        /// <summary>
        /// ゲーム終了時に発行するSubject
        /// </summary>
        private readonly Subject<Unit> gameOverSubject = new Subject<Unit>();
        public IObservable<Unit> GameOverObservable => gameOverSubject;


        private void Awake()
        {
            gameTimeManager = new GameTimeManager(timerUIManager);
            gameTimeManager.TimeUpObservable
                .First()
                .Subscribe(_ => ExitGame())
                .AddTo(this);
        }

        /// <summary>
        /// ゲームが終了した際に呼び出される処理
        /// </summary>
        private void ExitGame()
        {
            //進行管理するクラスにゲームが終わったことを伝える
            gameOverSubject.OnNext(Unit.Default);
        }

        /// <summary>
        /// カウントダウンを開始する処理
        /// </summary>
        public void StartCountDown()
        {
            this.UpdateAsObservable()
                .Subscribe(_ => gameTimeManager.ReduceTime())
                .AddTo(this);
        }
    }
}
