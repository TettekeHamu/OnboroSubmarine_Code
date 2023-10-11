using System;
using naichilab.EasySoundPlayer.Scripts;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Hamu.OnboroSubmarine
{
    /// <summary>
    /// ボタンの機能の親クラス
    /// </summary>
    public abstract class ButtonAbilityBase : MonoBehaviour
    {
        /// <summary>
        /// 潜水艦ゲームオブジェクト
        /// </summary>
        protected SubmarineManager Submarine;

        public void Awake()
        {
            //シーン内からボタンを取得
            Submarine = FindObjectOfType<SubmarineManager>();
        }

        /// <summary>
        /// ボタンが押されたときにおこなう処理、子クラス側で機能を実装する
        /// </summary>
        public virtual void OnButtonPressed()
        {
            
        }

        /// <summary>
        /// ボタンが押されているときにおこなう処理、子クラス側で機能を実装する
        /// </summary>
        public virtual void OnButtonPressing()
        {
            
        }
    }
}
