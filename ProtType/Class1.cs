namespace ClassLibrary1 {
    public class Class1 {

        public abstract class Monster {
            public abstract Monster Clone();
        }

        public class Ghost : Monster {
            private int health;
            private int speed;

            public Ghost(int _health, int _speed) {
                health = _health;
                speed = _speed;
            }

            public override Monster Clone() {
                return new Ghost(health, speed);
            }
        }
    }
}
