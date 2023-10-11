using System;
using System.Collections;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace Hamu.OnboroSubmarine
{
    /// <summary>
    /// ゲーム開始時にオブジェクトの生成・初期化をおこなうクラス
    /// </summary>
    public class GameStartingManager : MonoBehaviour
    {
        /// <summary>
        /// ボタンの親オブジェクト
        /// </summary>
        [SerializeField] private Image controllerPanelImage;
        /// <summary>
        /// 操作する用のボタン
        /// </summary>
        [SerializeField] private OneButtonManager oneButton;
        /// <summary>
        /// 潜水艦
        /// </summary>
        [SerializeField] private SubmarineManager submarine;

        public SubmarineManager Submarine => submarine;

        private void Awake()
        {
            oneButton.gameObject.SetActive(false);
        }

        public IEnumerator CreateOneButton()
        {
            /*
            //生成場所を指定
            var createPos = new Vector3(240,210,0);
            //コイツをワールド座標に変換
            //var oneButton = Instantiate(oneButtonPrefab, createPos, Quaternion.identity);
            //一旦スケールをゼロに
            var oneButtonTransform = oneButton.transform;
            oneButtonTransform.SetParent(controllerPanelImage.transform);
            var startScale = oneButtonTransform.localScale;
            oneButtonTransform.localScale = Vector3.zero;
            //アニメーションさせる
            yield return oneButtonTransform.DOScale(startScale * 1.5f, 0.8f).WaitForCompletion();
            yield return oneButtonTransform.DOScale(startScale, 0.2f).WaitForCompletion();
            */
            
            //ボタンをActiveに
            oneButton.gameObject.SetActive(true);
            var oneButtonTransform = oneButton.transform;
            var startScale = oneButtonTransform.localScale;
            
            //スケールを0にする
            oneButtonTransform.localScale = Vector3.zero;
            
            //アニメーションさせる
            yield return oneButton.transform.DOScale(startScale * 1.5f, 0.8f).WaitForCompletion();
            yield return oneButton.transform.DOScale(startScale, 0.2f).WaitForCompletion();
        }
    }
}
