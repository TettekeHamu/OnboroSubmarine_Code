using System;
using UniRx;
using UnityEngine;

namespace Hamu.OnboroSubmarine
{
    /// <summary>
    /// ゲームの時間を管理するクラス
    /// </summary>
    public class GameTimeManager
    {
        /// <summary>
        /// ゲームの残り時間
        /// </summary>
        private float gameTime;
        /// <summary>
        /// 時間を表示するUIの管理クラス
        /// </summary>
        private readonly TimerUIManager timerUI;
        /// <summary>
        /// 時間が0になったときに発行するSubject
        /// </summary>
        private readonly Subject<Unit> timeUpSubject = new Subject<Unit>();

        public float GameTime => gameTime;
        public IObservable<Unit> TimeUpObservable => timeUpSubject;

        public GameTimeManager(TimerUIManager tum)
        {
            #if UNITY_EDITOR
                gameTime = 30f;
            #else
                gameTime = 60 * 3f;
            #endif
            timerUI = tum;
            timerUI.UpdateTimerText(this);
        }

        /// <summary>
        /// 時間を減らす処理
        /// </summary>
        public void ReduceTime()
        {
            if (gameTime <= 0)
            {
                gameTime = 0;
                //ゲームが終わったことを伝える
                timeUpSubject.OnNext(Unit.Default);
            }
            gameTime -= Time.deltaTime;
            
            //UI側に通知する
            timerUI.UpdateTimerText(this);
        }
    }
}
