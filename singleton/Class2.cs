namespace singleton {
    internal class Bullet {
        private const int ScreenWidth = 800;
        private const int ScreenHeight = 600;

        public int X { get; private set; }
        public int Y { get; private set; }

        public Bullet(int x, int y) {
            X = x;
            Y = y;
        }

        public bool IsOnScreen() {
            return X >= 0 && X < ScreenWidth &&
                   Y >= 0 && Y < ScreenHeight;
        }

        public void Move() {
            X += 5;
        }
    }
}
