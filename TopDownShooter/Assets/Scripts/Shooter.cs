using UnityEngine;
using System.Collections;

public interface Shooter
{
    bool touched(Shooter shooter);
    bool hurt(PlayerControler shooter);
    bool hurt(Ennemy shooter);
}
