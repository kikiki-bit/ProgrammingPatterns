namespace State {
    public enum HeroineState {
        Standing,
        Jumping,
        Ducking
    }

    public enum Input {
        PressB,
        PressDown
    }

    public class Heroine {
        private HeroineState state_ = HeroineState.Standing;

        private const float JUMP_VELOCITY = 10.0f;

        private float yVelocity_;

        public void HandleInput(Input input) {
            switch (state_) {
                case HeroineState.Standing:
                    if (input == Input.PressB) {
                        state_ = HeroineState.Jumping;
                        yVelocity_ = JUMP_VELOCITY;
                    } else if (input == Input.PressDown) {
                        state_ = HeroineState.Ducking;
                    }
                    break;

                case HeroineState.Ducking:
                    if (input == Input.ReleaseDown) {
                        state_ = HeroineState.Standing;
                    }
                    break;

                case HeroineState.Jumping:
                    // 空中での入力処理
                    break;
            }
        }
    }
}
}
