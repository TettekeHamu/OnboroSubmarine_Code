using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Hamu.OnboroSubmarine
{
    /// <summary>
    /// ボタンが置かれる場所にアタッチするクラス
    /// </summary>
    public class ButtonPlaceManager : MonoBehaviour
    {
        /// <summary>
        /// 潜水艦ゲームオブジェクト
        /// </summary>
        private SubmarineManager submarine;
        
        private ButtonAbilityBase buttonAbility;

        private void Awake()
        {
            //シーン内から潜水艦を取得
            submarine = FindObjectOfType<SubmarineManager>();
            buttonAbility = GetComponent<ButtonAbilityBase>();
        }

        /// <summary>
        /// ボタンがドロップされたときに呼ばれる処理
        /// </summary>
        public void OnDropButton()
        {
            //潜水艦にボタンが置かれたことを知らせる
            submarine.SetButtonAbility(buttonAbility);
        }
    }
}
