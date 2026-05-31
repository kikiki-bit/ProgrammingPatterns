namespace ProgramingPattern {
    public class JumpCommand : ICommand {
        public void Execute() {
            Jump();
        }

        private void Jump() {
        }
    }

    public class FireCommand : ICommand {
        public void Execute() {
            FireGun();
        }

        private void FireGun() {
            Console.WriteLine("発射");
        }
    }
}
