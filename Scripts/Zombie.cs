using Godot;

namespace KeroKeep
{

public partial class Zombie : BaseMob
{
    public Zombie()
    {
        Health = 3;
        Speed = 55;
        GoldDrop = 3;
    }
}

}