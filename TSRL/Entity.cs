using System;
using System.Collections.Generic;
using System.Text;
using GoRogue;
using GoRogue.GameFramework;

namespace TSRL
{
    public class Entity : IHasID, IHasLayer, IHasComponents
    {
        static IDGenerator generator = new IDGenerator();
        public uint ID { get; private set; }
        public int Layer { get; private set; }
        private ComponentContainer components;

        public Entity()
        {
            Layer = 0;
            ID = generator.UseID();
        }

        public void AddComponent(object component)
        {
            components.AddComponent(component);
        }

        public T GetComponent<T>()
        {
            return components.GetComponent<T>();
        }

        public IEnumerable<T> GetComponents<T>()
        {
            return components.GetComponents<T>();
        }

        public bool HasComponent(Type componentType)
        {
            return components.HasComponent(componentType);
        }

        public bool HasComponent<T>()
        {
            return components.HasComponent<T>();
        }

        public bool HasComponents(params Type[] componentTypes)
        {
            return components.HasComponents(componentTypes);
        }

        public void RemoveComponent(object component)
        {
            components.RemoveComponent(component);
        }

        public void RemoveComponents(params object[] componentss)
        {
            components.RemoveComponents(componentss);
        }
    }
}
