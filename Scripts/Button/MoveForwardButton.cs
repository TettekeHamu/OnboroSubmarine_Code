using naichilab.EasySoundPlayer.Scripts;

namespace Hamu.OnboroSubmarine
{
    /// <summary>
    /// 潜水艦を前進させるボタン
    /// </summary>
    public class MoveForwardButton : ButtonAbilityBase
    {
        public override void OnButtonPressed()
        {
            SePlayer.Instance.Play("SE_Movement");
        }

        public override void OnButtonPressing()
        {
            Submarine.MoveSubmarine(true);
        }
    }
}
