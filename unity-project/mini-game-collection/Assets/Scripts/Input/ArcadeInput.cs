using UnityEngine;

namespace MiniGameCollection
{
    public class ArcadeInput : MonoBehaviour
    {
        public static Player Player1 { get; private set; } = new Player(1);
        public static Player Player2 { get; private set; } = new Player(2);
        public static Player[] Players => new Player[] { Player1, Player2 };
        private static ArcadeInput Instance { get; set; }

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else
            {
                Destroy(this);
            }
        }
        private void Update()
        {
            foreach (var player in Players)
            {
                foreach (var button in player.Buttons)
                {
                    // Apply old input
                    button.PreviousState = button.CurrentState;
                    // Record current input for next update
                    bool state = button.Down;
                    button.CurrentState = state;
                }
            }
        }

        public class Player
        {
            public Player(int id)
            {
                ID = id;
                AxisX = new Axis($"P{id}_AxisX");
                AxisY = new Axis($"P{id}_AxisX");
                Action1 = new Button($"P{id}_Action1");
                Action2 = new Button($"P{id}_Action2");
            }

            public Button[] Buttons => new Button[] { Action1, Action2 };

            public static int ID { get; private set; }
            public Axis AxisX { get; private set; }
            public Axis AxisY { get; private set; }
            public Button Action1 { get; private set; }
            public Button Action2 { get; private set; }
        }

        public class Axis
        {
            public Axis(string inputName)
            {
                InputName = inputName;
            }

            public string InputName { get; private set; }
            public float Read => Input.GetAxis(InputName);


            public static implicit operator float(Axis axis)
            {
                return axis.Read;
            }
        }

        public class Button
        {
            public Button(string inputName)
            {
                InputName = inputName;
            }

            public string InputName { get; private set; }
            public bool PreviousState { get; internal set; }
            public bool CurrentState { get; internal set; }
            public bool Down => Input.GetButtonDown(InputName);
            public bool Up => Input.GetButtonUp(InputName);
            public bool Pressed => Input.GetButtonDown(InputName) && !PreviousState;
            public bool Released => Input.GetButtonUp(InputName) && PreviousState;
        }

    }
}
