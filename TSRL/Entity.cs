using System;
using System.Collections.Generic;
using System.Text;
using GoRogue;

namespace TSRL
{
    public class Entity : IHasID, IHasLayer
    {
        static IDGenerator generator = new IDGenerator();
        public uint ID { get; private set; }
        public int Layer { get; private set; }

        private Dictionary<string, Component> _components;

        public Entity()
        {
            Layer = 0;
            ID = generator.UseID();
            _components = new Dictionary<string, Component>();
        }

        public void AddComponent<T>(T component) where T : Component
        {
            //Console.WriteLine(typeof(T).Name);
            _components[typeof(T).Name] = component;
        }

        public bool HasComponents(params Type[] components)
        {
            foreach (var comp in components)
                if (!_components.ContainsKey(comp.Name))
                    return false;

            return true;
        }

        public T GetComponent<T>() where T : Component
        {
            if (!_components.ContainsKey(typeof(T).Name))
                return default(T);

            return (T)_components[typeof(T).Name];
        }
    }
}
