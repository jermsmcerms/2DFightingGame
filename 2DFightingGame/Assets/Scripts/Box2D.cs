using UnityEngine;

namespace TDFG {
    public class Box2D
    {
        private Vector3 position;
        private Vector3 size;
        private Color color;

        public Box2D(BoxData data) : this(data.position, data.size, data.boxColor) { }

        public Box2D(Vector3 position, Vector3 size, Color color) {
            this.position = position;
            this.size = size;
            this.color = color;
        }

        public void DrawBox() {
            Gizmos.color = color;
            Gizmos.DrawCube(position, size);
        }
    }
}
