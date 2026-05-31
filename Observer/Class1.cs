using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Flyweight.Class2;

namespace Flyweight {
    internal class Class2 {

        public interface IObserver {
            void OnNotify(Entity entity, EventType eventType);
        }

        public class Subject {
            private readonly List<IObserver> observers = new();

            public void AddObserver(IObserver observer) {
                observers.Add(observer);
            }

            public void RemoveObserver(IObserver observer) {
                observers.Remove(observer);
            }

            protected void Notify(Entity entity, EventType eventType) {
                foreach (var observer in observers) {
                    observer.OnNotify(entity, eventType);
                }
            }
        }

        public enum EventType {
            StartFall
        }

        public class Physics : Subject {
            public void UpdateEntity(Entity entity) {
                bool wasOnSurface = entity.IsOnSurface();

                entity.Accelerate();

                if (wasOnSurface &&
                    !entity.IsOnSurface()) {
                    Notify(entity, EventType.StartFall);
                }
            }
        }

        public class Entity {
            public bool IsOnSurface() {
                return false;
            }

            public void Accelerate() {
            }
        }

        public class Achievements : IObserver {
            public void OnNotify(Entity entity, switch (eventType) {
                    case EventType.StartFall:
                    Unlock("FALL_OFF_BRIDGE");
                    break;
                }
            }

            private void Unlock(string id) {
                Console.WriteLine($"Achievement : {id}");
            }
        }

        public void AddObserver(IObserver observer) {
            observers.Add(observer);
        }

        public void RemoveObserver(IObserver observer) {
            observers.Remove(observer);
        }
    }
}