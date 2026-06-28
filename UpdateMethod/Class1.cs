namespace UpdateMethod {
    public class Class1 {
        public class Statue {
            private int frames_;

            public Statue() {
                frames_ = 0;
            }

            public void Update() {
                if (++frames_ == 30) {
                    ShootLightning();

                    frames_ = 0;
                }
            }

            private void ShootLightning() {
                Console.WriteLine("雷を撃つ");
            }
        }

        public abstract class Entity {
            public abstract void Update();
        }
        public class Statue : Entity {
            private int frames_;

            public Statue() {
                frames_ = 0;
            }

            public override void Update() {
                frames_++;

                if (frames_ == 30) {
                    ShootLightning();
                    frames_ = 0;
                }
            }

            private void ShootLightning() {
                Console.WriteLine("女神像が雷を放った！");
            }
        }

        Entity statue = new Statue();

    }
}
