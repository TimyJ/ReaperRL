using System.Collections;
using System.Collections.Generic;
using GoRogue;

namespace TSRL
{
    public class Level
    {
        public int MapWidth { get; }
        public int MapHeight { get; }
        private LayeredSpatialMap<Entity> entities;
        public Entity PlayerCharacter { get; private set; }
        public TerrainBase[,] Terrain; 

        public Level(int mapWidth, int mapHeight, int numberOfLayers)
        {
            MapWidth = mapWidth;
            MapHeight = mapHeight;
            entities = new LayeredSpatialMap<Entity>(numberOfLayers, 0, (uint)numberOfLayers);
            Terrain = new TerrainBase[mapWidth, mapHeight];
        }

        public void EnterLevel(Entity player)
        {
            PlayerCharacter = player;
            Add(PlayerCharacter, (10, 10));
        }

        public void Add(Entity e, Coord pos)
        {
            entities.Add(e, pos);
        }

        public bool MoveEntity(Entity e, Direction d)
        {
            if (entities.Move(e, entities.GetPosition(e)+d))
            {
                return true;
            }
            return false;
        }

        public bool MoveEntityTo(Entity e, Coord newPos)
        {
            if (entities.Move(e, newPos))
            {
                return true;
            }
            return false;
        }

        public Coord EntityPosition(Entity e)
        {
            return entities.GetPosition(e);
        }

        public IEnumerable<Entity> GetAllEntities()
        {
            return entities.Items;
        }

        public IEnumerable<Entity> GetEntitiesInRect(Rectangle rect, int layer)
        {
            for(int x = rect.X; x <= rect.Width; ++x)
            {
                for(int y = rect.Y; y <= rect.Height; ++y)
                {
                    foreach(Entity e in entities.GetLayer(layer).GetItems(x, y))
                    {
                        yield return e;
                    }
                }
            }
        }
    }
}
