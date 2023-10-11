using naichilab.EasySoundPlayer.Scripts;

namespace Hamu.OnboroSubmarine
{
    /// <summary>
    /// 左に回転させるボタン
    /// </summary>
    public class RotateLeftButton : ButtonAbilityBase
    {
        public override void OnButtonPressed()
        {
            SePlayer.Instance.Play("SE_Rotate");
        }

        public override void OnButtonPressing()
        {
            Submarine.RotateSubmarine(false);
        }
    }
}
