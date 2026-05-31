using System.ComponentModel.Design;
using System.Drawing;
using System.Numerics;

namespace Flyweight {
    public class Class1 {

        public class TreeModel {
            private Mesh _mesh;
            private Texture _bark;
            private Texture _leaves;
        }

        public class Terrain {
            private int movementCost_;

            public int GetMovementCost() {
                return movementCost_;
            }
        }

        public void GenerateTerrain() {
            for (int x = 0; x < Width; x++) {
                for (int y = 0; y < Height; y++) {
                    if (Random(10) == 0) {
                        tiles[x, y] = hillTerrain;
                    } else {
                        tiles[x, y] = grassTerrain;
                    }
                }
            }

            int xRiver = Random(Width);

            for (int y = 0; y < Height; y++) {
                tiles[xRiver, y] = riverTerrain;
            }
        }

        public Terrain GetTile(int x, int y) {
            return tiles[x, y];
        }
        // 使用側
        int cost = world.GetTile(2, 3).GetMovementCost();
    }
}
