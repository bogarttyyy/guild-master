using Models;
using NSBLib.EventChannelSystem;
using UnityEngine;

namespace Events.EventChannelSystem
{
    [CreateAssetMenu(fileName = "OrderEventChannel", menuName = "Events/OrderEventChannel")]
    public class OrderEventChannel : EventChannel<Order> {}
}