namespace DubbleBuffer {
    public class FrameBuffer {
        private const int WIDTH = 160;
        private const int HEIGHT = 120;

        private const char WHITE = ' ';
        private const char BLACK = '#';

        private char[] pixels_ =
            new char[WIDTH * HEIGHT];

        public FrameBuffer() {
            Clear();
        }

        public void Clear() {
            for (int i = 0; i < pixels_.Length; i++) {
                pixels_[i] = WHITE;
            }
        }

        public void Draw(int x, int y) {
            pixels_[(WIDTH * y) + x] = BLACK;
        }

        public char[] GetPixels() {
            return pixels_;
        }
    }

    public class Scene {
        private FrameBuffer[] buffers_ =
        {
        new FrameBuffer(),
        new FrameBuffer() };

        private int current_ = 0;

        public void Draw() {
            FrameBuffer buffer = buffers_[current_];

            buffer.Clear();

            buffer.Draw(1, 1);
            buffer.Draw(4, 1);

            Video.Instance.Render(buffer);

            current_ = 1 - current_;
        }
    }

    public class Actor {
        private bool currentSlapped_;
        private bool nextSlapped_;

        public void Slap() {
            nextSlapped_ = true;
        }

        public bool WasSlapped() {
            return currentSlapped_;
        }

        public void Swap() {
            currentSlapped_ = nextSlapped_;
            nextSlapped_ = false;
        }
    }
}
