using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Tilemaps;
using Object = UnityEngine.Object;

namespace SpawnPoint
{
    public class SpawnPointTilemap : MonoBehaviour
    {
        [SerializeField] private Tilemap tilemap;
        [SerializeField] private SpawnPointTilemapData[] tilemapTextureType;

        public SpawnPointTilemapData[] spawnPointTilemapDatas;

        private void Awake()
        {
            Init();
        }

        private void Init()
        {
            TryGetComponent(out tilemap);
            Scan();
        }

        private void Scan()
        {
            spawnPointTilemapDatas = Array.Empty<SpawnPointTilemapData>();
            var spawnPointTilemapDataList = new List<SpawnPointTilemapData>();
            var bounds = tilemap.cellBounds;
            var allTiles = tilemap.GetTilesBlock(bounds);
            for (var x = 0; x < bounds.size.x; x++)
            for (var y = 0; y < bounds.size.y; y++)
            {
                var tile = allTiles[x + y * bounds.size.x];
                if (tile == null) continue;
                var tilePosition = new Vector3Int(x + bounds.position.x, y + bounds.position.y);
                var tilemapTexture = tilemap.GetSprite(tilePosition);
                var tilemapTexture2D = tilemapTexture.texture;
                var textureType = GetTypeSpawnPoint(tilemapTexture2D);
                if (textureType == TypeSpawnPoint.None) continue;

                var spawnPointTilemapData = new SpawnPointTilemapData
                {
                    typeSpawnPoint = textureType,
                    position = tilePosition,
                    texture2D = tilemapTexture2D,
                    tileBase = tile
                };
                spawnPointTilemapDataList.Add(spawnPointTilemapData);
            }

            spawnPointTilemapDatas = spawnPointTilemapDataList.ToArray();
        }

        private TypeSpawnPoint GetTypeSpawnPoint(Object tilemapTexture2D)
        {
            return (from spawnPointTilemapData in tilemapTextureType
                where spawnPointTilemapData.texture2D == tilemapTexture2D
                select spawnPointTilemapData.typeSpawnPoint).FirstOrDefault();
        }

        [Serializable]
        public class SpawnPointTilemapData
        {
            // Name by type spawn point
            public string name;
            public TypeSpawnPoint typeSpawnPoint;
            public Vector3Int position;
            public Texture2D texture2D;
            public TileBase tileBase;

            public override string ToString()
            {
                return $"{name} {typeSpawnPoint} {position}";
            }
        }
    }
}