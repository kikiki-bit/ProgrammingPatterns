using System.Data;

namespace GameLoop {
    public class Class1 {
        while(true){
            processInput();
        Update();
        render();

    }

    public class Game {
        private const double MS_PER_UPDATE = 16.6667;

        public void Run() {
            double previous = GetCurrentTime();
            double lag = 0.0;

            while (true) {
                double current = GetCurrentTime();
                double elapsed = current - previous;
                previous = current;

                lag += elapsed;

                ProcessInput();

                while (lag >= MS_PER_UPDATE) {
                    Update();
                    lag -= MS_PER_UPDATE;
                }

                Render();
            }
        }

        private double GetCurrentTime() {
            return Environment.TickCount64;
        }

        private void ProcessInput() {
        }

        private void Update() {
        }

        private void Render() {
        }
    }
}
