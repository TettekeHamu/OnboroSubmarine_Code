using System;
using naichilab.EasySoundPlayer.Scripts;
using UniRx;
using UniRx.Triggers;
using UnityEngine;
using UnityEngine.UI;

namespace Hamu.OnboroSubmarine
{
    /// <summary>
    /// タイトルのUIを管理するクラス
    /// </summary>
    public class TitleUIManager : MonoBehaviour
    {
        /// <summary>
        /// クレジットパネル
        /// </summary>
        [SerializeField] private Image creditPanel;
        /// <summary>
        /// BGM・SEの音量を調節するパネル
        /// </summary>
        [SerializeField] private Image soundPanel;
        /// <summary>
        /// クレジットパネルを開けるボタン
        /// </summary>
        [SerializeField] private Button openCreditPanel;
        /// <summary>
        /// サウンドパネルを開けるボタン
        /// </summary>
        [SerializeField] private Button openSoundPanel;
        /// <summary>
        /// クレジットパネルを閉じるボタン
        /// </summary>
        [SerializeField] private Button closeCreditPanel;
        /// <summary>
        /// サウンドパネルを閉じるボタン
        /// </summary>
        [SerializeField] private Button closeSoundPanel;
        /// <summary>
        /// ゲームを開始させるボタン
        /// </summary>
        [SerializeField] private Button startGameButton;

        private void Awake()
        {
            //いったん非表示に
            creditPanel.gameObject.SetActive(false);
            soundPanel.gameObject.SetActive(false);

            //クリック時のイベントを登録
            openCreditPanel.onClick.AsObservable()
                .Subscribe(_ => ChangePanelView(creditPanel.gameObject, true))
                .AddTo(this);
            openSoundPanel.onClick.AsObservable()
                .Subscribe(_ => ChangePanelView(soundPanel.gameObject, true))
                .AddTo(this);
            closeCreditPanel.onClick.AsObservable()
                .Subscribe(_ => ChangePanelView(creditPanel.gameObject, false))
                .AddTo(this);
            closeSoundPanel.onClick.AsObservable()
                .Subscribe(_ => ChangePanelView(soundPanel.gameObject, false))
                .AddTo(this);
            startGameButton.onClick.AsObservable()
                .First()
                .Subscribe(_ => LoadMainScene())
                .AddTo(this);
        }

        /// <summary>
        /// Panel(Image)の表示非表示を変える処理
        /// </summary>
        /// <param name="gameObj">切り替えたいGameObject</param>
        /// <param name="canView">見せるか見せないか</param>
        private void ChangePanelView(GameObject gameObj, bool canView)
        {
            SePlayer.Instance.Play("SE_ButtonDown");
            gameObj.SetActive(canView);
        }

        /// <summary>
        /// メインのシーンを読み込む処理
        /// </summary>
        private void LoadMainScene()
        {
            SePlayer.Instance.Play("SE_ButtonDown");
            SceneChangeManager.Instance.ChangeScene("MainGameScene");
            startGameButton.gameObject.SetActive(false);
            openCreditPanel.gameObject.SetActive(false);
            openSoundPanel.gameObject.SetActive(false);
        }
    }
}
