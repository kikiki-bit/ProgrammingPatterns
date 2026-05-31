namespace ProgramingPattern {
    public class MoveUnitCommand : ICommand {
        private Unit unit_;
        private int x_;
        private int y_;

        public MoveUnitCommand(Unit unit, int x, int y) {
            unit_ = unit;
            x_ = x;
            y_ = y;
        }

        public void Execute() {
            unit_.MoveTo(x_, y_);
        }
    }

    public class Unit {
        public void MoveTo(int x, int y) {
            Console.WriteLine($"Move To : {x}, {y}");
        }
    }
}
