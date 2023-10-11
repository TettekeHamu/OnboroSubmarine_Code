using naichilab.EasySoundPlayer.Scripts;

namespace Hamu.OnboroSubmarine
{
    /// <summary>
    /// 周りを照らすボタン
    /// </summary>
    public class LightUpAroundButton : ButtonAbilityBase
    {
        public override void OnButtonPressed()
        {
            SePlayer.Instance.Play("SE_LightUp");
            //プレイヤーの周りを照らす
            Submarine.LightUpAround();
        }
    }
}
