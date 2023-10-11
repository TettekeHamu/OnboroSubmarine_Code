using UnityEngine;
using UnityEngine.UI;

namespace Hamu.OnboroSubmarine
{
    /// <summary>
    /// 時間経過のUIを管理するクラス
    /// </summary>
    public class TimerUIManager : MonoBehaviour
    {
        [SerializeField] private Text timerText;

        /// <summary>
        /// 残り時間を表示するTextを更新する処理
        /// </summary>
        /// <param name="gameTime">残り時間を持つクラス</param>
        public void UpdateTimerText(GameTimeManager gameTime)
        {
            if (gameTime.GameTime <= 0)
            {
                timerText.text = "タイムアップ";
            }
            else
            {
                timerText.text = "ノコリジカン：" + gameTime.GameTime.ToString("f2");   
            }
        }
    }
}
