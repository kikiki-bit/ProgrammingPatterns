namespace ProgramingPattern {

    // 武器変更
    public class SwapWeaponCommand : ICommand {
        public void Execute() {
            Console.WriteLine("Swap Weapon");
        }
    }

    // よろける
    public class LurchCommand : ICommand {
        public void Execute() {
            Console.WriteLine("Lurch");
        }
    }

    public class InputHandler {
        private ICommand buttonX_;
        private ICommand buttonY_;
        private ICommand buttonA_;
        private ICommand buttonB_;

        public InputHandler() {
            buttonX_ = new JumpCommand();
            buttonY_ = new FireCommand();
            buttonA_ = new SwapWeaponCommand();
            buttonB_ = new LurchCommand();
        }

        //public void HandleInput() {
        //    if (IsPressed(BUTTON_X)) {
        //        buttonX_.Execute();
        //    } else if (IsPressed(BUTTON_Y)) {
        //        buttonY_.Execute();
        //    } else if (IsPressed(BUTTON_A)) {
        //        buttonA_.Execute();
        //    } else if (IsPressed(BUTTON_B)) {
        //        buttonB_.Execute();
        //    }
        //}

        bool IsPressed(int button) {
            return false;
        }

        const int BUTTON_X = 0;
        const int BUTTON_Y = 1;
        const int BUTTON_A = 2;
        const int BUTTON_B = 3;

        public ICommand HandleInput() {
            Unit unit = GetSelectedUnit();

            if (IsPressed(BUTTON_UP)) {
                int destY = unit.Y() - 1;

                return new MoveUnitCommand(
                    unit,
                    unit.X(),
                    destY);
            }

            if (IsPressed(BUTTON_DOWN)) {
                int destY = unit.Y() + 1;

                return new MoveUnitCommand(
                    unit,
                    unit.X(),
                    destY);
            }

            return null;
        }
    }
}