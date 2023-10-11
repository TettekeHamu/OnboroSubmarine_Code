using naichilab.EasySoundPlayer.Scripts;

namespace Hamu.OnboroSubmarine
{
    public class FireBulletButton : ButtonAbilityBase
    {
        public override void OnButtonPressed()
        {
            SePlayer.Instance.Play("SE_FireBullet");
            //弾を発射する
            Submarine.FireBullet();
        }
    }
}
